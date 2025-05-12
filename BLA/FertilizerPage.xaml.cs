using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;


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
            SqlCommand sqlCommand = new SqlCommand(@"SELECT NameFertilizer as Название, Description as Описание FROM Fertilizer", dB.GetConnection());
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


        private void deleteFertilizerBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FertilizerData.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите удобрение для удаления", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Получаем выбранную строку
            DataRowView selectedRow = (DataRowView)FertilizerData.SelectedItem;
            string fertilizerName = selectedRow["Название"].ToString();

            // Подтверждение удаления
            MessageBoxResult result = MessageBox.Show(
                $"Вы уверены, что хотите удалить удобрение '{fertilizerName}'?",
                "Подтверждение удаления",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    DB dB = new DB();
                    using (SqlConnection connection = dB.GetConnection())
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(
                            "DELETE FROM Fertilizer WHERE NameFertilizer = @Name",
                            connection);
                        command.Parameters.AddWithValue("@Name", fertilizerName);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Удобрение успешно удалено", "Успех",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                            InitTable(); // Обновляем таблицу
                        }
                        else
                        {
                            MessageBox.Show("Не удалось удалить удобрение", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении удобрения: Это удобрение используется, перед удалением удалите все поливы с этим удобрением", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

    }
}
