using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Repository;
using Kozyrev_Hriha_SP.Repository.Interfaces;
using Kozyrev_Hriha_SP.Utils;
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
                OnPropertyChanged(nameof(ImageSource)); // Notify ImageSource property change
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
            LoginCommand = new ViewModelCommand(Login);
            CurrentView = new HomeVM();
            _loginViewModel = serviceProvider.GetService<LoginViewModel>();
            binaryContentRepository = serviceProvider.GetService<IBinaryContentRepository>();

            _loginViewModel.AuthorizationChanged += OnAuthorizationChanged;
        }
        private void OnAuthorizationChanged(bool isAuthorized)
        {
            IsAuthorized = _loginViewModel.IsAuthorized;

            if (IsAuthorized)
            {
                Console.WriteLine("Login");
                HandleAuthorizedUser();
            }
            else
            {
                Console.WriteLine("Logout");
                HandleUnauthorizedUser();
            }

        }

        private void HandleAuthorizedUser()
        {
            CurrentView = new HomeVM();
            AuthorizedUser = _loginViewModel.User;
            UserName = AuthorizedUser?.Email;

            BinaryImageData = binaryContentRepository.GetBlobById(AuthorizedUser.UserId);
        }

        private void HandleUnauthorizedUser()
        {
            CurrentView = new HomeVM();
            AuthorizedUser = null;
            UserName = null;
            BinaryImageData = null;
        }

        public BitmapImage ImageSource
        {
            get
            {
                if (_binaryImageData == null || _binaryImageData.Length == 0)
                    return null;

                var image = new BitmapImage();
                using (var mem = new System.IO.MemoryStream(_binaryImageData))
                {
                    mem.Position = 0;
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = mem;
                    image.EndInit();
                }
                return image;
            }
        }

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(nameof(CurrentView)); }
        }

        public ICommand LogoutCommand => _loginViewModel.LogoutCommand;
        public ICommand HomeCommand { get; set; }
        public ICommand CustomerCommand { get; set; }

        public ICommand LoginCommand { get; set; }

        private void Home(object obj) => CurrentView = new HomeVM();

        private void Customer(object obj) => CurrentView = ServiceProvider.GetRequiredService<Customer>();

        private void Login(object obj) => CurrentView = ServiceProvider.GetRequiredService<Login>();


    }
}
