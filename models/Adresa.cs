
using System.ComponentModel;


namespace Kozyrev_Hriha_SP.Models
{
    public class Adresa : INotifyPropertyChanged 
    {
        private int idAdresa;
        private string ulice;
        private string psc;
        private string mesto;
        private string cisloPopisne;
        private string cisloBytu;

        public int IdAdresa
        {
            get { return idAdresa; }
            set
            {
                idAdresa = value;
                OnPropertyChanged(nameof(IdAdresa));
            }
        }

        public string Ulice
        {
            get { return ulice; }
            set
            {
                ulice = value;
                OnPropertyChanged(nameof(Ulice));
            }
        }

        public string Psc
        {
            get { return psc; }
            set
            {
                psc = value;
                OnPropertyChanged(nameof(Psc));
            }
        }

        public string Mesto
        {
            get { return mesto; }
            set
            {
                mesto = value;
                OnPropertyChanged(nameof(Mesto));
            }
        }
        public string CisloPopisne
        {
            get { return cisloPopisne; }
            set
            {
                cisloPopisne = value;
                OnPropertyChanged(nameof(CisloPopisne));
            }
        }
        public string CisloBytu
        {
            get { return cisloBytu; }
            set
            {
                cisloBytu = value;
                OnPropertyChanged(nameof(CisloBytu));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
