using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApplication1.Controllers
{
    public class PostRequest
    {
        public string PostJson(string jsonString)
        {
            if (jsonString == null)
                return "Invalid data format";
            else
            {
                Connect connect = new Connect();
                MySqlConnection mySqlConnect = connect.SqlConnect();

                NewDataObject buildDataObject = new NewDataObject();
                newTask responseJsonString = buildDataObject.BuildData(jsonString);

                MySqlCommand cmd = new MySqlCommand
                {
                    CommandText = $"INSERT INTO organizer (id, dateBind, dateCreate, title, descr, isPin, isComplete) " +
                    $"values('{responseJsonString.id}','{responseJsonString.dateBind}','{responseJsonString.dateCreate}'," +
                    $"'{responseJsonString.title}','{responseJsonString.descr}','{responseJsonString.isPin}'," +
                    $"'{responseJsonString.isComplete}')",
                    Connection = mySqlConnect,
                };

                try
                {
                    int countRows = cmd.ExecuteNonQuery();
                    mySqlConnect.Close();
                    return "201";
                }
                catch (MySqlException ex)
                {
                    string cmdStatus = ex.Message;
                    mySqlConnect.Close();
                    return cmdStatus;
                }
            }
        }
    }
}
