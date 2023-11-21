using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace Kozyrev_Hriha_SP.Models
{
    public class ProhSluz : INotifyPropertyChanged
    {
        private int idProhlidka;
        private int idSluzba;

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
    }
}
