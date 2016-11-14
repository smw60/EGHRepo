using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EGH01.Models.EGHRGE
{
    public class EcoObjectView
    {
        public int      id {get; set;}   
        public string   name { get; set;}        

        public int list_cadastre { get; set; }  
        public int list_ecoType { get; set; }
        public bool iswaterobject { get;  set; }

    }

    


}