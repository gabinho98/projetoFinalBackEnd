using Microsoft.AspNetCore.Mvc;
using ProjetoEmpreiteira.Model;
using ProjetoEmpreiteira.Repositorios;
using ProjetoEmpreiteira.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEmpreiteira.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ClienteController : ControllerBase 
    {
       private readonly ClienteRepositorio clienteRep = new ClienteRepositorio();

        [HttpPost]
        public IActionResult Salvar([FromBody] SalvarClienteViewModel salvarclienteviewmodel)
        {
            var resultado = clienteRep.SalvarCliente(salvarclienteviewmodel.ClienteSalvar);

            if (resultado.Id > 0) return Ok(resultado);

            return BadRequest("Houve um problema ao salvar. Cliente não cadastrado.");
        }
        [HttpGet]
        public IActionResult BuscarCliente(int id) 
        {
            var resultado = clienteRep.BuscarCliente(id);

            if (resultado == null )
                return NotFound();

            return Ok(resultado);
        }

        [HttpGet]
        public IActionResult BuscarPorNome(string nome)
        {
            var resultado = clienteRep.BuscarPorNome(nome);

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            var resultado = clienteRep.BuscarTodos();

            if (resultado == null || !resultado.Any())
                return NotFound();

            return Ok(resultado);
        }

        [HttpDelete]
        public IActionResult DeletarCliente(int id)
        {
            var resultado = clienteRep.DeletarCliente(id);

            if (resultado) return Ok(new JsonResult(new
            {
                sucesso = true,
                mensagem = "Cliente Deletado!"
            }));

            return BadRequest(new
            {
                sucesso = false,
                mensagem = "Não foi possível deletar o Cliente"
            });

        }
        [HttpDelete]
        public IActionResult DeletarEnderecoCliente(int id)
        {
            var resultado = clienteRep.DeletarEnderecoCliente(id);

            if (resultado) return Ok(new JsonResult(new
            {
                sucesso = true,
                mensagem = "Endereço do cliente removido@"
            }));

            return BadRequest(new
            {
                sucesso = false,
                mensagem = "Não foi possível deletar o endereço do cliente"
            });
        }
        [HttpPut]
        public IActionResult Atualizar(AtualizarClienteViewModel atualizarpessoaviewmodel)
        {

            var res = clienteRep.AtualizarCliente(atualizarpessoaviewmodel.ClienteEncontrar, atualizarpessoaviewmodel.ClienteAtualizar);

            if (res.Id > 0) return Ok(res);
            return BadRequest("Não foi possivel atualizar funcionario. ");
            

        }
        [HttpPost]
        public IActionResult SalvarEndereco(SalvarEnderecoClienteViewModel enderecoClienteViewModel)
        {

            var res = clienteRep.SalvarEnderecoCliente(enderecoClienteViewModel.SalvarEndereco);

            if (res) return Ok(new JsonResult(new
            {
                sucesso = true,
                mensagem = "Endereço salvo com sucesso"
            }));

            return BadRequest(new
            {
                sucesso = false,
                mensagem = "Não foi possível salvar o endereço"
            });



        }



    }
}
