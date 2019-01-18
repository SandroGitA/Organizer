using Microsoft.AspNetCore.Mvc;

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
        public void Post(string jsonString)//Принимаем данные от клиента
        {
            PostRequest postRequest = new PostRequest();
            postRequest.PostJson(jsonString);           
        }

        [HttpPost("delete")]
        public string Delete(int id)//удаление записи по ID
        {
            DeleteRequest deleteRequest = new DeleteRequest();
            return deleteRequest.Delete(id);
        }

        [HttpGet("edit")]
        public void Edit(string jsonString)//изменение записи в бд
        {
            EditRequest editRequest = new EditRequest();
            editRequest.Edit(jsonString);
        }
    }
}
