using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EGH01DB;
using System.Collections.Specialized;
using EGH01DB.Objects;

namespace EGH01.Models.EGHCEQ
{
    public class CEQViewContext
    {
        
        public enum REGIM_CHOICE {INIT, CHOICE, CANCEL, ERROR, REPORT};
        public enum REGIM_EVALUTION{ INIT, CHOICE, CANCEL, ERROR, REPORT };
        public REGIM_CHOICE RegimChoice { get; set; }
        public REGIM_EVALUTION RegimEvalution { get; set; }
        public const string VIEWNAME = "ChoiceForecastResult";
        public int? id     { get; set; }
        public CEQContext.ECOEvalution  ecoevalution { get; set;} 

        public CEQViewContext()
        {
            this.RegimChoice = REGIM_CHOICE.INIT;
            this.RegimEvalution = REGIM_EVALUTION.INIT;
            //this.id = -1;    


        }
        
        public static REGIM_EVALUTION HandlerEvalutionForecast(CEQContext context, NameValueCollection parms)
        {
            REGIM_EVALUTION rc = REGIM_EVALUTION.INIT;
            CEQViewContext viewcontext = null;
            if ((viewcontext = context.GetViewContext("ChoiceForecastResult") as CEQViewContext) != null)
            {
                rc = viewcontext.RegimEvalution;
            
            }
            return rc;
        }
        
        public static REGIM_CHOICE  HandlerChoiceForecast(CEQContext context, NameValueCollection parms)
        {
            REGIM_CHOICE rc = REGIM_CHOICE.INIT;
            CEQViewContext viewcontext = null;
            if ((viewcontext = context.GetViewContext("ChoiceForecastResult") as CEQViewContext) != null)
            {
                rc = viewcontext.RegimChoice = REGIM_CHOICE.INIT;
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
                             rc = viewcontext.RegimChoice = REGIM_CHOICE.CHOICE;
                        }
                        else rc = viewcontext.RegimChoice = REGIM_CHOICE.ERROR;
                    }
                    else if (menuitem.Equals("ChoiceForecastResult.Cancel"))
                    {
                           rc = viewcontext.RegimChoice = REGIM_CHOICE.CANCEL;
                    }
                    else if (menuitem.Equals("ConfirmChoiceForecastResult.Confirm"))
                    {
                        rc = viewcontext.RegimChoice = REGIM_CHOICE.REPORT;
                    }
                    else if (menuitem.Equals("ConfirmChoiceForecastResult.Cancel"))
                    {
                        rc = viewcontext.RegimChoice = REGIM_CHOICE.INIT;
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