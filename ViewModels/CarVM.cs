using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.ViewModels
{
    public class CarVM : ViewModelBase
    {
        private ObservableCollection<Vozidlo> _vozidla;
        private Vozidlo _selectedVozidlo;

        private readonly IVozidloRepository _vozidloRepository;

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

        public CarVM(IVozidloRepository vozidloRepository)
        {
            _vozidloRepository = vozidloRepository;
            Vozidla = new ObservableCollection<Vozidlo>(vozidloRepository.GetAllVozidla());
        }
    }
}
