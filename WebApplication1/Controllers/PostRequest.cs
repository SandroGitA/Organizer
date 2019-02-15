using System;
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

            Data responseJsonString = JsonConvert.DeserializeObject<Data>(jsonString);

            responseJsonString.isPin = ConvertBoolField.Convert(responseJsonString.isPin);
            responseJsonString.isComplete = ConvertBoolField.Convert(responseJsonString.isComplete);

            string dtBind = ConvertDataField.Convert(responseJsonString.dateBind);
            string dtCreate = ConvertDataField.Convert(responseJsonString.dateCreate);           

            int id = Guid.NewGuid().GetHashCode();
            responseJsonString.id = id;

            string cmdStatus = "";

            MySqlCommand cmd = new MySqlCommand
            {               
                CommandText = $"INSERT INTO organizer (id, dateBind, dateCreate, title, descr, isPin, isComplete) " +
                $"values('{responseJsonString.id}','{dtBind}','{dtCreate}'," +
                $"'{responseJsonString.title}','{responseJsonString.descr}','{responseJsonString.isPin}'," +
                $"'{responseJsonString.isComplete}')",
                Connection = mySqlConnect,
            };

            try
            {
                int countRows = cmd.ExecuteNonQuery();
                mySqlConnect.Close();
                return responseJsonString.id.ToString();
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
