using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EGH01DB.Objects;

namespace EGH01.Models.EGHRGE
{
    public class ChoiceRiskObjectContext
    {
        
        public enum REGIM {INIT, CHOICE, SET};
        
        public REGIM Regim { get; set; }
        public string Template { get; set; }
        public int RiskObjectID { get; set;}
        
        public ChoiceRiskObjectContext()
        {
            this.Regim = REGIM.INIT;
            this.Template = string.Empty;
            this.RiskObjectID = -1;


        }
    }
}