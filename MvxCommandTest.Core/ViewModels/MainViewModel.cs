using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

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
                DoWorkCommand.RaiseCanExecuteChanged();
                DoAsyncWorkCommand.RaiseCanExecuteChanged();
            }
        }

        public IMvxCommand DoWorkCommand =>
            new MvxCommand(DoWork, () => AllowExecution);
        private void DoWork()
        {
            // Work logic here
        }

        public IMvxAsyncCommand DoAsyncWorkCommand =>
            new MvxAsyncCommand(DoAsyncWorkAsync, () => AllowExecution);
        private Task DoAsyncWorkAsync()
        {
            // Async work logic here
            return Task.FromResult(true);
        }
    }
}