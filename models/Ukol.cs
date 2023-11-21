
using System.ComponentModel;

namespace Kozyrev_Hriha_SP.Models
{
    public class Ukol : INotifyPropertyChanged 
    {
        private int idUkol;
        private string nazev;
        private string popis;
        private decimal cena;
        private int idSluzba;

        public int IdUkol
        {
            get { return idUkol; }
            set
            {
                idUkol = value;
                OnPropertyChanged(nameof(IdUkol));
            }
        }

        public string Nazev
        {
            get { return nazev; }
            set
            {
                nazev = value;
                OnPropertyChanged(nameof(Nazev));
            }
        }

        public string Popis
        {
            get { return popis; }
            set
            {
                popis = value;
                OnPropertyChanged(nameof(Popis));
            }
        }

        public decimal Cena
        {
            get { return cena; }
            set
            {
                cena = value;
                OnPropertyChanged(nameof(Cena));
            }
        }

        public int IdSluzba
        {
            get { return idSluzba; }
            set
            {
                idSluzba = value;
                OnPropertyChanged(nameof(IdSluzba));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
