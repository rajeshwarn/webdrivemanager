// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebDriveManagerTaskBarIcon.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the WebDriveManagerTaskBarIcon type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.WPF
{
    using System.Drawing;
    using System.Windows;

    using Appccelerate.EventBroker;

    using Hardcodet.Wpf.TaskbarNotification;

    using WebDriveManager.Core;
    using WebDriveManager.WPF.Properties;
    using WebDriveManager.WPF.View;
    using WebDriveManager.WPF.ViewModel;

    public class WebDriveManagerTaskBarIcon
    {
        private readonly TaskbarIcon taskbarIcon;

        private readonly AccountsOverviewViewModel accountsOverviewViewModel;

        private readonly AddAccountDialogViewModel addAccountDialogViewModel;

        private readonly EventBroker eventBroker;

        public WebDriveManagerTaskBarIcon(
            TaskbarIcon taskbarIcon,
            AccountsOverviewViewModel accountsOverviewViewModel,
            AddAccountDialogViewModel addAccountDialogViewModel, 
            EventBroker eventBroker)
        {
            this.taskbarIcon = taskbarIcon;
            this.accountsOverviewViewModel = accountsOverviewViewModel;
            this.addAccountDialogViewModel = addAccountDialogViewModel;
            this.eventBroker = eventBroker;
            this.taskbarIcon.TrayMiddleMouseDown += (sender, args) => Application.Current.Shutdown();
            this.taskbarIcon.TrayPopupOpen += (sender, args) => this.taskbarIcon.TrayPopup.SetValue(UIElement.VisibilityProperty, Visibility.Visible);
            this.taskbarIcon.TrayPopup = this.CreatePopup();
            ////this.taskbarIcon.TrayToolTip = this.CreateToolTip(gameClient);
            this.taskbarIcon.ToolTip = "WebDriveManager";
            this.taskbarIcon.Icon = Resources.webdrivemanager;
        }

        private UIElement CreatePopup()
        {
            PopUpView view = new PopUpView();
            PopUpViewModel viewModel = new PopUpViewModel(
                this.accountsOverviewViewModel,
                this.addAccountDialogViewModel,
                this.eventBroker);
            view.DataContext = viewModel;
            return view;
        }
    }
}