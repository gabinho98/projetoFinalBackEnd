using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoEmpreiteira.Model;

namespace ProjetoEmpreiteira.DTO
{
    public class FuncionarioDTO

    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Cargo { get; set; }
    }
}
