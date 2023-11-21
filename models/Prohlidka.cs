using System;
using System.ComponentModel;

namespace Kozyrev_Hriha_SP.Models
{

    public class Prohlidka : INotifyPropertyChanged
    {
        private int idProhlidka;
        private DateTime datumZacatek;
        private DateTime? datumKonec;
        private decimal? cenaProhlidky;
        private int idObjednavky;
        private int idZakaznik;
        private int idServis;
        private int idVozidlo;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int IdProhlidka
        {
            get { return idProhlidka; }
            set
            {
                if (idProhlidka != value)
                {
                    idProhlidka = value;
                    OnPropertyChanged(nameof(IdProhlidka));
                }
            }
        }

        public DateTime DatumZacatek
        {
            get { return datumZacatek; }
            set
            {
                if (datumZacatek != value)
                {
                    datumZacatek = value;
                    OnPropertyChanged(nameof(DatumZacatek));
                }
            }
        }

        public DateTime? DatumKonec
        {
            get { return datumKonec; }
            set
            {
                if (datumKonec != value)
                {
                    datumKonec = value;
                    OnPropertyChanged(nameof(DatumKonec));
                }
            }
        }

        public decimal? CenaProhlidky
        {
            get { return cenaProhlidky; }
            set
            {
                if (cenaProhlidky != value)
                {
                    cenaProhlidky = value;
                    OnPropertyChanged(nameof(CenaProhlidky));
                }
            }
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

        public int IdServis
        {
            get { return idServis; }
            set
            {
                if (idServis != value)
                {
                    idServis = value;
                    OnPropertyChanged(nameof(IdServis));
                }
            }
        }

        public int IdVozidlo
        {
            get { return idVozidlo; }
            set
            {
                if (idVozidlo != value)
                {
                    idVozidlo = value;
                    OnPropertyChanged(nameof(IdVozidlo));
                }
            }
        }
    }

}
