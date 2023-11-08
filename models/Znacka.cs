using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Models
{
    public class Znacka : INotifyPropertyChanged
    {
        private int idZnacka;
        private string nazevZnacky;
        private string typVozidla;

        public int ID_ZNACKA
        {
            get { return idZnacka; }
            set
            {
                idZnacka = value;
                OnPropertyChanged(nameof(ID_ZNACKA));
            }
        }

        public string NAZEV_ZNACKY
        {
            get { return nazevZnacky; }
            set
            {
                nazevZnacky = value;
                OnPropertyChanged(nameof(NAZEV_ZNACKY));
            }
        }

        public string TYP_VOZIDLA
        {
            get { return typVozidla; }
            set
            {
                typVozidla = value;
                OnPropertyChanged(nameof(TYP_VOZIDLA));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
