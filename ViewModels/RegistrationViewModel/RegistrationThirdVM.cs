using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kozyrev_Hriha_SP.ViewModels.RegistrationViewModel
{
    public class RegistrationThirdVM : ViewModelBase
    {
        private string _email;
        private SecureString _password;
        private bool isLoggingIn;
        private string _errorMessage;


        public ICommand FinishCommand { get; }
        public ICommand BackCommand { get; }
        

        public RegistrationThirdVM(Action<object> finish, Action<object> back)
        {
            FinishCommand = new ViewModelCommand(finish, CanExecuteNextCommand);
            BackCommand = new ViewModelCommand(back);
        }
        public bool IsLoggingIn
        {
            get { return isLoggingIn; }
            set
            {
                if (isLoggingIn != value)
                {
                    isLoggingIn = value;
                    OnPropertyChanged(nameof(IsLoggingIn));
                }
            }
        }
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }

            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public SecureString Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        private bool CanExecuteNextCommand(object obj)
        {
            return !string.IsNullOrEmpty(Email) &&
               Password!=null && Password.Length > 0;
        }
    }
}
