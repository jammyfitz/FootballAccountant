using FootballAccountant.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
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
        private readonly string googleUser = Resources.GoogleUser;

        public IList<IList<object>> GetSpreadsheetData()
        {
            var credential = InitialiseCredentials();
            var service = InitialiseSheetsService(credential);

            var request = service.Spreadsheets.Values.Get(spreadsheetId, spreadsheetRange);

            var response = request.Execute();

            return response.Values;
        }

        #region Private
        private UserCredential InitialiseCredentials()
        {
            UserCredential credentials;

            using (var stream = new FileStream(secretPath, FileMode.Open, FileAccess.Read))
            {
                credentials = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    googleUser,
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            return credentials;
        }

        private SheetsService InitialiseSheetsService(UserCredential credentials)
        {
            return new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentials,
                ApplicationName = Resources.ApplicationName,
            });
        }

        #endregion
    }
}