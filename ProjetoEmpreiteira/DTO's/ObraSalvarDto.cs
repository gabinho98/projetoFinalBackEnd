using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEmpreiteira.DTO_s
{
    public class ObraSalvarDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string DatadeInicio { get; set; }
        public string PrevisaodeTermino { get; set; }
    }
}
