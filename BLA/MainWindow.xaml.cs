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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BLA
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string role {  get; set; }

        public MainWindow(string role)
        {
            InitializeComponent();
            this.role = role;   
            WaterFlower waterFlower = new WaterFlower();
            MainFrame.Content = waterFlower;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            send send1 = new send();
            send1.Show();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void homePageBtn_Click(object sender, RoutedEventArgs e)
        {
            WaterFlower waterFlower = new WaterFlower();
            MainFrame.Content = waterFlower;
        }

        private void BackBtn_Click_1(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered_1(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BackBtn.Visibility = Visibility.Visible;
                sideBarPanel.Visibility = Visibility.Visible;
            }
            else
            {
                BackBtn.Visibility = Visibility.Hidden;
            }
        }

        private void fertBtn_Click(object sender, RoutedEventArgs e)
        {
            FertilizerPage fertilizerPage = new FertilizerPage();
            MainFrame.Content = fertilizerPage;
        }

        private void employerBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.role == "Администратор")
            {
                UsersPage usersPage = new UsersPage();
                MainFrame.Content = usersPage;
            }
            else
            {
                MessageBox.Show("Эта функция доступна только Администратору");
            }
       
        }

        private void toSupportBtn_Click(object sender, RoutedEventArgs e)
        {
            send send1 = new send();
            send1.Show();
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
