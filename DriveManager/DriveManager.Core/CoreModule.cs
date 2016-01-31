// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoreModule.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the CoreModule type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DriveManager.Core
{
    using Ninject.Modules;

    public class CoreModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IAuthenticator>().To<Authenticator>();
            this.Bind<IFilesGetter>().To<FilesGetter>();
            this.Bind<IFilesGetterFactory>().To<DriveFilesGetterFactory>();
            this.Bind<IFolderSynchronizerFactory>().To<DriveFolderSynchronizerFactory>();
            this.Bind<IFolderSynchronizer>().To<FolderSynchronizer>();
            this.Bind<IFileDownloader>().To<DriveFileDownloader>();
        }
    }
}