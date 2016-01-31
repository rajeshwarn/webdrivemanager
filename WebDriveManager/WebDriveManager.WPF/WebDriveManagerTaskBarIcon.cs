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

    using Hardcodet.Wpf.TaskbarNotification;

    using WebDriveManager.WPF.Properties;

    public class WebDriveManagerTaskBarIcon
    {
        private readonly TaskbarIcon taskbarIcon;

        private readonly AddAccountCommand addAccountCommand;

        public WebDriveManagerTaskBarIcon(TaskbarIcon taskbarIcon, AddAccountCommand addAccountCommand)
        {
            this.taskbarIcon = taskbarIcon;
            this.addAccountCommand = addAccountCommand;
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
            PopUpViewModel viewModel = new PopUpViewModel(this.addAccountCommand);
            view.DataContext = viewModel;
            return view;
        }
    }
}