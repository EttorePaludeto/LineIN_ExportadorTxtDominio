using LineIN_ExportadorDominio.Contabil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LineIN_ExportadorDominio.Util
{
    public static class Extentions
    {
        public static string Delimitador => "|";

        public static string SerizalizarTxtDominio<T>(this T value)
        {
            string txtReg = "";
            
            IOrderedEnumerable<PropertyInfo> campos = from prop in typeof(T).GetProperties()
                                                      where Attribute.IsDefined(prop, typeof(OrdemAttribute))
                                                      orderby ((OrdemAttribute)prop
                                                         .GetCustomAttributes(typeof(OrdemAttribute), false)
                                                         .Single()).Numero
                                                      select prop;
            foreach (PropertyInfo p in campos)
            {

                string valor = p.GetValue(value).ToString();

                //Tratar DataTypes
                if (p.PropertyType.Name == "DateTime") valor = valor.FormatDate();
             

                txtReg = String.Concat(txtReg, valor.ToString(), Delimitador);
            }

            return txtReg;
        }

        public static string FormatDate(this object value)
        {
           return Convert.ToDateTime(value).ToString("dd/MM/yyyy");
        }

    }
}
