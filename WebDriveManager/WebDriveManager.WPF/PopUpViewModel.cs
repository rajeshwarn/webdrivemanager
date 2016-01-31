// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PopUpViewModel.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the PopUpViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.WPF
{
    using System.Collections.Generic;
    using System.Windows.Documents;
    using System.Windows.Input;

    using WebDriveManager.Core;

    public class PopUpViewModel
    {
        public PopUpViewModel(AddAccountCommand addAccountCommand)
        {
            this.AddAccountCommand = addAccountCommand;
            this.RegisteredWebDriveAccounts = new List<IWebDriveAccount>();
        }

        public List<IWebDriveAccount> RegisteredWebDriveAccounts { get; private set; }

        public ICommand AddAccountCommand { get; private set; }
    }
}