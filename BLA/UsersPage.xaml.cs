using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BLA
{
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                DB db = new DB();
                db.openConnection();

                string query = "SELECT id, Login, Password, Role FROM Users";
                SqlDataAdapter adapter = new SqlDataAdapter(query, db.GetConnection());
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                List<User> users = new List<User>();
                foreach (DataRow row in dt.Rows)
                {
                    users.Add(new User
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Login = row["Login"].ToString(),
                        Password = row["Password"].ToString(),
                        Role = row["Role"].ToString()
                    });
                }

                UsersGrid.ItemsSource = users;
                db.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке пользователей: {ex.Message}");
            }
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            UserDialog dialog = new UserDialog();
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    DB db = new DB();
                    db.openConnection();

                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Users (Login, Password, Role) VALUES (@login, @password, @role)",
                        db.GetConnection());

                    cmd.Parameters.AddWithValue("@login", dialog.Login);
                    cmd.Parameters.AddWithValue("@password", dialog.Password);
                    cmd.Parameters.AddWithValue("@role", dialog.Role);

                    cmd.ExecuteNonQuery();
                    db.closeConnection();

                    LoadUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении пользователя: {ex.Message}");
                }
            }
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null && button.Tag != null)
            {
                int userId = (int)button.Tag;
                User user = (UsersGrid.ItemsSource as List<User>).Find(u => u.Id == userId);

                if (user != null)
                {
                    UserDialog dialog = new UserDialog(user);
                    if (dialog.ShowDialog() == true)
                    {
                        try
                        {
                            DB db = new DB();
                            db.openConnection();

                            SqlCommand cmd = new SqlCommand(
                                "UPDATE Users SET Login = @login, Password = @password, Role = @role WHERE Id = @id",
                                db.GetConnection());

                            cmd.Parameters.AddWithValue("@id", userId);
                            cmd.Parameters.AddWithValue("@login", dialog.Login);
                            cmd.Parameters.AddWithValue("@password", dialog.Password);
                            cmd.Parameters.AddWithValue("@role", dialog.Role);

                            cmd.ExecuteNonQuery();
                            db.closeConnection();

                            LoadUsers();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при обновлении пользователя: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null && button.Tag != null)
            {
                int userId = (int)button.Tag;

                MessageBoxResult result = MessageBox.Show(
                    "Вы уверены, что хотите удалить этого пользователя?",
                    "Подтверждение удаления",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        DB db = new DB();
                        db.openConnection();

                        SqlCommand cmd = new SqlCommand(
                            "DELETE FROM Users WHERE Id = @id",
                            db.GetConnection());

                        cmd.Parameters.AddWithValue("@id", userId);
                        cmd.ExecuteNonQuery();
                        db.closeConnection();

                        LoadUsers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении пользователя: {ex.Message}");
                    }
                }
            }
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    public class PasswordConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new string('*', value?.ToString().Length ?? 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}