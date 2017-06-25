using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvxCommandTest.Core.Commands;

namespace MvxCommandTest.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private bool _allowExecution;
        public bool AllowExecution
        {
            get { return _allowExecution; }
            set
            {
                SetProperty(ref _allowExecution, value);
                ((Command)DoWorkCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand DoWorkCommand =>
            new Command(DoWork, () => AllowExecution);
        private void DoWork()
        {
            AllowExecution = false;
        }
    }
}