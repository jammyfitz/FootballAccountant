using FootballAccountant.Models;

namespace FootballAccountant.Interfaces
{
    public interface IFootballEmailService
    {
        void SendEmail(Payment paymentRecord);
    }
}
