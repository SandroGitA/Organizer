using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace WebApplication1.Controllers
{
    public class Connect
    {
        static string server = "localhost";
        //static string user = "root";
        static string database = "organizer";
        static int port = 3306;
        //static string password = "root1311";
        static string password = "mysql";
        static string user = "mysql";

        static string connectionString = "server = " + server + "; user = " + user + "; database = " + database + "; port = " + port + "; password = " + password;
        string connectStatus = "";

        public MySqlConnection SqlConnect()
        {
            MySqlConnection connectMySql = new MySqlConnection(connectionString);

            try
            {
                connectMySql.Open();
                //connectStatus = "OK";
            }
            catch (SqlException ex)
            {
                connectStatus = ex.Message;
                //return new string[] { connectStatus };
            }

            return connectMySql;
        }
    }
}
