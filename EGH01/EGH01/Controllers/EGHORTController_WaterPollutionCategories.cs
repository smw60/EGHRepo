using EGH01.Models.EGHCCO;
using EGH01.Models.EGHORT;
using EGH01DB;
using EGH01DB.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace EGH01.Controllers
{
    public partial class EGHORTController : Controller
    {
        // GET: EGHORTController_WaterPollutionCategories
        public ActionResult WaterPollutionCategories()
        {
            ORTContext db = null;
            ViewBag.EGHLayout = "ORT.WaterPollutionCategories";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new ORTContext(this);
                WaterPollutionCategoriesView viewcontext = db.GetViewContext("WaterPollutionCategoriesCreate") as WaterPollutionCategoriesView;
                ViewBag.msg = "Соединение с базой данных установлено";
                view = View("WaterPollutionCategories", db);

                if (menuitem.Equals("WaterPollutionCategories.Create"))
                {

                    view = View("WaterPollutionCategoriesCreate");
                    viewcontext.min = null;
                    viewcontext.max = null;
                    viewcontext.name = "";

                }
                else if (menuitem.Equals("WaterPollutionCategories.Delete"))
                {
                    string type_code_item = this.HttpContext.Request.Params["id"];
                    if (type_code_item != null)
                    {
                        int c = 0;
                        if (int.TryParse(type_code_item, out c))
                        {
                            EGH01DB.Types.WaterPollutionCategories wp = new EGH01DB.Types.WaterPollutionCategories();
                            if (EGH01DB.Types.WaterPollutionCategories.GetByCode(db, c, out wp))
                            {
                                view = View("WaterPollutionCategoriesDelete", wp);
                            }
                        }
                    }
                }
                else if (menuitem.Equals("WaterPollutionCategories.Update"))
                {
                    string type_code_item = this.HttpContext.Request.Params["id"];

                    if (type_code_item != null)
                    {
                        int c = 0;
                        if (int.TryParse(type_code_item, out c))
                        {
                            EGH01DB.Types.WaterPollutionCategories wp = new EGH01DB.Types.WaterPollutionCategories();
                            if (EGH01DB.Types.WaterPollutionCategories.GetByCode(db, c, out wp))
                            {
                                view = View("WaterPollutionCategoriesUpdate", wp);
                            }
                        }
                    }
                }
                else if (menuitem.Equals("WaterPollutionCategories.Excel"))
                {
                    EGH01DB.Types.WaterPollutionCategoriesList wplist = new EGH01DB.Types.WaterPollutionCategoriesList(db);
                    XmlNode node = wplist.toXmlNode();
                    XmlDocument doc = new XmlDocument();
                    XmlNode nnode = doc.ImportNode(node, true);
                    doc.AppendChild(nnode);
                    doc.Save(Server.MapPath("~/App_Data/WaterPollutionCategories.xml"));
                    view = View("Index");

                    view = File(Server.MapPath("~/App_Data/WaterPollutionCategories.xml"), "text/plain", "Категории загрязнения грунтовых вод.xml");


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
        public ActionResult WaterPollutionCategoriesCreate(WaterPollutionCategoriesView sp)
        {
            ORTContext db = null;
            ViewBag.EGHLayout = "ORT.WaterPollutionCategories";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new ORTContext(this);
                if (!WaterPollutionCategoriesView.Handler(db, this.HttpContext.Request.Params))
                {

                }
                view = View("WaterPollutionCategories", db);
                if (menuitem.Equals("WaterPollutionCategories.Create.Create"))
                {

                    int code = -1;
                    if (EGH01DB.Types.WaterPollutionCategories.GetNextCode(db, out code))
                    {
                        float min;
                        string strmin = this.HttpContext.Request.Params["min"] ?? "Empty";
                        if (!Helper.FloatTryParse(strmin, out min))
                        {
                            min = 0.0f;
                        }
                        float max;
                        string strmax = this.HttpContext.Request.Params["max"] ?? "Empty";
                        if (!Helper.FloatTryParse(strmax, out max))
                        {
                            max = 0.0f;
                        }
                        String name = sp.name;
                        if (min < max)
                        {
                            EGH01DB.Types.WaterPollutionCategories water_pollution = new EGH01DB.Types.WaterPollutionCategories(code, name, min, max, null); //blinova


                            if (EGH01DB.Types.WaterPollutionCategories.Create(db, water_pollution))
                            {
                                view = View("WaterPollutionCategories", db);
                            }
                        }
                        else {

                            ViewBag.Error = "Проверьте введенные данные";
                            view = View("WaterPollutionCategoriesCreate", db);
                            return view;

                        }
                    }
                }

                else if (menuitem.Equals("WaterPollutionCategories.Create.Cancel")) view = View("WaterPollutionCategories", db);
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
        public ActionResult WaterPollutionCategoriesDelete(int code)
        {
            ORTContext db = null;
            ViewBag.EGHLayout = "ORT.WaterPollutionCategories";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new ORTContext();

                if (menuitem.Equals("WaterPollutionCategories.Delete.Delete"))
                {
                    if (EGH01DB.Types.WaterPollutionCategories.DeleteByCode(db, code)) view = View("WaterPollutionCategories", db);
                }
                else if (menuitem.Equals("WaterPollutionCategories.Delete.Cancel")) view = View("WaterPollutionCategories", db);

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
        public ActionResult WaterPollutionCategoriesUpdate(WaterPollutionCategoriesView sp)
        {
            ORTContext db = null;
            ViewBag.EGHLayout = "ORT.WaterPollutionCategories";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new ORTContext();
                view = View("WaterPollutionCategories", db);
                if (menuitem.Equals("WaterPollutionCategories.Update.Update"))
                {
                    int code = sp.code;
                    String name = sp.name;
                    string strmin = this.HttpContext.Request.Params["min"] ?? "Empty";
                    string strmax = this.HttpContext.Request.Params["max"] ?? "Empty";

                    float min = 0.0f;
                    float max = 0.0f;


                    if (!Helper.FloatTryParse(strmin, out min))
                    {
                        min = 0.0f;
                    }

                    if (!Helper.FloatTryParse(strmax, out max))
                    {
                        max = 0.0f;
                    }

                    EGH01DB.Types.WaterPollutionCategories water_pollution = new EGH01DB.Types.WaterPollutionCategories(code, name, min, max, null); //blinova
                    if (EGH01DB.Types.WaterPollutionCategories.Update(db, water_pollution))
                    {
                        view = View("WaterPollutionCategories", db);
                    }


                }
                else if (menuitem.Equals("WaterPollutionCategories.Update.Cancel"))
                    view = View("WaterPollutionCategories", db);



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

    }
}