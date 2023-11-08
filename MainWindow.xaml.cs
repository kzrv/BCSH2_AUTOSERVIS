using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
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
using WpfApp1.DataAccess;

namespace Kozyrev_Hriha_SP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {



            OracleDatabaseService db = new OracleDatabaseService();
            db.OpenConnection();
            //OracleCommand cmd = new OracleCommand();
            //cmd.Connection = db.;
            //cmd.CommandText = "select name from counttest where id = 100";
            //cmd.CommandType = CommandType.Text;
            //OracleDataReader dr = cmd.ExecuteReader();
            //dr.Read();
            //lbl_info.Content = dr.GetString(0);
            string query = "select name from counttest where id = 100";
            DataTable userTable = db.ExecuteQuery(query);

            DataRow row = userTable.Rows[0];
            var columnValue = row["name"];
            lbl_info.Content = columnValue;
            db.CloseConnection();

        }

    }
}
