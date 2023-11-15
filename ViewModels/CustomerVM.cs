﻿using System;
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
        private readonly PageModel _pageModel;
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
        public ICommand DeleteCommand { get; }

        public CustomerVM(IZakaznikRepository zakaznikRep)
        {
            this.zakaznikRepository = zakaznikRep;
            _pageModel = new PageModel();
            List<Zakaznik> z = zakaznikRepository.GetAllZakaznici();
            Zakaznici = new ObservableCollection<Zakaznik>(zakaznikRepository.GetAllZakaznici());
            DeleteCommand = new ViewModelCommand(DeleteItem, CanDeleteItem);
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
    }
}
