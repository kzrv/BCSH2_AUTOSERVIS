using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Kozyrev_Hriha_SP.CustomControls;
using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Repository;
using Kozyrev_Hriha_SP.Repository.Interfaces;
using Kozyrev_Hriha_SP.Views;

namespace Kozyrev_Hriha_SP.ViewModels
{
    public class CustomerVM : ViewModelBase
    {
        private ObservableCollection<Zakaznik> _zakaznici;
        private Zakaznik _selectedZakaznik;
        private Adresa _adresa;

        private readonly IZakaznikRepository zakaznikRepository;

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

        public Adresa Adresa
        {
            get { return _adresa; }
            set
            {
                _adresa = value;
                OnPropertyChanged(nameof(Adresa));
            }
        }


        // Other properties, commands, and methods

        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ClearCommand { get; }


        public CustomerVM(IZakaznikRepository zakaznikRep)
        {
            this.zakaznikRepository = zakaznikRep;
            List<Zakaznik> z = zakaznikRepository.GetAllZakaznici();
            Zakaznici = new ObservableCollection<Zakaznik>(zakaznikRepository.GetAllZakaznici());
            // AddCommand = new ViewModelCommand(AddItem, CanAddItem);
            DeleteCommand = new ViewModelCommand(DeleteItem, CanDeleteItem);
            UpdateCommand = new ViewModelCommand(UpdateItem, CanUpdateItem);
            ClearCommand = new ViewModelCommand(ClearBoxes, CanClearBoxes);
        }

        private void DeleteItem(object parameter)
        {
            zakaznikRepository.DeleteZakaznik(SelectedZakaznik.Id);
            Zakaznici.Remove(SelectedZakaznik);
        }

        private bool CanDeleteItem(object parameter)
        {
            return SelectedZakaznik != null;
        }

        private void UpdateItem(object parameter)
        {
            zakaznikRepository.UpdateZakaznik(SelectedZakaznik, Adresa);
            Zakaznici = new ObservableCollection<Zakaznik>(zakaznikRepository.GetAllZakaznici());
        }

        private bool CanUpdateItem(object parameter)
        {

            return SelectedZakaznik != null;
        }

        private void ClearBoxes(object parameter)
        {
            SelectedZakaznik = null;
            Adresa = null;
        }
        private bool CanClearBoxes(object parameter)
        {
            return SelectedZakaznik != null;
        }

        private void AddItem(object parameter)
        {

        }
        private bool CanAddItem(object parameter)
        {
            throw new NotImplementedException();
        }
        private void FetchAdresaForSelectedZakaznik()
        {
            if (SelectedZakaznik != null)
            {
                Adresa = zakaznikRepository.GetZakaznikAddress(SelectedZakaznik.Id).FirstOrDefault();
            }
            else
            {
                Adresa = null;
            }
        }
    }
}
