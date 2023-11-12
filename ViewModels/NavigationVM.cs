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
