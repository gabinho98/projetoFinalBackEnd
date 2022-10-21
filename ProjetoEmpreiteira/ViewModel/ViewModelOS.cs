using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoEmpreiteira.Model;

namespace ProjetoEmpreiteira.ViewModel
{
    public class ViewModelOS
    {
        public OS OrdemdeServico { get; set; }
        public Cliente cliente { get; set; }
        public Funcionario Funcionarios { get; set; }
        public Obra Obras { get; set; }
    }
}
