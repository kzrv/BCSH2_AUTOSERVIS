using Kozyrev_Hriha_SP.CustomControls;
using Kozyrev_Hriha_SP.DataAccess;
using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kozyrev_Hriha_SP.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _userName;
        private SecureString _password;
        private string _errorMessage;
        private bool isAuthorized;
        private UserData _userData;

        private readonly DbService DbService;
        public event EventHandler IsAuthorizedChanged;

        private bool isLoggingIn;
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

        public UserData User
        {
            get
            {
                return _userData;
            }
            set
            {
                _userData = value;
                OnPropertyChanged(nameof(User));
            }
        }
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
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

        public bool IsAuthorized
        {
            get { return isAuthorized; }
            set
            {
                if (isAuthorized != value)
                {
                    isAuthorized = value;
                    OnPropertyChanged(nameof(IsAuthorized));
                    IsAuthorizedChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand ShowPasswordCommand { get; }

        public LoginViewModel(DbService dbService)
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            DbService = dbService;
        }

        private async void ExecuteLoginCommand(object obj)
        {
            try
            {
                IsLoggingIn = true;

                using (var db = new AppDBContext())
                {
                    UserData user = await Task.Run(() => DbService.CheckCredentials(new NetworkCredential(UserName, Password)));

                    if (user == null)
                    {
                        ErrorMessage = "* Invalid username or password";
                    }
                    else
                    {
                        User = user;
                        IsAuthorized = true;
                        ErrorMessage = "";
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "* An error occurred during login";
                Console.WriteLine(ex.Message);
            }
            finally
            {
                IsLoggingIn = false;
            }
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(UserName) || UserName.Length < 3 ||
                Password == null || Password.Length < 3)
            {
                validData = false;
            }

            else
            {
                validData = true;
            }

            return validData;
        }
    }
}
