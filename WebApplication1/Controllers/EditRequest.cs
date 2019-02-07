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
                CommandText = string.Format("update organizer set dateBind = {0}, title = {1}, descr = {2}, isPin = {3}, isComplete = {4} where id = {5}", 
                response.dateBind, response.title, response.descr, response.isPin, response.isComplete, response.id),
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
