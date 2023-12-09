using Kozyrev_Hriha_SP.Models;
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
    public class OrderVM : ViewModelBase
    {
        private ObservableCollection<Objednavka> _objednavky;
        private Objednavka _selectedObjednavka;

        private readonly IObjednavkaRepository _objednavkaRepository;

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

        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ClearCommand { get; }

        public OrderVM(IObjednavkaRepository objednavkaRepository)
        {
            _objednavkaRepository = objednavkaRepository;
            Objednavky = new ObservableCollection<Objednavka>(objednavkaRepository.GetAllObjednavky().Result);
        }
    }
}
