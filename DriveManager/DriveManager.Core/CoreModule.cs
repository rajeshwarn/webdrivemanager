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
            this.Bind<IDriveAuthenticator>().To<DriveAuthenticator>();
            this.Bind<IDriveFilesGetter>().To<DriveFilesGetter>();
            this.Bind<IDriveFilesGetterFactory>().To<DriveFilesGetterFactory>();
            this.Bind<IDriveFolderSynchronizerFactory>().To<DriveFolderSynchronizerFactory>();
            this.Bind<IDriveFolderSynchronizer>().To<DriveFolderSynchronizer>();
            this.Bind<IDriveFileDownloader>().To<DriveFileDownloader>();
        }
    }
}