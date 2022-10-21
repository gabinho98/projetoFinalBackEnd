using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteRequest.Models
{
    public class EnderecoObra
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }

        public string Rua { get; set; }
        public string Numero { get; set; }
        public int IdClienteEndereco { get; set; }
    }
}
