using FootballAccountant.Models;
using System.Collections.Generic;
using System;
using System.Globalization;

namespace FootballAccountant.Helpers
{
    public class ChargeHelper
    {
        public static IList<Charge> MapToCharges(IList<IList<object>> data)
        {
            var charges = new List<Charge>();

            foreach (var row in data)
            {
                if (IsChargeRecord(row))
                {
                    var charge = CreateCharge(row);
                    charges.Add(charge);
                }
            }

            return charges;
        }

        private static Charge CreateCharge(IList<object> row)
        {
            return new Charge()
            {
                Date = UtilityHelper.ConvertDate(row[0].ToString()),
                Cost = UtilityHelper.ConvertDecimal(row[1].ToString()),
                Notes = row.Count > 2 ? row[2].ToString() : string.Empty
            };
        }

        private static bool IsChargeRecord(IList<object> record)
        {
            return RecordHelper.IsChargeRecord(record[0].ToString());
        }
    }
}