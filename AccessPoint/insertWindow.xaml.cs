using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;


namespace AccessPoint
{
    /// <summary>
    /// Логика взаимодействия для insertWindow.xaml
    /// </summary>
    public partial class insertWindow : Window
    {
        public insertWindow()
        {
            InitializeComponent();
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            dbData dbDataWin = new dbData();
            dbDataWin.Show();
            insertwWin.Close();
        }
    }
}
