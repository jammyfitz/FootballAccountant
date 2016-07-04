using FootballAccountant.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Globalization;

namespace FootballAccountant.Helpers
{
    public class ChargeHelper
    {
        public static IList<Charge> MapToCharges(IList<IList<object>> data)
        {
            var charges = new List<Charge>();

            //data.Where(x => x.Select(y => y))
            //data.RemoveRange(index, list.Count - index);

            foreach (var row in data)
            {
                if (IsNotDate(row[0].ToString()))
                {
                    continue;
                }

                var charge = CreateCharge(row);
                    
                 

                charges.Add(charge);
            }

            return charges;
        }

        private static Charge CreateCharge(IList<object> row)
        {
            return new Charge()
            {
                Date = ConvertDate(row[0].ToString()),
                Cost = ConvertDecimal(row[1].ToString()),
                Notes = row.Count > 2 ? row[2].ToString() : string.Empty
            };
        }

        private static decimal ConvertDecimal(string input)
        {
            return decimal.Parse(input.Substring(1, input.Length - 1));
        }

        private static DateTime ConvertDate(string input)
        {
            return DateTime.ParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        private static bool IsNotDate(string value)
        {
            DateTime result = DateTime.MinValue;
            DateTime.TryParse(value, out result);

            return (result == DateTime.MinValue);
        }
    }
}