using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Models
{
    [Table("ZAKAZNICI")]
    public class Zakaznik : INotifyPropertyChanged
    {
       
        private int idZakaznik;
        private string jmeno;
        private string prijmeni;
        private string telCislo;
        private string poznamky;
        private int idAdresa;
        private int idUser;

        [Key]
        [Column("ID_ZAKAZNIK")]
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
        [Column("ADRESY_ID_ADRESA")]
        public int IdAdresa { get { return idAdresa; }
            set
            {
                idAdresa = value;
                OnPropertyChanged(nameof(IdAdresa));
            }
        }
        [Column("USER_DATA_ID_USER")]
        public int IdUser
        {
            get { return idUser; }
            set
            {
                idUser = value;
                OnPropertyChanged(nameof(IdUser));
            }
        }
        [ForeignKey("IdAdresa")]
        public Adresa Adresa { get; set; }
        [ForeignKey("IdUser")]
        public virtual UserData UserData { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
