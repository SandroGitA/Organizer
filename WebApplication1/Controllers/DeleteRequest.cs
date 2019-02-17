using MySql.Data.MySqlClient;

namespace WebApplication1.Controllers
{
    public class DeleteRequest
    {
        public string Delete(int id)
        {
            Connect connect = new Connect();
            MySqlConnection mySqlConnect = connect.SqlConnect();

            string cmdStatus = "";

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = $"delete from organizer where id = {id}",
                Connection = mySqlConnect
            };
            
            try
            {
                int countRows = cmd.ExecuteNonQuery();
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
