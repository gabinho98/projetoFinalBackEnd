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
    public class FuncionarioRepositorio
    {
        private readonly string _connection = @"Data Source=ITELABD09\SQLEXPRESS;Initial Catalog=dbSistemaEmpreiteira;Integrated Security=True";

        public Funcionario SalvarFuncionario(Funcionario funcionario)
        {
            int IdPessoaCriada = -1;
            try
            {
                var query = @"INSERT INTO Funcionarios
                              (Nome, CPF, Cargo) 
                              OUTPUT Inserted.Id
                              VALUES (@nome, @cpf, @cargo)";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@nome", funcionario.Nome);
                    command.Parameters.AddWithValue("@cpf", funcionario.CPF);
                    command.Parameters.AddWithValue("@cargo", funcionario.Cargo);
                    command.Connection.Open();
                    IdPessoaCriada = (int)command.ExecuteScalar();
                }
                Console.WriteLine("Funcionario cadastrado com sucesso.");
                funcionario.Id = IdPessoaCriada;
                return funcionario;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public FuncionarioDTO BuscarFuncionario(int IdFuncionario)
        {
            try
            {
                var query = @"SELECT * FROM Funcionarios WHERE Id = @IdFuncionario";

                using (var connection = new SqlConnection(_connection))
                {

                    var parametros = new
                    {
                        IdFuncionario
                    };
                    return connection.QueryFirstOrDefault<FuncionarioDTO>(query, parametros);

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro: " + ex.Message);
                return null;

            }
        }

        public List<FuncionarioDTO> BuscarTodosFuncionarios()
        {
            try
            {
                var query = @"SELECT * FROM Funcionarios";

                using (var connection = new SqlConnection(_connection))
                {
                    return connection.Query<FuncionarioDTO>(query).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return new List<FuncionarioDTO>();
            }
        }

        public List<FuncionarioDTO> BuscarPorNome(string nome)
        {
            List<FuncionarioDTO> FuncionariosEncontrados;
            try
            {
                var query = @"SELECT Id,Nome,CPF,Cargo FROM Funcionarios WHERE Nome like CONCAT('%',@nome,'%')";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        nome
                    };
                    FuncionariosEncontrados = connection.Query<FuncionarioDTO>(query, parametros).ToList();
                }
                return FuncionariosEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public Funcionario AtualizarFuncionario(int idFuncionario, Funcionario funcionario)
        {
            try
            {

                var query = "UPDATE Funcionarios SET Nome = @nome, CPF = @cpf, Cargo = @cargo " +
                    "WHERE Id= @idFuncionario";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@nome", funcionario.Nome);
                    command.Parameters.AddWithValue("@cpf", funcionario.CPF);
                    command.Parameters.AddWithValue("@cargo", funcionario.Cargo);
                    command.Parameters.AddWithValue("@idFuncionario", idFuncionario);
                    command.ExecuteNonQuery();
                }
                funcionario.Id = idFuncionario;
                return funcionario;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public bool DeletarFuncionario(int idFuncionario)
        {
            try
            {
                var query = "DELETE FROM Funcionarios " +
                    "WHERE Id= @idFuncionario";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@idFuncionario", idFuncionario);

                    command.ExecuteNonQuery();

                }
                Console.WriteLine("Funcionario Removido!");
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
