using System;
using System.Globalization;
using System.Linq;

namespace TaxComputationAPI.Helpers
{
    public static  class Utilities
    {
        
        public static string FormatAmount(object amount, short decimalDigits=2){

            var amt=Convert.ToDecimal(amount);

            var numi=new NumberFormatInfo{CurrencySymbol=null+" ",CurrencyDecimalDigits=decimalDigits};
           var value= (amt).ToString("c",numi);
           value=String.Concat(value.Where(c => !Char.IsWhiteSpace(c)));
           return $"₦{value}";
        }


         public static decimal GetDecimal(object amount)
        {
           return Convert.ToDecimal(amount);
        }
    }
}