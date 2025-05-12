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
    /// Логика взаимодействия для addWaterFlower.xaml
    /// </summary>
    public partial class addWaterFlower : Window
    {
        public addWaterFlower()
        {
            InitializeComponent();


            tubeIdComboBox.Items.Add("Труба 1");
            tubeIdComboBox.Items.Add("Труба 2");
            tubeIdComboBox.Items.Add("Труба 3");
            tubeIdComboBox.Items.Add("Труба 4");


    
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
        void addflowerBed(string flowerbed) 
        {
            DB dB = new DB();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand(@"Insert Into Flowerbed (Flowerbed) Values (@FbedName)", dB.GetConnection());
            command.Parameters.Add("@FbedName", SqlDbType.VarChar).Value = flowerbed;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            
        }

        int  findFlowerBedID(string flowerbed) 
        {
            DB dB = new DB();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand(@"Select id from Flowerbed Where Flowerbed = @fname", dB.GetConnection());
            command.Parameters.Add("@fname", SqlDbType.VarChar).Value = flowerbed;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            int id = Convert.ToInt32(table.Rows[0]["id"]);

            return id ;
           
        }

        int gettubeIdComboBoxValue(string tube)
        {
            if (tube == "Труба 1")
            {
                return 1;
            }
            else if (tube == "Труба 2")
            {
                return 2;
            }
            else if (tube == "Труба 3")
            {
                return 3;
            }
            else if (tube == "Труба 4")
            {
                return 4;
            }
            
            return 5;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string flowerbed = flowerbedBox.Text;
            string tube = tubeIdComboBox.SelectedItem?.ToString();

            // Проверка на заполненность полей
            if (string.IsNullOrEmpty(flowerbed) || string.IsNullOrEmpty(tube))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
                return;
            }

            int tubeId = gettubeIdComboBoxValue(tube);

            try
            {
                DB db = new DB();

                // 1. Сначала добавляем клумбу (если её ещё нет)
                addflowerBed(flowerbed);

                // 2. Получаем ID клумбы
                int flowerbedID = findFlowerBedID(flowerbed);

                // 3. Добавляем запись в WaterFlowers (только Flowerbed_id и Tube_id)
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                SqlCommand command = new SqlCommand(
                    @"INSERT INTO WaterFlowers (Flowerbed_id, Tube_id) 
              VALUES (@Fid, @Tid)",
                    db.GetConnection());

                command.Parameters.Add("@Fid", SqlDbType.Int).Value = flowerbedID;
                command.Parameters.Add("@Tid", SqlDbType.Int).Value = tubeId;

                adapter.SelectCommand = command;
                adapter.Fill(table);

                MessageBox.Show("Данные успешно добавлены!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
