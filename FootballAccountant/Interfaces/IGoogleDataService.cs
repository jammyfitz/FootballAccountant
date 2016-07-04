using System.Collections.Generic;

namespace FootballAccountant.Interfaces
{
    public interface IGoogleDataService
    {
        IList<IList<object>> GetSpreadsheetData();
    }
}
