using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEmpreiteira.DTO

{
    public class OSDTO

    {

        public int OrdemDeServico{ get; set; }
        public float ValordaObra { get; set; }
        public string NomeCliente { get; set; }
        public int IdCliente { get; set; }
        public int IdFuncionario { get; set; }
        public int IdObra { get; set; }
        public string NomeFuncionario { get; set; }
        public string DescricaoDaObra { get; set; }

        public DateTime DataDeInicio { get; set; }

        public DateTime PrevisaoDeTermino { get; set; }
    }
}
