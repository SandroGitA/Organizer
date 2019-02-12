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

            //dynamic json = JObject.Parse(jsonString);
            Data responseJsonString = JsonConvert.DeserializeObject<Data>(jsonString);

            if ((bool)responseJsonString.isPin == true)
                responseJsonString.isPin = 1;
            else if ((bool)responseJsonString.isPin == false)
                responseJsonString.isPin = 0;

            if ((bool)responseJsonString.isComplete == true)
                responseJsonString.isComplete = 1;
            else if ((bool)responseJsonString.isComplete == false)
                responseJsonString.isComplete = 0;           

            double milliseconds = (long)responseJsonString.dateBind;
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(milliseconds);
            DateTime dateTime = new DateTime(1970, 1, 1);
            DateTime endDateTime = dateTime.AddHours(5);

            //responseJsonString.dateBind = endDateTime.Add(timeSpan);
            //responseJsonString.dateCreate = endDateTime.Add(timeSpan);

            string dtBind = endDateTime.Add(timeSpan).ToString("yyyy.MM.dd HH:mm:ss");
            string dtCreate = endDateTime.Add(timeSpan).ToString("yyyy.MM.dd HH:mm:ss");

            int id = Guid.NewGuid().GetHashCode();
            responseJsonString.id = id;

            string cmdStatus = "";

            MySqlCommand cmd = new MySqlCommand
            {               
                CommandText = $"INSERT INTO organizer (id, dateBind, dateCreate, title, descr, isPin, isComplete) values('{responseJsonString.id}','{dtBind}','{dtCreate}'," +
                $"'{responseJsonString.title}','{responseJsonString.descr}','{responseJsonString.isPin}','{responseJsonString.isComplete}')",
                Connection = mySqlConnect,
            };

            //int countRows = cmd.ExecuteNonQuery();

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
