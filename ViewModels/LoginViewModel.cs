
using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Repository;
using System;
using System.Net;
using System.Security;
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

        private readonly IUserDataRepository userDataRepository;
        public event Action<bool> AuthorizationChanged;

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
                    AuthorizationChanged?.Invoke(value); // Notify about the change
                }
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand LogoutCommand { get; }
        public ICommand ShowPasswordCommand { get; }

        public LoginViewModel(IUserDataRepository userData)
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            LogoutCommand = new ViewModelCommand(ExecuteLogoutCommand, CanExecuteLogoutCommand);
            userDataRepository = userData;
        }

        private async void ExecuteLoginCommand(object obj)
        {
            try
            {
                IsLoggingIn = true;


                UserData user = await Task.Run(() => userDataRepository.CheckCredentials(new NetworkCredential(UserName, Password)));
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

        private void ExecuteLogoutCommand(object obj)
        {
            IsAuthorized = false;
            User = null;
            UserName = null;
            Password.Clear(); //cant do it
            //TODO: Clear Password box after logout
        }

        private bool CanExecuteLogoutCommand(object obj)
        {
            return IsAuthorized;
        }
    }
}
