using Kozyrev_Hriha_SP.CustomControls;
using Kozyrev_Hriha_SP.DataAccess;
using Kozyrev_Hriha_SP.ViewModels;
using Kozyrev_Hriha_SP.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Kozyrev_Hriha_SP
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }
        private void ConfigureServices(IServiceCollection services)
        {
            // Регистрация сервисов
            //services.AddTransient<IDbService, DbService>();
            services.AddTransient<DbService>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<LoginView>();
            services.AddTransient<AppDBContext>();
            services.AddTransient<MainWindow>();
            services.AddTransient<NavigationVM>();


        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();


            //var loginViewModel = ServiceProvider.GetRequiredService<LoginViewModel>();
            //var loginView = new LoginView(loginViewModel);
            //loginView.Show();
            var navigate = ServiceProvider.GetRequiredService<NavigationVM>();
            var main = new MainWindow(navigate);
            main.Show();

        }
    }
}
