using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EGH01DB;
using System.Collections.Specialized;
using EGH01DB.Objects;

namespace EGH01.Models.EGHCEQ
{
    public class ChoiceForecastResultContext
    {
        
        public enum REGIM {INIT, CHOICE, CANCEL, ERROR, REPORT};
        
        public REGIM Regim { get; set; }
        public int? id     { get; set; }  
        
        public ChoiceForecastResultContext()
        {
            this.Regim = REGIM.INIT;
            //this.id = -1;    


        }
        public static REGIM  Handler(CEQContext context, NameValueCollection parms)
        {
            REGIM rc = REGIM.INIT;
            ChoiceForecastResultContext viewcontext = null;
            if ((viewcontext = context.GetViewContext("ChoiceForecastResult") as ChoiceForecastResultContext) != null)
            {
                rc = viewcontext.Regim = REGIM.INIT;
                string menuitem = parms["menuitem"];
                if (menuitem != null)
                {
                    if (menuitem.Equals("ChoiceForecastResult.Choice"))
                    {
                        string formid = parms["ChoiceForecastResult.id"];
                        int id = -1;
                        if (!string.IsNullOrEmpty(formid) && int.TryParse(formid, out id))
                        {
                            viewcontext.id = id;
                             rc = viewcontext.Regim = REGIM.CHOICE;
                        }
                        else rc = viewcontext.Regim = REGIM.ERROR;
                    }
                    else if (menuitem.Equals("ChoiceForecastResult.Cancel"))
                    {
                           rc = viewcontext.Regim = REGIM.CANCEL;
                    }
                    else if (menuitem.Equals("ConfirmChoiceForecastResult.Confirm"))
                    {
                        rc = viewcontext.Regim = REGIM.REPORT;
                    }
                    else if (menuitem.Equals("ConfirmChoiceForecastResult.Cancel"))
                    {
                        rc = viewcontext.Regim = REGIM.INIT;
                    }

                }
            }
          
            return rc;
        }

    }


}


//public string Template { get; set; }
//public int RiskObjectID { get; set;}
//ChoiceRiskObjectContext viewcontext = null;
//string choicefind = parms["ChoiceRiskObject.choicefind"];
//if (!string.IsNullOrEmpty(choicefind))
//{

//    if ((viewcontext = context.GetViewContext("_ChoiceRiskObject") as ChoiceRiskObjectContext) != null)
//    {
//        if (rc = choicefind.Equals("init"))
//        {
//            viewcontext.Regim = ChoiceRiskObjectContext.REGIM.INIT;
//        }
//        else if (rc = choicefind.Equals("choice"))
//        {
//            string template = parms["ChoiceRiskObject.template"];
//            if (!string.IsNullOrEmpty(template))
//            {
//                viewcontext.Regim = ChoiceRiskObjectContext.REGIM.CHOICE;
//                viewcontext.Template = template;
//            }

//        }
//        else if (rc = choicefind.Equals("set"))
//        {
//            int id = 0;
//            string formid = parms["ChoiceRiskObject.id"];
//            if (!string.IsNullOrEmpty(formid) && int.TryParse(formid, out id))
//            {
//                viewcontext.Regim = ChoiceRiskObjectContext.REGIM.SET;
//                viewcontext.RiskObjectID = id;
//            }
//        }
//    }

//}