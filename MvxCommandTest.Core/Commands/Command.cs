using System;
using System.Windows.Input;
using MvvmCross.Platform;

namespace MvxCommandTest.Core.Commands
{
    public interface ICommandHelper
    {
        bool HasCanExecuteFunction { get; set; }

        event EventHandler CanExecuteChanged;
        void RaiseCanExecuteChanged();
    }

    public class Command : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        private readonly ICommandHelper _commandHelper;

        protected Command()
        {
            _commandHelper = Mvx.Resolve<ICommandHelper>();
        }

        public Command(Action execute)
            : this()
        {
            _execute = execute;
        }

        public Command(Action execute, Func<bool> canExecute)
            : this()
        {
            _execute = execute;
            _canExecute = canExecute;
            _commandHelper.HasCanExecuteFunction = _canExecute != null;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                _commandHelper.CanExecuteChanged += value;
            }
            remove
            {
                _commandHelper.CanExecuteChanged -= value;
            }
        }

        public virtual void RaiseCanExecuteChanged()
        {
            _commandHelper.RaiseCanExecuteChanged();
        }
    }
}