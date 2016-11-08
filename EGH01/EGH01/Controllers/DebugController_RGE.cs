using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using EGH01DB.Primitives;
using EGH01DB.Types;
using EGH01DB.Points;
using EGH01DB.Objects;
using EGH01DB;

namespace EGH01.Controllers
{
    public partial  class DebugController:Controller
    {


        public ActionResult RGECalc()
        {
            RGEContext db = new RGEContext();
            
            {
                List<RiskObject> o = new List<RiskObject>(); 
                
                if (RiskObjectsList.GetListRiskObjectByLike(db, "Брест", ref o))
                {
                    int k = 1;
                
                }

            }
             




            return View();
        }




    }
}