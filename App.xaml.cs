using Kozyrev_Hriha_SP.CustomControls;

using Kozyrev_Hriha_SP.Repository;
using Kozyrev_Hriha_SP.Repository.Interfaces;
using Kozyrev_Hriha_SP.ViewModels;
using Kozyrev_Hriha_SP.ViewModels.RegistrationViewModel;
using Kozyrev_Hriha_SP.Views;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Configuration;
using System.Windows;
using Kozyrev_Hriha_SP.Service;
using Kozyrev_Hriha_SP.Service.Interfaces;

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

            services.AddSingleton<IBinaryContentRepository, BinaryContentRepository>(provider => new BinaryContentRepository(connectionString));
            services.AddSingleton<IAdresaRepository, AdresaRepository>(provider => new AdresaRepository(connectionString));
            services.AddSingleton<IUserSettingsRepository, UserSettingsRepository>(provider => new UserSettingsRepository(connectionString));
            services.AddSingleton<IZakaznikRepository, ZakaznikRepository>(provider =>
            new ZakaznikRepository(connectionString, provider.GetRequiredService<IUserDataRepository>(), provider.GetRequiredService<IAdresaRepository>()));
            services.AddSingleton<IZamestnanecRepository, ZamestnanecRepository>(provider =>
            new ZamestnanecRepository(connectionString, provider.GetRequiredService<IUserDataRepository>(), provider.GetRequiredService<IAdresaRepository>()));
            services.AddSingleton<IObjednavkaRepository, ObjednavkaRepository>(provider => new ObjednavkaRepository(connectionString));
            services.AddSingleton<IProhlidkaRepository, ProhlidkaRepository>(provider => new ProhlidkaRepository(connectionString));
            services.AddSingleton<IVozidloRepository, VozidloRepository>(provider => new VozidloRepository(connectionString));
            services.AddSingleton<ISluzbaRepository, SluzbaRepository>(provider => new SluzbaRepository(connectionString));
            services.AddSingleton<IUkolRepository, UkolRepository>(provider => new UkolRepository(connectionString));
            services.AddSingleton<ILogRepository, LogRepository>(provider => new LogRepository(connectionString));
            services.AddSingleton<IPlatbaRepository, PlatbaRepository>(provider => new PlatbaRepository(connectionString));
            services.AddSingleton<IUpdateUserProfileService, UpdateUserProfileService>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<CustomerVM>();
            services.AddTransient<EmployeeVM>();
            services.AddTransient<Login>();
            services.AddTransient<Customer>();
            services.AddTransient<Employee>();
            services.AddTransient<VisitEmployee>();
            services.AddTransient<VisitEmployeeVM>();
            services.AddTransient<UserSettings>();
            services.AddTransient<UserSettingsVM>();
            services.AddTransient<Order>();
            services.AddTransient<OrderVM>();
            services.AddTransient<Visit>();
            services.AddTransient<VisitVM>();
            services.AddTransient<Car>();
            services.AddTransient<CarVM>();
            services.AddTransient<ServiceTask>();
            services.AddTransient<ServiceTaskVM>();
            services.AddTransient<Logs>();
            services.AddTransient<LogsVM>();
            services.AddTransient<Payment>();
            services.AddTransient<PaymentVM>();
            services.AddTransient<CustomerOrder>();
            services.AddTransient<CustomerOrderVM>();
            services.AddSingleton<NotificationService>();

            services.AddSingleton<HomeVM>();
            services.AddTransient<RegistrationControlVM>();
            services.AddTransient<RegistrationControl>();

            services.AddSingleton<MainWindow>();
            services.AddSingleton<NavigationVM>();


        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            Serilog.Debugging.SelfLog.Enable(Console.Error);
            var navigate = ServiceProvider.GetRequiredService<NavigationVM>();
            var notif = ServiceProvider.GetRequiredService<NotificationService>();
            var main = new MainWindow(navigate, notif);
            main.Show();

        }
    }
}
