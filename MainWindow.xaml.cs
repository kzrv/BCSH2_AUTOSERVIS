using Kozyrev_Hriha_SP.ViewModels;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kozyrev_Hriha_SP.Service;

namespace Kozyrev_Hriha_SP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NotificationService _notificationService;
        public MainWindow(NavigationVM navigation,NotificationService notificationService)
        {
            InitializeComponent();
            DataContext = navigation;
            _notificationService = notificationService;
            _notificationService.OnNotificationRequested += NotificationService_OnNotificationRequested;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void NotificationService_OnNotificationRequested(string message, NotificationType type)
        {
            NotificationArea.ShowNotification(message, type);
        }


    }
}
