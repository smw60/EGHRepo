﻿using EGH01.Models.EGHCCO;
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

        public ActionResult SoilPollutionCategories()  
        {
            ORTContext db = null;
            ViewBag.EGHLayout = "ORT.SoilPollutionCategories";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new ORTContext();
                ViewBag.msg = "Соединение с базой данных установлено";
                view = View("SoilPollutionCategories", db);

                if (menuitem.Equals("SoilPollutionCategories.Create"))
                {

                    view = View("SoilPollutionCategoriesCreate");

                }
                else if (menuitem.Equals("SoilPollutionCategories.Delete"))
                {
                    string type_code_item = this.HttpContext.Request.Params["id"];
                    if (type_code_item != null)
                    {
                        int c = 0;
                        if (int.TryParse(type_code_item, out c))
                        {
                            EGH01DB.Types.SoilPollutionCategories sp = new EGH01DB.Types.SoilPollutionCategories();
                            if (EGH01DB.Types.SoilPollutionCategories.GetByCode(db, c, out sp))
                            {
                                view = View("SoilPollutionCategoriesDelete", sp);
                            }
                        }
                    }
                }
                else if (menuitem.Equals("SoilPollutionCategories.Update"))
                {
                    string type_code_item = this.HttpContext.Request.Params["id"];

                    if (type_code_item != null)
                    {
                        int c = 0;
                        if (int.TryParse(type_code_item, out c))
                        {
                            EGH01DB.Types.SoilPollutionCategories sp = new EGH01DB.Types.SoilPollutionCategories();
                            if (EGH01DB.Types.SoilPollutionCategories.GetByCode(db, c, out sp))
                            {
                                view = View("SoilPollutionCategoriesUpdate", sp);
                            }
                        }
                    }
                }
                else if (menuitem.Equals("SoilPollutionCategories.Excel"))
                {
                    EGH01DB.Types.SoilPollutionCategoriesList splist = new EGH01DB.Types.SoilPollutionCategoriesList(db);
                    XmlNode node = splist.toXmlNode();
                    XmlDocument doc = new XmlDocument();
                    XmlNode nnode = doc.ImportNode(node, true);
                    doc.AppendChild(nnode);
                    doc.Save(Server.MapPath("~/App_Data/SoilPollutionCategories.xml"));
                    view = View("Index");

                    view = File(Server.MapPath("~/App_Data/SoilPollutionCategories.xml"), "text/plain", "Категории загрязнения грунтов.xml");


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
        public ActionResult SoilPollutionCategoriesCreate(SoilPollutionCategoriesView sp)
        {
            ORTContext db = null;
            ViewBag.EGHLayout = "ORT.SoilPollutionCategories";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new ORTContext();
                view = View("SoilPollutionCategories", db);
                if (menuitem.Equals("SoilPollutionCategories.Create.Create"))
                {

                    int code = -1;
                    if (EGH01DB.Types.SoilPollutionCategories.GetNextCode(db, out code)) {
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
                        EGH01DB.Types.SoilPollutionCategories soil_pollution = new EGH01DB.Types.SoilPollutionCategories(code, name, min, max);


                        if (EGH01DB.Types.SoilPollutionCategories.Create(db, soil_pollution))
                        {
                            view = View("SoilPollutionCategories", db);
                        }

                    }
                }

                else if (menuitem.Equals("SoilPollutionCategories.Create.Cancel")) view = View("SoilPollutionCategories", db);
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
        public ActionResult SoilPollutionCategoriesDelete(int code)
        {
            ORTContext db = null;
            ViewBag.EGHLayout = "ORT.SoilPollutionCategories";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new ORTContext();

                if (menuitem.Equals("SoilPollutionCategories.Delete.Delete"))
                {
                    if (EGH01DB.Types.SoilPollutionCategories.DeleteByCode(db, code)) view = View("SoilPollutionCategories", db);
                }
                else if (menuitem.Equals("SoilPollutionCategories.Delete.Cancel")) view = View("SoilPollutionCategories", db);

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
        public ActionResult SoilPollutionCategoriesUpdate(SoilPollutionCategoriesView sp)
        {
            ORTContext db = null;
            ViewBag.EGHLayout = "ORT.SoilPollutionCategories";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new ORTContext();
                view = View("SoilPollutionCategories", db);
                if (menuitem.Equals("SoilPollutionCategories.Update.Update"))
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

                    EGH01DB.Types.SoilPollutionCategories soil_pollution = new EGH01DB.Types.SoilPollutionCategories(code,name,min,max);
                                if (EGH01DB.Types.SoilPollutionCategories.Update(db, soil_pollution))
                                {
                                    view = View("SoilPollutionCategories", db);
                                }


                            }
                            else if (menuitem.Equals("SoilPollutionCategories.Update.Cancel"))
                                view = View("SoilPollutionCategories", db);


                    
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