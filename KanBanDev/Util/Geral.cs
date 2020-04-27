using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanBanDev.Util
{
    public class Geral
    {
        public static String ConverterTextoParaBase64(String Texto)
        {
            byte[] toEncodeAsBytes =
            System.Text.Encoding.UTF8.GetBytes(Texto);
            string returnValue =
            System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        public static String ConverterBase64ParaTexto(String Texto)
        {
            byte[] encodedDataAsBytes =
            System.Convert.FromBase64String(Texto);
            string returnValue =
            System.Text.Encoding.UTF8.GetString(encodedDataAsBytes);
            return returnValue;
        }
    }
}
