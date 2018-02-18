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

        public static string GetBody(Payment duePayment, IList<Cancellation> unclaimedCancellations, IList<Cancellation> unsettledCancellations)
        {
            StringBuilder body = new StringBuilder("***Football Accountant v1.0***\n\n");

            BuildPaymentText(duePayment, body);

            BuildUnclaimedCancellationText(unclaimedCancellations, body);

            BuildUnsettledCancellationText(unsettledCancellations, body);

            return body.ToString();
        }

        private static void BuildPaymentText(Payment duePayment, StringBuilder body)
        {
            if (duePayment != null)
            {
                body.AppendFormat(Resources.DuePaymentText, duePayment.Total, duePayment.From, duePayment.To).Append("\n");

            }
            else
            {
                body.AppendLine(Resources.NoDuePayment);
            }

            body.AppendLine();
        }

        private static void BuildUnclaimedCancellationText(IList<Cancellation> unclaimedCancellations, StringBuilder body)
        {
            if(!unclaimedCancellations.Any())
            {
                body.AppendLine(Resources.NoDueCancellation);
                return;
            }

            foreach(var cancellation in unclaimedCancellations)
            {
                body.AppendFormat(Resources.DueCancellationText, cancellation.Cost, cancellation.Date).Append("\n");
            }

            body.AppendLine();
        }

        private static void BuildUnsettledCancellationText(IList<Cancellation> unsettledCancellations, StringBuilder body)
        {
            if (!unsettledCancellations.Any())
            {
                body.AppendLine(Resources.NoUnsettledCancellations);
                return;
            }

            foreach (var cancellation in unsettledCancellations)
            {
                body.AppendFormat(Resources.UnsettledCancellationText, cancellation.Cost, cancellation.Date).Append("\n");
            }

            body.AppendLine();
        }
    }
}