using Dapper;
using ProjetoEmpreiteira.DTO;
using ProjetoEmpreiteira.DTO_s;
using ProjetoEmpreiteira.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEmpreiteira.Repositorios
{
    public class ObraRepositorio
    {
        private readonly string _connection = @"Data Source=ITELABD09\SQLEXPRESS;Initial Catalog=dbSistemaEmpreiteira;Integrated Security=True";

        public Obra SalvarObra(Obra obra)
        {
            int IdObraCriada = -1;
            try
            {
                var query = @"INSERT INTO Obras (Descricao, DatadeInicio, PrevisaodeTermino) OUTPUT Inserted.Id VALUES (@descricao, @datadeinicio, @previsaodetermino)";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@descricao", obra.Descricao);
                    command.Parameters.AddWithValue("@datadeinicio", obra.DatadeInicio);
                    command.Parameters.AddWithValue("@previsaodetermino", obra.PrevisaodeTermino);
                    command.Connection.Open();
                    IdObraCriada = (int)command.ExecuteScalar();

                }
                Console.WriteLine("Obra cadastrada com sucesso.");

                

                obra.Id = IdObraCriada;             

                return obra;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return obra;
            }
        }

        public List<ObraDTO> BuscarPorNome(string nome)
        {
            List<ObraDTO> ObraEncontrados;
            try
            {
                var query = @"SELECT Id,Descricao,DatadeInicio,PrevisaodeTermino FROM Obras WHERE Descricao like CONCAT('%',@nome,'%')";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        nome
                    };
                    ObraEncontrados = connection.Query<ObraDTO>(query, parametros).ToList();
                }
                return ObraEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public bool SalvarEnderecoObra(EnderecoObras endereco, int id)
        {
            try
            {
                var query = @"INSERT INTO EnderecoObras 
                              (Estado, Cidade, Rua,Bairro, Numero, IdObras)                               
                              VALUES (@estado, @cidade, @rua,@bairro, @numero, @id)";

                using (var sql = new SqlConnection(_connection))
                {

                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@estado", endereco.Estado);
                    command.Parameters.AddWithValue("@cidade", endereco.Cidade);
                    command.Parameters.AddWithValue("@rua", endereco.Rua);
                    command.Parameters.AddWithValue("@bairro", endereco.Bairro);
                    command.Parameters.AddWithValue("@numero", endereco.Numero);
                    command.Parameters.AddWithValue("@id", id);
                    command.Connection.Open();
                    command.ExecuteNonQuery();

                }

                Console.WriteLine("Endereço da obra cadastrado com sucesso.");

                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }

        public ObraDTO BuscarObra(int IdObra)
        {
            try
            {
                var query = @"SELECT * FROM Obras WHERE Id = @IdObra";

                using (var connection = new SqlConnection(_connection))
                {

                    var parametros = new
                    {
                        IdObra
                    };
                    return connection.QueryFirstOrDefault<ObraDTO>(query, parametros);

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro: " + ex.Message);
                return null;

            }
        }


        public List<ObraSalvarDto> BuscarTodas()

        {
            try
            {
                var query = @"SELECT * FROM Obras";

                using (var connection = new SqlConnection(_connection))
                {

                    return connection.Query<ObraSalvarDto>(query).ToList();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);

                return new List<ObraSalvarDto>();

            }
        }
        public Obra AtualizarObra(int idObra, Obra obra)
        {
            try
            {

                var query = "UPDATE Obras SET Descricao = @descricao, DatadeInicio = @datadeinicio, PrevisaodeTermino = @previsaodetermino " +
                    "WHERE Id= @idObra";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@descricao", obra.Descricao);
                    command.Parameters.AddWithValue("@datadeinicio", obra.DatadeInicio);
                    command.Parameters.AddWithValue("@previsaodetermino", obra.PrevisaodeTermino);
                    command.Parameters.AddWithValue("@idObra", idObra);
                    command.ExecuteNonQuery();
                }
                obra.Id = idObra;

                return obra;

                          

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public bool DeletarObra(int id)
        {
            DeletarEnderecoObra(id);
            
            try
            {
                var query = "DELETE FROM Obras Where id = @id";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();

                    
                }

                Console.WriteLine("Obra Removida!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public bool DeletarEnderecoObra(int id)
        {
            try
            {
                var query = "DELETE FROM EnderecoObras Where idObras=@id";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();

                }

                Console.WriteLine("Endereco Removido!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
    }
}
