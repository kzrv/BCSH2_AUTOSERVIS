using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Models
{
    public class Ukol : INotifyPropertyChanged //TODO
    {
        private int idUkol;
        private string nazevUkol;
        private string popis;
        private decimal cena;
        private int idSluzba;

        public int ID_UKOL
        {
            get { return idUkol; }
            set
            {
                idUkol = value;
                OnPropertyChanged(nameof(ID_UKOL));
            }
        }

        public string NAZEV_UKOL
        {
            get { return nazevUkol; }
            set
            {
                nazevUkol = value;
                OnPropertyChanged(nameof(NAZEV_UKOL));
            }
        }

        public string POPIS
        {
            get { return popis; }
            set
            {
                popis = value;
                OnPropertyChanged(nameof(POPIS));
            }
        }

        public decimal CENA
        {
            get { return cena; }
            set
            {
                cena = value;
                OnPropertyChanged(nameof(CENA));
            }
        }

        public int ID_SLUZBA
        {
            get { return idSluzba; }
            set
            {
                idSluzba = value;
                OnPropertyChanged(nameof(ID_SLUZBA));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
