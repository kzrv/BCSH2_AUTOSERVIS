using Kozyrev_Hriha_SP.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Models
{
    [Table("BINARY_CONTENT")]
    public class BinaryContent : ViewModelBase
    {
        private int idContent;
        private byte[] binarniObsah;
        private string nazevSouboru;
        private string typSouboru;
        private string pripona;
        private DateTime datumNahrani;
        private DateTime datumZmeny;
        private int zmenil;
        private string operace;

        [Column("ID_CONTENT"), Key]

        public int IdContent
        {
            get { return idContent; }
            set
            {
                idContent = value;
                OnPropertyChanged(nameof(IdContent));
            }
        }

        [Required]
        [Column("BINARNI_OBSAH")]
        public byte[] BinarniObsah
        {
            get { return binarniObsah; }
            set
            {
                binarniObsah = value;
                OnPropertyChanged(nameof(BinarniObsah));
            }
        }

        [Required]
        [StringLength(50)]
        [Column("NAZEV_SOUBORU")]
        public string NazevSouboru
        {
            get { return nazevSouboru; }
            set
            {
                if (nazevSouboru != value)
                {
                    nazevSouboru = value;
                    OnPropertyChanged(nameof(NazevSouboru));
                }
            }
        }

        [Required]
        [StringLength(25)]
        [Column("TYP_SOUBORU")]
        public string TypSouboru
        {
            get { return typSouboru; }
            set
            {
                if (typSouboru != value)
                {
                    typSouboru = value;
                    OnPropertyChanged(nameof(TypSouboru));
                }
            }
        }

        [Required]
        [Column("PRIPONA")]
        [StringLength(10)]
        public string Pripona
        {
            get { return pripona; }
            set
            {
                if (pripona != value)
                {
                    pripona = value;
                    OnPropertyChanged(nameof(Pripona));
                }
            }
        }

        [Required]
        [Column("DATUM_NAHRANI")]
        public DateTime DatumNahrani
        {
            get { return datumNahrani; }
            set
            {
                if (datumNahrani != value)
                {
                    datumNahrani = value;
                    OnPropertyChanged(nameof(DatumNahrani));
                }
            }
        }

        [Required]
        [Column("DATUM_ZMENY")]
        public DateTime DatumZmeny
        {
            get { return datumZmeny; }
            set
            {
                if (datumZmeny != value)
                {
                    datumZmeny = value;
                    OnPropertyChanged(nameof(DatumZmeny));
                }
            }
        }

        [Required]
        public int Zmenil
        {
            get { return zmenil; }
            set
            {
                if (zmenil != value)
                {
                    zmenil = value;
                    OnPropertyChanged(nameof(Zmenil));
                }
            }
        }

        [Required]
        [StringLength(50)]
        public string Operace
        {
            get { return operace; }
            set
            {
                if (operace != value)
                {
                    operace = value;
                    OnPropertyChanged(nameof(Operace));
                }
            }
        }


    }
}
