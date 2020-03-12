using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;

namespace AccessPoint
{
    /// <summary>
    /// Логика взаимодействия для deleteWindow.xaml
    /// </summary>
    public partial class deleteWindow : Window
    {
        public deleteWindow()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            dbData dbDataWin = new dbData();
            dbDataWin.Show();
            deleteWin.Close();
        }
    }
}
