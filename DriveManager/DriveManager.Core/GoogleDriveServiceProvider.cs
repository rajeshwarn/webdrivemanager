// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoogleDriveServiceProvider.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the GoogleDriveServiceProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DriveManager.Core
{
    using Google.Apis.Drive.v2;
    using Google.Apis.Services;

    public class GoogleDriveServiceProvider
    {
        private static string applicationName = "DriveManager";

        private readonly IAuthenticator authenticator;

        public GoogleDriveServiceProvider(IAuthenticator authenticator)
        {
            this.authenticator = authenticator;
        }

        public DriveService GetService()
        {
            return new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = this.authenticator.Credential,
                ApplicationName = applicationName,
            });
        }
    }
}