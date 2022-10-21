using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoEmpreiteira.DTO;
using ProjetoEmpreiteira.Model;

namespace ProjetoEmpreiteira.ViewModel
{
    public class SalvarEnderecoObraClienteViewModel
    {
        public int ObraBuscar { get; set; }
        public EnderecoObras SalvarEnderecoObra { get; set; }
    }
}
