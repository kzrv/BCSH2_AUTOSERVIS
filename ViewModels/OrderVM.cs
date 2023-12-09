using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Repository;
using Kozyrev_Hriha_SP.Repository.Interfaces;
using Kozyrev_Hriha_SP.Service;
using MaterialDesignThemes.Wpf.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Kozyrev_Hriha_SP.ViewModels
{
    public class OrderVM : ViewModelBase
    {
        private ObservableCollection<Objednavka> _objednavky;
        private Objednavka _selectedObjednavka;
        private Objednavka _currObjednavka;

        private ObservableCollection<Sluzba> _sluzby;
        private Sluzba _selectedSluzba;

        private ObservableCollection<Zakaznik> _zakaznici;
        private Zakaznik _selectedZakaznik;

        private bool _isLoading;

        private readonly IObjednavkaRepository _objednavkaRepository;
        private readonly ISluzbaRepository _sluzbaRepository;
        private readonly IZakaznikRepository _zakaznikRepository;
        private readonly NotificationService _notificationService;

        public ObservableCollection<Objednavka> Objednavky
        {
            get { return _objednavky; }
            set
            {
                _objednavky = value;
                OnPropertyChanged(nameof(Objednavky));
            }
        }

        public Objednavka SelectedObjednavka
        {
            get { return _selectedObjednavka; }
            set
            {
                _selectedObjednavka = value;
                OnPropertyChanged(nameof(SelectedObjednavka));
                CurrObjednavka = SelectedObjednavka;
            }
        }

        public Objednavka CurrObjednavka
        {
            get { return _currObjednavka; }
            set
            {
                _currObjednavka = value;
                OnPropertyChanged(nameof(CurrObjednavka));
            }
        }

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
            }
        }

        public ObservableCollection<Zakaznik> Zakaznici
        {
            get { return _zakaznici; }
            set
            {
                _zakaznici = value;
                OnPropertyChanged(nameof(Zakaznik));
            }
        }

        public Zakaznik SelectedZakaznik
        {
            get { return _selectedZakaznik; }
            set
            {
                _selectedZakaznik = value;
                OnPropertyChanged(nameof(SelectedZakaznik));
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


        public ICommand AddUpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ClearCommand { get; }

        public OrderVM(IObjednavkaRepository objednavkaRepository, NotificationService notificationService, IZakaznikRepository zakaznikRepository, ISluzbaRepository sluzbaRepository)
        {
            _objednavkaRepository = objednavkaRepository;
            _zakaznikRepository = zakaznikRepository;
            _sluzbaRepository = sluzbaRepository;
            _notificationService = notificationService;
            Objednavky = new ObservableCollection<Objednavka>();
            Sluzby = new ObservableCollection<Sluzba>();
            Zakaznici = new ObservableCollection<Zakaznik>();
            CurrObjednavka = new Objednavka();
            ClearCommand = new ViewModelCommand(Clear);
            AddUpdateCommand = new ViewModelCommand(AddUpdateItem, CanAddUpdateItem);
            DeleteCommand = new ViewModelCommand(DeleteItem, CanDeleteItem);
            LoadData();
        }

        private async void LoadData()
        {
            IsLoading = true;
            try
            {
                var objednavkyList = await Task.Run(() => _objednavkaRepository.GetAllObjednavky());
                var zakazniciList = await Task.Run(() => _zakaznikRepository.GetAllZakaznici());
                var sluzbyList = await Task.Run(() => _sluzbaRepository.GetAllSluzby());

                Application.Current.Dispatcher.Invoke(() =>
                {
                    Objednavky.Clear();
                    Zakaznici.Clear();
                    Sluzby.Clear();
                    foreach (var obj in objednavkyList)
                    {
                        Objednavky.Add(obj);
                    }
                    foreach (var sluz in sluzbyList)
                    {
                        Sluzby.Add(sluz);
                    }
                    foreach (var zakaz in zakazniciList)
                    {
                        Zakaznici.Add(zakaz);
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

        private async void AddUpdateItem(object parameter)
        {
            if (SelectedObjednavka != null)
            {
                try
                {
                    await Task.Run(() => _objednavkaRepository.UpdateObjednavka(SelectedObjednavka));
                    LoadData();
                    _notificationService.ShowNotification("ORDER WAS UPDATED", NotificationType.Success);
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
                    await _objednavkaRepository.AddNewObjednavka(CurrObjednavka, SelectedZakaznik, SelectedSluzba);
                    _notificationService.ShowNotification("NEW ORDER WAS CREATED", NotificationType.Success);
                    CurrObjednavka = new Objednavka();
                    LoadData();
                }
                catch (Exception e)
                {
                    _notificationService.ShowNotification(e.Message, NotificationType.Error);
                }
            }
        }

        private bool CanAddUpdateItem(object parameter)
        {
            return SelectedObjednavka != null ||
                   (SelectedSluzba != null &&
                   SelectedZakaznik != null &&
                   !string.IsNullOrEmpty(CurrObjednavka.PopisObjednavky) &&
                   CurrObjednavka.CasObjednani != null);
        }

        private void Clear(object obj)
        {
            SelectedObjednavka = null;
            SelectedSluzba = null;
            SelectedZakaznik = null;
            CurrObjednavka = new Objednavka();
            CurrObjednavka.CasObjednani = DateTime.Now;
        }

        private async void DeleteItem(object parameter)
        {
            try
            {
                await Task.Run(() => _objednavkaRepository.DeleteObjednavka(SelectedObjednavka.IdObjednavky));
                Objednavky.Remove(SelectedObjednavka);
                CurrObjednavka = new Objednavka();
                SelectedZakaznik = null;
                _notificationService.ShowNotification("ORDER WAS DELETED", NotificationType.Success);
            }
            catch (Exception e)
            {
                _notificationService.ShowNotification("ERROR DURING DELETING ORDER", NotificationType.Error);
                throw;
            }

        }

        private bool CanDeleteItem(object parameter)
        {
            return SelectedObjednavka != null;
        }
    }
}
