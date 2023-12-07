
using System.ComponentModel;

namespace Kozyrev_Hriha_SP.Models
{
    public class Znacka : INotifyPropertyChanged
    {
        private int idZnacka;
        private string nazevZnacky;

        public int IdZnacka
        {
            get { return idZnacka; }
            set
            {
                idZnacka = value;
                OnPropertyChanged(nameof(IdZnacka));
            }
        }

        public string NazevZnacky
        {
            get { return nazevZnacky; }
            set
            {
                nazevZnacky = value;
                OnPropertyChanged(nameof(NazevZnacky));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
