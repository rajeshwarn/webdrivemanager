// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoogleDriveAccount.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the GoogleDriveAccount type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.GoogleDrive
{
    using System.Collections.Generic;

    using WebDriveManager.ServiceInterfaces;

    public class GoogleDriveAccount : IWebDriveAccount
    {
        private readonly IAuthenticator driveAuthenticator;

        private readonly IFilesGetter driveFilesGetter;

        private readonly IFolderSynchronizer driveFolderSynchronizer;

        public GoogleDriveAccount(
            string username,
            string rootFolderPath,
            IAuthenticator driveAuthenticator,
            IFilesGetterFactory driveFilesGetterFactory,
            IFolderSynchronizerFactory driveFolderSynchronizerFactory)
        {
            this.Username = username;
            this.driveAuthenticator = driveAuthenticator;
            this.RootFolderPath = rootFolderPath;
            this.driveFilesGetter = driveFilesGetterFactory.Create();
            this.driveFolderSynchronizer = driveFolderSynchronizerFactory.Create();
        }

        public string Username { get; private set; }

        /// <summary>
        /// Folders in the root directory
        /// </summary>
        public IEnumerable<GoogleDriveFile> Folders { get; private set; }

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
            this.Folders = this.driveFilesGetter.GetDriveFiles(GoogleDriveConstants.FolderMimeType);

            foreach (var driveFile in this.Folders)
            {
                this.driveFolderSynchronizer.SynchronizeFolder(driveFile, this.RootFolderPath);
            }
        }
    }
}