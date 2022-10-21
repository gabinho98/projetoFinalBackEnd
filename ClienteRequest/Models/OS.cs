using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteRequest.Models
{
    public class OS
    {
        public int Id { get; set; }
        public decimal ValordaObra { get; set; }
        public int IdCliente { get; set; }
        public int IdFuncionario { get; set; }
        public int IdObra { get; set; }
    }
}
