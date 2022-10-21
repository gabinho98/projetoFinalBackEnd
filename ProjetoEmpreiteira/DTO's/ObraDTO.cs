using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoEmpreiteira.Model;

namespace ProjetoEmpreiteira.DTO

{
    public class ObraDTO

    {
        public int Id { get; set; }
        public string Descricao {get;set;}      
        public DateTime DatadeInicio { get; set; }
        public DateTime PrevisaodeTermino { get; set; }

           }
}
