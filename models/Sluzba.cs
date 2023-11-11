using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Models
{
    public class Sluzba : INotifyPropertyChanged //TODO
    {
        private int idSluzba;
        private string nazevSluzba;
        private string popis;

        public int ID_SLUZBA
        {
            get { return idSluzba; }
            set
            {
                idSluzba = value;
                OnPropertyChanged(nameof(ID_SLUZBA));
            }
        }

        public string NAZEV_SLUZBA
        {
            get { return nazevSluzba; }
            set
            {
                nazevSluzba = value;
                OnPropertyChanged(nameof(NAZEV_SLUZBA));
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
