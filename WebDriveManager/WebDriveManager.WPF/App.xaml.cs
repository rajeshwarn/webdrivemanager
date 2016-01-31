// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Interaction logic for App.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.WPF
{
    using System.Windows;

    using Ninject;

    using WebDriveManager.Core;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            IKernel kernel = new StandardKernel(new CoreModule(), new UserInterfaceModule());

            var webDriveManagerTaskBarIcon = kernel.Get<WebDriveManagerTaskBarIcon>();
        }
    }
}
