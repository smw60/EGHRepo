using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using EGH01DB;

namespace EGH01.Models.EGHGEA
{
    public class GEAContextView
    {
        public const string VIEWNAME = "GEAContextView";
        public int? idevalution  { get; set; }
  
        public static GEAContextView HandlerChoice(GEAContext context, NameValueCollection parms)
        {
             GEAContextView rc = context.GetViewContext(VIEWNAME) as GEAContextView;
             


            return rc;     
       }
    }
}