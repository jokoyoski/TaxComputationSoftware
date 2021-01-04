using System;
using System.Globalization;
using System.Linq;

namespace TaxComputationAPI.Helpers
{
    public static class Utilities
    {

        public static string FormatAmount(object amount, short decimalDigits = 2)
        {

            var amt = Convert.ToDecimal(amount);

            var numi = new NumberFormatInfo { CurrencySymbol = null + " ", CurrencyDecimalDigits = decimalDigits };
            var value = (amt).ToString("c", numi);
            value = String.Concat(value.Where(c => !Char.IsWhiteSpace(c)));
            return $"{value}";
        }

        public static bool ValidateDate(DateTime openingDate, int yearId)
        {
            int openingDay = openingDate.Day;
            int openingMonth = openingDate.Month;
            string timeFormat = $"{yearId}/{openingMonth}/{openingDay}";
            if (DateTime.Parse(timeFormat) < openingDate)
            {
                return false;
            }
            if (DateTime.Parse(timeFormat) >= openingDate)
            {
                return false;
            }
            return true;
        }


        public static string AreaMapped(string mappedTo)
        {
            string areaMapped = "";
            bool isReady = false;

            for (int i = 0; i < mappedTo.Length; i++)
            {
                if (mappedTo[i] == ']')
                {
                    isReady = false;
                }
                if (isReady)
                {
                    areaMapped += mappedTo[i];
                }
                if (mappedTo[i] == '[')
                {
                    isReady = true;
                }

            }

            return areaMapped;


        }


        private static Random random = new Random();
        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 11)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        public static decimal GetDecimal(object amount)
        {
            return Convert.ToDecimal(amount);
        }
    }
}