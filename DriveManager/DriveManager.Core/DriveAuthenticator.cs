namespace DriveManager.Core
{
    using System;
    using System.IO;
    using System.Threading;
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Drive.v2;
    using Google.Apis.Util.Store;

    public class DriveAuthenticator
    {
        private static readonly string[] Scopes = { DriveService.Scope.DriveReadonly };
        private static string applicationName = "DriveManager";
        private UserCredential credential;

        public DriveAuthenticator()
        {
            this.IsAuthenticated = false;
        }

        public void Authenticate()
        {
            using (var stream = new FileStream("client_id.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/drive-dotnet-quickstart");

                this.credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }
        }

        public bool IsAuthenticated { get; private set; }
    }
}