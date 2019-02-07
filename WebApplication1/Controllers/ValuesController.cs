using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class ValuesController : ControllerBase
    {        
        [HttpGet]
        public string Get()//Отдаем данные клиенту
        {
            GetRequest getRequest = new GetRequest();
            return getRequest.GetJson();           
        }             

        [HttpPost]
        public string Post(string jsonString)//Принимаем данные от клиента строкой, и парсим ее
        {
            PostRequest postRequest = new PostRequest();
            return postRequest.PostJson(jsonString);
        }

        [HttpPost("delete")]
        public string Delete(int id)//удаление записи по ID
        {
            DeleteRequest deleteRequest = new DeleteRequest();
            return deleteRequest.Delete(id);
        }

        [HttpPost("edit")]
        public string Edit(string jsonString)//изменение записи в бд
        {
            EditRequest editRequest = new EditRequest();
            return editRequest.Edit(jsonString);
        }
    }
}
