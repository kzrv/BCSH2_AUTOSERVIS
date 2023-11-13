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
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : UserControl
    {
        public Customer(CustomerVM customerVM)
        {
            InitializeComponent();
            DataContext = customerVM;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle add button click
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle update button click
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle delete button click
        }
    }
}
