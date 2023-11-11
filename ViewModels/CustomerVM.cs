using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kozyrev_Hriha_SP.Models;

namespace Kozyrev_Hriha_SP.ViewModels
{
    public class CustomerVM : ViewModelBase
    {
        private readonly PageModel _pageModel;

        public int CustomerID
        {
            get { return _pageModel.CustomerCount; }
            set { _pageModel.CustomerCount = value; OnPropertyChanged(nameof(CustomerID)); }
        }

        public CustomerVM()
        {
            _pageModel = new PageModel();
            CustomerID = 2;
        }
    }
}
