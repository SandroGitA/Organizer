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
            //responseJsonString.id = Guid.NewGuid().GetHashCode();
            //responseJsonString.dateBind = responseJsonString.dateBind;
            //responseJsonString.dateCreate = responseJsonString.dateCreate;
            //responseJsonString.id = responseJsonString.id;

            return responseJsonString;
        }
    }
}
