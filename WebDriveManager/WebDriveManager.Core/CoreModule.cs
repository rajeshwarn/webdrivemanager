// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoreModule.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the CoreModule type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.Core
{
    using Ninject;
    using Ninject.Modules;

    public class CoreModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Load("WebDriveManager.GoogleDrive.dll");

            this.Bind<AccountManager>().ToSelf().InSingletonScope();
        }
    }
}