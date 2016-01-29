// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DriveServiceProvider.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the DriveServiceProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DriveManager.Core
{
    using Google.Apis.Drive.v2;
    using Google.Apis.Services;

    public class DriveServiceProvider
    {
        private static string applicationName = "DriveManager";

        private readonly DriveAuthenticator driveAuthenticator;

        public DriveServiceProvider(DriveAuthenticator driveAuthenticator)
        {
            this.driveAuthenticator = driveAuthenticator;
        }

        public DriveService GetService()
        {
            return new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = this.driveAuthenticator.Credential,
                ApplicationName = applicationName,
            });
        }
    }
}