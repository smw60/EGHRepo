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
        private bool ChoiceRiskObject(RGEContext context,  NameValueCollection parms)
        {
            bool rc = false;  
            ChoiceRiskObjectContext viewcontext = null;
            string choicefind  =  parms["ChoiceRiskObject.choicefind"];
            if (!string.IsNullOrEmpty(choicefind))
            {
                                 
                if ((viewcontext = context.GetViewContext("_ChoiceRiskObject") as ChoiceRiskObjectContext)!= null)
                {
                    if (rc = choicefind.Equals("init"))
                    {
                        viewcontext.Regim = ChoiceRiskObjectContext.REGIM.INIT;
                    }
                    else if (rc = choicefind.Equals("choice"))
                    {
                        string template = parms["ChoiceRiskObject.template"];
                        if (!string.IsNullOrEmpty(template)) 
                        {
                            viewcontext.Regim = ChoiceRiskObjectContext.REGIM.CHOICE;
                            viewcontext.Template = template;
                        }
                       
                    }
                    else if (rc = choicefind.Equals("set"))
                    {
                        int id = 0;
                        string formid = parms["ChoiceRiskObject.id"];
                        if (!string.IsNullOrEmpty(formid) && int.TryParse(formid, out id))
                        {
                            viewcontext.Regim = ChoiceRiskObjectContext.REGIM.SET;
                            viewcontext.RiskObjectID = id;                   
                        }
                    }
                    
                }
               
             }
            return rc;
        }

         public ActionResult Forecast( )
        {
            RGEContext context = null;
            
            ActionResult view = View("Index");
            ViewBag.EGHLayout = "RGE.Forecast";
            string strvolume = this.HttpContext.Request.Params["volume"] ?? "Empty";
           
            try
            {
                context = new RGEContext(this);

                if (!ChoiceRiskObject(context, this.HttpContext.Request.Params))
                {
                
                
                
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