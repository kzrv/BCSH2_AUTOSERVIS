using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kozyrev_Hriha_SP.ViewModels
{
    public class NavigationVM : ViewModelBase
    {
        private object _currentView;
        private readonly IServiceProvider ServiceProvider;
        private bool isAuthorized;
        private LoginViewModel _loginViewModel;
        private UserData _authorizedUser;
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(nameof(UserName)); }
        }

        public UserData AuthorizedUser
        {
            get
            {
                return _authorizedUser;
            }
            set
            {
                _authorizedUser = value;
                OnPropertyChanged(nameof(AuthorizedUser));
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
                }
            }
        }

        public NavigationVM(IServiceProvider serviceProvider, LoginViewModel loginView)
        {
            ServiceProvider = serviceProvider;
            HomeCommand = new ViewModelCommand(Home);
            CustomerCommand = new ViewModelCommand(Customer);
            LoginCommand = new ViewModelCommand(Login);
            CurrentView = new HomeVM();
            _loginViewModel = loginView;
            _loginViewModel.IsAuthorizedChanged += OnLoginViewModelIsAuthorizedChanged;
        }
        private void OnLoginViewModelIsAuthorizedChanged(object sender, EventArgs e)
        {
            IsAuthorized = _loginViewModel.IsAuthorized;
            if (isAuthorized)
            {
                CurrentView = new HomeVM();
                AuthorizedUser = _loginViewModel.User;
                UserName = AuthorizedUser.Zamestnanec.First().Prijmeni;
                //test
                //string fileName = AuthorizedUser.BinaryContentIdContent.
                if (_loginViewModel != null)
                {
                    _loginViewModel.IsAuthorizedChanged -= OnLoginViewModelIsAuthorizedChanged;
                }

            }
        }

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(nameof(CurrentView)); }
        }

        public ICommand HomeCommand { get; set; }
        public ICommand CustomerCommand { get; set; }

        public ICommand LoginCommand { get; set; }

        private void Home(object obj) => CurrentView = new HomeVM();

        private void Customer(object obj) => CurrentView = new CustomerVM();

        private void Login(object obj) => CurrentView = ServiceProvider.GetRequiredService<Login>();


    }
}
