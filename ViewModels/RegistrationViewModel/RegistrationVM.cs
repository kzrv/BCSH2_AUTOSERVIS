using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kozyrev_Hriha_SP.ViewModels.RegistrationViewModel
{
    public class RegistrationVM : ViewModelBase
    {
        private string _name;
        private string _surname;
        private string _telNumber;
        private string _error;

        public ICommand NextCommand { get; }
        public ICommand CancelCommand { get; }

        public RegistrationVM(Action<object> second, Action<object> login)
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

        
 

        public string Error
        {
            get
            {
                return _error;
            }
            set
            {
                _error = value;
                OnPropertyChanged(nameof(Error));
            }
        }


        private bool CanExecuteNextCommand(object obj)
        {
            var regex = new Regex(@"^\+\d{12}$");
            if (string.IsNullOrEmpty(Name)
                || string.IsNullOrEmpty(Surname)
                || string.IsNullOrEmpty(TelNumber))
            {
                Error = "* Fill all fields";
                return false;
            }
            else if (!regex.IsMatch(TelNumber))
            {
                Error = "* Invalid phone number format. Expected format: +420606776532";
                return false;
            }
            Error = "";
            return true;
        }
    }
}
