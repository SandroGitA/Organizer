using MySql.Data.MySqlClient;

namespace WebApplication1.Controllers
{
    public class PostRequest
    {
        public string PostJson(string jsonString)
        {
            Connect connect = new Connect();
            MySqlConnection mySqlConnect = connect.SqlConnect();//объект, который открывает соединение           

            string cmdStatus = "";

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "INSERT INTO organizer (id, label, done, important) VALUES('"+ jsonString +"', '"+ 1 +"', '"+ 2 +"', '"+ 3 +"')",
                Connection = mySqlConnect,
            };

            int countRows = cmd.ExecuteNonQuery();

            try
            {
                mySqlConnect.Close();
                return "OK";
            }
            catch(MySqlException ex)
            {
                cmdStatus = ex.Message;
                mySqlConnect.Close();
                return "Error: " + cmdStatus;
            }
        }
    }
}
