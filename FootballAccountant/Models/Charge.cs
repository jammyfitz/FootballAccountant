using System;
using System.ComponentModel.DataAnnotations;

namespace FootballAccountant.Models
{
    public class Charge
    {
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
        public string Notes { get; set; }
    }
}