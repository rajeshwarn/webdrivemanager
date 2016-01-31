// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserInterfaceModule.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the UserInterfaceModule type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.WPF
{
    using System;

    using Appccelerate.EventBroker;

    using Ninject.Modules;

    public class UserInterfaceModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<EventBroker>().ToSelf().InSingletonScope();
        }
    }
}