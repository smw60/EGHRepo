using System;
using System.Web.Mvc;
using EGH01DB;
using EGH01DB.Primitives;
using EGH01.Models.EGHRGE;


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

            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new RGEContext();
                ViewBag.msg = "Соединение с базой данных установлено";
                view = View("Report", db);


                if (menuitem.Equals("Report.Watch"))
                {


                    //RGEContext db = new RGEContext();
                    //string comment = "Comment";
                    //Report f = new Report();
                    //if (Report.GetById(db, 5, out f, out comment))
                    //{
                    //    int k = 1;

                    //};
                    //f.ToHTML();

                    string id = this.HttpContext.Request.Params["id"];
                    string comment;

                    if (id != null)
                    {
                        int c = 0;
                        if (int.TryParse(id, out c))
                        {
                            Report report = new Report();
                            if (EGH01DB.Primitives.Report.GetById(db, c, out report, out comment))
                            {
                                comment = this.HttpContext.Request.Params["comment"];
                                EGH01DB.Primitives.Report.UpdateCommentById(db, c, comment);
                               
                            }
                            report.ToHTML();
                        }
                    }
                    view = View("ReportWatch");
                  

                }

                else if (menuitem.Equals("Report.Delete"))
                {

                    //string code = this.HttpContext.Request.Params["code"];
                    //if (code != null)
                    //{
                    //    int c = 0;
                    //    if (int.TryParse(code, out c))
                    //    {
                    //        EGH01DB.Primitives.Report sc = new EGH01DB.Primitives.Report();
                    //        if (EGH01DB.Primitives.Report.GetByCode(db, c, out sc))
                    //        {
                    //            view = View("ReportDelete", sc);
                    //        }
                    //    }
                    //}


                }


                else if (menuitem.Equals("Report.SaveComment"))
                {
                    string id = this.HttpContext.Request.Params["id"];
                    string comment;

                    if (id != null)
                    {
                        int c = 0;
                        if (int.TryParse(id, out c))
                        {
                            Report report = new Report();
                            if (EGH01DB.Primitives.Report.GetById(db, c, out report, out comment))
                            {
                                comment = this.HttpContext.Request.Params["comment"];
                                EGH01DB.Primitives.Report.UpdateCommentById(db, c, comment);
                                view = View("Report", db);
                            }
                        }
                    }
                }
               
            }

            catch (RGEContext.Exception e)
            {
                ViewBag.msg = e.message;
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }

            return view;
        }


        [HttpPost]
        public ActionResult ReportWatch(ReportView rv)
        {
            RGEContext db = null;
            ViewBag.EGHLayout = "RGE.Report";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new RGEContext();
                view = View("Report", db);
                //if (menuitem.Equals("Report.Watch"))
                //{

                int id = rv.id;
                string comment = rv.comment;
                Report report = new EGH01DB.Primitives.Report();


                /*if (*/
                EGH01DB.Primitives.Report.GetById(db, id, out report, out comment);
                //{
                report.ToHTML();
                view = View("Report", report);
                //}
                //}
                //else if (menuitem.Equals("SpreadingCoefficient.Create.Cancel"))
                //            view = View("SpreadingCoefficient", db);
                //    }

            }
            catch (RGEContext.Exception e)
            {
                ViewBag.msg = e.message;
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }

            return view;
        }


        //[HttpPost]
        //public ActionResult ReportSaveComment(ReportView rv)
        //{
        //    RGEContext db = null;
        //    ViewBag.EGHLayout = "RGE.Report";
        //    ActionResult view = View("Index");
        //    //string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
        //    try
        //    {
        //        db = new RGEContext();
        //        //view = View("Report", db);
                
        //        int id = rv.id;
        //        string comment = rv.comment;
                
        //        EGH01DB.Primitives.Report.UpdateCommentById(db, id, comment);
        //        view = View("Report", db);
        //        //}

        //        //report.ToHTML();
        //        //view = View("Report", db);


        //    }
        //    catch (RGEContext.Exception e)
        //    {
        //        ViewBag.msg = e.message;
        //    }
        //    catch (Exception e)
        //    {
        //        ViewBag.msg = e.Message;
        //    }

        //    return view;
        //}

    }
}
