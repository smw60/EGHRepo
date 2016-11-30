using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using EGH01DB;
using System.Collections.Specialized;

namespace EGH01.Models.EGHRGE
{
    public class GroundTypeView
    {
        static public readonly string VIEWNAME = "GroundTypeView";
        public enum REGIM { INIT, ERROR, RUNERROR, REPORT };

        public REGIM Regim { get; set; }
        public int type_code { get; set; }    // код типа инцидента 
        public string name { get; set; }        // Наименование типа 
        public float porosity { get; set; }   // пористость     >0    <1, безразмерная , доля застрявшего  в грунте нефтепрдукта       
        public float soilmoisture { get; set; }   // влажность грунта (от 0 до 1)
        public float watercapacity { get; set; }   // капиллярная влагоемкость (от 0 до 1)
        public float holdmigration { get; set; }   // коэфф. задержки миграции нефтепродуктов 
        public float waterfilter { get; set; }   // коэфф. фильтрации воды  
        public float аveryanovfactor { get; set; }   // коэффициент Аверьянова (от 4 до 9)
        public float density { get; set; }

        public static bool Handler(RGEContext context, NameValueCollection parms)
        {
            bool rc = false;
            GroundTypeView viewcontext = null;
            string menuitem = parms["menuitem"];
            if ((viewcontext = context.GetViewContext(VIEWNAME) as GroundTypeView) != null)
            {
                viewcontext.Regim = REGIM.INIT;
                string namec = parms["name"];
                if (String.IsNullOrEmpty(namec)) viewcontext.Regim = REGIM.ERROR;
                else
                {
                    viewcontext.name = namec;

                }
            }
            return rc;
        }
    }


}