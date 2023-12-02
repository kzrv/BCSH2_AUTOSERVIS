using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Service;

namespace Kozyrev_Hriha_SP.Views
{
    public partial class Notification : UserControl
    {
        public ObservableCollection<NotificationItem> Notifications { get; } = new ObservableCollection<NotificationItem>();

        public Notification()
        {
            InitializeComponent();
            NotificationsList.ItemsSource = Notifications;
        }

        public void ShowNotification(string message, NotificationType type)
        {
            var backgroundColor = type == NotificationType.Success ? Colors.Green : Colors.Red;
        
            var notificationItem = new NotificationItem
            {
                Message = message,
                BackgroundColor = new SolidColorBrush(backgroundColor),
                Timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) }
            };

            notificationItem.Timer.Tick += (sender, args) =>
            {
                Notifications.Remove(notificationItem);
                notificationItem.Timer.Stop();
            };

            Notifications.Add(notificationItem);
            var container = NotificationsList.ItemContainerGenerator.ContainerFromItem(notificationItem) as FrameworkElement;
            if (container != null)
            {
                container.Loaded += (sender, args) =>
                {
                    var border = FindBorderInVisualTree(container);
                    if (border != null)
                    {
                        StartSlideInAnimation(border);
                    }
                };
            }
            
            notificationItem.Timer.Start();
        }
        
        private Border FindBorderInVisualTree(DependencyObject parent)
        {
            if (parent is Border border)
            {
                return border;
            }

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                var result = FindBorderInVisualTree(child);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }

        private void StartSlideInAnimation(Border border)
        {
            // Создаем новый TranslateTransform
            var transform = new TranslateTransform(0, 100);
            border.RenderTransform = transform;

            var animation = new DoubleAnimation(100, 0, new Duration(TimeSpan.FromSeconds(0.5)));
            transform.BeginAnimation(TranslateTransform.YProperty, animation);
        }
    }
}