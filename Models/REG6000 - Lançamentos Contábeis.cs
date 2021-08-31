using LineIN_ExportadorDominio.Util;
using System;
using System.Collections.Generic;
using System.IO;
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

    public class GerarTxtDominio<T> where T: IReg
    {
        public void Gerar(string path, List<T> list)
        {
            StreamWriter sw = new StreamWriter(path, false, Encoding.GetEncoding("ISO-8859-1"));

            foreach (var item in list)
            {
                sw.WriteLine(item.Exportar());
            }
            sw.Close();
        }
    }

    public interface IReg
    {
        string Exportar();
    }

       public class REG6000: IReg
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
      
      
        public string Exportar()
        {
            return this.SerizalizarTxtDominio<REG6000>();         
        }

    }

    public class REG6100: IReg
    {

        [Ordem(0)]
        public REG6000 Reg6000;
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

        public REG6100()
        {
            Reg6000 = new REG6000();
        }

        public string Exportar()
        {
            return String.Concat(this.Reg6000.Exportar(), 
                                 Environment.NewLine, 
                                 this.SerizalizarTxtDominio<REG6100>());
        }

    }




}
