using FootballAccountant.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Google.Apis.Util.Store;

namespace FootballAccountant.Services
{
    public class GoogleDataService : IGoogleDataService
    {
        string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        string ApplicationName = "Google Sheets API .NET Quickstart";

        UserCredential credential;

        public IList<IList<object>> GetSpreadsheetData()
        {
            using (var stream = new FileStream(@"C:\sandbox\FootballAccountant\FootballAccountant\Resources\client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/sheets.googleapis.com-dotnet-quickstart.json");

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
                ApplicationName = ApplicationName,
            });

            string spreadsheetId = "1Y1QyPzAo58oKZKQrp0LXY2nAknxWeLXmaOE9tYoGsh4";
            string range = "Current";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);

            // https://docs.google.com/spreadsheets/d/1Y1QyPzAo58oKZKQrp0LXY2nAknxWeLXmaOE9tYoGsh4/pubhtml
            ValueRange response = request.Execute();
            IList<IList<object>> values = response.Values;

            return values;
        }
    }
}