using Kozyrev_Hriha_SP.CustomControls;

using Kozyrev_Hriha_SP.Repository;
using Kozyrev_Hriha_SP.Repository.Interfaces;
using Kozyrev_Hriha_SP.ViewModels;
using Kozyrev_Hriha_SP.Views;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Configuration;
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
            string connectionString = ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString;
            services.AddSingleton<IUserDataRepository, UserDataRepository>(provider => new UserDataRepository(connectionString));
            services.AddSingleton<IZakaznikRepository, ZakaznikRepository>(provider => new ZakaznikRepository(connectionString));
            services.AddSingleton<IBinaryContentRepository, BinaryContentRepository>(provider => new BinaryContentRepository(connectionString));
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<CustomerVM>();
            services.AddSingleton<Login>();
            services.AddSingleton<Customer>();
            services.AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog(dispose: true));

            services.AddSingleton<MainWindow>();
            services.AddSingleton<NavigationVM>(provider =>
                new NavigationVM(provider.GetRequiredService<IServiceProvider>()));


        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("logs/autoService_log.txt", rollingInterval: RollingInterval.Day)
            .WriteTo.Console()
            .CreateLogger();
            Serilog.Debugging.SelfLog.Enable(Console.Error);
            var navigate = ServiceProvider.GetRequiredService<NavigationVM>();
            var main = new MainWindow(navigate);
            main.Show();

        }
    }
}
