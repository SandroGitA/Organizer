using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApplication1.Controllers
{
    public class PostRequest
    {
        public string PostJson(string jsonString)
        {
            Connect connect = new Connect();
            MySqlConnection mySqlConnect = connect.SqlConnect();//объект, который открывает соединение           

            dynamic json = JObject.Parse(jsonString);
            var response = JsonConvert.DeserializeObject<Data>(jsonString);
            
            string cmdStatus = "";

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "INSERT INTO organizer (id, dateBind, dateCreate, title, descr, isPin, isComplete)" +
                " VALUES('"+ response.id +"', '"+ response.dateBind +"', '"+ response.dateCreate +"'," +
                " '"+ response.title +"', '"+ response.descr + "','"+ response.isPin +"', '"+ response.isComplete +"')",
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
