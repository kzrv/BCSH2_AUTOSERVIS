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
using Kozyrev_Hriha_SP.DataAccess;
using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Views;

namespace Kozyrev_Hriha_SP.ViewModels
{
    public class CustomerVM : ViewModelBase
    {
        private readonly PageModel _pageModel;
        private ObservableCollection<Zakaznik> _zakaznici;
        private Zakaznik _selectedZakaznik;
        private ObservableCollection<string> _uniqueAttributes;
        private string _selectedAttribute;
        private ObservableCollection<Zakaznik> _filteredCustomers;

        private readonly DbService DbService;

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

        public CustomerVM(DbService dbService)
        {
            _pageModel = new PageModel();
            using (var dbContext = new AppDBContext())
            {
                // Retrieve all customers from the database
                Zakaznici = new ObservableCollection<Zakaznik>(dbContext.Zakaznik.ToList());
            }
            DeleteCommand = new ViewModelCommand(DeleteItem, CanDeleteItem);
            DbService = dbService;
        }

        private void DeleteItem(object parameter)
        {
            if (SelectedZakaznik != null)
            {
                Zakaznici.Remove(SelectedZakaznik);
                DbService.DeleteItemFromDatabase(SelectedZakaznik);
            }
        }

        private bool CanDeleteItem(object parameter)
        {
            return SelectedZakaznik != null;
        }
    }
}
