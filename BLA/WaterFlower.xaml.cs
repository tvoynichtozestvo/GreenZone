using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Forms;

namespace BLA
{
    public partial class WaterFlower : Page
    {
        private ICollectionView _collectionView;
        private List<WaterFlowers> _waterFlowers;

        public WaterFlower()
        {
            InitializeComponent();
            InitTable();
            LoadComboBoxValues();
        }

        public class WaterFlowers
        {
            public int id { get; set; }
            public int Flowerbed_id { get; set; }
            public string flowerbed { get; set; }
            public string tube { get; set; }
            public string startWater { get; set; }
            public string endWater { get; set; }
            public string weekDate { get; set; }
            public string nameFertilizer { get; set; }
            public string color { get; set; }
        }

        private void WaterFlower2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (WaterFlower2.SelectedItem is WaterFlowers selectedFlower)
            {
                FlowerInfo flowerInfoPage = new FlowerInfo(selectedFlower);
                NavigationService?.Navigate(flowerInfoPage);
            }
        }

        void InitTable()
        {
            _waterFlowers = new List<WaterFlowers>();
            DB dB = new DB();
            dB.openConnection();

            // Сначала получаем все записи полива
            SqlCommand sqlCommand = new SqlCommand(@"SELECT 
                                       wf.id, 
                                       fb.Flowerbed, 
                                       t.Tube, 
                                       wf.StartWater, 
                                       wf.EndWater, 
                                       wf.WaterDate, 

                                       wf.Flowerbed_id
                                       FROM WaterFlowers wf
                                       INNER JOIN Flowerbed fb ON wf.Flowerbed_id = fb.id
                                       INNER JOIN Tube t ON wf.Tube_id = t.id
                                       
                                       ORDER BY wf.Flowerbed_id", dB.GetConnection());

            SqlDataReader reader = sqlCommand.ExecuteReader();

            DateTime currentDateTime = DateTime.Now;
            string currentDayOfWeek = currentDateTime.ToString("dddd", new CultureInfo("ru-RU"));
            TimeSpan currentTime = currentDateTime.TimeOfDay;

            // Словарь для хранения информации о клумбах и их активных поливах
            Dictionary<int, (WaterFlowers data, bool isActive)> flowerbedsData = new Dictionary<int, (WaterFlowers, bool)>();

            while (reader.Read())
            {
                int flowerbedId = Convert.ToInt32(reader["Flowerbed_id"]);
                string weekDate = reader["WaterDate"].ToString();
                string startWater = reader["StartWater"].ToString();
                string endWater = reader["EndWater"].ToString();
                string nameFertilizer = null;
                if (string.IsNullOrEmpty(startWater) || string.IsNullOrEmpty(endWater) )
                {
                    startWater = "00:00";
                    endWater = "00:00";
                   
                }
                if (string.IsNullOrEmpty(nameFertilizer))
                {
                    nameFertilizer = "Не выбрано";
                }

                TimeSpan.TryParse(startWater, out TimeSpan startTime);
                TimeSpan.TryParse(endWater, out TimeSpan endTime);

                // Проверяем, активен ли текущий полив
                bool isActiveNow = weekDate.Equals(currentDayOfWeek, StringComparison.OrdinalIgnoreCase) &&
                                  currentTime >= startTime && currentTime <= endTime;

                // Если клумба уже есть в словаре
                if (flowerbedsData.TryGetValue(flowerbedId, out var existingData))
                {
                    // Если текущий полив активен, обновляем статус
                    if (isActiveNow)
                    {
                        flowerbedsData[flowerbedId] = (existingData.data, true);
                    }
                }
                else
                {
                    // Создаем новую запись для клумбы
                    var flowerData = new WaterFlowers
                    {
                        id = Convert.ToInt32(reader["id"]),
                        Flowerbed_id = flowerbedId,
                        flowerbed = reader["Flowerbed"].ToString(),
                        tube = reader["Tube"].ToString(),
                        startWater = startWater,
                        endWater = endWater,
                        weekDate = weekDate,
                        nameFertilizer = nameFertilizer,
                        color = isActiveNow ? "#FF60EF60" : "#FFEF6060" // Устанавливаем цвет сразу
                    };

                    flowerbedsData.Add(flowerbedId, (flowerData, isActiveNow));
                }
            }

            reader.Close();
            dB.closeConnection();

            // Добавляем клумбы в итоговый список, устанавливая правильный цвет
            foreach (var item in flowerbedsData)
            {
                var (data, isActive) = item.Value;
                data.color = isActive ? "#FF60EF60" : "#FFEF6060";
                _waterFlowers.Add(data);
            }

            _collectionView = CollectionViewSource.GetDefaultView(_waterFlowers);
            WaterFlower2.ItemsSource = _collectionView;
        }

        void LoadComboBoxValues()
        {
            DB dB = new DB();
            dB.openConnection();

            LoadComboBox(flowerbedBox, "Flowerbed", dB);
            LoadComboBox(tubeBox, "Tube", dB);

            dB.closeConnection();
        }

        void LoadComboBox(System.Windows.Controls.ComboBox comboBox, string columnName, DB dB)
        {
            SqlCommand sqlCommand = new SqlCommand($"SELECT DISTINCT {columnName} FROM View_1", dB.GetConnection());
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<string> items = new List<string> { "Все" };

            while (reader.Read())
            {
                items.Add(reader[columnName].ToString());
            }

            reader.Close();
            comboBox.ItemsSource = items;
            comboBox.SelectedIndex = 0;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        void ApplyFilters()
        {
            string selectedFlowerbed = flowerbedBox.SelectedItem?.ToString();
            string selectedTube = tubeBox.SelectedItem?.ToString();

            _collectionView.Filter = item =>
            {
                var flower = item as WaterFlowers;

                return (string.IsNullOrEmpty(selectedFlowerbed) || selectedFlowerbed == "Все" || flower?.flowerbed == selectedFlowerbed) &&
                       (string.IsNullOrEmpty(selectedTube) || selectedTube == "Все" || flower?.tube == selectedTube);
            };
        }

        private void CheckWater_Checked(object sender, RoutedEventArgs e)
        {
            _collectionView.Filter = item =>
            {
                var flower = item as WaterFlowers;
                return flower?.color == "#FF60EF60";
            };
        }

        private void CheckWater_Unchecked(object sender, RoutedEventArgs e)
        {
            _collectionView.Filter = null;
            ApplyFilters();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            InitTable();
            LoadComboBoxValues();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            addWaterFlower addWaterFlower = new addWaterFlower();
            addWaterFlower.ShowDialog();
            InitTable();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FertilizerPage flower = new FertilizerPage();
            NavigationService?.Navigate(flower);
        }

        private void deleteFlowerBedById_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
            if (button != null && button.Tag != null)
            {
                int id = int.Parse(button.Tag.ToString());

                // Удаляем запись из базы данных
                MessageBoxResult result = System.Windows.MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
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
                        System.Windows.MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally
                    {
                        System.Windows.MessageBox.Show("Полив успешно удалён.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        InitTable();
                    }
                }
            }
        }

    }
}
