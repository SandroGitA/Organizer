using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class ConvertDataField
    {
        public static string Convert(object milliseconds)
        {
            double mlsc = (long)milliseconds;
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(mlsc);
            DateTime dateTime = new DateTime(1970, 1, 1);
            DateTime endDateTime = dateTime.AddHours(5);
            return endDateTime.Add(timeSpan).ToString("yyyy.MM.dd HH:mm:ss");
        }
    }
}
