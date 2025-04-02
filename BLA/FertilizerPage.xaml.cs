using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BLA
{
    /// <summary>
    /// Логика взаимодействия для FertilizerPage.xaml
    /// </summary>
    public partial class FertilizerPage : Page
    {
        public FertilizerPage()
        {
            InitializeComponent();
            InitTable();

        }


        void InitTable()
        {
            DB dB = new DB();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand(@"SELECT * FROM Fertilizer", dB.GetConnection());
            sqlDataAdapter.SelectCommand = sqlCommand;
            sqlDataAdapter.Fill(dataTable);

            FertilizerData.ItemsSource = dataTable.DefaultView;
        }

        private void addFertilizerBtn_Click(object sender, RoutedEventArgs e)
        {
            AddFertilizerWindow addFertilizerWindow = new AddFertilizerWindow();
            addFertilizerWindow.ShowDialog();
            InitTable();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            InitTable();
        }

        private void printPdfBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var saveFileDialog = new Microsoft.Win32.SaveFileDialog();
                saveFileDialog.Filter = "PDF файлы (*.pdf)|*.pdf";
                saveFileDialog.Title = "Сохранить отчет PDF";
                saveFileDialog.FileName = "Отчет_по_удобрениям_" + DateTime.Now.ToString("yyyyMMdd") + ".pdf";

                if (saveFileDialog.ShowDialog() == true)
                {
                    // Остальной код создания PDF остается таким же
                    Document document = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10);
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));

                    // ... остальной код ...

                    System.Windows.MessageBox.Show("Отчет успешно сохранен в PDF!", "Успех",
                        System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка при создании PDF: {ex.Message}", "Ошибка",
                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

    }
}
