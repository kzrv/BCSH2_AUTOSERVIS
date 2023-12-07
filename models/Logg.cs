using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Models
{
    public class Logg : INotifyPropertyChanged
    {

        private int idLog;
        private DateTime timeDate;
        private string operace;
        private string tableName;
        private string performed_by;

        public int IdLog
        {
            get { return idLog; }
            set
            {
                idLog = value;
                OnPropertyChanged(nameof(IdLog));
            }
        }

        public DateTime TimeDate
        {
            get { return timeDate; }
            set
            {
                timeDate = value;
                OnPropertyChanged(nameof(TimeDate));
            }
        }

        public string Operace
        {
            get { return operace; }
            set
            {
                operace = value;
                OnPropertyChanged(nameof(Operace));
            }
        }

        public string TableName
        {
            get { return tableName; }
            set
            {
                tableName = value;
                OnPropertyChanged(nameof(TableName));
            }
        }

        public string PerformedBy
        {
            get { return performed_by; }
            set
            {
                performed_by = value;
                OnPropertyChanged(nameof(PerformedBy));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
