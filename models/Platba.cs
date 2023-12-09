using Kozyrev_Hriha_SP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Models
{
    public class Platba : ViewModelBase
    {
        private int idPlatba;
        private DateTime datumPlatby;
        private char typPlatby;

        public int IdPlatba
        {
            get { return idPlatba; }
            set
            {
                idPlatba = value;
                OnPropertyChanged(nameof(IdPlatba));
            }
        }

        public DateTime DatumPlatby
        {
            get { return datumPlatby; }
            set
            {
                datumPlatby = value;
                OnPropertyChanged(nameof(DatumPlatby));
            }
        }

        public char TypPlatby
        {
            get { return typPlatby; }
            set
            {
                typPlatby = value;
                OnPropertyChanged(nameof(TypPlatby));
            }
        }
    }
}
