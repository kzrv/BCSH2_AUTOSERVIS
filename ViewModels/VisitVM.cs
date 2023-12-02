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
    public class VisitVM : ViewModelBase
    {
        private ObservableCollection<Prohlidka> _prohlidky;
        private Prohlidka _selectedProhlidka;

        private readonly IProhlidkaRepository _prohlidkaRepository;

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
            }
        }

        public VisitVM(IProhlidkaRepository prohlidkaRepository)
        {
            _prohlidkaRepository = prohlidkaRepository;
            Prohlidky = new ObservableCollection<Prohlidka>(prohlidkaRepository.GetAllProhlidky());
        }
    }
}
