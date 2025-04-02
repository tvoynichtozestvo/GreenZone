using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using static BLA.WaterFlower;

namespace BLA
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string loginUser = loginBox.Text;
            string password = PasswordBox.Text;

            DB dB = new DB();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand(@"SELECT Role,Login, Password From Users Where login = @uL AND password = @uP", dB.GetConnection());
            command.Parameters.Add("@uL", SqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", SqlDbType.VarChar).Value = password;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                string group = table.Rows[0]["role"].ToString();
                if (group == "Администратор")
                {
                    UsersPage mainWindowAdmin = new UsersPage();
                    NavigationService?.Navigate(mainWindowAdmin);
                }
                else if (group == "Работник")
                {
                    WaterFlower mainWindowAdmin = new WaterFlower();
                    NavigationService?.Navigate(mainWindowAdmin);

                }
                else
                {
                    MessageBox.Show("У вас нет доступа");
                }

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            send send1 = new send();
            send1.Show();
        }
    }
}
