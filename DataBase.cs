using MySql.Data.MySqlClient;


namespace AccessPoint
{
    class DataBase
    {

        MySqlConnection connection = new MySqlConnection("server = localhost;port = 3306; username = root; password = ; database = users");
        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
