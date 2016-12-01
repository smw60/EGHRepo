using System.Web.Mvc;
using EGH01.Models.EGHRGE;
using EGH01DB;
using EGH01DB.Primitives;
using EGH01DB.Types;

namespace EGH01.Controllers
{
    public partial class EGHRGEController : Controller
    {
        // GET: EGHRGEController_Report
        public ActionResult Report()
        {
            RGEContext db = null;
            ViewBag.EGHLayout = "RGE.Report";
            ActionResult view = View("Index");
            db = new RGEContext();
            return View();
        }

    }
}
