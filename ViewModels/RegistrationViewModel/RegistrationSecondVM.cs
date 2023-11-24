using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kozyrev_Hriha_SP.ViewModels.RegistrationViewModel
{
    public class RegistrationSecondVM : ViewModelBase
    {
        private string _city;
        private string _street;
        private string _house;
        private string _postCode;
        private string _apart;
        public ICommand NextCommand { get; }
        public ICommand BackCommand { get; }
        public RegistrationSecondVM(Action<object> third, Action<object> back)
        {
            NextCommand = new ViewModelCommand(third, CanExecuteNextCommand);
            BackCommand = new ViewModelCommand(back);
        }

        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                OnPropertyChanged(nameof(Street));
            }
        }

        public string House
        {
            get { return _house; }
            set
            {
                _house = value;
                OnPropertyChanged(nameof(House));
            }
        }

        public string PostCode
        {
            get { return _postCode; }
            set
            {
                _postCode = value;
                OnPropertyChanged(nameof(PostCode));
            }
        }

        public string Apart
        {
            get { return _apart; }
            set
            {
                _apart = value;
                OnPropertyChanged(nameof(Apart));
            }
        }
        private bool CanExecuteNextCommand(object obj)
        {
            return !string.IsNullOrEmpty(City) &&
               !string.IsNullOrEmpty(Street) &&
               !string.IsNullOrEmpty(House) &&
               !string.IsNullOrEmpty(PostCode) &&
               !string.IsNullOrEmpty(Apart);
        }


       

    }
}
