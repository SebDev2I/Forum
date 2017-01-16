using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// Classe contenant les propriétés statiques définissant les valeurs null
    /// </summary>
    public class CommonBase
    {
        //Valeurs null de configuration
        public static int Int_NullValue = int.MinValue;
        public static float Float_NullValue = float.MinValue;
        public static decimal Decimal_NullValue = decimal.MinValue;
        public static string String_NullValue = null;
        public static DateTime DateTime_NullValue = DateTime.MinValue;
    }
}
