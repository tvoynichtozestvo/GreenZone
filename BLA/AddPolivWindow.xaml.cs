using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace BLA
{
    /// <summary>
    /// Логика взаимодействия для AddPolivWindow.xaml
    /// </summary>
    public partial class AddPolivWindow : Window
    {
        public int flowerbed { get; set; }
        public int tube { get; set; }
        public AddPolivWindow(int flowerbed, int tube)
        {
            this.tube = tube;
            this.flowerbed = flowerbed;

            InitializeComponent();
            weekBox.Items.Add("Понедельник");
            weekBox.Items.Add("Вторник");
            weekBox.Items.Add("Среда");
            weekBox.Items.Add("Четверг");
            weekBox.Items.Add("Пятница");
            weekBox.Items.Add("Суббота");
            weekBox.Items.Add("Воскресенье");
            loadComboBox();
        }
        void loadComboBox()
        {
            DB db = new DB();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand(@"Select NameFertilizer From Fertilizer", db.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            fertilizerBox.ItemsSource = table.DefaultView;
            fertilizerBox.DisplayMemberPath = "NameFertilizer";

        }
        int getIdFromComboBox(string comandName)
        {
            DB db = new DB();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand(@"Select id from Fertilizer Where NameFertilizer = @Name", db.GetConnection());
            command.Parameters.Add("@Name", SqlDbType.VarChar).Value = comandName;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            int id = Convert.ToInt32(table.Rows[0]["id"]);

            return id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int flowerbedId = this.flowerbed;
            int tubeId = this.tube;
            string startTime = startBox.Text;
            string endTime = endBox.Text;
            string weekItem = weekBox.SelectedItem.ToString();
            DataRowView selectedFertilizerBoxItem = (DataRowView)fertilizerBox.SelectedItem;
            string fertilizerBoxItem = selectedFertilizerBoxItem["NameFertilizer"].ToString();
            int fertilizerId = getIdFromComboBox(fertilizerBoxItem);

            try
            {
                DB db = new DB();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                SqlCommand command = new SqlCommand(@"Insert Into WaterFlowers (Flowerbed_id, Tube_id, StartWater, EndWater, WaterDate, Fertilizer_id) Values (@Fid, @Tid, @StartT, @EndT, @Week, @FertId)", db.GetConnection());
                command.Parameters.Add("@Fid", SqlDbType.Int).Value = flowerbedId;
                command.Parameters.Add("@Tid", SqlDbType.Int).Value = tubeId;
                command.Parameters.Add("@StartT", SqlDbType.VarChar).Value = startTime;
                command.Parameters.Add("@EndT", SqlDbType.VarChar).Value = endTime;
                command.Parameters.Add("@Week", SqlDbType.VarChar).Value = weekItem;
                command.Parameters.Add("@FertId", SqlDbType.Int).Value = fertilizerId;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                this.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
            finally
            {
                this.Close();
            }
        }


    }
}
