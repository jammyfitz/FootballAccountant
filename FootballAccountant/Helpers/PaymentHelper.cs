using FootballAccountant.Models;
using System;
using System.Collections.Generic;

namespace FootballAccountant.Helpers
{
    public class PaymentHelper
    {
        public static IList<Payment> MapToPayments(IList<IList<object>> data)
        {
            var payments = new List<Payment>();
            IList<object> previousRow = null;

            foreach (var row in data)
            {
                if (IsPaymentRecord(row))
                {
                    var payment = CreatePayment(row, previousRow);
                    payments.Add(payment);
                }
                previousRow = row;
            }

            return payments;
        }

        private static bool IsPaymentRecord(IList<object> record)
        {
            return RecordHelper.IsPaymentRecord(record[0].ToString());
        }

        private static Payment CreatePayment(IList<object> row, IList<object> previousRow)
        {
            return new Payment()
            {
                Total = UtilityHelper.ConvertDecimal(row[1].ToString()),
                DatePaid = GetDatePaidFromNotes(row),
                From = GetFromDateFromNotes(row),
                To = GetToDate(previousRow),
                IsPaid = IsPaid(row)
            };
        }

        private static DateTime GetDatePaidFromNotes(IList<object> row)
        {
            var note = row.Count > 2 ? row[2].ToString() : string.Empty;
            return RecordHelper.GetDatePaidFromNotes(note);
        }

        private static DateTime GetFromDateFromNotes(IList<object> row)
        {
            var note = row.Count > 2 ? row[2].ToString() : string.Empty;
            return RecordHelper.GetFromDateFromNotes(note);
        }

        private static DateTime GetToDate(IList<object> row)
        {
            return UtilityHelper.ConvertDate(row[0].ToString());
        }

        private static bool IsPaid(IList<object> row)
        {
            var note = row.Count > 2 ? row[2].ToString() : string.Empty;
            return RecordHelper.IsPaid(note);
        }
    }
}