using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WebApplication1.Controllers
{
    public class EditRequest
    {
        public string Edit(string jsonString)
        {
            Connect connect = new Connect();
            MySqlConnection mySqlConnect = connect.SqlConnect();//объект, который открывает соединение

            string cmdStatus = "";

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = string.Format("update organizer set label = {0}", jsonString),
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
