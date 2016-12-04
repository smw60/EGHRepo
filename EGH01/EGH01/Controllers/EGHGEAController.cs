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
using EGH01.Models.EGHGEA;
namespace EGH01.Controllers
{
    public partial class EGHGEAController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.EGHLayout = "GEA";
            GEAContext db = null;
            try
            {
                db = new GEAContext();
               
       

            }
            catch (RGEContext.Exception e)
            {
                ViewBag.msg = e.message;
            }
            finally
            {
                //if (db != null) db.Disconnect();
            }

            return View();
        }
       
        public ActionResult ChoiceEvalutionResult()
        {
            ViewBag.EGHLayout = "GEA";
            ActionResult view = View("Index");
            GEAContext db = null;
            try
            {
                db = new GEAContext();
                GEAContextView context = GEAContextView.HandlerChoice(db,this.Request.Params);
                switch(context.Regim)
                { 
                 case GEAContextView.REGIM.CHOICE:   break;
                 case GEAContextView.REGIM.CANCEL: context.Regim = GEAContextView.REGIM.INIT;  break; 
                 default:  view = View(db); break;
                }                 

            }
            catch (RGEContext.Exception e)
            {
                ViewBag.msg = e.message;
            }
            finally
            {
                //if (db != null) db.Disconnect();
            }

            return view;
        }




    }
}

