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
using Kozyrev_Hriha_SP.Models.Enum;

namespace Kozyrev_Hriha_SP.Views
{
    /// <summary>
    /// Interaction logic for UserSettings.xaml
    /// </summary>
    public partial class UserSettings : UserControl
    {
        public UserSettings(UserSettingsVM userSettingsVM)
        {
            InitializeComponent();
            DataContext = userSettingsVM;
            var viewModel = DataContext as UserSettingsVM;
            employeeData.picker.IsHitTestVisible = false;
            DaysWorked.Visibility = Visibility.Hidden;
            if (viewModel != null)
            {

                var rol = viewModel.UserRole;
                if (rol == Role.ZAMESTNANEC)
                {
                    customerData.Visibility = Visibility.Collapsed;
                    employeeData.Visibility = Visibility.Visible;
                    ManazerVis.Visibility = Visibility.Visible;
                    DaysVis.Visibility = Visibility.Visible;
                }
                else
                {
                    DaysVis.Visibility = Visibility.Collapsed;
                    customerData.Visibility = Visibility.Visible;
                    employeeData.Visibility = Visibility.Collapsed;
                    ManazerVis.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
