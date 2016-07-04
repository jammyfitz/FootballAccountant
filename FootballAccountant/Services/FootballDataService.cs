using System.Collections.Generic;
using FootballAccountant.Models;
using FootballAccountant.Interfaces;
using FootballAccountant.Helpers;

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
    }
}