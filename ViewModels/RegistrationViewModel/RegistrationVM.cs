using Kozyrev_Hriha_SP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kozyrev_Hriha_SP.ViewModels.RegistrationViewModel
{
    public class RegistrationVM : ViewModelBase
    {
        private string _name;
        private string _surname;
        private string _telNumber;

        public ICommand NextCommand { get; }
        public ICommand CancelCommand { get; }

        public RegistrationVM(Action<object> second,Action<object> login)
        {
            NextCommand = new ViewModelCommand(second, CanExecuteNextCommand);
            CancelCommand = new ViewModelCommand(login);
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        public string TelNumber
        {
            get
            {
                return _telNumber;
            }
            set
            {
                _telNumber = value;
                OnPropertyChanged(nameof(TelNumber));
            }
        }

       
        private bool CanExecuteNextCommand(object obj)
        {
            return !string.IsNullOrEmpty(Name)
                || !string.IsNullOrEmpty(Surname)
                || !string.IsNullOrEmpty(TelNumber);
            
        }
    }
}
