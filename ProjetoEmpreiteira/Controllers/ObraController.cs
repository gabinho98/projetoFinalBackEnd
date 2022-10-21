using Microsoft.AspNetCore.Mvc;
using ProjetoEmpreiteira.DTO_s;
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
    public class ObraController : ControllerBase
    {
        private readonly ObraRepositorio obraRep = new ObraRepositorio();

        [HttpPost]
        public IActionResult Salvar(SalvarObraViewModelObra salvarobraviewmodel)
        {
            var salvo = obraRep.SalvarObra(salvarobraviewmodel.SalvarObra);

            var resultado = new ObraSalvarDto()

            {
                DatadeInicio = salvo.DatadeInicio.ToString("dd/MM/yyyy"),
                Descricao = salvo.Descricao,
                Id = salvo.Id,
                PrevisaodeTermino = salvo.PrevisaodeTermino.ToString("dd/MM/yyyy")
            };

            if (resultado.Id > 0) return Ok(resultado);

            return BadRequest("Não deu certo");
        }
        [HttpGet]
        public IActionResult BuscarObra(int id)
        {
            var salvo = obraRep.BuscarObra(id);

         

            var resultado = new ObraSalvarDto()

            {
                DatadeInicio = salvo.DatadeInicio.ToString("dd/MM/yyyy"),
                Descricao = salvo.Descricao,
                Id = salvo.Id,
                PrevisaodeTermino = salvo.PrevisaodeTermino.ToString("dd/MM/yyyy")
            };
            if (resultado.Id > 0) return Ok(resultado);



            return BadRequest("Deu certo");
        }
        [HttpGet]
        public IActionResult BuscarTodas()
        {
            var resultado = obraRep.BuscarTodas();
            return Ok(resultado);

        }

        [HttpGet]
        public IActionResult BuscarPorNome(string nome)
        {
            var resultado = obraRep.BuscarPorNome(nome);

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }


        [HttpDelete]
        public IActionResult DeletarObra(int id)
        {
            var resultado = obraRep.DeletarObra(id);
            if (resultado) return Ok(new JsonResult(new
            {
                sucesso = true,
                mensagem = "Obra deletada com sucesso!"
            }));

            return BadRequest(new
            {
                sucesso = false,
                mensagem = "Não foi possível deletar a obra"
            });

        }

        [HttpDelete]

        public IActionResult DeletarEnderecoObra(int id)
        {
            var resultado = obraRep.DeletarEnderecoObra(id);

            if (resultado) return Ok("Endereco removido !");

            return Ok("Erro ao Deletar!");
        }

        [HttpPut]
        public IActionResult Atualizar(AtualizarObraViewModel atualizarobraviewmodel)
        {

            var res = obraRep.AtualizarObra(atualizarobraviewmodel.ObraEncontrar, atualizarobraviewmodel.ObraAtualizar);

               

            if (res.Id > 0) return Ok(res);
            return BadRequest("Houve um problema ao atualizar");

        }

        [HttpPost]
        public IActionResult SalvarEnderecoObra(SalvarEnderecoObraClienteViewModel salvarenderecoobraclienteviewmodel)
        {

            var res = obraRep.SalvarEnderecoObra(salvarenderecoobraclienteviewmodel.SalvarEnderecoObra, salvarenderecoobraclienteviewmodel.ObraBuscar);

            if (res) return Ok("Endereco do cliente criado! ");

            return Ok(new
            {
                sucesso = false,
                mensagem = "Erro ao salvar o endereco. Contate o administrador."
            });



        }
    }
}
