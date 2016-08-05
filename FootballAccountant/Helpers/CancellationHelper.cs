using FootballAccountant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAccountant.Helpers
{
    public class CancellationHelper
    {
        public static IList<Cancellation> MapToCancellations(IList<IList<object>> data)
        {
            var cancellations = new List<Cancellation>();

            foreach (var row in data)
            {
                if (IsCancellationRecord(row))
                {
                    var cancellation = CreateCancellation(row);
                    cancellations.Add(cancellation);
                }
            }

            return cancellations;
        }

        private static Cancellation CreateCancellation(IList<object> row)
        {
            return new Cancellation()
            {
                Date = UtilityHelper.ConvertDate(row[0].ToString()),
                Cost = UtilityHelper.ConvertDecimal(row[1].ToString()),
                Unclaimed = row[3].ToString() == "Y" ? true : false,
                Unsettled = row[4].ToString() == "Y" ? true : false
            };
        }

        private static bool IsCancellationRecord(IList<object> record)
        {
            return RecordHelper.IsCancellationRecord(record);
        }
    }
}