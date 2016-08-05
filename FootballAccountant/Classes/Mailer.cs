using FootballAccountant.Helpers;
using FootballAccountant.Interfaces;
using FootballAccountant.Models;
using System.Collections.Generic;
using System.Net.Mail;

namespace FootballAccountant.Classes
{
    public class Mailer : IMailer
    {
        SmtpData _smtpData;

        public Mailer(SmtpData smtpData)
        {
            _smtpData = smtpData;
        }

        public bool SendMail(Payment duePayment, IList<Cancellation> unclaimedCancellations, IList<Cancellation> unsettledCancellations)
        {
            var mail = CreateMail(duePayment, unclaimedCancellations, unsettledCancellations);

            SmtpClient SmtpServer = new SmtpClient(_smtpData.Host);
            SmtpServer.Port = int.Parse(_smtpData.Port);
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential(_smtpData.AgentSine, _smtpData.AgentDutyCode);
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            return true;
        }

        public MailMessage CreateMail(Payment duePayment, IList<Cancellation> unclaimedCancellations, IList<Cancellation> unsettledCancellations)
        {
            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(MailHelper.GetFromAddress()),
                Subject = MailHelper.GetSubject(),
                Body = MailHelper.GetBody(duePayment, unclaimedCancellations, unsettledCancellations)
            };

            mail.To.Add(MailHelper.GetToAddress());

            return mail;
        }
    }
}
