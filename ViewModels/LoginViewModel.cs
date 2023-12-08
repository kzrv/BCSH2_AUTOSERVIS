
using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Repository;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;
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
        private UserData _userData;
        
        private readonly NavigationVM _navigation;
        private readonly IUserDataRepository _userDataRepository;

        private bool _isLoggingIn;
        public bool IsLoggingIn
        {
            get { return _isLoggingIn; }
            set
            {
                if (_isLoggingIn != value)
                {
                    _isLoggingIn = value;
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
        public ICommand LoginCommand { get; }


        public LoginViewModel(IUserDataRepository userData, NavigationVM navigation)
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            _userDataRepository = userData;
            _navigation = navigation;
        }

        private async void ExecuteLoginCommand(object obj)
        {
            try
            {
                IsLoggingIn = true;


                UserData user = await Task.Run(() => _userDataRepository.CheckCredentials(new NetworkCredential(UserName, Password)));
                if (user == null)
                {
                    ErrorMessage = "* Invalid username or password";
                }
                else
                {
                    _navigation.Authorized(user);
                }

            }
            catch (OracleException e)
            {
                ErrorMessage = "* Error connecting to server";
                
            }
            catch (Exception ex)
            {
                ErrorMessage = "* An error occurred during login";
                
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
