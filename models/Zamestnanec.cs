using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Kozyrev_Hriha_SP.Models
{
    public class Zamestnanec : INotifyPropertyChanged
    {
        private int idZamestnanec;
        private string jmeno;
        private string prijmeni;
        private DateTime denNastupu;
        private decimal plat;
        private int idAdresa;
        private int? idManazer;
        private int idUser;

        public event PropertyChangedEventHandler PropertyChanged;

        public int IdZamestnanec
        {
            get => idZamestnanec;
            set => SetProperty(ref idZamestnanec, value);
        }

        public string Jmeno
        {
            get => jmeno;
            set => SetProperty(ref jmeno, value);
        }

        public string Prijmeni
        {
            get => prijmeni;
            set => SetProperty(ref prijmeni, value);
        }

        public DateTime DenNastupu
        {
            get => denNastupu;
            set => SetProperty(ref denNastupu, value);
        }

        public decimal Plat
        {
            get => plat;
            set => SetProperty(ref plat, value);
        }

        public int IdAdresa
        {
            get => idAdresa;
            set => SetProperty(ref idAdresa, value);
        }

        public int? IdManazer
        {
            get => idManazer;
            set => SetProperty(ref idManazer, value);
        }

        public int IdUser
        {
            get => idUser;
            set => SetProperty(ref idUser, value);
        }
        
        protected void SetProperty<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value)) return;
            backingField = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
