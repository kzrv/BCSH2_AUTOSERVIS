using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Models
{
    public class Autoservis : INotifyPropertyChanged
    {
        private int idServis;
        private string nazevServisu;
        private int idAdresa;

        public int ID_SERVIS
        {
            get { return idServis; }
            set
            {
                idServis = value;
                OnPropertyChanged(nameof(ID_SERVIS));
            }
        }

        public string NAZEV_SERVISU
        {
            get { return nazevServisu; }
            set
            {
                nazevServisu = value;
                OnPropertyChanged(nameof(NAZEV_SERVISU));
            }
        }

        public int ID_ADRESA
        {
            get { return idAdresa; }
            set
            {
                idAdresa = value;
                OnPropertyChanged(nameof(ID_ADRESA));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
