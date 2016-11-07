using System;
using System.Collections.Specialized;
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
       
        public ActionResult Forecast( )
        {
            RGEContext context = null;
            
            ActionResult view = View("Index");
            ViewBag.EGHLayout = "RGE.Forecast";
            string menuitem = this.HttpContext.Request.Params["menuitem"];
           
            try
            {
                context = new RGEContext(this);
                view = View(context);

                if (!ForecastViewConext.Handler(context, this.HttpContext.Request.Params))
                {
                    if (!ChoiceRiskObjectContext.Handler(context, this.HttpContext.Request.Params))
                    {
                        if (menuitem != null)
                        {
                            if (menuitem.Equals("Forecast.Forecast"))
                            {

                                //   Menu start = new Menu(
                                //new Menu.MenuItem("Прогноз", "Forecast.Forecast", true),
                                //new Menu.MenuItem("Отказаться", "Forecast.Cancel", true),
                                //mitem
                            }
                            else if (menuitem.Equals("Forecast.Cancel")) view = Redirect("Index");
                       }
                   }
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
            
         return view;
        }
        

        [ChildActionOnly]
        public ActionResult ChoiceRiskObject()
        {
            RGEContext context = null;
            try
            {
                context = new RGEContext(this);
               
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