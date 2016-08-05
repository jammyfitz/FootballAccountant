using System;

namespace FootballAccountant.Models
{
    public class Cancellation
    {
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
        public bool Unclaimed { get; set; }
        public bool Unsettled { get; set; }
    }
}