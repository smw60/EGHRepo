using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Globalization;
using EGH01.Models.EGHRGE;
using EGH01DB;
using EGH01DB.Primitives;
using EGH01DB.Types;
using EGH01DB.Points;
using EGH01DB.Objects;
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
                                ForecastViewConext viewcontext = context.GetViewContext("Forecast") as ForecastViewConext;
                                if (viewcontext != null)
                                {
                                    RiskObject riskobject = new RiskObject();
                                    if (RiskObject.GetById(context, (int)viewcontext.RiskObjectId, ref riskobject))
                                    {
                                        PetrochemicalType petrochemicaltype = new PetrochemicalType();
                                        if( PetrochemicalType.GetByCode(context,(int)viewcontext.Petrochemical_type_code, ref petrochemicaltype))
                                        {
                                            SpreadPoint spreadpoint = new SpreadPoint(riskobject, petrochemicaltype, (float)viewcontext.Volume);
                                            EGH01DB.Types.IncidentType incidenttype = new EGH01DB.Types.IncidentType();
                                            if (EGH01DB.Types.IncidentType.GetByCode(context, (int)viewcontext.Incident_type_code, out  incidenttype))
                                            {

                                                Incident incident = new Incident(
                                                                                 (DateTime)viewcontext.Incident_date,
                                                                                 (DateTime)viewcontext.Incident_date_message,
                                                                                 incidenttype,
                                                                                 spreadpoint
                                                                                 );
                                                RGEContext.ECOForecast ecoforecst = new RGEContext.ECOForecast(incident); 
                                                viewcontext.Regim = ForecastViewConext.REGIM.REPORT;
                                             }
                                            else viewcontext.Regim = ForecastViewConext.REGIM.RUNERROR;
                                            
                                        }
                                        else viewcontext.Regim = ForecastViewConext.REGIM.RUNERROR;
                                       
                                    }
                                    else viewcontext.Regim = ForecastViewConext.REGIM.RUNERROR;
                              
                                        
                                        
                                        
                                        //  (context,  (int)(viewcontext.RiskObjectId), riskobject))
                                    
                                    //RiskObject.GetById(context,  viewcontext.RiskObjectId);
                                    
                                    //Incident incident = new Incident(
                                    //                                viewcontext.Incident_date,
                                    //                                viewcontext.Incident_date_message,
                                                                    
                                    //                                )
                                
                                
                                
                                }
                                



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