// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PopUpViewModel.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the PopUpViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.WPF.ViewModel
{
    using System;

    using Appccelerate.EventBroker;
    using Appccelerate.EventBroker.Handlers;

    using WebDriveManager.WPF.View;

    public class PopUpViewModel : ViewModelBase
    {
        private readonly AccountsOverviewViewModel accountsOverviewViewModel;

        private readonly AddAccountDialogViewModel addAccountDialogViewModel;

        public PopUpViewModel(
            AccountsOverviewViewModel accountsOverviewViewModel,
            AddAccountDialogViewModel addAccountDialogViewModel,
            EventBroker eventBroker)
        {
            eventBroker.Register(this);
            this.accountsOverviewViewModel = accountsOverviewViewModel;
            this.addAccountDialogViewModel = addAccountDialogViewModel;

            this.SetViewContent(this.accountsOverviewViewModel);
        }

        public ViewModelBase ViewContent { get; private set; }

        [EventSubscription(EventTopics.SwitchToAddAcountView, typeof(OnPublisher))]
        public void SwitchToAddAccountView(object sender, EventArgs e)
        {
            AddAccountDialogView dialog = new AddAccountDialogView { DataContext = this.addAccountDialogViewModel };
            dialog.ShowDialog();
        }

        [EventSubscription(EventTopics.SwitchToAcountoverview, typeof(OnPublisher))]
        public void SwitchToAcountoverview(object sender, EventArgs e)
        {
            this.SetViewContent(this.accountsOverviewViewModel);
        }

        private void SetViewContent(ViewModelBase viewModelBase)
        {
            this.ViewContent = viewModelBase;
            this.OnPropertyChanged("ViewContent");
        }
    }
}