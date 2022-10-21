using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteRequest.DTOs
{
    public class FuncionarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Cargo { get; set; }
    }
}
