// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoogleDriveModule.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the GoogleDriveModule type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.GoogleDrive
{
    using Ninject.Modules;

    using WebDriveManager.ServiceInterfaces;

    public class GoogleDriveModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IAuthenticator>().To<Authenticator>();
            this.Bind<IFilesGetter>().To<FilesGetter>();
            this.Bind<IFilesGetterFactory>().To<DriveFilesGetterFactory>();
            this.Bind<IFolderSynchronizerFactory>().To<DriveFolderSynchronizerFactory>();
            this.Bind<IFolderSynchronizer>().To<FolderSynchronizer>();
            this.Bind<IFileDownloader>().To<FileDownloader>();
            this.Bind<IWebDriveAccount>().To<GoogleDriveAccount>();
        }
    }
}