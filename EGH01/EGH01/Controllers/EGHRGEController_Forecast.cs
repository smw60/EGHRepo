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
using EGH01.Models.EGHRGE;
namespace EGH01.Controllers
{
    public partial  class EGHRGEController: Controller
    {
        public ActionResult Forecast()
        {
            RGEContext context = null;
            ChoiceRiskObjectContext viewcontext = null;
            ActionResult view = View("Index");
            ViewBag.EGHLayout = "RGE.Forecast";
            string strvolume = this.HttpContext.Request.Params["volume"] ?? "Empty";
            string startfind = this.HttpContext.Request.Params["startfind"] ?? "Empty";
            string riskobjectlist = this.HttpContext.Request.Params["riskobjectlist"] ?? "Empty";
            try
            {
                context = new RGEContext(this);
               
                if (startfind.Equals("ChoiceRiskObject.startfind"))
                {
                    viewcontext = context.GetViewContext("_ChoiceRiskObject") as ChoiceRiskObjectContext;
                    if (viewcontext != null) viewcontext.Regim = ChoiceRiskObjectContext.REGIM.CHOICE;
                }
            
            }
            catch (RGEContext.Exception e)
            {
                ViewBag.msg = e.message;
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }
            
         return View(context);
        }
        
        [ChildActionOnly]
        public ActionResult ChoiceRiskObject()
        {
            RGEContext context = null;
            ChoiceRiskObjectContext viewcontext = null;
            try
            {
                context = new RGEContext(this);
               
               // "_ChoiceRiskObject.startchoice"
                
                //context.SaveViewContext("_ChoiceRiskObject", new Models.EGHRGE.ChoiceRiskObjectViewContext());

            }
            catch (RGEContext.Exception e)
            {
                ViewBag.msg = e.message;
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }

            return PartialView("_ChoiceRiskObject",context);

        }





    }
}