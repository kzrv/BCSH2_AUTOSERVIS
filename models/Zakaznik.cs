
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kozyrev_Hriha_SP.Models
{
    [Table("ZAKAZNIK")]
    public class Zakaznik : INotifyPropertyChanged
    {
       
        private int idZakaznik;
        private string jmeno;
        private string prijmeni;
        private string telCislo;
        private string poznamky;
        private int idAdresa;
        private int idUser;

        
        [Column("ID_ZAKAZNIK"),Key]
        public int Id
        {
            get { return idZakaznik; }
            set
            {
                idZakaznik = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string Jmeno
        {
            get { return jmeno; }
            set
            {
                jmeno = value;
                OnPropertyChanged(nameof(Jmeno));
            }
        }
        public string Prijmeni
        {
            get { return prijmeni; }
            set
            {
                prijmeni = value;
                OnPropertyChanged(nameof(Prijmeni));
            }
        }
        [Column("TEL_CISLO")]
        public string TelCislo
        {
            get { return telCislo; }
            set
            {
                telCislo = value;
                OnPropertyChanged(nameof(TelCislo));
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
        [Column("ID_ADRESA")]
        public int IdAdresa { get { return idAdresa; }
            set
            {
                idAdresa = value;
                OnPropertyChanged(nameof(IdAdresa));
            }
        }
        [Column("ID_USER")]
        public int IdUser
        {
            get { return idUser; }
            set
            {
                idUser = value;
                OnPropertyChanged(nameof(IdUser));
            }
        }
 
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
