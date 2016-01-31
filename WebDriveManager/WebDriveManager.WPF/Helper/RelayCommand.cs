// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelayCommand.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the RelayCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.WPF.Helper
{
    using System;
    using System.Windows.Input;

    public class RelayCommand : ICommand
    {
        private readonly Action methodToExecute;

        private readonly Func<bool> canExecuteEvaluator;

        public RelayCommand(Action methodToExecute)
            : this(methodToExecute, null)
        {
        }

        public RelayCommand(Action methodToExecute, Func<bool> canExecuteEvaluator)
        {
            this.methodToExecute = methodToExecute;
            this.canExecuteEvaluator = canExecuteEvaluator;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            this.methodToExecute.Invoke();
        }

        public bool CanExecute(object parameter)
        {
            if (this.canExecuteEvaluator == null)
            {
                return true;
            }
            else
            {
                bool result = this.canExecuteEvaluator.Invoke();
                return result;
            }
        }
    }
}