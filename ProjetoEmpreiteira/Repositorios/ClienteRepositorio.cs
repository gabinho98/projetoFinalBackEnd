using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProjetoEmpreiteira.Model;
using Dapper;
using ProjetoEmpreiteira.DTO;

namespace ProjetoEmpreiteira.Repositorios
{
    public class ClienteRepositorio
    {
        private readonly string _connection = @"Data Source=ITELABD09\SQLEXPRESS;Initial Catalog=dbSistemaEmpreiteira;Integrated Security=True";

        public Cliente SalvarCliente(Cliente cliente)
        {
            int IdPessoaCriada = -1;
            try
            {
                var query = @"INSERT INTO Cliente 
                              (Nome, CNPJ, Telefone) 
                              OUTPUT Inserted.Id
                              VALUES (@nome, @cnpj, @telefone)";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@nome", cliente.Nome);
                    command.Parameters.AddWithValue("@cnpj", cliente.CNPJ);
                    command.Parameters.AddWithValue("@telefone", cliente.Telefone);
                    command.Connection.Open();
                    IdPessoaCriada = (int)command.ExecuteScalar();
                    

                    //Executa a consulta e retorna a primeira coluna da primeira linha no conjunto de resultados retornado pela consulta. Colunas ou linhas adicionais são ignoradas.
                }

                //SalvarEndereco(cliente.Endereco, IdPessoaCriada);
                cliente.Id = IdPessoaCriada;
                Console.WriteLine("Pessoa cadastrada com sucesso.");
                return cliente;

            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro: " + ex.Message);
                throw new Exception(ex.Message);

            }
        }

        public List<ClienteDTO> BuscarPorNome(string nome)
        {
            List<ClienteDTO> ClientesEncontrados;
            try
            {
                var query = @"SELECT Id,Nome,CNPJ,Telefone FROM Cliente WHERE Nome like CONCAT('%',@nome,'%')";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        nome
                    };
                    ClientesEncontrados = connection.Query<ClienteDTO>(query, parametros).ToList();
                }
                return ClientesEncontrados;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
            
        }
        public bool SalvarEnderecoCliente(EnderecoCliente endereco)
        {
            try
            {
                var query = @"INSERT INTO EnderecoCliente 
                              (Rua, Numero, Bairro, Estado, Cidade, IdCliente)                               
                              VALUES (@rua,@bairro, @numero, @estado, @cidade, @idCliente)";

                using (var sql = new SqlConnection(_connection))
                {

                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@rua", endereco.Rua);
                    command.Parameters.AddWithValue("@numero", endereco.Numero);
                    command.Parameters.AddWithValue("@bairro", endereco.Bairro);
                    command.Parameters.AddWithValue("@estado", endereco.Estado);
                    command.Parameters.AddWithValue("@cidade", endereco.Cidade);
                    command.Parameters.AddWithValue("@idCliente", endereco.IdCliente);
                    command.Connection.Open();
                    command.ExecuteNonQuery();

                }

                Console.WriteLine("Endereço cadastrado com sucesso.");

                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }

        public ClienteDTO BuscarCliente(int IdCliente)
        {
            try
            {
                var query = @"SELECT * FROM Cliente WHERE Id = @IdCliente";

                using (var connection = new SqlConnection(_connection))
                {

                    var parametros = new
                    {
                        IdCliente
                    };
                    return connection.QueryFirstOrDefault<ClienteDTO>(query, parametros);

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro: " + ex.Message);
                return null;

            }
        }
        public List<ClienteDTO> BuscarTodos()
        {
            try
            {
                var query = @"SELECT * FROM Cliente";

                using (var connection = new SqlConnection(_connection))
                {
                    return connection.Query<ClienteDTO>(query).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return new List<ClienteDTO>();
            }
        }

        public Cliente AtualizarCliente(int idCliente, Cliente cliente)
        {
            try
            {
                
                var query = "UPDATE Cliente SET Nome = @nome, Cnpj = @cnpj, Telefone = @telefone " +
                    "WHERE Id= @idCliente";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@nome", cliente.Nome);
                    command.Parameters.AddWithValue("@cnpj", cliente.CNPJ);
                    command.Parameters.AddWithValue("@telefone", cliente.Telefone);
                    command.Parameters.AddWithValue("@idCliente", idCliente);
                    command.ExecuteNonQuery();

                }
                cliente.Id = idCliente;
                return cliente;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message); 
            }
        }
        public bool DeletarCliente(int idCliente)
        {
            DeletarEnderecoCliente(idCliente);
            try
            {

                var query = "DELETE FROM Cliente WHERE Id= @idCliente";
                    
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@idCliente", idCliente);

                    command.ExecuteNonQuery();

                }
                Console.WriteLine("Cliente Removido!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não é possível deletar um cliente se tiver dentro de uma OS");
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public bool DeletarEnderecoCliente(int id)
        {
            try
            {
                var query = "DELETE FROM EnderecoCliente Where IdCliente=@id";
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
