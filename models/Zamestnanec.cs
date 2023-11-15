using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Models
{
    [Table("ZAMESTNANEC")]
    public class Zamestnanec : INotifyPropertyChanged
    {
        private int idZamestnanec;
        private string jmeno;
        private string prijmeni;
        private DateTime denNastupu;
        private decimal plat;
        private int adresyIdAdresa;
        private int? zamestnanciIdZamestnanec;
        private int userDataIdUser;

        public event PropertyChangedEventHandler PropertyChanged;

        [Key]
        [Column("ID_ZAMESTNANEC")]
        public int IdZamestnanec
        {
            get => idZamestnanec;
            set => SetProperty(ref idZamestnanec, value);
        }

        [Required]
        [StringLength(20)]
        [Column("JMENO")]
        public string Jmeno
        {
            get => jmeno;
            set => SetProperty(ref jmeno, value);
        }

        [Required]
        [StringLength(25)]
        [Column("PRIJMENI")]
        public string Prijmeni
        {
            get => prijmeni;
            set => SetProperty(ref prijmeni, value);
        }

        [Required]
        [Column("DEN_NASTUPU")]
        public DateTime DenNastupu
        {
            get => denNastupu;
            set => SetProperty(ref denNastupu, value);
        }

        [Required]
        [Column("PLAT")]
        public decimal Plat
        {
            get => plat;
            set => SetProperty(ref plat, value);
        }

        [Required]
        [Column("ADRESY_ID_ADRESA")]
        public int AdresyIdAdresa
        {
            get => adresyIdAdresa;
            set => SetProperty(ref adresyIdAdresa, value);
        }

        [Column("ZAMESTNANCI_ID_ZAMESTNANEC")]
        public int? ZamestnanciIdZamestnanec
        {
            get => zamestnanciIdZamestnanec;
            set => SetProperty(ref zamestnanciIdZamestnanec, value);
        }

        [Required]
        [Column("USER_DATA_ID_USER")]
        public int UserDataIdUser
        {
            get => userDataIdUser;
            set => SetProperty(ref userDataIdUser, value);
        }
        
        protected void SetProperty<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value)) return;
            backingField = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
