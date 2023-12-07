using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Models
{
    public class Model : INotifyPropertyChanged
    {
        private int idModel;
        private string nazev;
        private int idZnacka;

        public int IdModel
        {
            get { return idModel; }
            set
            {
                idModel = value;
                OnPropertyChanged(nameof(IdModel));
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

        public int IdZnacka
        {
            get { return idZnacka; }
            set
            {
                idZnacka = value;
                OnPropertyChanged(nameof(IdZnacka));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
