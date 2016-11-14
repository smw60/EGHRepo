﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using EGH01DB;
using EGH01DB.Primitives;
using EGH01DB.Types;
using EGH01.Models.EGHRGE;


namespace EGH01.Controllers
{
    public partial class EGHRGEController : Controller
    {

        public ActionResult SpreadingCoefficient(SpreadingCoefficientView scv)
        {

            RGEContext db = null;
            ActionResult view = View("Index");
            ViewBag.EGHLayout = "RGE.SpreadingCoefficient";
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new RGEContext();
                ViewBag.msg = "Соединение с базой данных установлено";
                view = View("SpreadingCoefficient", db);


                if (menuitem.Equals("SpreadingCoefficient.Create"))
                {

                    view = View("SpreadingCoefficientCreate");

                }

                else if (menuitem.Equals("SpreadingCoefficient.Delete"))
                {
                    EGH01DB.Types.GroundType type_grounde = new EGH01DB.Types.GroundType();
                    if (EGH01DB.Types.GroundType.GetByCode(db, scv.list_groundType, out type_grounde))
                    {
                        //GroundType ground_type = new GroundType(scv.list_groundType, type_groud.name, type_groud.porosity, type_groud.holdmigration, type_groud.waterfilter, type_groud.diffusion,
                        //type_groud.distribution, type_groud.sorption, type_groud.watercapacity, type_groud.soilmoisture, type_groud.аveryanovfactor, type_groud.permeability);

                        string strmin_angle = this.HttpContext.Request.Params["min_angle"] ?? "Empty";
                        float min_angle;
                        Helper.FloatTryParse(strmin_angle, out min_angle);

                        string strmax_angle = this.HttpContext.Request.Params["max_angle"] ?? "Empty";
                        float max_angle;
                        Helper.FloatTryParse(strmax_angle, out max_angle);

                        string strmin_volume = this.HttpContext.Request.Params["min_volume"] ?? "Empty";
                        float min_volume;
                        Helper.FloatTryParse(strmin_volume, out min_volume);

                        string strmax_volume = this.HttpContext.Request.Params["max_volume "] ?? "Empty";
                        float max_volume;
                        Helper.FloatTryParse(strmax_volume, out max_volume);

                        string strkoef = this.HttpContext.Request.Params["koef"] ?? "Empty";
                        float koef;
                        Helper.FloatTryParse(strkoef, out koef);


                        float volume = max_volume - min_volume;
                        float angle = max_angle - min_angle;
                        SpreadingCoefficient sc = new EGH01DB.Primitives.SpreadingCoefficient((GroundType)type_grounde, (float)min_volume, (float)max_volume, (float)min_angle, (float)max_angle, (float)koef);

                    
                        //if (EGH01DB.Primitives.SpreadingCoefficient.GetByData(db, (GroundType)type_grounde,(float)volume,(float)angle))
                        //{
                            view = View("SpreadingCoefficientDelete", sc);
                        //}

                    }

                    //else if (menuitem.Equals("SpreadingCoefficient.Update"))
                    //{
                    //    string type_code_item = this.HttpContext.Request.Params["type_code"];

                    //    if (type_code_item != null)
                    //    {
                    //        int c = 0;
                    //        if (int.TryParse(type_code_item, out c))
                    //        {
                    //            EGH01DB.Primitives.SpreadingCoefficient sc = new EGH01DB.Primitives.SpreadingCoefficient();
                    //            if (EGH01DB.Primitives.SpreadingCoefficient.GetByData()
                    //            {
                    //                view = View("SpreadingCoefficientUpdate", pt);
                    //            }
                    //        }
                    //    }
                    //}
                    else if (menuitem.Equals("SpreadingCoefficient.Excel"))
                    {
                        //EGH01DB.Types.PetrochemicalType.PetrochemicalTypeList list = new EGH01DB.Types.PetrochemicalType.PetrochemicalTypeList();
                        //XmlNode node = list.toXmlNode();
                        //XmlDocument doc = new XmlDocument();
                        //XmlNode nnode = doc.ImportNode(node, true);
                        //doc.AppendChild(nnode);
                        //doc.Save(Server.MapPath("~/App_Data/PetrochemicalType.xml"));
                        //view = View("Index");

                        //view = File(Server.MapPath("~/App_Data/PetrochemicalType.xml"), "text/plain", "PetrochemicalType.xml");


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
        public ActionResult SpreadingCoefficientCreate(SpreadingCoefficientView scv)
        {
            RGEContext db = null;
            ViewBag.EGHLayout = "RGE";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new RGEContext();
                view = View("SpreadingCoefficient", db);
                if (menuitem.Equals("SpreadingCoefficient.Create.Create"))
                {

                    EGH01DB.Types.GroundType type_groud = new EGH01DB.Types.GroundType();
                    if (EGH01DB.Types.GroundType.GetByCode(db, scv.list_groundType, out type_groud))
                    {
                        //GroundType ground_type = new GroundType(scv.list_groundType, type_groud.name, type_groud.porosity, type_groud.holdmigration, type_groud.waterfilter, type_groud.diffusion,
                        //type_groud.distribution, type_groud.sorption, type_groud.watercapacity, type_groud.soilmoisture, type_groud.аveryanovfactor, type_groud.permeability);

                        string strmin_angle = this.HttpContext.Request.Params["min_angle"] ?? "Empty";
                        float min_angle;
                        Helper.FloatTryParse(strmin_angle, out min_angle);

                        string strmax_angle = this.HttpContext.Request.Params["max_angle"] ?? "Empty";
                        float max_angle;
                        Helper.FloatTryParse(strmax_angle, out max_angle);

                        string strmin_volume = this.HttpContext.Request.Params["min_volume"] ?? "Empty";
                        float min_volume;
                        Helper.FloatTryParse(strmin_volume, out min_volume);

                        string strmax_volume = this.HttpContext.Request.Params["max_volume"] ?? "Empty";
                        float max_volume;
                        Helper.FloatTryParse(strmax_volume, out max_volume);

                        string strkoef = this.HttpContext.Request.Params["koef"] ?? "Empty";
                        float koef;
                        Helper.FloatTryParse(strkoef, out koef);

                        SpreadingCoefficient sc = new EGH01DB.Primitives.SpreadingCoefficient(type_groud, (float)min_volume, (float)max_volume, (float)min_angle, (float)max_angle, (float)koef);

                        koef = EGH01DB.Primitives.SpreadingCoefficient.Get(db, sc);

                        if (EGH01DB.Primitives.SpreadingCoefficient.Create(db, sc))
                        {
                            view = View("SpreadingCoefficient", db);
                        }
                        else if (menuitem.Equals("SpreadingCoefficient.Create.Cancel")) view = View("SpreadingCoefficient", db);
                    }

                    else if (menuitem.Equals("SpreadingCoefficient.Create.Cancel")) view = View("SpreadingCoefficient", db);
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
        public ActionResult SpreadingCoefficientDelete(SpreadingCoefficient sc)
        {
            RGEContext db = null;
            ViewBag.EGHLayout = "CCO";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new RGEContext();
                if (menuitem.Equals("PetrochemicalType.Delete.Delete"))
                {
                    //SpreadingCoefficient sc = new EGH01DB.Primitives.SpreadingCoefficient();
                    if (EGH01DB.Primitives.SpreadingCoefficient.Delete(db, sc))
                        view = View("SpreadingCoefficient", db);
                }
                else if (menuitem.Equals("SpreadingCoefficient.Delete.Cancel"))
                    view = View("SpreadingCoefficient", db);

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
