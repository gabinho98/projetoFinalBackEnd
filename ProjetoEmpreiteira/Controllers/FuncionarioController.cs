using Microsoft.AspNetCore.Mvc;
using ProjetoEmpreiteira.Model;
using ProjetoEmpreiteira.Repositorios;
using ProjetoEmpreiteira.ViewModel.FuncionarioViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEmpreiteira.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionarioRepositorio funcionarioRepositorio = new FuncionarioRepositorio();

        [HttpPost]
        public IActionResult Salvar(SalvarFuncionarioViewModel salvarFuncionarioViewModel)
        {
            var resultado = funcionarioRepositorio.SalvarFuncionario(salvarFuncionarioViewModel.SalvarFuncionario);

            if (resultado.Id > 0) return Ok(resultado);

            return BadRequest("Houve um problema ao salvar. Funcionario não cadastrado.");
        }

        [HttpGet]
        public IActionResult BuscarFuncionario(int id)
        {
            var resultado = funcionarioRepositorio.BuscarFuncionario(id);

            return Ok(resultado);
        }

        [HttpGet]
        public IActionResult BuscarTodosFuncionarios()
        {
            var resultado = funcionarioRepositorio.BuscarTodosFuncionarios();

            return Ok(resultado);
        }

        [HttpDelete]
        public IActionResult DeletarFuncionario(int id)
        {
            var resultado = funcionarioRepositorio.DeletarFuncionario(id);
            if (resultado) return Ok(new JsonResult(new
            {
                sucesso = true,
                mensagem = "Funcionário deletado com sucesso"
            }));

            return BadRequest(new
            {
                sucesso = false,
                mensagem = "Não foi possível deletar o funcionários"
            });
        }

        [HttpGet]
        public IActionResult BuscarPorNome(string nome)
        {
            var resultado = funcionarioRepositorio.BuscarPorNome(nome);

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        [HttpPut]
        public IActionResult AtualizarFuncionario(AtualizarFuncionarioViewModel atualizarFuncionarioViewModel)
        {

            var res = funcionarioRepositorio.AtualizarFuncionario(atualizarFuncionarioViewModel.FuncionarioEncontrar, atualizarFuncionarioViewModel.FuncionarioAtualizar);
            if(res.Id > 0) return Ok(res);

            return BadRequest("Houve um problema ao atualizar");
        }
    }
}
