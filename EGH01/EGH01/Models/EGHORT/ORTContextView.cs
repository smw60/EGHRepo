using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using EGH01DB;
namespace EGH01.Models.EGHORT
{
    public class ORTContextView
    {
        public enum REGIM {INIT, CHOICE, CANCEL, REPORT, SAVE}
        public const string VIEWNAME = "ORTContextView";
        public int? idevalution  { get; set; }
        public CEQContext.ECOEvalution       ecoevolution = null;
        public GEAContext.ECOClassification  ecoclassifiation = null;
        public REGIM Regim = REGIM.INIT;
  
       // public static ORTContextView HandlerChoice(GEAContext db, NameValueCollection parms)
       // {
       //      ORTContextView rc = db.GetViewContext(VIEWNAME) as ORTContextView;
       //      if (rc == null) db.SaveViewContext(ORTContextView.VIEWNAME, rc = new GEAContextView());
       //      string menuitem = parms["menuitem"];
       //      if (menuitem != null)
       //      {
       //             if  (menuitem.Equals("ChoiceEvalutionResult.Choice")) 
       //             {
       //                  rc.Regim = REGIM.CHOICE;
       //                  if (!string.IsNullOrEmpty(parms["ChoiceEvalutionResult.id"]))
       //                  {
       //                     int id = 0;
       //                     if (int.TryParse(parms["ChoiceEvalutionResult.id"], out id)) rc.ecoevolution = CEQContext.ECOEvalution.GetById(db,id); 
       //                     else rc.ecoevolution = null; 
       //                  }
       //              } 
       //             else  if (menuitem.Equals("ChoiceEvalutionResult.Cancel"))    rc.Regim = REGIM.CANCEL;
       //      } else rc.Regim = REGIM.INIT;            
 
       //      return rc;     
       //}
       // public static ORTontextView HandlerClassification(GEAContext db, NameValueCollection parms)
       // {
       //      GEAContextView rc = db.GetViewContext(VIEWNAME) as GEAContextView;
       //      if (rc == null) db.SaveViewContext(GEAContextView.VIEWNAME, rc = new GEAContextView());
           
       //      string menuitem = parms["menuitem"];
       //      if (menuitem != null)
       //      {
       //         if (menuitem.Equals("Report.Save")) 
       //         {
       //              rc.Regim = REGIM.SAVE;

       //         }  
       //      }
       //      else  if (rc.ecoevolution != null) 
       //      { 
       //        rc.Regim = REGIM.REPORT;
       //        rc.ecoclassifiation = new GEAContext.ECOClassification(rc.ecoevolution);
       //      }
       //      return rc;  
       // }  

    }
}