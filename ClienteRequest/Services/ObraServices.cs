using ClienteRequest.DTOs;
using ClienteRequest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ClienteRequest.Services
{
    public class ObraServices
    {
        public void EnviarObra(Obra obra)
        {
            //recebe os dados para enviar para a API cria a viewModel que será enviada;
            var viewModel = new
            {

                SalvarObra = obra
            };

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //converte o objeto em um JSON 
            var json = JsonConvert.SerializeObject(viewModel);

            try
            {
                //envia os dados para a API, convertendo em uma cadeia de string
                response = httpClient.PostAsync("https://localhost:44349/obra/salvar", new StringContent(json, Encoding.UTF8, "application/json")).Result;
                response.EnsureSuccessStatusCode();
                //faz a request, envia os dados e recebe a resposta da API.
                var resultado = response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void EnviarEnderecoObra(int id, EnderecoObra enderecoObra)
        {
            //recebe os dados para enviar para a API cria a viewModel que será enviada;
            var viewModel = new
            {
                ObraBuscar = id,
                SalvarEnderecoObra = enderecoObra
            };

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //converte o objeto em um JSON 
            var json = JsonConvert.SerializeObject(viewModel);

            try
            {
                //envia os dados para a API, convertendo em uma cadeia de string
                response = httpClient.PostAsync("https://localhost:44349/obra/salvarenderecoobra", new StringContent(json, Encoding.UTF8, "application/json")).Result;
                response.EnsureSuccessStatusCode();
                //faz a request, envia os dados e recebe a resposta da API.
                var resultado = response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string AtualizarObra(int id, Obra obra)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var viewModel = new
            {
                ObraEncontrar = id,
                ObraAtualizar = obra
            };
            var json = JsonConvert.SerializeObject(viewModel);
            try
            {
                response = httpClient.PutAsync("https://localhost:44349/obra/atualizar", new StringContent(json, Encoding.UTF8, "application/json")).Result;
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

        public void DeletarObra(int id)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            try
            {
                response = httpClient.DeleteAsync($"https://localhost:44349/obra/deletarobra?id= {id}").Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;
                //var objetoDesserializado = JsonConvert.DeserializeObject<Cliente>(resultado);              
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void DeletarEnderecoObra(int id)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            try
            {
                response = httpClient.DeleteAsync($"https://localhost:44349/obra/DeletarEnderecoObra?id= {id}").Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;
                //var objetoDesserializado = JsonConvert.DeserializeObject<Cliente>(resultado);              
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public List<ObraDTO> BuscarTodos()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //Busca todos os clientes dentro da api;
            try
            {
                //monta a request para a api;
                response = httpClient.GetAsync("https://localhost:44349/obra/buscartodas").Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                //converte os dados recebidos e retorna eles como objetos do C#;
                var objetoDesserializado = JsonConvert.DeserializeObject<List<ObraDTO>>(resultado);

                return objetoDesserializado;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }

        public ObraDTO BuscarPorObra(int id)
        {

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //Busca todos os clientes dentro da api;
            try
            {
                //monta a request para a api;
                response = httpClient.GetAsync($"https://localhost:44349/obra/buscarobra?id= {id}").Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                //converte os dados recebidos e retorna eles como objetos do C#;
                var objetoDesserializado = JsonConvert.DeserializeObject<ObraDTO>(resultado);

                return objetoDesserializado;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }
    }
}
