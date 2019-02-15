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
            MySqlConnection mySqlConnect = connect.SqlConnect();//объект, который открывает соединение

            Data responseJsonString = JsonConvert.DeserializeObject<Data>(jsonString);            

            responseJsonString.isPin = ConvertBoolField.Build(responseJsonString.isPin);
            responseJsonString.isComplete = ConvertBoolField.Build(responseJsonString.isComplete);

            string cmdStatus = "";

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = $"update organizer set title = '{responseJsonString.title}', " +
                $"descr = '{responseJsonString.descr}', isPin = '{responseJsonString.isPin}', " +
                $"isComplete = '{responseJsonString.isComplete}' where id = '{responseJsonString.id}'",
                Connection = mySqlConnect
            };

            int countRows = cmd.ExecuteNonQuery();

            try
            {
                mySqlConnect.Close();
                return "Edit!";
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
