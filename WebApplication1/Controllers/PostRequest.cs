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

            dynamic json = JObject.Parse(jsonString);
            var response = JsonConvert.DeserializeObject<Data>(jsonString);

            if ((bool)response.isPin == true)
                response.isPin = 1;
            else if ((bool)response.isPin == false)
                response.isPin = 0;

            if ((bool)response.isComplete == true)
                response.isComplete = 1;
            else if ((bool)response.isComplete == false)
                response.isComplete = 0;

            DateTime dateTime = new DateTime(1970, 1, 1);
            TimeSpan timeSpan = TimeSpan.FromMilliseconds((double)response.dateBind);
            dateTime += timeSpan;

            string cmdStatus = "";

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "INSERT INTO organizer (id, dateBind, dateCreate, title, descr, isPin, isComplete)" +
                " VALUES('"+ response.id +"', '"+ response.dateBind +"', '"+ response.dateCreate +"'," +
                " '"+ response.title +"', '"+ response.descr + "','"+ response.isPin +"', '"+ response.isComplete +"')",
                Connection = mySqlConnect,
            };

            //int countRows = cmd.ExecuteNonQuery();

            try
            {
                int countRows = cmd.ExecuteNonQuery();
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
