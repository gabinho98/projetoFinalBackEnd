using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteRequest.DTOs
{
    public class OSDTO
    {
        public int OrdemDeServico { get; set; }
        public float ValordaObra { get; set; }
        public string NomeCliente { get; set; }
        public string NomeFuncionario { get; set; }
        public string DescricaoDaObra { get; set; }

        public DateTime DataDeInicio { get; set; }

        public DateTime PrevisaoDeTermino { get; set; }

    }
}
