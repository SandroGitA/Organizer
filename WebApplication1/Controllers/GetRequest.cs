using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class GetRequest
    {
        public string GetJson()
        {
            List<Data> JsonData = new List<Data>();

            Connect connect = new Connect();
            MySqlConnection mySqlConnect = connect.SqlConnect();//объект, который открывает соединение

            MySqlCommand cmd = new MySqlCommand//запрос к БД
            {
                CommandText = "SELECT * FROM organizer",
                Connection = mySqlConnect
            };

            MySqlDataReader reader = cmd.ExecuteReader();//читаем данные

            while (reader.Read())
            {
                object newID = reader.GetValue(0);
                object newLabel = reader.GetValue(1);
                object newDone = reader.GetValue(2);
                object newImportant = reader.GetValue(3);

                JsonData.Add(new Data() { id = newID, label = newLabel, done = newDone, important = newImportant });
            }

            mySqlConnect.Close();

            string js = JsonConvert.SerializeObject(JsonData);

            return js;
        }

        /*public ActionResult<IEnumerable<string>> GetJson()//Отдаем данные клиенту
        {           
            List<Data> JsonData = new List<Data>();

            Connect connect = new Connect();
            MySqlConnection mySqlConnect = connect.SqlConnect();//объект, который открывает соединение

            MySqlCommand cmd = new MySqlCommand//запрос к БД
            {
                CommandText = "SELECT * FROM organizer",
                Connection = mySqlConnect
            };

            MySqlDataReader reader = cmd.ExecuteReader();//читаем данные

            while (reader.Read())
            {
                object newID = reader.GetValue(0);
                object newLabel = reader.GetValue(1);
                object newDone = reader.GetValue(2);
                object newImportant = reader.GetValue(3);

                JsonData.Add(new Data() { id = newID, label = newLabel, done = newDone, important = newImportant });
            }

            mySqlConnect.Close();

            string js = JsonConvert.SerializeObject(JsonData);

            return new string[] { js };
        }*/
    }
}
