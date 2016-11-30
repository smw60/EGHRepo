using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EGH01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
<<<<<<< HEAD
        public ActionResult Map()
        {
            ViewBag.Message = "Map";

            return View();
        }
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            ViewBag.Message = "Map";
            ActionResult view = View("Index");
            view = View("Map");
            if (upload != null)
            {
             
                // сохраняем файл в папку Files в проекте
                upload.SaveAs(Server.MapPath("~/App_Data/RiskObject.xml"));
            }
      
            return view;
        }
=======

>>>>>>> b6cbc93d3ad47ba444d2f02efcf9a4f6718f3684
    }
}