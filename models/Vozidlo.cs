using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Models
{
    using System.ComponentModel;

    public class Vozidlo : INotifyPropertyChanged
    {
        private int idVozidlo;
        private string vin;
        private string spz;
        private int rokVyroby;
        private string poznamky;
        private int idZnacka;

        public int ID_VOZIDLO
        {
            get { return idVozidlo; }
            set
            {
                idVozidlo = value;
                OnPropertyChanged(nameof(ID_VOZIDLO));
            }
        }

        public string VIN
        {
            get { return vin; }
            set
            {
                vin = value;
                OnPropertyChanged(nameof(VIN));
            }
        }

        public string SPZ
        {
            get { return spz; }
            set
            {
                spz = value;
                OnPropertyChanged(nameof(SPZ));
            }
        }

        public int ROK_VYROBY
        {
            get { return rokVyroby; }
            set
            {
                rokVyroby = value;
                OnPropertyChanged(nameof(ROK_VYROBY));
            }
        }

        public string POZNAMKY
        {
            get { return poznamky; }
            set
            {
                poznamky = value;
                OnPropertyChanged(nameof(POZNAMKY));
            }
        }

        public int ID_ZNACKA
        {
            get { return idZnacka; }
            set
            {
                idZnacka = value;
                OnPropertyChanged(nameof(ID_ZNACKA));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
