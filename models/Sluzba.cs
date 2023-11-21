
using System.ComponentModel;


namespace Kozyrev_Hriha_SP.Models
{
    public class Sluzba : INotifyPropertyChanged 
    {
        private int idSluzba;
        private string nazevSluzba;
        private string popis;

        public int IdSluzba
        {
            get { return idSluzba; }
            set
            {
                idSluzba = value;
                OnPropertyChanged(nameof(IdSluzba));
            }
        }

        public string NazevSluzby
        {
            get { return nazevSluzba; }
            set
            {
                nazevSluzba = value;
                OnPropertyChanged(nameof(NazevSluzby));
            }
        }

        public string Popis
        {
            get { return popis; }
            set
            {
                popis = value;
                OnPropertyChanged(nameof(Popis));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
