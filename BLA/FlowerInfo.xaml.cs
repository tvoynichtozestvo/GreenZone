using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BLA
{
    public partial class FlowerInfo : Page
    {
        private int _selectedFlowerId;
        public int flowerbedId { get; set; }
        public string flowerbed { get; set; }
        public int tubeId { get; set; }

        
        public FlowerInfo(WaterFlower.WaterFlowers selectedFlower)
        {
            InitializeComponent();
            this.flowerbed = selectedFlower.flowerbed;

            // Сохраняем ID выбранного полива для удаления
            _selectedFlowerId = selectedFlower.id;

            // Заполнение данных
            numFlowerbed.Content = selectedFlower.flowerbed;
            int id  = Convert.ToInt32(selectedFlower.flowerbed.Split().Last());
            int tubeId  = Convert.ToInt32(selectedFlower.tube.Split().Last());
            this.flowerbedId = id;
            this.tubeId = tubeId;

            // Логика работы полива и проверка цвета
            TrueFalse.Content = selectedFlower.color == "#FF60EF60"
                ? "Полив сейчас работает"
                : "Полив сейчас не работает";

            // Устанавливаем цвет текста в зависимости от логики
            TrueFalse.Foreground = new SolidColorBrush(
                (selectedFlower.color == "#FF60EF60")
                    ? (Color)ColorConverter.ConvertFromString("#4CAF50")
                    : Colors.Red
            );

            // Загрузка данных в расписание 
            LoadSchedule(selectedFlower.flowerbed);
        }


        private void LoadSchedule(string flowerbedName)
        {
            try
            {
                DB dB = new DB();
                dB.openConnection();

                SqlCommand sqlCommand = new SqlCommand(
                    @"SELECT Flowerbed, StartWater, EndWater, WaterDate, Tube, NameFertilizer, id
                      FROM View_1
                      WHERE Flowerbed = @flowerbed", dB.GetConnection());
                sqlCommand.Parameters.AddWithValue("@flowerbed", flowerbedName);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                List<WaterFlower.WaterFlowers> schedule = new List<WaterFlower.WaterFlowers>();
                while (reader.Read())
                {
                    schedule.Add(new WaterFlower.WaterFlowers
                    {
                        flowerbed = reader["Flowerbed"].ToString(),
                        id = Convert.ToInt32(reader["id"]),
                        startWater = $"Начало: {reader["StartWater"]}",
                        endWater = $"Конeц: {reader["EndWater"]}",
                        weekDate = reader["WaterDate"].ToString(),
                        tube = reader["Tube"].ToString(),
                        nameFertilizer = reader["NameFertilizer"].ToString()
                    });
                }

                reader.Close();
                dB.closeConnection();

                // Сортируем по дням недели
                var orderedSchedule = schedule.OrderBy(item => Array.IndexOf(
                    new[] { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" },
                    item.weekDate)).ToList();

                WeekWater.ItemsSource = orderedSchedule;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при загрузке расписания: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        int getFlowerbedId()
        {
            DB dB = new DB();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("Select id From Flowerbed Where Flowerbed = @fname ", dB.GetConnection());
            sqlCommand.Parameters.Add("@fname", SqlDbType.VarChar).Value = this.flowerbed;
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dataTable);
            int id = Convert.ToInt32(dataTable.Rows[0]["id"]);
            return id;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // Окно подтверждения удаления
            var result = MessageBox.Show("Вы уверены, что хотите удалить данный полив?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            int id = getFlowerbedId();

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    DB dB = new DB();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataTable dt = new DataTable();
                    SqlCommand deleteCommand = new SqlCommand("DELETE FROM WaterFlowers WHERE Flowerbed_id = @id", dB.GetConnection());
                    deleteCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    adapter.SelectCommand = deleteCommand;
                    adapter.Fill(dt);

                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    MessageBox.Show("Полив успешно удалён.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService?.GoBack();
                }
            }
        }

        private void AddWater_Click(object sender, RoutedEventArgs e)
        {
            AddPolivWindow addPolivWindow = new AddPolivWindow(this.flowerbedId, this.tubeId);
            addPolivWindow.ShowDialog();
            LoadSchedule(this.flowerbed);
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {


            // Загрузка данных в расписание 
            LoadSchedule(this.flowerbed);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null && button.Tag != null)
            {
                int id = int.Parse(button.Tag.ToString());

                // Удаляем запись из базы данных
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        DB dB = new DB();
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        DataTable dt = new DataTable();
                        SqlCommand deleteCommand = new SqlCommand("DELETE FROM WaterFlowers WHERE id = @id", dB.GetConnection());
                        deleteCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                        adapter.SelectCommand = deleteCommand;
                        adapter.Fill(dt);


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally
                    {
                        MessageBox.Show("Полив успешно удалён.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                }
            }
        }
    }
}
