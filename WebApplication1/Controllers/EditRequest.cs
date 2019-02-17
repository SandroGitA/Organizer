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

            Data responseJsonString = JsonConvert.DeserializeObject<Data>(jsonString);            

            responseJsonString.isPin = ConvertBoolField.Convert(responseJsonString.isPin);
            responseJsonString.isComplete = ConvertBoolField.Convert(responseJsonString.isComplete);

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
