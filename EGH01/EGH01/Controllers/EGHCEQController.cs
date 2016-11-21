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
using EGH01.Models.EGHCEQ;

namespace EGH01.Controllers
{
    public partial class EGHCEQController : Controller
    {

        public ActionResult ChoiceForecastResult()
        {
            ViewBag.EGHLayout = "CEQ";
            ActionResult rc = View("Index");
            try
            {
                CEQContext db  = new CEQContext(this);
                switch (ChoiceForecastResultContext.Handler(db, this.HttpContext.Request.Params))
                {
                    case ChoiceForecastResultContext.REGIM.INIT:   rc = View(db); break;
                    case ChoiceForecastResultContext.REGIM.CHOICE: rc = View(db); break;
                    case ChoiceForecastResultContext.REGIM.CANCEL: rc = View("Index"); break;
                    case ChoiceForecastResultContext.REGIM.ERROR:  rc = View(db); break;
                    case ChoiceForecastResultContext.REGIM.REPORT: rc = View(db); break;
                    default: rc = View("Index"); break;
                }

            }
            catch (EGHDBException)
            {
                rc = View("Index");
            }
            catch (Exception)
            {
                rc = View("Index");
            }
            return rc;
        }


         public ActionResult Index()
        {
            ViewBag.EGHLayout = "CEQ";
            CEQContext db = null;
            try
            {
                db = new CEQContext();
               // ViewBag.msg = "Соединение с базой данных установлено";
                           }
            catch (RGEContext.Exception e)
            {
                ViewBag.msg = e.message;
            }
            finally
            {
                //if (db != null) db.Disconnect();
            }

            return View("Index", db);
        }
    }

}




