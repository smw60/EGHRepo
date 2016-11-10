using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGH01DB.Primitives
{
    public class WaterProperties
    {



        public static bool Get(out  WaterProperties waterproperties)
        {
            waterproperties = new WaterProperties();

            return true; 
        }
    }
}
