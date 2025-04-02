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
using System.Windows.Shapes;

namespace BLA
{
    /// <summary>
    /// Логика взаимодействия для AddFertilizerWindow.xaml
    /// </summary>
    public partial class AddFertilizerWindow : Window
    {
        public AddFertilizerWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DB dB = new DB();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO Fertilizer (NameFertilizer, Description) VALUES (@name, @dis)", dB.GetConnection());
            sqlCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = startBox.Text;
            sqlCommand.Parameters.Add("@dis", SqlDbType.Text).Value = endBox.Text;
            sqlDataAdapter.SelectCommand = sqlCommand;
            sqlDataAdapter.Fill(dataTable);

            this.Close();
        }
    }
}
