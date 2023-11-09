using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Models
{
    public class Zakaznik : INotifyPropertyChanged
    {
       
        private int idZakaznik;
        private string jmeno;
        private string prijmeni;
        private string telCislo;
        private string email;
        private string poznamky;
        private int idAdresa;

        [Key]
        public int ID_ZAKAZNIK
        {
            get { return idZakaznik; }
            set
            {
                idZakaznik = value;
                OnPropertyChanged(nameof(ID_ZAKAZNIK));
            }
        }

        public string JMENO
        {
            get { return jmeno; }
            set
            {
                jmeno = value;
                OnPropertyChanged(nameof(JMENO));
            }
        }

        public string PRIJMENI
        {
            get { return prijmeni; }
            set
            {
                prijmeni = value;
                OnPropertyChanged(nameof(PRIJMENI));
            }
        }

        public string TEL_CISLO
        {
            get { return telCislo; }
            set
            {
                telCislo = value;
                OnPropertyChanged(nameof(TEL_CISLO));
            }
        }

        public string EMAIL
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged(nameof(EMAIL));
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
