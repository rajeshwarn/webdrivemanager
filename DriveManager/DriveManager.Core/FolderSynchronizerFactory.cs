// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DriveFolderSynchronizerFactory.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the DriveFolderSynchronizerFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DriveManager.Core
{
    public class DriveFolderSynchronizerFactory : IDriveFolderSynchronizerFactory
    {
        private readonly IDriveFilesGetterFactory driveFileGetterFactory;

        private readonly IDriveFileDownloader driveFileDownloader;

        public DriveFolderSynchronizerFactory(IDriveFilesGetterFactory driveFileGetterFactory, IDriveFileDownloader driveFileDownloader)
        {
            this.driveFileGetterFactory = driveFileGetterFactory;
            this.driveFileDownloader = driveFileDownloader;
        }

        public IFolderSynchronizer Create()
        {
            return new FolderSynchronizer(
                this.driveFileGetterFactory.Create(),
                this.driveFileDownloader);
        }
    }
}