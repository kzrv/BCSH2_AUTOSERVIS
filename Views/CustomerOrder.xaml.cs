using System.Windows.Controls;
using Kozyrev_Hriha_SP.ViewModels;

namespace Kozyrev_Hriha_SP.Views
{
    public partial class CustomerOrder : UserControl
    {
        public CustomerOrder(CustomerOrderVM customerOrderVM)
        {
            InitializeComponent();
            DataContext = customerOrderVM;
        }
    }
}