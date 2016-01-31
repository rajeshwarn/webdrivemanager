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
    public class DriveFolderSynchronizerFactory : IFolderSynchronizerFactory
    {
        private readonly IFilesGetterFactory driveFileGetterFactory;

        private readonly IFileDownloader driveFileDownloader;

        public DriveFolderSynchronizerFactory(IFilesGetterFactory driveFileGetterFactory, IFileDownloader driveFileDownloader)
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