using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using EGH01DB;
using EGH01DB.Primitives;
using EGH01DB.Types;
using System.Globalization;
namespace EGH01.Controllers
{
    public partial  class EGHRGEController: Controller
    {
        public ActionResult Forecast()
        {
            RGEContext db = null;
            ActionResult view = View("Index");
            ViewBag.EGHLayout = "RGE.Forecast";
            string strvolume = this.HttpContext.Request.Params["volume"] ?? "Empty";
            float volume = 0.1f;

            if (!Helper.FloatTryParse(strvolume,  out volume))
            {
                volume = 0.0f;
            }

            try
            {
                db = new RGEContext();
            
            
            }
            catch (RGEContext.Exception e)
            {
                ViewBag.msg = e.message;
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }
            
         return View(db);
        }




    }
}