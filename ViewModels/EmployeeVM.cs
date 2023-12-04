using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Repository;
using Kozyrev_Hriha_SP.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kozyrev_Hriha_SP.ViewModels
{
    public class EmployeeVM : ViewModelBase
    {
        private ObservableCollection<Zamestnanec> _zamestnanci;
        private Zamestnanec _selectedZamestnanec;
        private Adresa _adresa;

        private readonly IZamestnanecRepository _zamestnanecRepository;
        private readonly IAdresaRepository _adresaRepository;

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
                FetchAdresaForSelectedZamestnanec();
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

        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ClearCommand { get; }

        public EmployeeVM(IZamestnanecRepository zamestnanecRepository, IAdresaRepository adresaRepository)
        {
            _zamestnanecRepository = zamestnanecRepository;
            _adresaRepository = adresaRepository;
            List<Zamestnanec> zamest = zamestnanecRepository.GetAllZamestnanci();
            Zamestnanci = new ObservableCollection<Zamestnanec>(zamestnanecRepository.GetAllZamestnanci());
            // AddCommand = new ViewModelCommand(AddItem, CanAddItem);
            DeleteCommand = new ViewModelCommand(DeleteItem, CanDeleteItem);
            UpdateCommand = new ViewModelCommand(UpdateItem, CanUpdateItem);
            ClearCommand = new ViewModelCommand(ClearBoxes, CanClearBoxes);
            _adresaRepository = adresaRepository;
        }

        private void DeleteItem(object parameter)
        {
            _zamestnanecRepository.DeleteZamestnanec(SelectedZamestnanec.IdZamestnanec);
            Zamestnanci.Remove(SelectedZamestnanec);
        }

        private bool CanDeleteItem(object parameter)
        {
            return SelectedZamestnanec != null;
        }

        private void UpdateItem(object parameter)
        {
            _zamestnanecRepository.UpdateZamestnanec(SelectedZamestnanec, Adresa);
            Zamestnanci = new ObservableCollection<Zamestnanec>(_zamestnanecRepository.GetAllZamestnanci());
        }

        private bool CanUpdateItem(object parameter)
        {

            return SelectedZamestnanec != null;
        }

        private void ClearBoxes(object parameter)
        {
            SelectedZamestnanec = null;
            Adresa = null;
        }
        private bool CanClearBoxes(object parameter)
        {
            return SelectedZamestnanec != null;
        }

        private void AddItem(object parameter)
        {

        }
        private bool CanAddItem(object parameter)
        {
            throw new NotImplementedException();
        }
        private void FetchAdresaForSelectedZamestnanec()
        {
            if (SelectedZamestnanec != null)
            {
              //TODO  Adresa = _adresaRepository.GetAdresaById(SelectedZamestnanec.IdZamestnanec);
            }
            else
            {
                Adresa = null;
            }
        }
    }
}
