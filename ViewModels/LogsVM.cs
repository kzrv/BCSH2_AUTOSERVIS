using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Repository;
using Kozyrev_Hriha_SP.Repository.Interfaces;
using Kozyrev_Hriha_SP.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Kozyrev_Hriha_SP.ViewModels
{
    public class LogsVM : ViewModelBase
    {
        private ObservableCollection<Logg> _logy;
        private bool _isLoading;

        private readonly ILogRepository _logRepository;
        private readonly NotificationService _notificationService;

        public ObservableCollection<Logg> Logy
        {
            get { return _logy; }
            set
            {
                _logy = value;
                OnPropertyChanged(nameof(Logy));
            }

        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));

            }
        }

        public ICommand DeleteCommand { get; }

        public LogsVM(ILogRepository logRepository, NotificationService notificationService)
        {
            _logRepository = logRepository;
            Logy = new ObservableCollection<Logg>();
            DeleteCommand = new ViewModelCommand(DeleteData, CanDeleteData);
            _notificationService = notificationService;
            LoadData();
        }

        private void DeleteData(object obj)
        {
            _logRepository.DeleteAllLogs();
            Logy.Clear();
        }

        private bool CanDeleteData(object obj)
        {
            return Logy != null;
        }

        private async void LoadData()
        {
            IsLoading = true;

            try
            {
                var logyList = await Task.Run(() => _logRepository.GetAllLogy());

                Application.Current.Dispatcher.Invoke(() =>
                {
                    Logy.Clear();
                    foreach (var log in logyList)
                    {
                        Logy.Add(log);
                    }
                });
            }
            catch (Exception ex)
            {
                _notificationService.ShowNotification(ex.Message, NotificationType.Error);
            }
            finally
            {
                IsLoading = false;
            }

        }
    }
}
