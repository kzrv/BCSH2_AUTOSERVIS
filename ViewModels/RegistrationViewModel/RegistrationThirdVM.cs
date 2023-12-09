using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kozyrev_Hriha_SP.ViewModels.RegistrationViewModel
{
    public class RegistrationThirdVM : ViewModelBase
    {
        private string _email;
        private SecureString _password;
        private bool isLoggingIn;
        private string _error;


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
        public string Error
        {
            get
            {
                return _error;
            }

            set
            {
                _error = value;
                OnPropertyChanged(nameof(Error));
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
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (string.IsNullOrEmpty(Email))
            {
                Error = "* Fill in the email field";
                return false;
            }
            else if (!regex.IsMatch(Email))
            {
                Error = "* Invalid email format";
                return false;
            }
            else if (Password == null || Password.Length == 0)
            {
                Error = "* Fill in the password field";
                return false;
            }

            Error = "";
            return true;
        }
    }
}
