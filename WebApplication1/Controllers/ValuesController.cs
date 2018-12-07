using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet("[get]")]//исправлено, обычный ответ
        public string start()
        {
            return "200 OK";
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            List<Data> JsonData = new List<Data>();

            Connect connect = new Connect();
            MySqlConnection mySqlConnect = connect.SqlConnect();//объект, который открывает соединение

            MySqlCommand cmd = new MySqlCommand//запрос к БД
            {
                CommandText = "SELECT * FROM organizer",
                Connection = mySqlConnect
            };

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                object id = reader.GetValue(0);
                object label = reader.GetValue(1);
                object done = reader.GetValue(2);
                object important = reader.GetValue(3);

                JsonData.Add(new Data() { id = id, label = label, done = done, important = important });
            }

            mySqlConnect.Close();

            string js = JsonConvert.SerializeObject(JsonData);

            return new string[] { js };
        }

        //GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<IEnumerable<string>> Get(int id)
        //{

        //    return new string[] { "value" };
        //}

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string label, string done, string important)
        {
            Connect connect = new Connect();
            MySqlConnection mySqlConnect = connect.SqlConnect();//объект, который открывает соединение

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "INSERT INTO `organizer` (`label`, `done`,`important`) VALUES("+ label +", "+ done +", "+ important +")",
                Connection = mySqlConnect
            };

            mySqlConnect.Close();
        }
    }
}
