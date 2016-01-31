// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DriveAccount.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the DriveAccount type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DriveManager.Core
{
    using System.Collections.Generic;

    public class DriveAccount
    {
        private readonly IDriveAuthenticator driveAuthenticator;

        private readonly IDriveFilesGetter driveFilesGetter;

        private readonly IDriveFolderSynchronizer driveFolderSynchronizer;

        public DriveAccount(
            string username,
            string rootFolderPath,
            IDriveAuthenticator driveAuthenticator,
            IDriveFilesGetterFactory driveFilesGetterFactory,
            IDriveFolderSynchronizerFactory driveFolderSynchronizerFactory)
        {
            this.Username = username;
            this.driveAuthenticator = driveAuthenticator;
            this.RootFolderPath = rootFolderPath;
            DriveServiceProvider driveServiceProvider = new DriveServiceProvider(this.driveAuthenticator);
            this.driveFilesGetter = driveFilesGetterFactory.Create();
            this.driveFolderSynchronizer = driveFolderSynchronizerFactory.Create();
        }

        public string Username { get; private set; }

        /// <summary>
        /// Folders in the root directory
        /// </summary>
        public IEnumerable<DriveFile> Folders { get; private set; }

        public string RootFolderPath { get; private set; }

        public bool IsAuthenticated
        {
            get
            {
                return this.driveAuthenticator.IsAuthenticated;
            }
        }

        public void UpdateAccount()
        {
            this.driveAuthenticator.Authenticate(this.Username);
            this.Folders = this.driveFilesGetter.GetDriveFiles(DriveConstants.FolderMimeType);

            foreach (var driveFile in this.Folders)
            {
                this.driveFolderSynchronizer.SynchronizeFolder(driveFile, this.RootFolderPath);
            }
        }
    }
}