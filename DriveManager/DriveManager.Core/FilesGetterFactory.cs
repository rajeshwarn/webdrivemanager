// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DriveFilesGetterFactory.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the DriveFilesGetterFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DriveManager.Core
{
    public class DriveFilesGetterFactory : IDriveFilesGetterFactory
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