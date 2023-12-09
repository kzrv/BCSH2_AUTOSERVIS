using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Repository.Interfaces;
using Kozyrev_Hriha_SP.Service;

namespace Kozyrev_Hriha_SP.ViewModels
{
    public class CustomerOrderVM : ViewModelBase
    {
        private ObservableCollection<Sluzba> _sluzby;
        private Sluzba _selectedSluzba;
        private Sluzba _currSluzba;

        private ObservableCollection<Ukol> _ukoly;
        private Ukol _selectedUkol;
        private Ukol currUkol;

        private bool _isLoading;
        private readonly NotificationService _notificationService;
        private readonly ISluzbaRepository _sluzbaRepository;
        private readonly IUkolRepository _ukolRepository;
        private Objednavka _currObjednavka;
        private ObservableCollection<Objednavka> _objednavky;
        private readonly IObjednavkaRepository _objednavkaRepository;
        private Zakaznik _currZakaz;
        private readonly IZakaznikRepository _zakaznikRepository;
        private readonly NavigationVM _navigationVm;
        private Objednavka _selectedObjednavka;

        public ObservableCollection<Sluzba> Sluzby
        {
            get { return _sluzby; }
            set
            {
                _sluzby = value;
                OnPropertyChanged(nameof(Sluzby));
            }
        }
        public Objednavka SelectedObjednavka
        {
            get { return _selectedObjednavka; }
            set
            {
                _selectedObjednavka = value;
                OnPropertyChanged(nameof(SelectedObjednavka));
                if(SelectedObjednavka != null) CurrObjednavka = SelectedObjednavka;
                LoadChoosenOrders();
            }
        }
        public ObservableCollection<Objednavka> Objednavky
        {
            get { return _objednavky; }
            set
            {
                _objednavky = value;
                OnPropertyChanged(nameof(Objednavky));
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
        public Zakaznik CurrZakaz
        {
            get { return _currZakaz; }
            set
            {
                _currZakaz = value;
                OnPropertyChanged(nameof(CurrZakaz));

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
        public Objednavka CurrObjednavka
        {
            get { return _currObjednavka; }
            set
            {
                _currObjednavka = value;
                OnPropertyChanged(nameof(CurrObjednavka));

            }
        }
        public ICommand ClearCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        public CustomerOrderVM(ISluzbaRepository sluzbaRepository, 
            IUkolRepository ukolRepository, 
            NotificationService notificationService,
            IObjednavkaRepository objednavkaRepository,
            NavigationVM navigationVm,
            IZakaznikRepository zakaznikRepository)
        {
            DeleteCommand = new ViewModelCommand(Delete, CanDelete);
            ClearCommand = new ViewModelCommand(Clear);
            AddCommand = new ViewModelCommand(AddAsync,CanAdd);
            _navigationVm = navigationVm;
            _zakaznikRepository = zakaznikRepository;
            _objednavkaRepository = objednavkaRepository;
            _sluzbaRepository = sluzbaRepository;
            _ukolRepository = ukolRepository;
            _notificationService = notificationService;
            Sluzby = new ObservableCollection<Sluzba>();
            Ukoly = new ObservableCollection<Ukol>();
            CurrObjednavka = new Objednavka();
            Objednavky = new ObservableCollection<Objednavka>();
            CurrZakaz = new Zakaznik();
            InitializeDataAsync();

        }

        private bool CanDelete(object obj)
        {
            return SelectedObjednavka != null;
        }

        private async void Delete(object obj)
        {
            try
            {
                await Task.Run(()=>_objednavkaRepository.DeleteObjednavka(SelectedObjednavka.IdObjednavky));
                Objednavky.Remove(SelectedObjednavka);
                SelectedObjednavka = null;
                SelectedSluzba = null;
                SelectedUkol = null;
                _notificationService.ShowNotification("ORDER WAS DELETED", NotificationType.Success);
            }
            catch (Exception e)
            {
                _notificationService.ShowNotification("ERROR DURING DELETING ORDER", NotificationType.Error);
                ReloadData();
                throw;
            }
        }

        private async Task Add()
        {
            try
            {
                Objednavka objed = CurrObjednavka;
                objed.CasObjednani = DateTime.Now;
                objed.IdZakaznik = CurrZakaz.Id;
                objed.IdSluzba = SelectedSluzba.IdSluzba;
                await Task.Run(()=>_objednavkaRepository.AddNewObjednavka(objed)); //TODO ADD MB CHECK
                _notificationService.ShowNotification("ORDER WAS ADDED", NotificationType.Success);
            }
            catch (Exception e)
            {
                _notificationService.ShowNotification("ERROR DURING ADDING ORDER", NotificationType.Error);
            }
            
            
        }
        private async void AddAsync(object obj)
        {
            await Add();  
            ReloadData(); 
        }

        private bool CanAdd(object obj)
        {
            return SelectedSluzba != null;
        }

        private async void LoadChoosenOrders()
        {
            IsLoading = true;

            try
            {
                if (SelectedObjednavka != null)
                {
                    SelectedSluzba = Sluzby.FirstOrDefault(s => s.IdSluzba == SelectedObjednavka.IdSluzba);
                    SelectedUkol = Ukoly.FirstOrDefault(u => u.IdSluzba == SelectedSluzba.IdSluzba); //TODO CGECK SLUZBU WITHOUT UKOL
                }
            }
            catch (Exception ex)
            {
                    
                _notificationService.ShowNotification(ex.Message, NotificationType.Error);
                throw;
            }
            finally
            {
                IsLoading = false;
            }
        }

        private void Clear(object obj)
        {
            CurrObjednavka = new Objednavka();
            CurrSluzba = new Sluzba();
            CurrUkol = new Ukol();
            SelectedSluzba = null;
            SelectedUkol = null;
            SelectedObjednavka = null;
            Ukoly.Clear();
        }

        private async void InitializeDataAsync()
        {
            await LoadZakaznik();  
            ReloadData(); 
        }

        private async Task LoadZakaznik()
        {
            IsLoading = true;
            CurrZakaz = await Task.Run(()=>_zakaznikRepository.GetZakaznikByUserId(_navigationVm.AuthorizedUser.UserId)); 
            _isLoading = false;
        }
        private async void ReloadData()
        {
            IsLoading = true;

            try
            {
                var sluzbyList = await Task.Run(() => _sluzbaRepository.GetAllSluzby());
                var objednavkyList = await Task.Run(() => _objednavkaRepository.GetAllObjednavkyByIdZakaznik(CurrZakaz.Id)); 

                Application.Current.Dispatcher.Invoke(() =>
                {
                    Sluzby.Clear();
                    foreach (var sluzba in sluzbyList)
                    {
                        Sluzby.Add(sluzba);
                    }
                    Objednavky.Clear();
                    foreach (var obj in objednavkyList)
                    {
                        Objednavky.Add(obj);
                    }

                });
            }
            catch (Exception ex)
            {
                _notificationService.ShowNotification(ex.Message, NotificationType.Error);
                throw;
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
                    throw;
                }
                finally
                {
                    IsLoading = false;
                }
            }
        }
    }
}