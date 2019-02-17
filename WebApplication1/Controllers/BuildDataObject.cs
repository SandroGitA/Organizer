using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class BuildDataObject
    {
        public string dateBind;
        public string dateCreate;

        public Data BuildData(string dataString)
        {
            Data responseJsonString = JsonConvert.DeserializeObject<Data>(dataString);

            responseJsonString.isPin = ConvertBoolField.Convert(responseJsonString.isPin);
            responseJsonString.isComplete = ConvertBoolField.Convert(responseJsonString.isComplete);
            responseJsonString.dateBind = ConvertDataField.Convert(responseJsonString.dateBind);
            responseJsonString.dateCreate = ConvertDataField.Convert(responseJsonString.dateCreate);
            responseJsonString.id = Guid.NewGuid().GetHashCode();

            return responseJsonString;
        }
    }
}
