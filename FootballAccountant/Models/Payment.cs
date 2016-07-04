using System;

namespace FootballAccountant.Models
{
    public class Payment
    {
        public DateTime DatePaid { get; set; }
        public decimal Total { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool IsPaid { get; set; }
    }
}