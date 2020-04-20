using MySql.Data.MySqlClient;


namespace AccessPoint
{
    static class DataBase
    {
        public static MySqlConnection connection = new MySqlConnection("server = localhost;port = 3306; username = root; password = Ghjcnjgfhjkm; database = users");
        public static void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public static void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public static MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
