using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Repository;
using Kozyrev_Hriha_SP.Repository.Interfaces;
using Kozyrev_Hriha_SP.Service;

namespace Kozyrev_Hriha_SP.ViewModels
{
    public class CustomerVM : ViewModelBase
    {
        private ObservableCollection<Zakaznik> _zakaznici;
        private Zakaznik _selectedZakaznik;
        private Adresa _adresa;
        private UserData _user;
        private Zakaznik _zakaz;
        private bool _isLoading;
        
        
        private readonly IZakaznikRepository _zakaznikRepository;
        private readonly IAdresaRepository _adresaRepository;
        private readonly IUserDataRepository _userDataRepository;
        private readonly NotificationService _notificationService;

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
                FetchAdresaForSelectedZakaznik();
            }
        }
        public Zakaznik Zakaz
        {
            get { return _zakaz; }
            set
            {
                _zakaz = value;
                OnPropertyChanged(nameof(Zakaz));
                
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

        public Adresa Adresa
        {
            get { return _adresa; }
            set
            {
                _adresa = value;
                OnPropertyChanged(nameof(Adresa));
            }
        }
        public UserData User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        public ICommand AddUpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ClearCommand { get; }


        public CustomerVM(IZakaznikRepository zakaznikRep, IAdresaRepository adresaRepository,IUserDataRepository userDataRepository,NotificationService notificationService)
        {
            IsLoading = false;
            _userDataRepository = userDataRepository;
            _notificationService = notificationService;
            _zakaznikRepository = zakaznikRep;
            Zakaznici = new ObservableCollection<Zakaznik>();
            ReloadData();
            DeleteCommand = new ViewModelCommand(DeleteItem, CanDeleteItem);
            AddUpdateCommand = new ViewModelCommand(AddUpdateItem, CanAddUpdateItem);
            ClearCommand = new ViewModelCommand(ClearBoxes, CanClearBoxes);
            _adresaRepository = adresaRepository;
            Zakaz = new Zakaznik();
            User = new UserData();
            Adresa = new Adresa();
            
        }

        private void DeleteItem(object parameter)
        {
            try
            {
                _zakaznikRepository.DeleteZakaznik(SelectedZakaznik);
                Zakaznici.Remove(SelectedZakaznik);
                Zakaz = new Zakaznik();
                Adresa = new Adresa();
                User = new UserData();
                SelectedZakaznik = null;
                _notificationService.ShowNotification("CUSTOMER WAS DELETED",NotificationType.Success);
            }
            catch (Exception e)
            {
                _notificationService.ShowNotification("ERROR DURING DELETING CUSTOMER",NotificationType.Error);
                throw;
            }
            
        }

        private bool CanDeleteItem(object parameter)
        {
            return SelectedZakaznik != null;
        }

        private async void ReloadData()
        {
            IsLoading = true;

            try
            {
                var zakazniciList = await Task.Run(() => _zakaznikRepository.GetAllZakaznici());

                
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Zakaznici.Clear();
                    foreach (var zakaznik in zakazniciList)
                    {
                        Zakaznici.Add(zakaznik);
                    }
                });
            }
            catch (Exception ex)
            {
                _notificationService.ShowNotification(ex.Message,NotificationType.Error);
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async void AddUpdateItem(object parameter)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (SelectedZakaznik != null)
            {
                try
                {
                    await Task.Run(()=>_zakaznikRepository.UpdateZakaznik(SelectedZakaznik, Adresa, User));
                    ReloadData();
                    _notificationService.ShowNotification("CUSTOMER WAS UPDATED",NotificationType.Success);
                }
                catch (Exception e)
                {
                    _notificationService.ShowNotification(e.Message,NotificationType.Error);
                }
                
            }
            else
            {
                if (Regex.IsMatch(User.Email, pattern))
                {
                    try
                    {
                        await _zakaznikRepository.AddNewZakaznik(Zakaz, Adresa, new NetworkCredential(User.Email, "abcde"));
                        _notificationService.ShowNotification("NEW CUSTOMER WAS CREATED WITH DEFAULT PASSWORD: abcde",NotificationType.Success);
                        Zakaz = new Zakaznik();
                        User = new UserData();
                        Adresa = new Adresa();
                        ReloadData();
                    }
                    catch (Exception e)
                    {
                        _notificationService.ShowNotification(e.Message,NotificationType.Error);
                    }
                }
                else _notificationService.ShowNotification("EMAIL IS NOT CORRECT, IT MUST LOOKS LIKE: EXAMPLE@EMAIL.COM",NotificationType.Error);
            }
        }

        private bool CanAddUpdateItem(object parameter)
        {
            return SelectedZakaznik != null || 
                   (!string.IsNullOrEmpty(Zakaz.TelCislo) 
                     && !string.IsNullOrEmpty(Zakaz.Jmeno) 
                     && !string.IsNullOrEmpty(Zakaz.Prijmeni)
                     && !string.IsNullOrEmpty(Adresa.Ulice)
                     && !string.IsNullOrEmpty(Adresa.Mesto) 
                     && !string.IsNullOrEmpty(Adresa.Psc)
                     && !string.IsNullOrEmpty(Adresa.CisloPopisne)
                     && !string.IsNullOrEmpty(User.Email));
        }

        private void ClearBoxes(object parameter)
        {
            SelectedZakaznik = null;
            Zakaz = new Zakaznik();
            User = new UserData();
            Adresa = new Adresa();
        }
        private bool CanClearBoxes(object parameter)
        {
            return SelectedZakaznik != null;
        }

        
        private async void FetchAdresaForSelectedZakaznik()
        {
            if (SelectedZakaznik != null)
            {
                IsLoading = true;
                Adresa = await Task.Run(() => _adresaRepository.GetAdresaById(SelectedZakaznik.IdAdresa)); 
                User = await Task.Run(() => _userDataRepository.GetZakaznikEmailByUserId(SelectedZakaznik.IdUser));
                Zakaz = SelectedZakaznik;
                IsLoading = false;
            }
        }
    }
}
