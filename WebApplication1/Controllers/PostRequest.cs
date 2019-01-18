using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WebApplication1.Controllers
{
    public class PostRequest
    {
        public void PostJson(string jsonString)
        {
            Connect connect = new Connect();
            MySqlConnection mySqlConnect = connect.SqlConnect();//объект, который открывает соединение           
            //парсим и записывыем в бд
            //string cmdStatus = "";

            MySqlCommand cmd = new MySqlCommand
            {
                //CommandText = "INSERT INTO organizer (id, label, done, important) VALUES('"+ id +"', '"+ label +"', '"+ done +"', '"+ important +"')",
                Connection = mySqlConnect
            };
           
            /*try
            {
                mySqlConnect.Close();
                return "OK";
            }
            catch(MySqlException ex)
            {
                cmdStatus = ex.Message;
                return "Error: " + cmdStatus;
            }*/
        }
    }
}
