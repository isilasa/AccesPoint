using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;


namespace AccessPoint
{
    /// <summary>
    /// Логика взаимодействия для dbData.xaml
    /// </summary>
    public partial class dbData : Window
    {
        public dbData()
        {
            InitializeComponent();
            dbWindow.Title = "DataBase";
        }
        private void buttonSelect_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server = localhost;port = 3306; username = root; password = 1123581321Bkmz ; database = accesspoint");
            DataTable table = new DataTable();

            if (tableBox.Text == "Кабинеты")
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM `room` ", connection);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                dbDataGrid.AutoGenerateColumns = true;
                dbDataGrid.ItemsSource = table.DefaultView;

                connection.Close();
            }
            if(tableBox.Text == "Кафедры")
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM `cathedras` ", connection);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                dbDataGrid.AutoGenerateColumns = true;
                dbDataGrid.ItemsSource = table.DefaultView;

                connection.Close();
            }
            if (tableBox.Text == "Название Абонентского пункта")
            {
                MySqlCommand command = new MySqlCommand("SELECT `name`,`number_of_room`,`categories` FROM `name_of_access_point` LEFT JOIN `room` ON name_of_access_point.idtable1 = room.idRoom LEFT JOIN `categories` ON room.categories_idcategories = categories.idcategories", connection);

                connection.Open();

                 MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                dbDataGrid.AutoGenerateColumns = true;
                dbDataGrid.ItemsSource = table.DefaultView;

                connection.Close();
            }
            if (tableBox.Text == "Защищенность")
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM `is_protected_access_point` ", connection);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                dbDataGrid.AutoGenerateColumns = true;
                dbDataGrid.ItemsSource = table.DefaultView;

                connection.Close();
            }
            if (tableBox.Text == "Дата установки")
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM `installation_date` ", connection);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                dbDataGrid.AutoGenerateColumns = true;
                dbDataGrid.ItemsSource = table.DefaultView;

                connection.Close();
            }
            if (tableBox.Text == "Категории")
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM `categories` ", connection);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                dbDataGrid.AutoGenerateColumns = true;
                dbDataGrid.ItemsSource = table.DefaultView;

                connection.Close();
            }
            if (tableBox.Text == "Таблицы")
            {
                MessageBox.Show("Chooce conditions!","Warning");
            }
        }
    }
}
