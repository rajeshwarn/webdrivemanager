// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceInterfaceModule.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the ServiceInterfaceModule type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.ServiceInterfaces
{
    using Ninject;
    using Ninject.Modules;

    public class ServiceInterfaceModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Load("WebDriveManager.GoogleDrive.dll");
        }
    }
}