using FootballAccountant.Models;
using FootballAccountant.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballAccountant.Helpers
{
    public static class MailHelper
    {
        public static string GetFromAddress()
        {
            return Resources.MasterEmailAddress;
        }

        public static string GetToAddress()
        {
            return Resources.MasterEmailAddress;
        }

        public static string GetSubject()
        {
            return DateTime.Now.ToString("yyyy-MM-dd") + " - Football Accountant";
        }

        public static string GetBody(Payment duePayment, IList<Cancellation> dueCancellations)
        {
            StringBuilder body = new StringBuilder("***Football Accountant v1.0***\n\n");

            BuildPaymentText(duePayment, body);

            BuildCancellationText(dueCancellations, body);

            return body.ToString();
        }

        private static void BuildPaymentText(Payment duePayment, StringBuilder body)
        {
            if (duePayment != null)
            {
                body.AppendFormat(Resources.DuePaymentText, duePayment.Total, duePayment.From, duePayment.To);
            }

            body.AppendLine(Resources.NoDuePayment);
        }

        private static void BuildCancellationText(IList<Cancellation> dueCancellations, StringBuilder body)
        {
            if(!dueCancellations.Any())
            {
                body.AppendLine(Resources.NoDueCancellation);
                return;
            }

            foreach(var cancellation in dueCancellations)
            {
                body.AppendFormat(Resources.DueCancellationText, cancellation.Cost, cancellation.Date);
            }
        }
    }
}