using LineIN_ExportadorDominio.Contabil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LineIN_ExportadorDominio
{
    class Program
    {
        static void Main(string[] args)
        {
            REG6000 Reg6000 = new REG6000();

            REG6100 Reg6100 = new REG6100();

            Reg6100.DataLacto = DateTime.Now;
            Reg6100.DebitoId = 1000;
            Reg6100.CreditoID = 2000;
            Reg6100.Valor = 10458.58M;
            Reg6100.CodHist = 101;
            Reg6100.Histórico = "Sou o Histórico do Contábil";
            Reg6100.Usuario = "Ettore";
            Reg6100.CodFilial = 136;
            Reg6100.SCP = 0;

            REG6100 Reg6100a = new REG6100();

            Reg6100a.DataLacto = DateTime.Now;
            Reg6100a.DebitoId = 1000;
            Reg6100a.CreditoID = 2000;
            Reg6100a.Valor = 10458.58M;
            Reg6100a.CodHist = 101;
            Reg6100a.Histórico = "Sou o Histórico do Contábil AAAAAAAAAAAA";
            Reg6100a.Usuario = "Ettore";
            Reg6100a.CodFilial = 136;
            Reg6100a.SCP = 0;

            Console.WriteLine(Reg6000.Exportar());
            Console.WriteLine(Reg6100.Exportar());
            Console.WriteLine(Reg6100a.Exportar());

            // }

            Console.ReadLine();
        }
    }
}
