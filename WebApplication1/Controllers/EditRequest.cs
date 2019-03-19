using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApplication1.Controllers
{
    public class EditRequest
    {
        public string Edit(string jsonString)
        {
            Connect connect = new Connect();
            MySqlConnection mySqlConnect = connect.SqlConnect();

            BuildDataObject buildDataObject = new BuildDataObject();
            newTask responseJsonString = buildDataObject.BuildData(jsonString);           

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = $"update organizer set title = '{responseJsonString.title}', " +
                $"descr = '{responseJsonString.descr}', isPin = '{responseJsonString.isPin}', " +
                $"isComplete = '{responseJsonString.isComplete}' where id = '{responseJsonString.id}'",
                Connection = mySqlConnect
            };
          
            try
            {
                int countRows = cmd.ExecuteNonQuery();
                mySqlConnect.Close();
                return "Edit!";
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
