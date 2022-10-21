using Microsoft.AspNetCore.Mvc;
using ProjetoEmpreiteira.Repositorios;
using ProjetoEmpreiteira.ViewModel.OsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEmpreiteira.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OSController : ControllerBase
    {

        private readonly OSRepositorio osRep = new OSRepositorio();

        [HttpPost]
        public IActionResult SalvarOS(SalvarOsViewModel salvarOsViewModel)
        {
            var resultado = osRep.SalvarOs(salvarOsViewModel.ParametrosOs.ValordaObra, salvarOsViewModel.ParametrosOs.IdCliente, salvarOsViewModel.ParametrosOs.IdFuncionario,salvarOsViewModel.ParametrosOs.IdObra);

            if (resultado) return Ok(new JsonResult(new
            {
                sucesso = true,
                mensagem = "Ordem de Serviço Cadastrada!"
            }));

            return BadRequest(new
            {
                sucesso = false,
                mensagem = "Não foi possível cadastrar a Ordem de Serviço"
            });
        }

        [HttpGet]
        public IActionResult BuscarTodas()
        {
            var resultado = osRep.BuscarTodasOS();

            if (resultado == null || !resultado.Any())
                return NotFound();

            return Ok(resultado);
        }

        [HttpGet]
        public IActionResult BuscarPorNome(string nome)
        {
            var resultado = osRep.BuscarPorNome(nome);

            if (resultado == null || !resultado.Any())
                return NotFound();

            return Ok(resultado);
        }
        [HttpGet]
        public IActionResult BuscarOS(int id)
        {
            var resultado = osRep.BuscarOS(id);

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }
        [HttpDelete]
        public IActionResult DeletarOS(int id)
        {
            var resultado = osRep.DeletarOS(id);

            if (resultado) return Ok(new JsonResult(new
            {
                sucesso = true,
                mensagem = "Ordem de Serviço Deletada!"
            }));

            return BadRequest(new
            {
                sucesso = false,
                mensagem = "Não foi possível deletar a Ordem de Serviço"
            });

        }
        [HttpPut]
        public IActionResult AtualizarValor(AtualizarValorOsViewModel atualizarvalorosviewmodel)
        {

            var res = osRep.AtualizarValorOS(atualizarvalorosviewmodel.OSencontrar, atualizarvalorosviewmodel.OSatualizar);

            if (res) return Ok(new JsonResult(new
            {
                sucesso = true,
                mensagem = "Ordem de Serviço atualizada!"
            }));

            return BadRequest(new
            {
                sucesso = false,
                mensagem = "Erro ao atualizar. Contate o administrador."
            });

        }

    }

}
