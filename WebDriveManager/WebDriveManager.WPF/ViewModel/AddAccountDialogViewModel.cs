// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddAccountDialogViewModel.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the AddAccountDialogViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.WPF.ViewModel
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Windows.Input;

    using Appccelerate.EventBroker;

    using WebDriveManager.Core;
    using WebDriveManager.WPF.Helper;

    using Application = System.Windows.Application;

    public class AddAccountDialogViewModel : ViewModelBase
    {
        private readonly AccountManager accountManager;

        private readonly EventBroker eventBroker;

        public AddAccountDialogViewModel(
            AccountManager accountManager, 
            EventBroker eventBroker)
        {
            this.accountManager = accountManager;
            this.eventBroker = eventBroker;
            this.BrowseCommand = new RelayCommand(this.Browse, () => true);
            this.AddAccountCommand = new RelayCommand(
                this.AddAccount, 
                () => this.Username != string.Empty 
                   && this.RootFolderPath != string.Empty);
        }

        public string Username { get; set; }

        public string RootFolderPath { get; set; }

        public ICommand BrowseCommand { get; private set; }

        public ICommand AddAccountCommand { get; private set; }

        private void AddAccount()
        {
            this.accountManager.AddAccount(this.Username, this.RootFolderPath);
            this.FireEventBrokerEvent(EventTopics.AccountAdded);
            this.FireEventBrokerEvent(EventTopics.SwitchToAcountoverview);
        }

        private void FireEventBrokerEvent(string topic)
        {
            this.eventBroker.Fire(topic, this, HandlerRestriction.Synchronous, this, new EventArgs());
        }

        private void Browse()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                        
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.RootFolderPath = folderBrowserDialog.SelectedPath;
                this.OnPropertyChanged("RootFolderPath");
            }
        }
    }
}