// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddAccountCommand.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the AddAccountCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.WPF
{
    using System;
    using System.Windows.Input;

    using WebDriveManager.Core;

    public class AddAccountCommand : ICommand
    {
        private readonly AccountManager accountManager;

        public AddAccountCommand(AccountManager accountManager)
        {
            this.accountManager = accountManager;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            AddAccountDialog dialog = new AddAccountDialog();
            dialog.ShowDialog();

            if (dialog.DialogResult == true)
            {
                this.accountManager.AddAccount(dialog.Username, dialog.RootFolderPath);
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}