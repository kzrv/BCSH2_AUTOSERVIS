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
    public class ServiceTaskVM : ViewModelBase
    {
        private ObservableCollection<Sluzba> _sluzby;
        private Sluzba _selectedSluzba;

        private ObservableCollection<Ukol> _ukoly;
        private Ukol _selectedUkol;

        private readonly ISluzbaRepository _sluzbaRepository;
        private readonly IUkolRepository _ukolRepository;


    }
}
