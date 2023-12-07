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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Kozyrev_Hriha_SP.ViewModels
{
    public class CarVM : ViewModelBase
    {
        private ObservableCollection<Vozidlo> _vozidla;
        private Vozidlo _selectedVozidlo;
        private Vozidlo _currVozidlo;

        private ObservableCollection<string> _znacky;
        private Znacka _currZnacka;

        private Model _currModel;

        private readonly IVozidloRepository _vozidloRepository;
        private readonly NotificationService _notificationService;

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
                GetCurrModel();
            }
        }

        public Vozidlo CurrVozidlo
        {
            get { return _currVozidlo; }
            set
            {
                _currVozidlo = value;
                OnPropertyChanged(nameof(CurrVozidlo));
            }
        }

        public ObservableCollection<string> Znacky
        {
            get { return _znacky; }
            set
            {
                _znacky = value;
                OnPropertyChanged(nameof(Znacky));
            }
        }

        public Znacka CurrZnacka
        {
            get { return _currZnacka; }
            set
            {
                _currZnacka = value;
                OnPropertyChanged(nameof(CurrZnacka));
            }
        }




        public Model CurrModel
        {
            get { return _currModel; }
            set
            {
                _currModel = value;
                OnPropertyChanged(nameof(CurrModel));
                GetCurrZnacka();
            }
        }

        public ICommand ClearCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand AddUpdateCommand { get; }

        public CarVM(IVozidloRepository vozidloRepository, NotificationService notificationService)
        {
            _vozidloRepository = vozidloRepository;
            Vozidla = new ObservableCollection<Vozidlo>();
            Znacky = new ObservableCollection<string>();
            ClearCommand = new ViewModelCommand(ClearVozidlo, CanClearVozidlo);
            DeleteCommand = new ViewModelCommand(DeleteVozidlo, CanDeleteVozidlo);
            AddUpdateCommand = new ViewModelCommand(AddUpdateVozidlo, CanAddUpdateVozidlo);
            LoadVozidla();
            _notificationService = notificationService;
            CurrVozidlo = new Vozidlo();
            CurrModel = new Model();
            CurrZnacka = new Znacka();
        }

        private async void LoadVozidla()
        {
            try
            {
                var vozidlaList = await Task.Run(() => _vozidloRepository.GetAllVozidla());
                var znackyList = await Task.Run(() => _vozidloRepository.GetAllZnacky());

                Application.Current.Dispatcher.Invoke(() =>
                {
                    Vozidla.Clear();
                    Znacky.Clear();
                    foreach (var vozidlo in vozidlaList)
                    {
                        Vozidla.Add(vozidlo);
                    }
                    foreach (var znacka in znackyList)
                    {
                        Znacky.Add(znacka.NazevZnacky);
                    }
                });
            }
            catch (Exception ex)
            {
                _notificationService.ShowNotification(ex.Message, NotificationType.Error);
            }

        }

        private void GetCurrModel()
        {
            if (SelectedVozidlo != null)
            {
                CurrModel = _vozidloRepository.GetModelById(SelectedVozidlo.IdModel);
                CurrVozidlo = SelectedVozidlo;
            }
        }

        private void GetCurrZnacka()
        {
            if (SelectedVozidlo != null)
            {
                CurrZnacka = _vozidloRepository.GetZnackaById(CurrModel.IdZnacka);
            }
        }

        private void ClearVozidlo(object obj)
        {
            SelectedVozidlo = null;
            CurrVozidlo = new Vozidlo();
            CurrZnacka = new Znacka();
            CurrModel = new Model();
        }

        private bool CanClearVozidlo(object obj)
        {
            return SelectedVozidlo != null;
        }

        private void DeleteVozidlo(object obj)
        {
            try
            {
                _vozidloRepository.DeleteVozidlo(SelectedVozidlo);
                Vozidla.Remove(SelectedVozidlo);
                CurrVozidlo = new Vozidlo();
                CurrModel = new Model();
                CurrZnacka = new Znacka();
                SelectedVozidlo = null;
                _notificationService.ShowNotification("CAR WAS DELETED", NotificationType.Success);
            }
            catch (Exception e)
            {
                _notificationService.ShowNotification("ERROR DURING DELETING CAR", NotificationType.Error);
                throw;
            }
        }

        private bool CanDeleteVozidlo(object obj)
        {
            return SelectedVozidlo != null;
        }

        private async void AddUpdateVozidlo(object obj)
        {

            if (SelectedVozidlo != null)
            {
                try
                {
                    _vozidloRepository.UpdateVozidlo(SelectedVozidlo, CurrModel, CurrZnacka);
                    LoadVozidla();
                    _notificationService.ShowNotification("VOZIDLO WAS UPDATED", NotificationType.Success);
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
                    CurrZnacka.IdZnacka = _vozidloRepository.GetZnackaIdByName(CurrZnacka.NazevZnacky).IdZnacka;
                    await _vozidloRepository.AddNewVozidlo(CurrVozidlo, CurrModel, CurrZnacka);
                    _notificationService.ShowNotification("NEW VOZIDLO WAS CREATED ", NotificationType.Success);
                    CurrVozidlo = new Vozidlo();
                    CurrModel = new Model();
                    CurrZnacka = new Znacka();
                    LoadVozidla();
                }
                catch (Exception e)
                {
                    _notificationService.ShowNotification(e.Message, NotificationType.Error);
                }

            }
        }

        private bool CanAddUpdateVozidlo(object obj)
        {
            return SelectedVozidlo != null ||
                   (!string.IsNullOrEmpty(CurrVozidlo?.Vin)
                     && !string.IsNullOrEmpty(CurrVozidlo?.Spz)
                     && CurrVozidlo?.RokVyroby != 0
                     && !string.IsNullOrEmpty(CurrModel?.Nazev)
                     && !string.IsNullOrEmpty(CurrZnacka?.NazevZnacky));
        }
    }
}
