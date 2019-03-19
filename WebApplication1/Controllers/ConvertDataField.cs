using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class ConvertDataField
    {
        public static string Convert(object date)
        {
            DateTime dt = DateTime.Parse(date.ToString());
            return dt.ToString("yyyy.MM.dd HH:mm:ss");
        }
    }
}
