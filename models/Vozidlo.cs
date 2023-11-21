
namespace Kozyrev_Hriha_SP.Models
{
    using System.ComponentModel;

    public class Vozidlo : INotifyPropertyChanged 
    { 
        private int idVozidlo;
        private string vin;
        private string spz;
        private int rokVyroby;
        private string poznamky;
        private int idModel;

        public int IdVozidlo
        {
            get { return idVozidlo; }
            set
            {
                idVozidlo = value;
                OnPropertyChanged(nameof(IdVozidlo));
            }
        }

        public string Vin
        {
            get { return vin; }
            set
            {
                vin = value;
                OnPropertyChanged(nameof(Vin));
            }
        }

        public string Spz
        {
            get { return spz; }
            set
            {
                spz = value;
                OnPropertyChanged(nameof(Spz));
            }
        }

        public int RokVyroby
        {
            get { return rokVyroby; }
            set
            {
                rokVyroby = value;
                OnPropertyChanged(nameof(RokVyroby));
            }
        }

        public string Poznamky
        {
            get { return poznamky; }
            set
            {
                poznamky = value;
                OnPropertyChanged(nameof(Poznamky));
            }
        }

        public int IdModel
        {
            get { return idModel; }
            set
            {
                idModel = value;
                OnPropertyChanged(nameof(IdModel));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
