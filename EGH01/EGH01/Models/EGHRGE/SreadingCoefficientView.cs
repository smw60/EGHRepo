using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EGH01.Models.EGHRGE
{
    public class SreadingCoefficientView
    {
        //
        // GET: /SreadingCoefficientView/
        
        public EGH01DB.Types.GroundType groundtype {get; set;}
        public float volume {get; set;}
        public float angle {get; set;}    
        
	}
}