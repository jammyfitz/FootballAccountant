using System;
using System.Globalization;

namespace FootballAccountant.Helpers
{
    public class UtilityHelper
    {
        public static decimal ConvertDecimal(string input)
        {
            return decimal.Parse(input.Substring(1, input.Length - 1));
        }

        public static DateTime ConvertDate(string input)
        {
            return DateTime.ParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}