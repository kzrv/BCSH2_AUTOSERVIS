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
                OnPropertyChanged(nameof(Zakaznik));
            }
        }

        // Other properties, commands, and methods

        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }



        public CustomerVM(IZakaznikRepository zakaznikRep)
        {
            this.zakaznikRepository = zakaznikRep;
            List<Zakaznik> z = zakaznikRepository.GetAllZakaznici();
            Zakaznici = new ObservableCollection<Zakaznik>(zakaznikRepository.GetAllZakaznici());
            DeleteCommand = new ViewModelCommand(DeleteItem, CanDeleteItem);
            UpdateCommand = new ViewModelCommand(UpdateItem, CanUpdateItem);
        }

        private void DeleteItem(object parameter)
        {
            if (SelectedZakaznik != null)
            {
                zakaznikRepository.DeleteZakaznik(SelectedZakaznik.Id);
                Zakaznici.Remove(SelectedZakaznik);
            }
        }

        private bool CanDeleteItem(object parameter)
        {

            return SelectedZakaznik != null;
        }

        private void UpdateItem(object parameter)
        {
            if (SelectedZakaznik != null)
            {
                //TODO
            }
        }

        private bool CanUpdateItem(object parameter)
        {

            return SelectedZakaznik != null;
        }
    }
}
