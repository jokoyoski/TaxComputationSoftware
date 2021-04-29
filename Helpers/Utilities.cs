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

        public static bool ValidateDate(DateTime openingDate, DateTime closingDate, DateTime currentOpenDate, DateTime currentClosingDate)
        {
            if (currentOpenDate < openingDate)
            {
                return false;
            }
            if (currentOpenDate > closingDate)
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

        public static string ValueMoneyFormatter(this string money, string currency, bool addCurrency)
        {

            if (string.IsNullOrEmpty(money)) return string.Empty;

            if (!Decimal.TryParse(money, out decimal moneyValue)) return string.Empty;

            money = Math.Round(moneyValue, 2).ToString();

            bool isNegative = false;

            if (moneyValue < 0)
            {
                money = money.Substring(1);
                isNegative = true;
            }

            string result = string.Empty;
            string curr = string.Empty;

            string[] currencyArray = { "=N=", "=S=", "=E=", "=P=", "=Y=" };

            switch (currency)
            {
                case "NGN":
                    curr = currencyArray[0];
                    break;
                case "USD":
                    curr = currencyArray[1];
                    break;
                case "EUR":
                    curr = currencyArray[2];
                    break;
                case "GBP":
                    curr = currencyArray[3];
                    break;
                case "CNY":
                    curr = currencyArray[4];
                    break;
                default:
                    curr = currencyArray[0];
                    break;
            }

            money = money.Trim();

            bool hasDot = money.Any(p => p.Equals('.'));

            int moneySize = money.Length;
            int count = 1;
            bool fountDot = false;

            for (int i = money.Length - 1; i >= 0; i--)
            {

                string value = money[i].ToString();

                if (string.IsNullOrEmpty(result))
                {
                    result += value;
                }
                else
                {
                    result = result.Insert(0, value);
                }

                moneySize--;

                if (hasDot)
                {
                    if (fountDot)
                    {
                        var report = AddComma(result, count, moneySize);

                        result = report.Item1;
                        count = report.Item2;
                    }
                    if (money[i] == '.') fountDot = true;
                }
                else
                {
                    var report = AddComma(result, count, moneySize);

                    result = report.Item1;
                    count = report.Item2;
                }
                
            }

            if (isNegative) result = $"({result})";

            if (addCurrency) result = curr + result;

            return result;
        }

        private static Tuple<string, int> AddComma(string result, int count, int moneySize)
        {
            if (count == 3 && (moneySize > 3 || moneySize >= 1))
            {
                result = "," + result;
                count = 0;
            }
            count++;
            return new Tuple<string, int>(result, count);
        }

    }
}