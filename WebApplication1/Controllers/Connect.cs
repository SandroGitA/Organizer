using MySql.Data.MySqlClient;

namespace WebApplication1.Controllers
{
    public class Connect
    {        
        //static string user = "root";//данные для рабочего сервера
        //static string password = "root1311";//данные для рабочего сервера

        static readonly string password = "mysql";//test server
        static readonly string user = "mysql";//test server

        static readonly string database = "organizer";
        static readonly int port = 3306;
        static readonly string server = "localhost";
        static readonly string charset = "utf8";

        static readonly string connectionString = $"server = {server}; user = {user}; " +
            $"database = {database}; port = {port}; password = {password}; charset = {charset}";
        string connectStatus = "";

        public MySqlConnection SqlConnect()
        {
            MySqlConnection connectMySql = new MySqlConnection(connectionString);
            try
            {
                connectMySql.Open();
            }
            catch (MySqlException ex)
            {
                connectStatus = ex.Message;//записываем сообщение об ошибке, но не возвращаем его(!)
            }
            return connectMySql;
        }
    }
}
