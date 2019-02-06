using MySql.Data.MySqlClient;

namespace WebApplication1.Controllers
{
    public class DeleteRequest
    {
        public string Delete(int id)
        {
            Connect connect = new Connect();
            MySqlConnection mySqlConnect = connect.SqlConnect();//объект, который открывает соединение

            string cmdStatus = "";

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = string.Format("delete from organizer where id = {0}", id),
                Connection = mySqlConnect
            };

            int countRows = cmd.ExecuteNonQuery();

            try
            {
                mySqlConnect.Close();
                return "Delete!";
            }
            catch (MySqlException ex)
            {
                cmdStatus = ex.Message;
                mySqlConnect.Close();
                return cmdStatus;
            }
        }
    }
}
