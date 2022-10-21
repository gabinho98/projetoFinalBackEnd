using ClienteRequest.DTOs;
using ClienteRequest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ClienteRequest.Services
{
    class FuncionarioServices
    {
        public void EnviarFuncionario(Funcionario funcionario)
        {
            //recebe os dados para enviar para a API cria a viewModel que será enviada;
            var viewModel = new
            {

                SalvarFuncionario = funcionario
            };

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //converte o objeto em um JSON 
            var json = JsonConvert.SerializeObject(viewModel);

            try
            {
                //envia os dados para a API, convertendo em uma cadeia de string
                response = httpClient.PostAsync("https://localhost:44349/Funcionario/salvar", new StringContent(json, Encoding.UTF8, "application/json")).Result;
                response.EnsureSuccessStatusCode();
                //faz a request, envia os dados e recebe a resposta da API.
                var resultado = response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public FuncionarioDTO BuscarPorFuncionario(int id)
        {

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //Busca todos os funcionarios dentro da api;
            try
            {
                //monta a request para a api;
                response = httpClient.GetAsync($"https://localhost:44349/funcionario/BuscarFuncionario?id= {id}").Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                //converte os dados recebidos e retorna eles como objetos do C#;
                var objetoDesserializado = JsonConvert.DeserializeObject<FuncionarioDTO>(resultado);

                return objetoDesserializado;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }

        }

        public List<FuncionarioDTO> BuscarTodos()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //Busca todos os clientes dentro da api;
            try
            {
                //monta a request para a api;
                response = httpClient.GetAsync("https://localhost:44349/funcionario/BuscarTodosFuncionarios").Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                //converte os dados recebidos e retorna eles como objetos do C#;
                var objetoDesserializado = JsonConvert.DeserializeObject<List<FuncionarioDTO>>(resultado);

                return objetoDesserializado;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }
        public string AtualizarFuncionario(int id, Funcionario funcionario)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var viewModel = new
            {
                 FuncionarioAtualizar = funcionario,
                 FuncionarioEncontrar  = id
            };
            var json = JsonConvert.SerializeObject(viewModel);
            try
            {
                response = httpClient.PutAsync("https://localhost:44349/funcionario/atualizarfuncionario", new StringContent(json, Encoding.UTF8, "application/json")).Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;
                //var objetoDesserializado = JsonConvert.DeserializeObject<Cliente>(resultado);

                return resultado;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }

        }
        public void DeletarFuncionario(int id)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            try
            {
                response = httpClient.DeleteAsync($"https://localhost:44349/funcionario/DeletarFuncionario?id= {id}").Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;
                //var objetoDesserializado = JsonConvert.DeserializeObject<Cliente>(resultado);              
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
