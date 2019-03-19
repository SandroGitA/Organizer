using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

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
        public string Delete(int id)
        {
            DeleteRequest deleteRequest = new DeleteRequest();
            return deleteRequest.Delete(id);
        }

        [HttpPost("edit")]
        public string Edit(string jsonString)
        {
            EditRequest editRequest = new EditRequest();
            return editRequest.Edit(jsonString);
        }
    }
}
