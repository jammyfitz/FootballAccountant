using FootballAccountant.Interfaces;
using FootballAccountant.Models;
using FootballAccountant.Classes;
using FootballAccountant.Properties;

namespace FootballAccountant.Services
{
    public class FootballEmailService : IFootballEmailService
    {
        IMailer _mailer;
        SmtpData _smtpData;

        public FootballEmailService()
        {
            _smtpData = InitialiseSmtpData();
            _mailer = new Mailer(_smtpData);
        }

        public FootballEmailService(IMailer mailer)
        {
            _mailer = mailer;
        }

        public void SendEmail(Payment paymentRecord)
        {
            _mailer.SendMail(paymentRecord);
        }

        private SmtpData InitialiseSmtpData()
        {
            return new SmtpData
            {
                AgentSine = Resources.SmtpAgentSine,
                AgentDutyCode = GetDecryptedAgentDutyCode(Resources.SmtpAgentDutyCode),
                Host = Resources.SmtpServer,
                Port = Resources.SmtpPort
            };
        }

        private string GetDecryptedAgentDutyCode(string agentDutyCode)
        {
            return Decrypt(agentDutyCode);
        }

        private string Decrypt(string inputString)
        {
            return StringCipherService.Decrypt(inputString, Resources.PassPhrase);
        }
    }
}