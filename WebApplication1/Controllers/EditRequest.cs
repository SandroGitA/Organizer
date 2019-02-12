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

            dynamic json = JObject.Parse(jsonString);
            var response = JsonConvert.DeserializeObject<Data>(jsonString);

            string cmdStatus = "";

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = $"update organizer set dateBind = {response.dateBind}, title = {response.title}, " +
                $"descr = {response.descr}, isPin = {response.isPin}, " +
                $"isComplete = {response.isComplete} where id = {response.id}",
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
