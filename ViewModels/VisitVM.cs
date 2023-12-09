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
    public class VisitVM : ViewModelBase
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
                    CurrProhlidka = SelectedProhlidka;
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
            }
        }

        public ICommand AddUpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ClearCommand { get; }

        public VisitVM(IProhlidkaRepository prohlidkaRepository, NotificationService notificationService, IObjednavkaRepository objednavkaRepository, IZamestnanecRepository zamestnanecRepository, IVozidloRepository vozidloRepository)
        {
            _prohlidkaRepository = prohlidkaRepository;
            _notificationService = notificationService;
            _objednavkaRepository = objednavkaRepository;
            _zamestnanecRepository = zamestnanecRepository;
            _vozidloRepository = vozidloRepository;
            Prohlidky = new ObservableCollection<Prohlidka>();
            Objednavky = new ObservableCollection<Objednavka>();
            Zamestnanci = new ObservableCollection<Zamestnanec>();
            Vozidla = new ObservableCollection<Vozidlo>();
            CurrProhlidka = new Prohlidka();
            ClearCommand = new ViewModelCommand(Clear);
            AddUpdateCommand = new ViewModelCommand(AddUpdateItem, CanAddUpdateItem);
            DeleteCommand = new ViewModelCommand(DeleteItem, CanDeleteItem);
            LoadData();

        }

        private async void LoadData()
        {
            try
            {
                var prohlidkyList = await Task.Run(() => _prohlidkaRepository.GetAllProhlidky());
                var objednavkyList = await Task.Run(() => _objednavkaRepository.GetAllObjednavky());
                var zamList = await Task.Run(() => _zamestnanecRepository.GetAllZamestnanci());
                var vozidlaList = await Task.Run(() => _vozidloRepository.GetAllVozidla());
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Prohlidky.Clear();
                    Objednavky.Clear();
                    Zamestnanci.Clear();
                    Vozidla.Clear();
                    foreach (var prh in prohlidkyList)
                    {
                        Prohlidky.Add(prh);
                    }
                    foreach (var obj in objednavkyList)
                    {
                        Objednavky.Add(obj);
                    }
                    foreach (var zam in zamList)
                    {
                        Zamestnanci.Add(zam);
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
                    await _prohlidkaRepository.AddNewProhlidka(CurrProhlidka, SelectedObjednavka, SelectedZamestnanec, SelectedVozidlo);
                    _notificationService.ShowNotification("NEW VISIT WAS CREATED", NotificationType.Success);
                    CurrProhlidka = new Prohlidka();
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
            return SelectedProhlidka != null ||
                   (CurrProhlidka.DatumZacatek != null &&
                    CurrProhlidka.CenaProhlidky != 0 &&
                    SelectedObjednavka != null &&
                    SelectedVozidlo != null &&
                    SelectedZamestnanec != null);
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
            SelectedZamestnanec = null;
            CurrProhlidka = new Prohlidka();
            CurrProhlidka.DatumZacatek = DateTime.Now;
            CurrProhlidka.DatumKonec = DateTime.Now;
        }
    }
}
