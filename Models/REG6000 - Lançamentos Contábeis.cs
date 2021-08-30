using LineIN_ExportadorDominio.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LineIN_ExportadorDominio.Contabil
{
    public class OrdemAttribute: Attribute
    {
        public OrdemAttribute(int numero)
        {
            Numero = numero;
        }
        public int Numero { get;}
      
      
    }

       public class REG6000
    {
        [Ordem(1)]
        public string Reg => "6000";
        [Ordem(2)]
        public string TipoLcto => "X";
        [Ordem(3)]
        public string CodLactoPadrao => "";
        [Ordem(4)]
        public string Localizador => "";
        [Ordem(5)]
        public string RTT => "";
       
        public IList<REG6100> Reg6100s { get; set; }

        public REG6000()
        {
            Reg6100s = new List<REG6100>();
        }

        public string Exportar()
        {
            return this.SerizalizarTxtDominio<REG6000>();         
        }

    }

    public class REG6100
    {
        [Ordem(1)]
        public string Reg => "6100";
        [Ordem(2)]
        public DateTime DataLacto { get; set; }
        [Ordem(3)]
        public int DebitoId { get; set; }
        [Ordem(4)]
        public int CreditoID { get; set; }
        [Ordem(5)]
        public decimal Valor { get; set; }
        [Ordem(6)]
        public int CodHist { get; set; }
        [Ordem(7)]
        public string Histórico { get; set; }
        [Ordem(8)]
        public string Usuario { get; set; }
        [Ordem(9)]
        public int CodFilial { get; set; }
        [Ordem(10)]
        public int SCP { get; set; }

        public string Exportar()
        {
            return this.SerizalizarTxtDominio<REG6100>();
        }

    }




}
