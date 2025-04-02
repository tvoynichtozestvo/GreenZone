using System.Windows;
using System.Windows.Controls;

namespace BLA
{
    public partial class UserDialog : Window
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }

        public UserDialog()
        {
            InitializeComponent();
            RoleComboBox.SelectedIndex = 1; // По умолчанию "Пользователь"
        }

        public UserDialog(User user) : this()
        {
            LoginTextBox.Text = user.Login;
            PasswordBox.Password = user.Password;
            RoleComboBox.SelectedItem = user.Role;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTextBox.Text))
            {
                MessageBox.Show("Введите логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Login = LoginTextBox.Text;
            Password = PasswordBox.Password;
            Role = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}