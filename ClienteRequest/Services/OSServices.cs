using ClienteRequest.DTOs;
using ClienteRequest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ClienteRequest.Services
{
    public class OSServices
    {
        public void EnviarOS(OS oS)
        {
            //recebe os dados para enviar para a API cria a viewModel que será enviada;
            var viewModel = new
            {
                ParametrosOs = oS

            };

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //converte o objeto em um JSON 
            var json = JsonConvert.SerializeObject(viewModel);

            try
            {
                //envia os dados para a API, convertendo em uma cadeia de string
                response = httpClient.PostAsync("https://localhost:44349/Os/SalvarOs", new StringContent(json, Encoding.UTF8, "application/json")).Result;
                response.EnsureSuccessStatusCode();
                //faz a request, envia os dados e recebe a resposta da API.
                var resultado = response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string AtualizarOS(int id, OS oS)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var viewModel = new
            {
                OSencontrar = id,
                OSatualizar = oS
            };
            var json = JsonConvert.SerializeObject(viewModel);
            try
            {
                response = httpClient.PutAsync("https://localhost:44349/os/atualizarvalor", new StringContent(json, Encoding.UTF8, "application/json")).Result;
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

        public string DeletarOS(int id)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            try
            {
                response = httpClient.DeleteAsync($"https://localhost:44349/os/deletaros?id= {id}").Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;
                return resultado;
                //var objetoDesserializado = JsonConvert.DeserializeObject<Cliente>(resultado);              
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }

        }

        public List<OSDTO> BuscarTodos()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //Busca todos os clientes dentro da api;
            try
            {
                //monta a request para a api;
                response = httpClient.GetAsync("https://localhost:44349/os/buscartodas").Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                //converte os dados recebidos e retorna eles como objetos do C#;
                var objetoDesserializado = JsonConvert.DeserializeObject<List<OSDTO>>(resultado);

                return objetoDesserializado;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public OSDTO BuscarPorOS(int id)
        {

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //Busca todos os clientes dentro da api;
            try
            {
                //monta a request para a api;
                response = httpClient.GetAsync($"https://localhost:44349/os/buscarOS?id= {id}").Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                //converte os dados recebidos e retorna eles como objetos do C#;
                var objetoDesserializado = JsonConvert.DeserializeObject<OSDTO>(resultado);

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
