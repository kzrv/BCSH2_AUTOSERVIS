using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP
{
    public class Objednavka : INotifyPropertyChanged
    {
        private int idObjednavky;
        private string popisObjednavky;
        private decimal cenaObjednavky;
        private int idZakaznik;
        private int idSluzba;
        private DateTime casObjednani;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int IdObjednavky
        {
            get { return idObjednavky; }
            set
            {
                if (idObjednavky != value)
                {
                    idObjednavky = value;
                    OnPropertyChanged(nameof(IdObjednavky));
                }
            }
        }

        public string PopisObjednavky
        {
            get { return popisObjednavky; }
            set
            {
                if (popisObjednavky != value)
                {
                    popisObjednavky = value;
                    OnPropertyChanged(nameof(PopisObjednavky));
                }
            }
        }

        public decimal CenaObjednavky
        {
            get { return cenaObjednavky; }
            set
            {
                if (cenaObjednavky != value)
                {
                    cenaObjednavky = value;
                    OnPropertyChanged(nameof(CenaObjednavky));
                }
            }
        }

        public int IdZakaznik
        {
            get { return idZakaznik; }
            set
            {
                if (idZakaznik != value)
                {
                    idZakaznik = value;
                    OnPropertyChanged(nameof(IdZakaznik));
                }
            }
        }

        public int IdSluzba
        {
            get { return idSluzba; }
            set
            {
                if (idSluzba != value)
                {
                    idSluzba = value;
                    OnPropertyChanged(nameof(IdSluzba));
                }
            }
        }

        public DateTime CasObjednani
        {
            get { return casObjednani; }
            set
            {
                if (casObjednani != value)
                {
                    casObjednani = value;
                    OnPropertyChanged(nameof(CasObjednani));
                }
            }
        }
    }
}
