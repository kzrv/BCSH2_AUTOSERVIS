using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Models
{
    public class Adresa : INotifyPropertyChanged
    {
        private int idAdresa;
        private string ulice;
        private string psc;
        private string mesto;
        private string cisloPopisne;
        private string cisloBytu;

        public int ID_ADRESA
        {
            get { return idAdresa; }
            set
            {
                idAdresa = value;
                OnPropertyChanged(nameof(ID_ADRESA));
            }
        }

        public string ULICE
        {
            get { return ulice; }
            set
            {
                ulice = value;
                OnPropertyChanged(nameof(ULICE));
            }
        }

        public string PSC
        {
            get { return psc; }
            set
            {
                psc = value;
                OnPropertyChanged(nameof(PSC));
            }
        }

        public string MESTO
        {
            get { return mesto; }
            set
            {
                mesto = value;
                OnPropertyChanged(nameof(MESTO));
            }
        }

        public string CISLO_POPISNE
        {
            get { return cisloPopisne; }
            set
            {
                cisloPopisne = value;
                OnPropertyChanged(nameof(CISLO_POPISNE));
            }
        }

        public string CISLO_BYTU
        {
            get { return cisloBytu; }
            set
            {
                cisloBytu = value;
                OnPropertyChanged(nameof(CISLO_BYTU));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
