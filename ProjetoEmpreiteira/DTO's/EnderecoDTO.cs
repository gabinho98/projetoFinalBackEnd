using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoEmpreiteira.Model;

namespace ProjetoEmpreiteira.DTO
{
    public class EnderecoDTO
    {
        public int Id { get; set; }
        public string Rua { get; set; }

        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
    }
}
