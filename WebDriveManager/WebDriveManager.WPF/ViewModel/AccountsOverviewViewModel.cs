// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountsOverviewViewModel.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the AccountsOverviewViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.WPF.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Input;

    using Appccelerate.EventBroker;
    using Appccelerate.EventBroker.Handlers;

    using WebDriveManager.Core;
    using WebDriveManager.WPF.Helper;

    public class AccountsOverviewViewModel : ViewModelBase
    {
        private readonly EventBroker eventBroker;

        private readonly AccountManager accountManager;

         public AccountsOverviewViewModel(
            EventBroker eventBroker,
            AccountManager accountManager)
        {
             this.eventBroker = eventBroker;
             this.eventBroker.Register(this);
             this.accountManager = accountManager;
             this.AddAccountCommand = new RelayCommand(this.SwitchToAddAccoutView);
        }

        public IEnumerable<IReadOnlyWebDriveAccount> RegisteredWebDriveAccounts
        {
            get
            {
                return this.accountManager.Accounts;
            }
        }

        public ICommand AddAccountCommand { get; private set; }

        [EventSubscription(EventTopics.AccountAdded, typeof(OnPublisher))]
        public void WhenAccountAdded(object sender, EventArgs e)
        {
            this.OnPropertyChanged("RegisteredWebDriveAccounts");
        }

        private void SwitchToAddAccoutView()
        {
            this.eventBroker.Fire(
                EventTopics.SwitchToAddAcountView,
                this,
                HandlerRestriction.Synchronous,
                this,
                new EventArgs());
        }
    }
}