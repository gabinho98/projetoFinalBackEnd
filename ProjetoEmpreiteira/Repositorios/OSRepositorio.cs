using Dapper;
using ProjetoEmpreiteira.DTO;
using ProjetoEmpreiteira.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEmpreiteira.Repositorios
{
    public class OSRepositorio
    {
        private readonly string _connection = @"Data Source=ITELABD09\SQLEXPRESS;Initial Catalog=dbSistemaEmpreiteira;Integrated Security=True";
        public bool SalvarOs(decimal valorOs, int idCliente, int idFuncionario, int idObra)
        {
            int IdPessoaCriada = -1;
            try
            {
                var query = @"INSERT INTO OS 
                              (ValorDaObra,idCliente,idFuncionario,idObra) 
                              OUTPUT Inserted.Id
                              VALUES (@ValorDaObra, @idCliente, @idFuncionario,@idObra)";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@ValorDaObra", valorOs);
                    command.Parameters.AddWithValue("@idCliente", idCliente);
                    command.Parameters.AddWithValue("@idFuncionario", idFuncionario);
                    command.Parameters.AddWithValue("@idObra", idObra);
                    command.Connection.Open();
                    IdPessoaCriada = (int)command.ExecuteScalar();

                    //Executa a consulta e retorna a primeira coluna da primeira linha no conjunto de resultados retornado pela consulta. Colunas ou linhas adicionais são ignoradas.
                }

                //SalvarEndereco(cliente.Endereco, IdPessoaCriada);

                Console.WriteLine("Ordem de serviço cadastrada com sucesso.");
                return true;

            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro: " + ex.Message);
                return false;

            }
        }

        public bool AtualizarValorOS(int id, OS os)
        {
            try
            {

                var query = "UPDATE OS SET ValorDaObra = @valordaobra, IdCliente = @idcliente, IdFuncionario = @idfuncionario, IdObra = @idobra WHERE Id = @id";

                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@valordaobra", os.ValordaObra);
                    command.Parameters.AddWithValue("@idcliente", os.IdCliente);
                    command.Parameters.AddWithValue("@idfuncionario", os.IdFuncionario);
                    command.Parameters.AddWithValue("@idobra", os.IdObra);
                    command.ExecuteNonQuery();

                }
                return true;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public List<OSDTO> BuscarTodasOS()
        {
            try
            {
                var query = @"SELECT o.Id AS OrdemDeServico,o.ValorDaObra,c.Nome AS NomeCliente,f.Nome AS NomeFuncionario,a.Descricao AS DescricaoDaObra,a.DatadeInicio,a.PrevisaodeTermino,
                              c.Id as IdCliente, f.Id as IdFuncionario, a.Id as IdObra
                              FROM OS o
                              INNER JOIN Cliente c ON  c.Id = o.IdCliente 
                              INNER JOIN Funcionarios f ON  f.Id = o.IdFuncionario
                              INNER JOIN Obras a  ON a.Id = o.IdObra";

                using (var connection = new SqlConnection(_connection))
                {
                    return connection.Query<OSDTO>(query).ToList();
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro: " + ex.Message);
                return null;

            }
        }
        public OSDTO BuscarOS(int id)
        {
            try
            {
                var query = @"SELECT o.Id AS OrdemDeServico,o.ValorDaObra,c.Nome AS NomeCliente,f.Nome AS NomeFuncionario,a.Descricao AS DescricaoDaObra,a.DatadeInicio,a.PrevisaodeTermino,
                                c.Id as IdCliente, f.Id as IdFuncionario, a.Id as IdObra
                              FROM OS o
                              INNER JOIN Cliente c ON  c.Id = o.IdCliente 
                              INNER JOIN Funcionarios f ON  f.Id = o.IdFuncionario
                              INNER JOIN Obras a  ON a.Id = o.IdObra
                              WHERE o.Id = @id";

                using (var connection = new SqlConnection(_connection))
                {

                    var parametros = new
                    {
                        id
                    };
                    return connection.QueryFirstOrDefault<OSDTO>(query, parametros);

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro: " + ex.Message);
                return null;

            }
        }
        public bool DeletarOS(int id)
        {
            try
            {
                var query = "DELETE FROM OS Where id = @id";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();

                }

                Console.WriteLine("Ordem de serviço removida!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public List<OSDTO> BuscarPorNome(string nome)
        {
            List<OSDTO> OsEncontrados;
            try
            {
                var query = @"SELECT o.Id AS OrdemDeServico,o.ValorDaObra,c.Nome AS NomeCliente,f.Nome AS NomeFuncionario,a.Descricao AS DescricaoDaObra,a.DatadeInicio,a.PrevisaodeTermino
                              FROM OS o
                              INNER JOIN Cliente c ON  c.Id = o.IdCliente 
                              INNER JOIN Funcionarios f ON  f.Id = o.IdFuncionario
                              INNER JOIN Obras a  ON a.Id = o.IdObra
                              WHERE c.Nome like CONCAT('%',@nome,'%')";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        nome
                    };
                    OsEncontrados = connection.Query<OSDTO>(query, parametros).ToList();
                }
                return OsEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }


    }
}
