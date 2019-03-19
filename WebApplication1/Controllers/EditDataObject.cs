using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class EditDataObject
    {
        public EditTask BuildData(string dataString)
        {
            EditTask responseJsonString = JsonConvert.DeserializeObject<EditTask>(dataString);

            if ((string)responseJsonString.propName == "isComplete")
                responseJsonString.value = ConvertBoolField.Convert(responseJsonString.value);
            if ((string)responseJsonString.propName == "isPin")
                responseJsonString.value = ConvertBoolField.Convert(responseJsonString.value);

            return responseJsonString;
        }
    }
}
