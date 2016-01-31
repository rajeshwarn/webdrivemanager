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

    public class PopUpViewModel : ViewModelBase
    {
        private readonly AccountsOverviewViewModel accountsOverviewViewModel;

        private readonly AddAcountViewModel addAcountViewModel;

        public PopUpViewModel(
            AccountsOverviewViewModel accountsOverviewViewModel,
            AddAcountViewModel addAcountViewModel,
            EventBroker eventBroker)
        {
            eventBroker.Register(this);
            this.accountsOverviewViewModel = accountsOverviewViewModel;
            this.addAcountViewModel = addAcountViewModel;

            this.SetViewContent(this.accountsOverviewViewModel);
        }

        public ViewModelBase ViewContent { get; private set; }

        [EventSubscription(EventTopics.SwitchToAddAcountView, typeof(OnPublisher))]
        public void SwitchToAddAccountView(object sender, EventArgs e)
        {
            this.SetViewContent(this.addAcountViewModel);
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