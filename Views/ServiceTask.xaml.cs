using Kozyrev_Hriha_SP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kozyrev_Hriha_SP.Views
{
    /// <summary>
    /// Interaction logic for ServiceTask.xaml
    /// </summary>
    public partial class ServiceTask : UserControl
    {
        public ServiceTask(ServiceTaskVM serviceTaskVM)
        {
            InitializeComponent();
            DataContext = serviceTaskVM;
        }
    }
}
