using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class BuildBoolData
    {
        public object Build(object fieldInData)
        {
            if ((bool)fieldInData == true)
                return fieldInData = 1;
            else if ((bool)fieldInData == false)
                return fieldInData = 0;
            return null;
        }
    }
}
