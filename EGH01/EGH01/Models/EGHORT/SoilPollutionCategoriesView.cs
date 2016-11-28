using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EGH01.Models.EGHCCO
{
    public class SoilPollutionCategoriesView
    {
        public int    code { get; set; }           
        public string name { get; set; }               
        public float  min { get; set; }        
        public float  max { get; set; }            


    }
}