using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Repository;
using Kozyrev_Hriha_SP.Repository.Interfaces;
using Kozyrev_Hriha_SP.Utils;
using Kozyrev_Hriha_SP.ViewModels.RegistrationViewModel;
using Kozyrev_Hriha_SP.Views;
using Microsoft.Extensions.DependencyInjection;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

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
        private byte[] _binaryImageData; // Property to hold binary image data

        private readonly IBinaryContentRepository binaryContentRepository;

        public byte[] BinaryImageData
        {
            get => _binaryImageData;
            set
            {
                _binaryImageData = value;
                OnPropertyChanged(nameof(BinaryImageData));
            }
        }


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

        public NavigationVM(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            HomeCommand = new ViewModelCommand(Home);
            CustomerCommand = new ViewModelCommand(Customer);
            EmployeeCommand = new ViewModelCommand(Employee);
            LoginCommand = new ViewModelCommand(Login);
            RegCommand = new ViewModelCommand(Reg);
            UserSettingsCommand = new ViewModelCommand(UserSettings);
            CurrentView = HomePage;
            _loginViewModel = serviceProvider.GetService<LoginViewModel>();
            binaryContentRepository = serviceProvider.GetService<IBinaryContentRepository>();

            _loginViewModel.AuthorizationChanged += OnAuthorizationChanged;
        }
        private void OnAuthorizationChanged(bool isAuthorized)
        {
            IsAuthorized = _loginViewModel.IsAuthorized;

            if (IsAuthorized)
            {
                HandleAuthorizedUser();
            }
            else
            {
                HandleUnauthorizedUser();
            }

        }

        private void HandleAuthorizedUser()
        {
            CurrentView = HomePage;
            AuthorizedUser = _loginViewModel.User;
            UserName = AuthorizedUser?.Email;

            BinaryImageData = binaryContentRepository.GetBlobById(AuthorizedUser.IdContent);
        }

        private void HandleUnauthorizedUser()
        {
            CurrentView = HomePage;
            AuthorizedUser = null;
            UserName = null;
            BinaryImageData = null;
        }

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(nameof(CurrentView)); }
        }
        public void GoToLoginPage()
        {
            CurrentView = ServiceProvider.GetRequiredService<Login>();
        }
        public HomeVM HomePage { get { return ServiceProvider.GetRequiredService<HomeVM>(); } }

        public ICommand LogoutCommand => _loginViewModel.LogoutCommand;
        public ICommand HomeCommand { get; set; }
        public ICommand CustomerCommand { get; set; }
        public ICommand EmployeeCommand { get; set; }

        public ICommand LoginCommand { get; set; }

        public ICommand UserSettingsCommand { get; set; }
        public ICommand RegCommand { get; set; }

        private void Home(object obj) => CurrentView = ServiceProvider.GetRequiredService<HomeVM>();

        private void Customer(object obj) => CurrentView = ServiceProvider.GetRequiredService<Customer>();

        private void Employee(object obj) => CurrentView = ServiceProvider.GetRequiredService<Employee>();

        private void UserSettings(object obj) => CurrentView = ServiceProvider.GetRequiredService<UserSettings>();

        private void Login(object obj) => CurrentView = ServiceProvider.GetRequiredService<Login>();
        private void Reg(object obj) => CurrentView = ServiceProvider.GetRequiredService<RegistrationControl>();


    }
}
