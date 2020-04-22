using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;


namespace AccessPoint
{
    /// <summary>
    /// Логика взаимодействия для viewWindow.xaml
    /// </summary>
    public partial class viewWindow : Window
    {
        public viewWindow()
        {
            InitializeComponent();
            viewWin.Title = "View Tables";
        }

        private void viewButton_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server = localhost;port = 3306; username = root; password =" + GivePass.Pass + "; database = accesspoint");
            DataTable table = new DataTable();

            if (tableBox.Text == "Кабинеты")
            {

                MySqlCommand command = new MySqlCommand("SELECT number_of_room, categories FROM room" +
                    "                                    LEFT JOIN categories ON room.categories_idcategories = categories.idcategories", connection);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                dbDataGrid.AutoGenerateColumns = true;
                dbDataGrid.ItemsSource = table.DefaultView;

                connection.Close();
            }
            if (tableBox.Text == "Кафедры")
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM cathedras ", connection);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                dbDataGrid.AutoGenerateColumns = true;
                dbDataGrid.ItemsSource = table.DefaultView;

                connection.Close();
            }
            if (tableBox.Text == "Название абонентского пункта")
            {
                MySqlCommand command = new MySqlCommand("SELECT name,number_of_room,categories,number_of_cathedras,date,isProtected " +
                    "                                    FROM name_of_access_point " +
                    "                                    LEFT JOIN cathedras ON name_of_access_point.cathedras_idcathedras = cathedras.idcathedras " +
                    "                                    LEFT JOIN is_protected_access_point ON name_of_access_point.is_protected_access_point_idis_protected_access_point = is_protected_access_point.idis_protected_access_point " +
                    "                                    LEFT JOIN installation_date ON name_of_access_point.installation_date_idinstallation_date = installation_date.idinstallation_date " +
                    "                                    LEFT JOIN room ON name_of_access_point.Room_idRoom = room.idRoom " +
                    "                                    LEFT JOIN categories ON room.categories_idcategories = categories.idcategories", connection);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                dbDataGrid.AutoGenerateColumns = true;
                dbDataGrid.ItemsSource = table.DefaultView;

                connection.Close();
            }
            if (tableBox.Text == "Защищенность")
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM is_protected_access_point ", connection);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                dbDataGrid.AutoGenerateColumns = true;
                dbDataGrid.ItemsSource = table.DefaultView;

                connection.Close();
            }
            if (tableBox.Text == "Дата установки")
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM installation_date ", connection);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                dbDataGrid.AutoGenerateColumns = true;
                dbDataGrid.ItemsSource = table.DefaultView;

                connection.Close();
            }
            if (tableBox.Text == "Категории")
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM categories ", connection);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                dbDataGrid.AutoGenerateColumns = true;
                dbDataGrid.ItemsSource = table.DefaultView;

                connection.Close();
            }
            if (tableBox.Text == "Таблицы")
            {
                MessageBox.Show("Chooce conditions!", "Warning");
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            dbData dbDataWin = new dbData();
            dbDataWin.Show();
            viewWin.Close();
        }
    }
}
