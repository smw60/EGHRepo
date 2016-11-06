using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EGH01.Models.EGHRGE
{
    public class ChoiceRiskObjectContext
    {
        
        public enum REGIM {INIT, CHOICE, SET};
        
        public REGIM Regim { get; set; }
        public string Findtemplate { get; set; }

       
        public ChoiceRiskObjectContext()
        {
            this.Regim = REGIM.INIT;
        }
    }
}