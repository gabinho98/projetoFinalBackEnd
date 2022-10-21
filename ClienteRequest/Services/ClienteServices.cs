using ClienteRequest.DTOs;
using ClienteRequest.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ClienteRequest.Services
{
    public class ClienteServices
    {
        public ClienteDTO BuscarPorCliente(int id)
        {

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //Busca todos os clientes dentro da api;
            try
            {
                //monta a request para a api;
                response = httpClient.GetAsync($"https://localhost:44349/Cliente/BuscarCliente?id= {id}").Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                //converte os dados recebidos e retorna eles como objetos do C#;
                var objetoDesserializado = JsonConvert.DeserializeObject<ClienteDTO>(resultado);

                return objetoDesserializado;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }
        public List<ClienteDTO> BuscarTodos()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //Busca todos os clientes dentro da api;
            try
            {
                //monta a request para a api;
                response = httpClient.GetAsync("https://localhost:44349/Cliente/BuscarTodos").Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                //converte os dados recebidos e retorna eles como objetos do C#;
                var objetoDesserializado = JsonConvert.DeserializeObject<List<ClienteDTO>>(resultado);

                return objetoDesserializado;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }

        public void EnviarEndereco(EnderecoCliente enderecoCliente)
        {
            //recebe os dados para enviar para a API cria a viewModel que será enviada;
            var viewModel = new
            {

                SalvarEndereco = enderecoCliente
            };

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //converte o objeto em um JSON 
            var json = JsonConvert.SerializeObject(viewModel);

            try
            {
                //envia os dados para a API, convertendo em uma cadeia de string
                response = httpClient.PostAsync("https://localhost:44349/cliente/SalvarEndereco", new StringContent(json, Encoding.UTF8, "application/json")).Result;
                response.EnsureSuccessStatusCode();
                //faz a request, envia os dados e recebe a resposta da API.
                var resultado = response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void EnviarCliente(Cliente cliente)
        {
            //recebe os dados para enviar para a API cria a viewModel que será enviada;
            var viewModel = new
            {
                
                ClienteSalvar = cliente
            };

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //converte o objeto em um JSON 
            var json = JsonConvert.SerializeObject(viewModel);

            try
            {
                //envia os dados para a API, convertendo em uma cadeia de string
                response = httpClient.PostAsync("https://localhost:44349/Cliente/Salvar", new StringContent(json, Encoding.UTF8, "application/json")).Result;
                response.EnsureSuccessStatusCode();
                //faz a request, envia os dados e recebe a resposta da API.
                var resultado = response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string AtualizarCliente(int id, Cliente cliente)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var viewModel = new
            {
                clienteAtualizar = cliente, 
                clienteEncontrar = id                                    
            };
            var json = JsonConvert.SerializeObject(viewModel);
            try
            {
                response = httpClient.PutAsync("https://localhost:44349/Cliente/Atualizar", new StringContent(json, Encoding.UTF8, "application/json")).Result;
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
        public IActionResult DeletarCliente(int id)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;
          
            try
            {
                response = httpClient.DeleteAsync($"https://localhost:44349/Cliente/DeletarCliente?id= {id}").Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;
                //var objetoDesserializado = JsonConvert.DeserializeObject<Cliente>(resultado);              
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Não é possível deletar um cliente se tiver dentro de uma OS");
                Console.WriteLine(ex.Message);
            }

        }

        public void DeletarEnderecoCliente(int id)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            try
            {
                response = httpClient.DeleteAsync($"https://localhost:44349/Cliente/DeletarEnderecoCliente?id= {id}").Result;
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
