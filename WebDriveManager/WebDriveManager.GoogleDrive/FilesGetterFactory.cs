// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DriveFilesGetterFactory.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the DriveFilesGetterFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.GoogleDrive
{
    public class DriveFilesGetterFactory : IFilesGetterFactory
    {
        private readonly GoogleDriveServiceProvider googleDriveServiceProvider;

        public DriveFilesGetterFactory(GoogleDriveServiceProvider googleDriveServiceProvider)
        {
            this.googleDriveServiceProvider = googleDriveServiceProvider;
        }

        public IFilesGetter Create()
        {
            return new FilesGetter(this.googleDriveServiceProvider);
        }
    }
}