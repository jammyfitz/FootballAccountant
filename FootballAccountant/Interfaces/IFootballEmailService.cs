using FootballAccountant.Models;
using System.Collections.Generic;

namespace FootballAccountant.Interfaces
{
    public interface IFootballEmailService
    {
        void SendEmail(Payment paymentRecord, IList<Cancellation> cancellationRecords);
    }
}
