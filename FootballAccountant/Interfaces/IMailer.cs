using FootballAccountant.Classes;
using FootballAccountant.Models;
using System.Collections.Generic;
using System.Net.Mail;

namespace FootballAccountant.Interfaces
{
    public interface IMailer
    {
        MailMessage CreateMail(Payment duePayment, IList<Cancellation> dueCancellations);
        bool SendMail(Payment duePayment, IList<Cancellation> dueCancellations);
    }
}
