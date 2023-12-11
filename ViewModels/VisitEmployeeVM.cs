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
    public class VisitEmployeeVM : ViewModelBase
    { 
        private ObservableCollection<Prohlidka> _prohlidky;
        private Prohlidka _selectedProhlidka;
        private Prohlidka _currProhlidka;

        private ObservableCollection<Objednavka> _objednavky;
        private Objednavka _selectedObjednavka;

        private ObservableCollection<Vozidlo> _vozidla;
        private Vozidlo _selectedVozidlo;

        private ObservableCollection<Zamestnanec> _zamestnanci;
        private Zamestnanec _selectedZamestnanec;

        private readonly IProhlidkaRepository _prohlidkaRepository;
        private readonly IObjednavkaRepository _objednavkaRepository;
        private readonly IVozidloRepository _vozidloRepository;
        private readonly IZamestnanecRepository _zamestnanecRepository;
        private readonly NotificationService _notificationService;
        private readonly NavigationVM _navigationVm;
        private bool _isLoading;
        private Zamestnanec _currZamest;

        public ObservableCollection<Prohlidka> Prohlidky
        {
            get { return _prohlidky; }
            set
            {
                _prohlidky = value;
                OnPropertyChanged(nameof(Prohlidky));
            }
        }

        public Prohlidka SelectedProhlidka
        {
            get { return _selectedProhlidka; }
            set
            {
                _selectedProhlidka = value;
                OnPropertyChanged(nameof(SelectedProhlidka));
                if (SelectedProhlidka != null)
                {
                    CurrProhlidka = SelectedProhlidka;
                    SelectedObjednavka = Objednavky.FirstOrDefault(o => o.IdObjednavky == SelectedProhlidka.IdObjednavky);
                    SelectedVozidlo = Vozidla.FirstOrDefault(o => o.IdVozidlo == SelectedProhlidka.IdVozidlo);
                }
            }
        }

        

        public Prohlidka CurrProhlidka
        {
            get { return _currProhlidka; }
            set
            {
                _currProhlidka = value;
                OnPropertyChanged(nameof(CurrProhlidka));
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

        public Objednavka SelectedObjednavka
        {
            get { return _selectedObjednavka; }
            set
            {
                _selectedObjednavka = value;
                OnPropertyChanged(nameof(SelectedObjednavka));
            }
        }

        public ObservableCollection<Vozidlo> Vozidla
        {
            get { return _vozidla; }
            set
            {
                _vozidla = value;
                OnPropertyChanged(nameof(Vozidla));
            }
        }

        public Vozidlo SelectedVozidlo
        {
            get { return _selectedVozidlo; }
            set
            {
                _selectedVozidlo = value;
                OnPropertyChanged(nameof(SelectedVozidlo));
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
        public Zamestnanec CurrZamest
        {
            get { return _currZamest; }
            set
            {
                _currZamest = value;
                OnPropertyChanged(nameof(CurrZamest));

            }
        }
        

        public ICommand AddUpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ClearCommand { get; }

        public VisitEmployeeVM(IProhlidkaRepository prohlidkaRepository, 
            NotificationService notificationService, 
            IObjednavkaRepository objednavkaRepository, 
            IZamestnanecRepository zamestnanecRepository, 
            IVozidloRepository vozidloRepository,
            NavigationVM navigationVm)
        {
            _navigationVm = navigationVm;
            _prohlidkaRepository = prohlidkaRepository;
            _notificationService = notificationService;
            _objednavkaRepository = objednavkaRepository;
            _zamestnanecRepository = zamestnanecRepository;
            _vozidloRepository = vozidloRepository;
            Prohlidky = new ObservableCollection<Prohlidka>();
            Objednavky = new ObservableCollection<Objednavka>();
            Vozidla = new ObservableCollection<Vozidlo>();
            CurrProhlidka = new Prohlidka();
            ClearCommand = new ViewModelCommand(Clear);
            AddUpdateCommand = new ViewModelCommand(AddUpdateItem, CanAddUpdateItem);
            DeleteCommand = new ViewModelCommand(DeleteItem, CanDeleteItem);
            InitializeDataAsync();
            Clear(null);

        }
        private async void InitializeDataAsync()
        {
            await LoadZakaznik();  
            LoadData(); 
        }
        private async Task LoadZakaznik()
        {
            IsLoading = true;
            CurrZamest = await Task.Run(()=>_zamestnanecRepository.GetZamestnanecByUserId(_navigationVm.AuthorizedUser.UserId)); 
            _isLoading = false;
        }

        private async void LoadData()
        {
            try
            {
                var prohlidkyList = await Task.Run(() => _prohlidkaRepository.GetAllProhlidky());
                var objednavkyList = await Task.Run(() => _objednavkaRepository.GetAllObjednavky());
                var vozidlaList = await Task.Run(() => _vozidloRepository.GetAllVozidla());
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Prohlidky.Clear();
                    Objednavky.Clear();
                    Vozidla.Clear();
                    foreach (var prh in prohlidkyList)
                    {
                        Prohlidky.Add(prh);
                    }
                    foreach (var obj in objednavkyList)
                    {
                        Objednavky.Add(obj);
                    }
                    foreach (var vozidlo in vozidlaList)
                    {
                        Vozidla.Add(vozidlo);
                    }
                });
            }
            catch (Exception ex)
            {
                _notificationService.ShowNotification(ex.Message, NotificationType.Error);
            }
        }
        
        private async void AddUpdateItem(object parameter)
        {
            if (SelectedProhlidka != null)
            {
                try
                {
                    await Task.Run(() => _prohlidkaRepository.UpdateProhlidka(SelectedProhlidka));
                    CurrProhlidka = new Prohlidka();
                    LoadData();
                    _notificationService.ShowNotification("VISIT WAS UPDATED", NotificationType.Success);
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
                    await _prohlidkaRepository.AddNewProhlidka(CurrProhlidka, SelectedObjednavka, CurrZamest, SelectedVozidlo);
                    _notificationService.ShowNotification("NEW VISIT WAS CREATED", NotificationType.Success);
                    CurrProhlidka = new Prohlidka();
                    LoadData();
                }
                catch (Exception e)
                {
                    if (e.Message.Contains("ORA-00001")) // ORA-00001: unique constraint (constraint_name) violated
                    {
                        _notificationService.ShowNotification("THIS ORDER ALREADY HAS A VISIT", NotificationType.Error);
                    }
                    else _notificationService.ShowNotification(e.Message, NotificationType.Error);
                }
            }
        }

        private bool CanAddUpdateItem(object parameter)
        {
            return SelectedProhlidka != null ||
                   (CurrProhlidka.CenaProhlidky >= 0 &&
                    SelectedObjednavka != null &&
                    SelectedVozidlo != null );
        }

        private async void DeleteItem(object parameter)
        {
            try
            {
                await Task.Run(() => _prohlidkaRepository.DeleteProhlidka(SelectedProhlidka));
                Prohlidky.Remove(SelectedProhlidka);
                CurrProhlidka = new Prohlidka();
                SelectedProhlidka = null;
                _notificationService.ShowNotification("VISIT WAS DELETED", NotificationType.Success);
            }
            catch (Exception e)
            {
                _notificationService.ShowNotification("ERROR DURING DELETING VISIT", NotificationType.Error);
                throw;
            }

        }

        private bool CanDeleteItem(object parameter)
        {
            return SelectedProhlidka != null;
        }

        private void Clear(object obj)
        {
            SelectedObjednavka = null;
            SelectedProhlidka = null;
            SelectedVozidlo = null;
            CurrProhlidka = new Prohlidka();
            CurrProhlidka.DatumZacatek = DateTime.Now;
            CurrProhlidka.DatumKonec = DateTime.Now;
        }
    }
}