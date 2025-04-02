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

            if (loginBox.Text == "" && PasswordBox.Text == "")
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                string login = loginBox.Text;
                string password = PasswordBox.Text;
                DB db = new DB();
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand sqlCommand = new SqlCommand(@"SELECT Login, Password FROM Users WHERE Login = @lg AND Password = @ps", db.GetConnection());
                sqlCommand.Parameters.Add("@lg", SqlDbType.VarChar).Value = login;
                sqlCommand.Parameters.Add("@ps", SqlDbType.VarChar).Value = password;
                adapter.SelectCommand = sqlCommand;
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    WaterFlower waterFlower = new WaterFlower();
                    NavigationService?.Navigate(waterFlower);
                }
                else
                {
                    MessageBox.Show("Неверные данные");
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
