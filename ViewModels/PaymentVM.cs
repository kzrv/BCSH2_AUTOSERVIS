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
    public class PaymentVM : ViewModelBase
    {
        private ObservableCollection<PlatbaWrapper> _platby;
        private PlatbaWrapper _selectedPlatba;


        private readonly IPlatbaRepository _platbaRepository;
        private readonly NotificationService _notificationService;

        public class PlatbaWrapper : ViewModelBase
        {
            public Platba PlatbaItem { get; set; }
            public string Identifier { get; set; }
        }

        public ObservableCollection<PlatbaWrapper> Platby
        {
            get { return _platby; }
            set
            {
                _platby = value;
                OnPropertyChanged(nameof(Platby));
            }
        }

        public PlatbaWrapper SelectedPlatba
        {
            get { return _selectedPlatba; }
            set
            {
                _selectedPlatba = value;
                OnPropertyChanged(nameof(SelectedPlatba));
            }
        }

        public ICommand DeleteCommand { get; }
        public PaymentVM(IPlatbaRepository platbaRepository, NotificationService notificationService)
        {
            _platbaRepository = platbaRepository;
            _notificationService = notificationService;
            Platby = new ObservableCollection<PlatbaWrapper>();
            DeleteCommand = new ViewModelCommand(Delete, CanDelete);
            LoadPlatby();
        }


        private async void LoadPlatby()
        {
            try
            {
                var platbyList = await Task.Run(() => _platbaRepository.GetAllPlatby());

                Application.Current.Dispatcher.Invoke(() =>
                {
                    Platby.Clear();
                    foreach (var platba in platbyList)
                    {
                        PlatbaWrapper wrapper = new PlatbaWrapper();
                        wrapper.PlatbaItem = platba;
                        wrapper.Identifier = _platbaRepository.GetIdentByPlatba(platba);
                        Platby.Add(wrapper);
                    }
                });
            }
            catch (Exception ex)
            {
                _notificationService.ShowNotification(ex.Message, NotificationType.Error);
            }

        }

        private async void Delete(object obj)
        {
            try
            {
                await Task.Run(() => _platbaRepository.DeletePlatba(SelectedPlatba.PlatbaItem));
                Platby.Remove(SelectedPlatba);
                SelectedPlatba = null;
                _notificationService.ShowNotification("PAYMENT WAS DELETED", NotificationType.Success);
            }
            catch (Exception e)
            {
                _notificationService.ShowNotification("ERROR DURING DELETING PAYMENT", NotificationType.Error);
                throw;
            }
        }

        private bool CanDelete(object parameter)
        {
            return SelectedPlatba != null;
        }
    }
}
