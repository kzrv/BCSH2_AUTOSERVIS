using System;
using System.ComponentModel;

namespace Kozyrev_Hriha_SP.Models
{

    public class Prohlidka : INotifyPropertyChanged
    {
        private int idProhlidka;
        private DateTime datumZacatek;
        private DateTime? datumKonec;
        private decimal cenaProhlidky;
        private int idObjednavky;
        private int idZakaznik;
        private int idVozidlo;
        private int idZamestnanec;

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
                idProhlidka = value;
                OnPropertyChanged(nameof(IdProhlidka));
            }
        }

        public DateTime DatumZacatek
        {
            get { return datumZacatek; }
            set
            {
                datumZacatek = value;
                OnPropertyChanged(nameof(DatumZacatek));
            }
        }

        public DateTime? DatumKonec
        {
            get { return datumKonec; }
            set
            {
                datumKonec = value;
                OnPropertyChanged(nameof(DatumKonec));
            }
        }

        public decimal CenaProhlidky
        {
            get { return cenaProhlidky; }
            set
            {
                cenaProhlidky = value;
                OnPropertyChanged(nameof(CenaProhlidky));
            }
        }

        public int IdObjednavky
        {
            get { return idObjednavky; }
            set
            {
                idObjednavky = value;
                OnPropertyChanged(nameof(IdObjednavky));
            }
        }

        public int IdZakaznik
        {
            get { return idZakaznik; }
            set
            {
                idZakaznik = value;
                OnPropertyChanged(nameof(IdZakaznik));
            }
        }

        public int IdZamestnanec
        {
            get { return idZamestnanec; }
            set
            {
                idZamestnanec = value;
                OnPropertyChanged(nameof(IdZamestnanec));
            }
        }

        public int IdVozidlo
        {
            get { return idVozidlo; }
            set
            {
                idVozidlo = value;
                OnPropertyChanged(nameof(IdVozidlo));
            }
        }
    }

}
