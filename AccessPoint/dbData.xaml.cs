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

            if ((roomName.Text.Equals("") && kafedrName.Text.Equals("")) ||
                (roomName.Text.Equals("room") && kafedrName.Text.Equals("kafedras")) ||
                (roomName.Text.Equals("room") && kafedrName.Text.Equals("")) ||
                (roomName.Text.Equals("") && kafedrName.Text.Equals("kafedras")))// select onlu categories
            {
                MySqlCommand command = new MySqlCommand("SELECT name,number_of_room,categories,number_of_cathedras,date,isProtected " +
                    "                                    FROM name_of_access_point " +
                    "                                    LEFT JOIN cathedras ON name_of_access_point.cathedras_idcathedras = cathedras.idcathedras " +
                    "                                    LEFT JOIN is_protected_access_point ON name_of_access_point.is_protected_access_point_idis_protected_access_point = is_protected_access_point.idis_protected_access_point " +
                    "                                    LEFT JOIN installation_date ON name_of_access_point.installation_date_idinstallation_date = installation_date.idinstallation_date " +
                    "                                    LEFT JOIN room ON name_of_access_point.Room_idRoom = room.idRoom " +
                    "                                    LEFT JOIN categories ON room.categories_idcategories = categories.idcategories" +
                "                                    WHERE categories = \"" + categories.Text + "\"", connection);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                dbDataGrid.AutoGenerateColumns = true;
                dbDataGrid.ItemsSource = table.DefaultView;

                connection.Close();
            }
            if ((categories.Text.Equals("Категории") && kafedrName.Text.Equals("")) || 
                (categories.Text.Equals("Категории") && kafedrName.Text.Equals("kafedras")))//select only rooms
            {
                MySqlCommand command = new MySqlCommand("SELECT name,number_of_room,categories,number_of_cathedras,date,isProtected " +
                    "                                    FROM name_of_access_point " +
                    "                                    LEFT JOIN cathedras ON name_of_access_point.cathedras_idcathedras = cathedras.idcathedras " +
                    "                                    LEFT JOIN is_protected_access_point ON name_of_access_point.is_protected_access_point_idis_protected_access_point = is_protected_access_point.idis_protected_access_point " +
                    "                                    LEFT JOIN installation_date ON name_of_access_point.installation_date_idinstallation_date = installation_date.idinstallation_date " +
                    "                                    LEFT JOIN room ON name_of_access_point.Room_idRoom = room.idRoom " +
                    "                                    LEFT JOIN categories ON room.categories_idcategories = categories.idcategories" +
                    "                                    WHERE number_of_room = \"" + roomName.Text + "\"", connection);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                dbDataGrid.AutoGenerateColumns = true;
                dbDataGrid.ItemsSource = table.DefaultView;

                connection.Close();
            }
            if ((categories.Text.Equals("Категории") && roomName.Text.Equals("")) ||
                (categories.Text.Equals("Категории") && roomName.Text.Equals("room")))//select only kafedras
            {
                MySqlCommand command = new MySqlCommand("SELECT name,number_of_room,categories,number_of_cathedras,date,isProtected " +
                    "                                    FROM name_of_access_point " +
                    "                                    LEFT JOIN cathedras ON name_of_access_point.cathedras_idcathedras = cathedras.idcathedras " +
                    "                                    LEFT JOIN is_protected_access_point ON name_of_access_point.is_protected_access_point_idis_protected_access_point = is_protected_access_point.idis_protected_access_point " +
                    "                                    LEFT JOIN installation_date ON name_of_access_point.installation_date_idinstallation_date = installation_date.idinstallation_date " +
                    "                                    LEFT JOIN room ON name_of_access_point.Room_idRoom = room.idRoom " +
                    "                                    LEFT JOIN categories ON room.categories_idcategories = categories.idcategories" +
                    "                                    WHERE number_of_cathedras = \"" + kafedrName.Text + "\"", connection);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                dbDataGrid.AutoGenerateColumns = true;
                dbDataGrid.ItemsSource = table.DefaultView;

                connection.Close();
            }
            if (kafedrName.Text.Equals("") || kafedrName.Text.Equals("kafedras"))//select rooms and categories
            {
                MySqlCommand command = new MySqlCommand("SELECT name,number_of_room,categories,number_of_cathedras,date,isProtected " +
                    "                                    FROM name_of_access_point " +
                    "                                    LEFT JOIN cathedras ON name_of_access_point.cathedras_idcathedras = cathedras.idcathedras " +
                    "                                    LEFT JOIN is_protected_access_point ON name_of_access_point.is_protected_access_point_idis_protected_access_point = is_protected_access_point.idis_protected_access_point " +
                    "                                    LEFT JOIN installation_date ON name_of_access_point.installation_date_idinstallation_date = installation_date.idinstallation_date " +
                    "                                    LEFT JOIN room ON name_of_access_point.Room_idRoom = room.idRoom " +
                    "                                    LEFT JOIN categories ON room.categories_idcategories = categories.idcategories" +
                    "                                    WHERE number_of_room = \"" + roomName.Text + "\" AND categories = \"" + categories.Text + "\"", connection);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                dbDataGrid.AutoGenerateColumns = true;
                dbDataGrid.ItemsSource = table.DefaultView;

                connection.Close();
            }
            if (roomName.Text.Equals("") || roomName.Text.Equals("room"))//select kafedr and categories
            {
                MySqlCommand command = new MySqlCommand("SELECT name,number_of_room,categories,number_of_cathedras,date,isProtected " +
                    "                                    FROM name_of_access_point " +
                    "                                    LEFT JOIN cathedras ON name_of_access_point.cathedras_idcathedras = cathedras.idcathedras " +
                    "                                    LEFT JOIN is_protected_access_point ON name_of_access_point.is_protected_access_point_idis_protected_access_point = is_protected_access_point.idis_protected_access_point " +
                    "                                    LEFT JOIN installation_date ON name_of_access_point.installation_date_idinstallation_date = installation_date.idinstallation_date " +
                    "                                    LEFT JOIN room ON name_of_access_point.Room_idRoom = room.idRoom " +
                    "                                    LEFT JOIN categories ON room.categories_idcategories = categories.idcategories" +
                    "                                    WHERE number_of_cathedras = \"" + kafedrName.Text + "\" AND categories = \"" + categories.Text + "\"", connection);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                dbDataGrid.AutoGenerateColumns = true;
                dbDataGrid.ItemsSource = table.DefaultView;

                connection.Close();
            }

            else//select evrething
            {
                MySqlCommand command = new MySqlCommand("SELECT name,number_of_room,categories,number_of_cathedras,date,isProtected " +
                    "                                    FROM name_of_access_point " +
                    "                                    LEFT JOIN cathedras ON name_of_access_point.cathedras_idcathedras = cathedras.idcathedras " +
                    "                                    LEFT JOIN is_protected_access_point ON name_of_access_point.is_protected_access_point_idis_protected_access_point = is_protected_access_point.idis_protected_access_point " +
                    "                                    LEFT JOIN installation_date ON name_of_access_point.installation_date_idinstallation_date = installation_date.idinstallation_date " +
                    "                                    LEFT JOIN room ON name_of_access_point.Room_idRoom = room.idRoom " +
                    "                                    LEFT JOIN categories ON room.categories_idcategories = categories.idcategories" +
                    "                                    WHERE number_of_cathedras = \"" + kafedrName.Text + "\" AND " +
                    "                                          number_of_room = \"" + roomName.Text + "\"AND " +
                    "                                          categories = \"" + categories.Text + "\" AND " +
                    "                                          isProtected = \"" + isProtected.Text + "\" AND " +
                    "                                          date = \"" + kalendar.SelectedDate + "\"", connection);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                dbDataGrid.AutoGenerateColumns = true;
                dbDataGrid.ItemsSource = table.DefaultView;

                connection.Close();
            }
        }


        private void roomName_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            roomName.Text = "";
        }

        private void kafedrName_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            kafedrName.Text = "";
        }

        private void viewButton_Click(object sender, RoutedEventArgs e)
        {
            viewWindow viewWin = new viewWindow();
            viewWin.Show();
            dbWindow.Close();
        }

        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            insertWindow insertWin = new insertWindow();
            insertWin.Show();
            dbWindow.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            deleteWindow deleteWin = new deleteWindow();
            deleteWin.Show();
            dbWindow.Close();
        }
    }
}
