
using System.ComponentModel;

namespace Kozyrev_Hriha_SP.Models
{
    public class Znacka : INotifyPropertyChanged
    {
        private int idZnacka;
        private string nazevZnacky;

        public int IdZnazka
        {
            get { return idZnacka; }
            set
            {
                idZnacka = value;
                OnPropertyChanged(nameof(IdZnazka));
            }
        }

        public string NazevZnazky
        {
            get { return nazevZnacky; }
            set
            {
                nazevZnacky = value;
                OnPropertyChanged(nameof(NazevZnazky));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
