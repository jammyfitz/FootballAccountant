using System;
using System.Collections.Generic;
using System.Globalization;

namespace FootballAccountant.Helpers
{
    public class RecordHelper
    {
        public static bool IsChargeRecord(string value)
        {
            DateTime result = DateTime.MinValue;
            DateTime.TryParse(value, out result);

            return (result != DateTime.MinValue);
        }

        public static bool IsPaymentRecord(string value)
        {
            return (value == "TOTAL");
        }

        public static DateTime GetDatePaidFromNotes(string note)
        {
            if (string.IsNullOrEmpty(note))
                return DateTime.MinValue;

            var dateString = note.Substring(14, 8);
            return DateTime.ParseExact(dateString, "dd/MM/yy", CultureInfo.InvariantCulture);
        }

        public static DateTime GetFromDateFromNotes(string note)
        {
            if (string.IsNullOrEmpty(note))
                return DateTime.MinValue;

            var dateString = note.Substring(28);
            return DateTime.ParseExact(dateString, "dd/MM/yy", CultureInfo.InvariantCulture);
        }

        public static bool IsPaid(string note)
        {
            return (note.Contains("PAID TOTAL"));
        }

        public static bool IsCancellationRecord(IList<object> record)
        {
            if (record.Count > 3 && record[3].ToString() == "Y")
                return true;

            return false;
        }
    }
}