using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGH01DB
{

    public partial class RGEContext
    {
        public partial class ECOForecast         //  модель прогнозирования 
        {

            public static int Create (IDBContext db, ECOForecast ecoforecat)
            {
                int id = -1;   // id ECOForecast

                return id;
            }
            public static bool GetById(IDBContext db, int id, out  ECOForecast ecoforecat)
            {
                ecoforecat = new ECOForecast();

                return true;
            }
            public static bool DeleteById(IDBContext db, int id)
            {
              
                return true;
            }
          
                    
        }

       
        public class ECOForecastlist : List<ECOForecast>
        {
         
          public static  bool  Get(IDBContext db, out ECOForecastlist ecoforecastlist)
          {
              ecoforecastlist = new ECOForecastlist();


              return true;
          }

          

        
        }
     }
}
