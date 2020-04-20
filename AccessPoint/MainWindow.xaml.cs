using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;
using System.Windows.Input;


namespace AccessPoint
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            authorizationWindow.Title = "Authorization";
        }
        private void passwordText_MouseLeave(object sender, MouseEventArgs e)
        {
            information.Content = "";
        }

        private void PasswordBox_MouseEnter(object sender, MouseEventArgs e)
        {
            information.Content = "Input password for connect to DataBase";
        }

        private void passwordText_MouseLeave_1(object sender, MouseEventArgs e)
        {
            information.Content = "";
        }

        private void passwordText_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                buttonConnect_Click(sender, e);
            }
        }

        private void buttonConnect_Click(object sender, RoutedEventArgs e)
        {
            if (passwordText.Password == "")
            {
                MessageBox.Show("Please, input password!");
            }
            else
            {
                MySqlConnection connection = new MySqlConnection("server = localhost;port = 3306; username = root; password =" + passwordText.Password + " ; database = accesspoint");
                try
                {
                    connection.Open();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message,"Error");
                }

                if (connection.State == ConnectionState.Open)
                {
                    
                    dbData dbWindow = new dbData();
                    dbWindow.Pass = passwordText.Password;
                    dbWindow.Show();
                    authorizationWindow.Close();

                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
