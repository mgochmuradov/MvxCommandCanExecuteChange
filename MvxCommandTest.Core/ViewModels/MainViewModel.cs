using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace MvxCommandTest.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private bool _allowExecution;
        public bool AllowExecution
        {
            get { return _allowExecution; }
            set { SetProperty(ref _allowExecution, value); }
        }

        public ICommand DoWorkCommand =>
            new MvxCommand(() =>
            {
                AllowExecution = false;
            });

        public ICommand DoAsyncWorkCommand =>
            new MvxAsyncCommand(() =>
            {
                AllowExecution = false;
                return Task.FromResult(true);
            });
    }
}