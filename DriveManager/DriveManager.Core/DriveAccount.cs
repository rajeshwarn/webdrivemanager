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
        private readonly DriveAuthenticator driveAuthenticator;

        private readonly DriveFilesGetter driveFilesGetter;

        private readonly DriveFolderSynchronizer driveFolderSynchronizer;

        public DriveAccount(
            string username,
            string rootFolderPath,
            DriveAuthenticator driveAuthenticator)
        {
            this.Username = username;
            this.driveAuthenticator = driveAuthenticator;
            this.RootFolderPath = rootFolderPath;
            DriveServiceProvider driveServiceProvider = new DriveServiceProvider(new DriveAuthenticator());
            this.driveFilesGetter = new DriveFilesGetter(driveServiceProvider);
            this.driveFolderSynchronizer = new DriveFolderSynchronizer(
                this.driveFilesGetter, 
                new DriveFileDownloader(driveServiceProvider));
        }

        public string Username { get; private set; }

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