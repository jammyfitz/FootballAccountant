using FootballAccountant.Models;
using FootballAccountant.Properties;
using System;
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

        public static string GetBody(Payment duePayment)
        {
            StringBuilder body = new StringBuilder("***Football Accountant v1.0***\n\n");

            if(duePayment != null)
            {
                body.AppendFormat(Resources.DuePaymentText, duePayment.Total, duePayment.From, duePayment.To);
            }

            body.AppendLine(Resources.NoDuePayment);

            return body.ToString();
        }
    }
}