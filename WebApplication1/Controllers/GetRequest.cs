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
                object newDateBind = reader.GetValue(1);
                object newDateCreate = reader.GetValue(2);
                object newTitle = reader.GetValue(3);
                object newDescr = reader.GetValue(4);
                object newIsPin = reader.GetValue(5);
                object newIsComplete = reader.GetValue(6);

                JsonData.Add(new Data() { id = newID, dateBind = newDateBind, dateCreate = newDateCreate,
                    title = newTitle, descr = newDescr, isPin = newIsPin, isComplete = newIsComplete });
            }

            mySqlConnect.Close();

            string js = JsonConvert.SerializeObject(JsonData);

            return js;
        }       
    }
}
