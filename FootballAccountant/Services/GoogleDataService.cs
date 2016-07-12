using FootballAccountant.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Google.Apis.Util.Store;
using FootballAccountant.Properties;

namespace FootballAccountant.Services
{
    public class GoogleDataService : IGoogleDataService
    {
        private string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        private readonly string secretPath = Resources.WorkingDir + Resources.GoogleSecretPath;
        private readonly string credPath = Resources.WorkingDir + Resources.GoogleCredPath;
        private readonly string spreadsheetId = Resources.SpreadsheetId;
        private readonly string spreadsheetRange = Resources.SpreadsheetRange;

        UserCredential credential;

        public IList<IList<object>> GetSpreadsheetData()
        {
            using (var stream = new FileStream(secretPath, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "jammyfitz",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = Resources.ApplicationName,
            });

            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, spreadsheetRange);

            // https://docs.google.com/spreadsheets/d/1Y1QyPzAo58oKZKQrp0LXY2nAknxWeLXmaOE9tYoGsh4/pubhtml
            ValueRange response = request.Execute();
            IList<IList<object>> values = response.Values;

            return values;
        }
    }
}