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

            EditDataObject buildDataObject = new EditDataObject();
            EditTask responseJsonString = buildDataObject.BuildData(jsonString);

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = $"update organizer set {responseJsonString.propName} = " +
                $"'{responseJsonString.value}' where id = '{responseJsonString.id}' ",
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
