using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteRequest.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
    }
}
