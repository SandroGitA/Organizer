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
            MySqlConnection mySqlConnect = connect.SqlConnect();

            Data responseJsonString = JsonConvert.DeserializeObject<Data>(jsonString);

            responseJsonString.isPin = ConvertBoolField.Convert(responseJsonString.isPin);
            responseJsonString.isComplete = ConvertBoolField.Convert(responseJsonString.isComplete);

            string dateBind = ConvertDataField.Convert(responseJsonString.dateBind);
            string dateCreate = ConvertDataField.Convert(responseJsonString.dateCreate);

            responseJsonString.id = Guid.NewGuid().GetHashCode();

            string cmdStatus = "";

            MySqlCommand cmd = new MySqlCommand
            {               
                CommandText = $"INSERT INTO organizer (id, dateBind, dateCreate, title, descr, isPin, isComplete) " +
                $"values('{responseJsonString.id}','{dateBind}','{dateCreate}'," +
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
