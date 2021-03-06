﻿using FootballAccountant.Interfaces;
using FootballAccountant.Models;
using FootballAccountant.Classes;
using FootballAccountant.Properties;
using System.Collections.Generic;

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

        public void SendEmail(Payment paymentRecord, IList<Cancellation> unclaimedCancellationRecords, IList<Cancellation> unsettledCancellationRecords)
        {
            _mailer.SendMail(paymentRecord, unclaimedCancellationRecords, unsettledCancellationRecords);
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