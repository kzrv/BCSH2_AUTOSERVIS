using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Repository;
using Kozyrev_Hriha_SP.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Kozyrev_Hriha_SP.Service;

namespace Kozyrev_Hriha_SP.ViewModels
{
    public class EmployeeVM : ViewModelBase
    {
        private ObservableCollection<Zamestnanec> _zamestnanci;
        private Zamestnanec _selectedZamestnanec;
        private Adresa _adresa;

        private readonly IZamestnanecRepository _zamestnanecRepository;
        private readonly IAdresaRepository _adresaRepository;
        private bool _isLoading;
        private Zamestnanec _zamest;
        private NotificationService _notificationService;
        private UserData _user;
        private readonly IUserDataRepository _userDataRepository;

        public ObservableCollection<Zamestnanec> Zamestnanci
        {
            get { return _zamestnanci; }
            set
            {
                _zamestnanci = value;
                OnPropertyChanged(nameof(Zamestnanec));
            }
        }

        public Zamestnanec SelectedZamestnanec
        {
            get { return _selectedZamestnanec; }
            set
            {
                _selectedZamestnanec = value;
                OnPropertyChanged(nameof(SelectedZamestnanec));
                //FetchAdresaForSelectedZamestnanec().Wait();
                FetchAdresaForSelectedZamestnanec();
            }
        }
        public Zamestnanec Zamest
        {
            get { return _zamest; }
            set
            {
                _zamest = value;
                OnPropertyChanged(nameof(Zamest));
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
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
                
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
        

        public EmployeeVM(IZamestnanecRepository zamestnanecRepository, IAdresaRepository adresaRepository,NotificationService notificationService,IUserDataRepository userDataRepository)
        {
            _userDataRepository = userDataRepository;
            _notificationService = notificationService;
            _zamestnanecRepository = zamestnanecRepository;
            _adresaRepository = adresaRepository;
            DeleteCommand = new ViewModelCommand(DeleteItem, CanDeleteItem);
            AddUpdateCommand = new ViewModelCommand(AddUpdateItem, CanAddUpdateItem);
            ClearCommand = new ViewModelCommand(ClearBoxes, CanClearBoxes);
            _adresaRepository = adresaRepository;
            Zamestnanci = new ObservableCollection<Zamestnanec>();
            ReloadData();
            Clear();
        }
        private async void ReloadData()
        {
            IsLoading = true;

            try
            {
                var zamList = await Task.Run(() => _zamestnanecRepository.GetAllZamestnanci());

                
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Zamestnanci.Clear();
                    foreach (var zam in zamList)
                    {
                        Zamestnanci.Add(zam);
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

        private void DeleteItem(object parameter)
        {
            try
            {
                _zamestnanecRepository.DeleteZamestnanec(SelectedZamestnanec.IdZamestnanec);
                Zamestnanci.Remove(SelectedZamestnanec);
                Clear();
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
            return SelectedZamestnanec != null;
        }

        private async void AddUpdateItem(object parameter)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (SelectedZamestnanec != null)
            {
                try
                {
                    await Task.Run(()=>_zamestnanecRepository.UpdateZamestnanec(SelectedZamestnanec, Adresa, User));
                    ReloadData();
                    _notificationService.ShowNotification("EMPLOYEE WAS UPDATED",NotificationType.Success);
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
                        await _zamestnanecRepository.AddNewZamestnanec(Zamest, Adresa, new NetworkCredential(User.Email, "abcde"));
                        _notificationService.ShowNotification("NEW EMPLOYEE WAS CREATED WITH DEFAULT PASSWORD: abcde",NotificationType.Success);
                        Zamest = new Zamestnanec();
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
            return SelectedZamestnanec !=null ||
            (!string.IsNullOrEmpty(Zamest.Jmeno) 
             && !string.IsNullOrEmpty(User.Email)
             && !string.IsNullOrEmpty(Zamest.Prijmeni)
             && Zamest.Plat>=0
             && !string.IsNullOrEmpty(Adresa.Ulice)
             && !string.IsNullOrEmpty(Adresa.Mesto) 
             && !string.IsNullOrEmpty(Adresa.Psc)
             && !string.IsNullOrEmpty(Adresa.CisloPopisne)
             && !string.IsNullOrEmpty(User.Email));
        }

        private void ClearBoxes(object parameter)
        {
            Clear();
        }

        private void Clear()
        {
            SelectedZamestnanec = null;
            Adresa = new Adresa();
            User = new UserData();
            Zamest = new Zamestnanec();
            Zamest.DenNastupu = DateTime.Now;
        }

        private bool CanClearBoxes(object parameter)
        {
            return SelectedZamestnanec != null;
        }
        
        private async Task FetchAdresaForSelectedZamestnanec()
        {
            if (SelectedZamestnanec != null)
            {
                IsLoading = true;
                Adresa = await Task.Run(() => _adresaRepository.GetAdresaById(SelectedZamestnanec.IdAdresa)); 
                User = await Task.Run(() => _userDataRepository.GetZakaznikEmailByUserId(SelectedZamestnanec.IdUser));
                Zamest = SelectedZamestnanec;
                IsLoading = false;
            }
        }
    }
}
