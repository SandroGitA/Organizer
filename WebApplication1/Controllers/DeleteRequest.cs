using MySql.Data.MySqlClient;

namespace WebApplication1.Controllers
{
    public class DeleteRequest
    {
        public string Delete(string jsonString)
        {
            Connect connect = new Connect();
            MySqlConnection mySqlConnect = connect.SqlConnect();

            DeleteDataObject deleteDataObject = new DeleteDataObject();
            DeleteTask deleteTask = deleteDataObject.BuildData(jsonString);

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = $"delete from organizer where id = {deleteTask.id}",
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
                string cmdStatus = ex.Message;
                mySqlConnect.Close();
                return cmdStatus;
            }
        }
    }
}
