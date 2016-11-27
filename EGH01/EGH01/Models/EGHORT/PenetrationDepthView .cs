using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EGH01.Models.EGHORT
{
    public class PenetrationDepthView
    {
        public int    code { get; set; }           
        public string name { get; set; }               
        public float  mindepth { get; set; }        
        public float  maxdepth { get; set; }            


    }
}