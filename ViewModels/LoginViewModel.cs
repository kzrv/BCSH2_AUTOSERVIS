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
        private bool _isViewVisible = true;

        private readonly DbService DbService;



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

        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }

            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand ShowPasswordCommand { get; }

        public LoginViewModel(DbService dbService)
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            DbService = dbService;
        }

        private void ExecuteLoginCommand(object obj) //Добавить 
        {
            using (var db = new AppDBContext())
            {
                bool log = DbService.CheckCredentials(new NetworkCredential(UserName, Password));
                if (!log)
                {
                    ErrorMessage = "* Invalid username or password";
                }
                else
                {
                    ErrorMessage = "* SUCES";
                }
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
