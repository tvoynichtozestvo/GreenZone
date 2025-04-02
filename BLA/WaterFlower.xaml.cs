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

            SqlCommand sqlCommand = new SqlCommand(@"SELECT * FROM View_1", dB.GetConnection());
            SqlDataReader reader = sqlCommand.ExecuteReader();

            DateTime currentDateTime = DateTime.Now;
            string currentDayOfWeek = currentDateTime.ToString("dddd", new CultureInfo("ru-RU"));
            TimeSpan currentTime = currentDateTime.TimeOfDay;

            var groupedData = new Dictionary<string, List<WaterFlowers>>();

            while (reader.Read())
            {
                string flowerbed = reader["Flowerbed"].ToString();
                string startWater = reader["StartWater"].ToString();
                string endWater = reader["EndWater"].ToString();
                string weekDate = reader["WaterDate"].ToString();

                if (TimeSpan.TryParse(startWater, out TimeSpan startTime) &&
                    TimeSpan.TryParse(endWater, out TimeSpan endTime))
                {
                    var flowerData = new WaterFlowers
                    {
                        id = Convert.ToInt32(reader["id"]),
                        Flowerbed_id = Convert.ToInt32(reader["Flowerbed_id"]),
                        flowerbed = flowerbed,
                        tube = reader["Tube"].ToString(),
                        startWater = startWater,
                        endWater = endWater,
                        weekDate = weekDate,
                        nameFertilizer = reader["NameFertilizer"].ToString(),
                        color = "#FFEF6060"
                    };

                    if (!groupedData.ContainsKey(flowerbed))
                        groupedData[flowerbed] = new List<WaterFlowers>();

                    groupedData[flowerbed].Add(flowerData);
                }
            }

            reader.Close();
            dB.closeConnection();

            foreach (var group in groupedData)
            {
                var flowers = group.Value;

                var current = flowers.FirstOrDefault(f =>
                    f.weekDate.Equals(currentDayOfWeek, StringComparison.OrdinalIgnoreCase) &&
                    TimeSpan.TryParse(f.startWater, out TimeSpan startTime) &&
                    TimeSpan.TryParse(f.endWater, out TimeSpan endTime) &&
                    currentTime >= startTime && currentTime <= endTime);

                if (current != null)
                {
                    current.color = "#FF60EF60";
                    _waterFlowers.Add(current);
                }
                else
                {
                    var future = flowers
                        .Where(f =>
                            f.weekDate.Equals(currentDayOfWeek, StringComparison.OrdinalIgnoreCase) &&
                            TimeSpan.TryParse(f.startWater, out TimeSpan startTime) &&
                            startTime > currentTime)
                        .OrderBy(f => TimeSpan.Parse(f.startWater))
                        .FirstOrDefault();

                    if (future == null)
                    {
                        future = flowers
                            .OrderBy(f => Array.IndexOf(Enum.GetNames(typeof(DayOfWeek)), f.weekDate))
                            .ThenBy(f => TimeSpan.Parse(f.startWater))
                            .FirstOrDefault();
                    }

                    if (future != null)
                    {
                        _waterFlowers.Add(future);
                    }
                }
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
            LoadComboBox(nameFertilizerBox, "NameFertilizer", dB);

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
            string selectedNameFertilizer = nameFertilizerBox.SelectedItem?.ToString();

            _collectionView.Filter = item =>
            {
                var flower = item as WaterFlowers;

                return (string.IsNullOrEmpty(selectedFlowerbed) || selectedFlowerbed == "Все" || flower?.flowerbed == selectedFlowerbed) &&
                       (string.IsNullOrEmpty(selectedTube) || selectedTube == "Все" || flower?.tube == selectedTube) &&
                       (string.IsNullOrEmpty(selectedNameFertilizer) || selectedNameFertilizer == "Все" || flower?.nameFertilizer == selectedNameFertilizer);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InitTable();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
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

        private void Button_Click_PrintPDF(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                Title = "Сохранить отчет как PDF",
                FileName = $"Отчет_полива_{DateTime.Now:yyyyMMdd}.pdf"
            };

            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    Document document = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
                    PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    document.Open();

                    // Заголовок
                    Paragraph title = new Paragraph("Отчет о поливе клумб",
                        FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK));
                    title.Alignment = Element.ALIGN_CENTER;
                    document.Add(title);
                    document.Add(new Paragraph("\n"));

                    // Таблица
                    PdfPTable pdfTable = new PdfPTable(5);
                    pdfTable.WidthPercentage = 100;
                    pdfTable.SetWidths(new float[] { 1.5f, 1.5f, 2f, 1f, 3f });

                    // Заголовки таблицы
                    AddHeaderCell(pdfTable, "Клумба");
                    AddHeaderCell(pdfTable, "Труба");
                    AddHeaderCell(pdfTable, "Удобрение");
                    AddHeaderCell(pdfTable, "Статус");
                    AddHeaderCell(pdfTable, "Время полива");

                    // Данные
                    foreach (WaterFlowers item in _waterFlowers)
                    {
                        AddDataCell(pdfTable, item.flowerbed ?? "-");
                        AddDataCell(pdfTable, item.tube ?? "-");
                        AddDataCell(pdfTable, item.nameFertilizer ?? "-");

                        string status = item.color == "#FF60EF60" ? "Активный" : "Ожидание";
                        AddDataCell(pdfTable, status);

                        string wateringTime = $"{item.startWater ?? "-"} - {item.endWater ?? "-"} ({item.weekDate ?? "-"})";
                        AddDataCell(pdfTable, wateringTime);
                    }

                    document.Add(pdfTable);
                    document.Close();

                    System.Windows.MessageBox.Show("Отчет успешно сохранен в PDF!", "Успех",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show($"Ошибка при создании PDF: {ex.Message}", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void AddHeaderCell(PdfPTable table, string text)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text,
                FontFactory.GetFont(FontFactory.HELVETICA_BOLD)));
            cell.BackgroundColor = new BaseColor(200, 200, 200);
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
        }

        private void AddDataCell(PdfPTable table, string text)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
        }
    }
}
