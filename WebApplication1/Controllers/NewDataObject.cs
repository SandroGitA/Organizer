using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class BuildDataObject
    {
        public newTask BuildData(string dataString)
        {
            newTask responseJsonString = JsonConvert.DeserializeObject<newTask>(dataString);

            responseJsonString.isPin = ConvertBoolField.Convert(responseJsonString.isPin);
            responseJsonString.isComplete = ConvertBoolField.Convert(responseJsonString.isComplete);
            responseJsonString.dateBind = ConvertDataField.Convert(responseJsonString.dateBind);
            responseJsonString.dateCreate = ConvertDataField.Convert(responseJsonString.dateCreate);

            return responseJsonString;
        }
    }
}
