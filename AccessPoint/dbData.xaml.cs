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
            MySqlConnection connection = new MySqlConnection("server = localhost;port = 3306; username = root; password = Ghjcnjgfhjkm ; database = accesspoint");
            DataTable table = new DataTable();

            // select only categories
            if ((roomNameText.Text.Equals("") && kafedrNameText.Text.Equals("") && isProtectedComboBox.Text.Equals("Защищённость") && kalendarDatePicker.SelectedDate == null) ||
                (roomNameText.Text.Equals("room") && kafedrNameText.Text.Equals("kafedras") && isProtectedComboBox.Text.Equals("Защищённость") && kalendarDatePicker.SelectedDate == null) ||
                (roomNameText.Text.Equals("room") && kafedrNameText.Text.Equals("") && isProtectedComboBox.Text.Equals("Защищённость") && kalendarDatePicker.SelectedDate == null) ||
                (roomNameText.Text.Equals("") && kafedrNameText.Text.Equals("kafedras") && isProtectedComboBox.Text.Equals("Защищённость") && kalendarDatePicker.SelectedDate == null))
            {
                MySqlCommand command = new MySqlCommand("SELECT name,number_of_room,categories,number_of_cathedras,date,isProtected " +
                    "                                    FROM name_of_access_point " +
                    "                                    LEFT JOIN cathedras ON name_of_access_point.cathedras_idcathedras = cathedras.idcathedras " +
                    "                                    LEFT JOIN is_protected_access_point ON name_of_access_point.is_protected_access_point_idis_protected_access_point = is_protected_access_point.idis_protected_access_point " +
                    "                                    LEFT JOIN installation_date ON name_of_access_point.installation_date_idinstallation_date = installation_date.idinstallation_date " +
                    "                                    LEFT JOIN room ON name_of_access_point.Room_idRoom = room.idRoom " +
                    "                                    LEFT JOIN categories ON room.categories_idcategories = categories.idcategories" +
                "                                    WHERE categories = \"" + categoriesComboBox.Text + "\"", connection);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                dbDataGrid.AutoGenerateColumns = true;
                dbDataGrid.ItemsSource = table.DefaultView;

                connection.Close();
            }
            //select only rooms
            if ((categoriesComboBox.Text.Equals("Категории") && kafedrNameText.Text.Equals("") && isProtectedComboBox.Text.Equals("Защищённость") && kalendarDatePicker.SelectedDate == null) || 
                (categoriesComboBox.Text.Equals("Категории") && kafedrNameText.Text.Equals("kafedras") && isProtectedComboBox.Text.Equals("Защищённость") && kalendarDatePicker.SelectedDate == null))
            {
                MySqlCommand command = new MySqlCommand("SELECT name,number_of_room,categories,number_of_cathedras,date,isProtected " +
                    "                                    FROM name_of_access_point " +
                    "                                    LEFT JOIN cathedras ON name_of_access_point.cathedras_idcathedras = cathedras.idcathedras " +
                    "                                    LEFT JOIN is_protected_access_point ON name_of_access_point.is_protected_access_point_idis_protected_access_point = is_protected_access_point.idis_protected_access_point " +
                    "                                    LEFT JOIN installation_date ON name_of_access_point.installation_date_idinstallation_date = installation_date.idinstallation_date " +
                    "                                    LEFT JOIN room ON name_of_access_point.Room_idRoom = room.idRoom " +
                    "                                    LEFT JOIN categories ON room.categories_idcategories = categories.idcategories" +
                    "                                    WHERE number_of_room = \"" + roomNameText.Text + "\"", connection);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                dbDataGrid.AutoGenerateColumns = true;
                dbDataGrid.ItemsSource = table.DefaultView;

                connection.Close();
            }
            //select only kafedras
            if ((categoriesComboBox.Text.Equals("Категории") && roomNameText.Text.Equals("") && isProtectedComboBox.Text.Equals("Защищённость") && kalendarDatePicker.SelectedDate == null) ||
                (categoriesComboBox.Text.Equals("Категории") && roomNameText.Text.Equals("room") && isProtectedComboBox.Text.Equals("Защищённость") && kalendarDatePicker.SelectedDate == null))
            {
                MySqlCommand command = new MySqlCommand("SELECT name,number_of_room,categories,number_of_cathedras,date,isProtected " +
                    "                                    FROM name_of_access_point " +
                    "                                    LEFT JOIN cathedras ON name_of_access_point.cathedras_idcathedras = cathedras.idcathedras " +
                    "                                    LEFT JOIN is_protected_access_point ON name_of_access_point.is_protected_access_point_idis_protected_access_point = is_protected_access_point.idis_protected_access_point " +
                    "                                    LEFT JOIN installation_date ON name_of_access_point.installation_date_idinstallation_date = installation_date.idinstallation_date " +
                    "                                    LEFT JOIN room ON name_of_access_point.Room_idRoom = room.idRoom " +
                    "                                    LEFT JOIN categories ON room.categories_idcategories = categories.idcategories" +
                    "                                    WHERE number_of_cathedras = \"" + kafedrNameText.Text + "\"", connection);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                dbDataGrid.AutoGenerateColumns = true;
                dbDataGrid.ItemsSource = table.DefaultView;

                connection.Close();
            }
            //select only protected
            if ((categoriesComboBox.Text.Equals("Категории") && roomNameText.Text.Equals("") && kafedrNameText.Text.Equals("") && kalendarDatePicker.SelectedDate == null) ||
                (categoriesComboBox.Text.Equals("Категории") && roomNameText.Text.Equals("room") && kafedrNameText.Text.Equals("kafedras") && kalendarDatePicker.SelectedDate == null))
            {
                MySqlCommand command = new MySqlCommand("SELECT name,number_of_room,categories,number_of_cathedras,date,isProtected " +
                    "                                    FROM name_of_access_point " +
                    "                                    LEFT JOIN cathedras ON name_of_access_point.cathedras_idcathedras = cathedras.idcathedras " +
                    "                                    LEFT JOIN is_protected_access_point ON name_of_access_point.is_protected_access_point_idis_protected_access_point = is_protected_access_point.idis_protected_access_point " +
                    "                                    LEFT JOIN installation_date ON name_of_access_point.installation_date_idinstallation_date = installation_date.idinstallation_date " +
                    "                                    LEFT JOIN room ON name_of_access_point.Room_idRoom = room.idRoom " +
                    "                                    LEFT JOIN categories ON room.categories_idcategories = categories.idcategories" +
                    "                                    WHERE isProtected = \"" + isProtectedComboBox.Text + "\"", connection);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                dbDataGrid.AutoGenerateColumns = true;
                dbDataGrid.ItemsSource = table.DefaultView;

                connection.Close();
            }

            //select only date
            if ((categoriesComboBox.Text.Equals("Категории") && roomNameText.Text.Equals("") && kafedrNameText.Text.Equals("") && isProtectedComboBox.Text.Equals("Защищённость")) ||
                (categoriesComboBox.Text.Equals("Категории") && roomNameText.Text.Equals("room") && kafedrNameText.Text.Equals("kafedras") && isProtectedComboBox.Text.Equals("Защищённость")))
            {
                MySqlCommand command = new MySqlCommand("SELECT name,number_of_room,categories,number_of_cathedras,date,isProtected " +
                    "                                    FROM name_of_access_point " +
                    "                                    LEFT JOIN cathedras ON name_of_access_point.cathedras_idcathedras = cathedras.idcathedras " +
                    "                                    LEFT JOIN is_protected_access_point ON name_of_access_point.is_protected_access_point_idis_protected_access_point = is_protected_access_point.idis_protected_access_point " +
                    "                                    LEFT JOIN installation_date ON name_of_access_point.installation_date_idinstallation_date = installation_date.idinstallation_date " +
                    "                                    LEFT JOIN room ON name_of_access_point.Room_idRoom = room.idRoom " +
                    "                                    LEFT JOIN categories ON room.categories_idcategories = categories.idcategories" +
                    "                                    WHERE isProtected = \"" + kalendarDatePicker.SelectedDate.Value.ToString("yyyy-MM-dd") + "\"", connection);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                dbDataGrid.AutoGenerateColumns = true;
                dbDataGrid.ItemsSource = table.DefaultView;

                connection.Close();
            }


            //select rooms and categories
            if (kafedrNameText.Text.Equals("") || kafedrNameText.Text.Equals("kafedras"))
            {
                MySqlCommand command = new MySqlCommand("SELECT name,number_of_room,categories,number_of_cathedras,date,isProtected " +
                    "                                    FROM name_of_access_point " +
                    "                                    LEFT JOIN cathedras ON name_of_access_point.cathedras_idcathedras = cathedras.idcathedras " +
                    "                                    LEFT JOIN is_protected_access_point ON name_of_access_point.is_protected_access_point_idis_protected_access_point = is_protected_access_point.idis_protected_access_point " +
                    "                                    LEFT JOIN installation_date ON name_of_access_point.installation_date_idinstallation_date = installation_date.idinstallation_date " +
                    "                                    LEFT JOIN room ON name_of_access_point.Room_idRoom = room.idRoom " +
                    "                                    LEFT JOIN categories ON room.categories_idcategories = categories.idcategories" +
                    "                                    WHERE number_of_room = \"" + roomNameText.Text + "\" AND categories = \"" + categoriesComboBox.Text + "\"", connection);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                dbDataGrid.AutoGenerateColumns = true;
                dbDataGrid.ItemsSource = table.DefaultView;

                connection.Close();
            }
            //select kafedr and categories
            if (roomNameText.Text.Equals("") || roomNameText.Text.Equals("room"))
            {
                MySqlCommand command = new MySqlCommand("SELECT name,number_of_room,categories,number_of_cathedras,date,isProtected " +
                    "                                    FROM name_of_access_point " +
                    "                                    LEFT JOIN cathedras ON name_of_access_point.cathedras_idcathedras = cathedras.idcathedras " +
                    "                                    LEFT JOIN is_protected_access_point ON name_of_access_point.is_protected_access_point_idis_protected_access_point = is_protected_access_point.idis_protected_access_point " +
                    "                                    LEFT JOIN installation_date ON name_of_access_point.installation_date_idinstallation_date = installation_date.idinstallation_date " +
                    "                                    LEFT JOIN room ON name_of_access_point.Room_idRoom = room.idRoom " +
                    "                                    LEFT JOIN categories ON room.categories_idcategories = categories.idcategories" +
                    "                                    WHERE number_of_cathedras = \"" + kafedrNameText.Text + "\" AND categories = \"" + categoriesComboBox.Text + "\"", connection);

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
                    "                                    WHERE number_of_cathedras = \"" + kafedrNameText.Text + "\" AND " +
                    "                                          number_of_room = \"" + roomNameText.Text + "\"AND " +
                    "                                          categories = \"" + categoriesComboBox.Text + "\" AND " +
                    "                                          isProtected = \"" + isProtectedComboBox.Text + "\" AND " +
                    "                                          date = \"" + kalendarDatePicker.SelectedDate.Value.ToString("yyyy-MM-dd") + "\"", connection);

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
            roomNameText.Text = "";
        }

        private void kafedrName_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            kafedrNameText.Text = "";
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

        private void kalendar_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            kalendarDatePicker.Text = "";
        }
    }
}
