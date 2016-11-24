using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using EGH01DB.Objects;


namespace EGH01DB
{
    public  partial class CEQContext : IDBContext
    {

        public class ECOEvalution: RGEContext.ECOForecast
        {

            public ECOEvalution(RGEContext.ECOForecast  forecast): base (forecast)
            { 
            

            
            }

        }





        


    }

}

