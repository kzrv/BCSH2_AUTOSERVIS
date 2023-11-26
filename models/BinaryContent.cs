using Kozyrev_Hriha_SP.ViewModels;
using System;


namespace Kozyrev_Hriha_SP.Models
{
    public class BinaryContent : ViewModelBase
    {
        private int idContent;
        private byte[] binarniObsah;
        private string nazevSouboru;
        private string typSouboru;
        private string pripona;
        private DateTime datumNahrani;
        private DateTime datumZmeny;
        private string zmenil;
        private string operace;


        public int IdContent
        {
            get { return idContent; }
            set
            {
                idContent = value;
                OnPropertyChanged(nameof(IdContent));
            }
        }

        public byte[] BinarniObsah
        {
            get { return binarniObsah; }
            set
            {
                binarniObsah = value;
                OnPropertyChanged(nameof(BinarniObsah));
            }
        }
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

        public string Zmenil
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
