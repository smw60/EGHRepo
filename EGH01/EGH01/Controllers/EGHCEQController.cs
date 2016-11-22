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
                switch (CEQViewContext.HandlerChoiceForecast(db, this.HttpContext.Request.Params))
                {
                    case CEQViewContext.REGIM_CHOICE.INIT:   rc = View(db); break;
                    case CEQViewContext.REGIM_CHOICE.CHOICE: rc = View(db); break;
                    case CEQViewContext.REGIM_CHOICE.CANCEL: rc = View("Index",db); break;
                    case CEQViewContext.REGIM_CHOICE.ERROR: rc = View(db); break;
                    case CEQViewContext.REGIM_CHOICE.REPORT: rc = View(db); break;
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

        public ActionResult EvalutionForecast()
        {
            ViewBag.EGHLayout = "CEQ";
            CEQContext db = null; 
            ActionResult rc = View("Index");
            try
            {
                db = new CEQContext(this);
                rc = rc = View("Index",db);
                switch (CEQViewContext.HandlerEvalutionForecast(db, this.HttpContext.Request.Params))
                {
                    case CEQViewContext.REGIM_EVALUTION.INIT:   rc = View(db); break;
                    case CEQViewContext.REGIM_EVALUTION.CHOICE: rc = View(db); break;
                    default: rc = View("Index", db); break;
                }

                rc = View(db);

            }
            catch (EGHDBException)
            {
                rc = View("Index",db);
            }
            catch (Exception)
            {
                rc = View("Index", db);
            }
            return rc;
        }





         public ActionResult Index()
        {
            ViewBag.EGHLayout = "CEQ";
            CEQContext db = null;
            ActionResult view = View("Index", db);
            try
            {
                db = new CEQContext();
               
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




