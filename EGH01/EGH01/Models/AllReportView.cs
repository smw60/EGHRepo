using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EGH01.Models
{
    public class AllReportView 
    {
        public EGH01.Models.EGHRGE.ReportView RGEReportView { get; set; }
        public EGH01.Models.EGHCEQ.ReportView CEQReportView { get; set; }
	}
}