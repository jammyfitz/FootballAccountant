﻿using System.Collections.Generic;
using FootballAccountant.Models;
using FootballAccountant.Interfaces;
using FootballAccountant.Helpers;
using System.Linq;

namespace FootballAccountant.Services
{
    public class FootballDataService : IFootballDataService
    {
        private IGoogleDataService _googleDataService;

        public FootballDataService(IGoogleDataService googleDataService)
        {
            _googleDataService = googleDataService;
        }

        public FootballDataService()
        {
            _googleDataService = new GoogleDataService();
        }

        public IList<Charge> GetCharges()
        {
            var data = _googleDataService.GetSpreadsheetData();
            var charges = ChargeHelper.MapToCharges(data);
            return charges;
        }

        public IList<Payment> GetPayments()
        {
            var data = _googleDataService.GetSpreadsheetData();
            var payments = PaymentHelper.MapToPayments(data);
            return payments;
        }

        public IList<Cancellation> GetUnclaimedCancellations()
        {
            var data = _googleDataService.GetSpreadsheetData();
            var cancellations = CancellationHelper.MapToCancellations(data);
            return cancellations.Where(x => x.Unclaimed).ToList();
        }

        public IList<Cancellation> GetUnsettledCancellations()
        {
            var data = _googleDataService.GetSpreadsheetData();
            var cancellations = CancellationHelper.MapToCancellations(data);
            return cancellations.Where(x => x.Unsettled).ToList();
        }

        public Payment GetDuePayment()
        {
            var data = _googleDataService.GetSpreadsheetData();
            var duePayment = PaymentHelper.GetDuePayment(data);
            return duePayment;
        }
    }
}