using FootballAccountant.Classes;
using FootballAccountant.Models;
using System.Net.Mail;

namespace FootballAccountant.Interfaces
{
    public interface IMailer
    {
        MailMessage CreateMail(Payment duePayment);
        bool SendMail(Payment duePayment);
    }
}
