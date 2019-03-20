using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class DeleteDataObject
    {
        public DeleteTask BuildData(string dataString)
        {
            DeleteTask deleteTask = JsonConvert.DeserializeObject<DeleteTask>(dataString);

            return deleteTask;
        }
    }
}
