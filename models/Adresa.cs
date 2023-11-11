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
    [Table("ADRESY")]
    public class Adresa : INotifyPropertyChanged 
    {
        private int idAdresa;
        private string ulice;
        private string psc;
        private string mesto;
        private string cisloPopisne;
        private string cisloBytu;
        [Key]
        [Column("ID_ADRESA")]
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
        [Column("CISLO_POPISNE")]
        public string CisloPopisne
        {
            get { return cisloPopisne; }
            set
            {
                cisloPopisne = value;
                OnPropertyChanged(nameof(CisloPopisne));
            }
        }
        [Column("CISLO_BYTU")]
        public string CisloBytu
        {
            get { return cisloBytu; }
            set
            {
                cisloBytu = value;
                OnPropertyChanged(nameof(CisloBytu));
            }
        }
        public List<Zakaznik> zakazniks { get; set; } = new List<Zakaznik>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
