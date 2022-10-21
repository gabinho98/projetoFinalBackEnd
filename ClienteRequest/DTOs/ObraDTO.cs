using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteRequest.DTOs
{
    public class ObraDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DatadeInicio { get; set; }
        public DateTime PrevisaodeTermino { get; set; }
    }
}
