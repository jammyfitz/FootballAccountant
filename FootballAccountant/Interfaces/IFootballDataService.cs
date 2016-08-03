using FootballAccountant.Models;
using System.Collections.Generic;

namespace FootballAccountant.Interfaces
{
    public interface IFootballDataService
    {
        IList<Charge> GetCharges();
        IList<Payment> GetPayments();
        Payment GetDuePayment();
    }
}
