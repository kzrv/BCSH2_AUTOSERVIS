using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Repository;
using Kozyrev_Hriha_SP.Repository.Interfaces;
using Kozyrev_Hriha_SP.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Kozyrev_Hriha_SP.ViewModels
{
    public class ServiceTaskVM : ViewModelBase
    {
        private ObservableCollection<Sluzba> _sluzby;
        private Sluzba _selectedSluzba;
        private Sluzba _currSluzba;

        private ObservableCollection<Ukol> _ukoly;
        private Ukol _selectedUkol;
        private Ukol currUkol;

        private bool _isLoading;

        private readonly ISluzbaRepository _sluzbaRepository;
        private readonly IUkolRepository _ukolRepository;
        private readonly NotificationService _notificationService;

        public ObservableCollection<Sluzba> Sluzby
        {
            get { return _sluzby; }
            set
            {
                _sluzby = value;
                OnPropertyChanged(nameof(Sluzby));
            }
        }

        public Sluzba SelectedSluzba
        {
            get { return _selectedSluzba; }
            set
            {
                _selectedSluzba = value;
                OnPropertyChanged(nameof(SelectedSluzba));
                FetchUkolForSelectedSluzba();
            }
        }

        public Sluzba CurrSluzba
        {
            get { return _currSluzba; }
            set
            {
                _currSluzba = value;
                OnPropertyChanged(nameof(CurrSluzba));
            }
        }

        public ObservableCollection<Ukol> Ukoly
        {
            get { return _ukoly; }
            set
            {
                _ukoly = value;
                OnPropertyChanged(nameof(Ukoly));
            }
        }

        public Ukol SelectedUkol
        {
            get { return _selectedUkol; }
            set
            {
                _selectedUkol = value;
                OnPropertyChanged(nameof(SelectedUkol));
                CurrUkol = SelectedUkol;
            }
        }

        public Ukol CurrUkol
        {
            get { return currUkol; }
            set
            {
                currUkol = value;
                OnPropertyChanged(nameof(CurrUkol));

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

        public ICommand ClearSluzbaCommand { get; }
        public ICommand AddUpdateSluzbaCommand { get; }
        public ICommand DeleteSluzbaCommand { get; }

        public ICommand ClearUkolCommand { get; }
        public ICommand AddUpdateUkolCommand { get; }
        public ICommand DeleteUkolCommand { get; }

        public ServiceTaskVM(ISluzbaRepository sluzbaRepository, IUkolRepository ukolRepository, NotificationService notificationService)
        {
            _sluzbaRepository = sluzbaRepository;
            _ukolRepository = ukolRepository;
            _notificationService = notificationService;
            Sluzby = new ObservableCollection<Sluzba>();
            Ukoly = new ObservableCollection<Ukol>();
            ReloadData();
            ClearSluzbaCommand = new ViewModelCommand(ClearSluzba);
            ClearUkolCommand = new ViewModelCommand(ClearUkol);
            DeleteUkolCommand = new ViewModelCommand(DeleteUkol, CanDeleteUkol);
            DeleteSluzbaCommand = new ViewModelCommand(DeleteSluzba, CanDeleteSluzba);
            AddUpdateUkolCommand = new ViewModelCommand(AddUpdateUkol, CanAddUpdateUkol);
            AddUpdateSluzbaCommand = new ViewModelCommand(AddUpdateSluzba, CanAddUpdateSluzba);
            CurrUkol = new Ukol();
            CurrSluzba = new Sluzba();
        }

        private async void ReloadData()
        {
            IsLoading = true;

            try
            {
                var sluzbyList = await Task.Run(() => _sluzbaRepository.GetAllSluzby());

                Application.Current.Dispatcher.Invoke(() =>
                {
                    Sluzby.Clear();
                    foreach (var sluzba in sluzbyList)
                    {
                        Sluzby.Add(sluzba);
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

        private async void FetchUkolForSelectedSluzba()
        {
            if (SelectedSluzba != null)
            {
                IsLoading = true;

                try
                {
                    var ukolyList = await Task.Run(() => _ukolRepository.GetUkolyBySluzbaID(SelectedSluzba.IdSluzba));
                    CurrSluzba = SelectedSluzba;

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Ukoly.Clear();
                        foreach (var ukol in ukolyList)
                        {
                            Ukoly.Add(ukol);
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

        private void ClearSluzba(object obj)
        {
            SelectedSluzba = null;
            SelectedUkol = null;
            CurrUkol = new Ukol();
            CurrSluzba = new Sluzba();
            Ukoly.Clear();
        }

        private void ClearUkol(object obj)
        {
            SelectedUkol = null;
            CurrUkol = new Ukol();
        }

        private void DeleteUkol(object obj)
        {
            try
            {
                _ukolRepository.DeleteUkol(SelectedUkol);
                Ukoly.Remove(SelectedUkol);
                SelectedUkol = null;
                _notificationService.ShowNotification("TASK WAS DELETED", NotificationType.Success);
            }
            catch (Exception e)
            {
                _notificationService.ShowNotification("ERROR DURING DELETING TASK", NotificationType.Error);
                throw;
            }
        }

        private bool CanDeleteUkol(object obj)
        {
            return SelectedUkol != null;
        }

        private void DeleteSluzba(object obj)
        {
            try
            {
                _sluzbaRepository.DeleteSluzba(SelectedSluzba);
                Sluzby.Remove(SelectedSluzba);
                SelectedSluzba = null;
                SelectedUkol = null;
                _notificationService.ShowNotification("SERVICE WAS DELETED", NotificationType.Success);
            }
            catch (Exception e)
            {
                _notificationService.ShowNotification("ERROR DURING DELETING SERVICE", NotificationType.Error);
                throw;
            }
        }

        private bool CanDeleteSluzba(object obj)
        {
            return SelectedSluzba != null;
        }

        private async void AddUpdateUkol(object obj)
        {
            if (SelectedUkol != null)
            {
                try
                {
                    _ukolRepository.UpdateUkol(SelectedUkol);
                    _notificationService.ShowNotification("TASK WAS UPDATED", NotificationType.Success);
                }
                catch (Exception e)
                {
                    _notificationService.ShowNotification(e.Message, NotificationType.Error);
                }

            }
            else
            {
                try
                {

                    await _ukolRepository.AddNewUkol(CurrUkol, SelectedSluzba.IdSluzba);
                    _notificationService.ShowNotification("NEW TASK WAS ADDED", NotificationType.Success);
                    CurrUkol = new Ukol();


                }
                catch (Exception e)
                {
                    _notificationService.ShowNotification(e.Message, NotificationType.Error);
                }
            }
        }

        private bool CanAddUpdateUkol(object obj)
        {
            return
                   SelectedUkol != null && SelectedSluzba != null ||
                   (!string.IsNullOrEmpty(CurrUkol?.Nazev) &&
                   !string.IsNullOrEmpty(CurrUkol?.Popis) &&
                   CurrUkol?.Cena != 0);
        }

        private async void AddUpdateSluzba(object obj)
        {
            if (SelectedSluzba != null)
            {
                try
                {
                    _sluzbaRepository.UpdateSluzba(SelectedSluzba);
                    _notificationService.ShowNotification("SERVICE WAS UPDATED", NotificationType.Success);
                }
                catch (Exception e)
                {
                    _notificationService.ShowNotification(e.Message, NotificationType.Error);
                }

            }
            else
            {
                try
                {
                    await _sluzbaRepository.AddNewSluzba(CurrSluzba);
                    _notificationService.ShowNotification("NEW TASK WAS ADDED", NotificationType.Success);
                    CurrSluzba = new Sluzba();

                }
                catch (Exception e)
                {
                    _notificationService.ShowNotification(e.Message, NotificationType.Error);
                }
            }
        }

        private bool CanAddUpdateSluzba(object obj)
        {
            return SelectedSluzba != null || (!string.IsNullOrEmpty(CurrSluzba.NazevSluzby) &&
                                              !string.IsNullOrEmpty(CurrSluzba.Popis));
        }
    }
}
