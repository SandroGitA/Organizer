using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class ValuesController : ControllerBase
    {        
        [HttpGet]
        public string Get()
        {
            GetRequest getRequest = new GetRequest();
            return getRequest.GetJson();           
        }        

        [HttpPost]
        public string Post(string jsonString)
        {            
            PostRequest postRequest = new PostRequest();           
            return postRequest.PostJson(jsonString);
        }

        [HttpPost("delete")]
        public string Delete(string jsonString)
        {
            DeleteRequest deleteRequest = new DeleteRequest();
            return deleteRequest.Delete(jsonString);
        }

        [HttpPost("edit")]
        public string Edit(string jsonString)
        {
            EditRequest editRequest = new EditRequest();
            return editRequest.Edit(jsonString);
        }
    }
}
