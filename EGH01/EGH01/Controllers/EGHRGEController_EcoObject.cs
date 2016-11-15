﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using EGH01.Models.EGHRGE;
using EGH01DB;
using EGH01DB.Primitives;
using EGH01DB.Types;
using System.Globalization;
using EGH01DB.Points;

namespace EGH01.Controllers
{
    public partial class EGHRGEController : Controller
    {
        public ActionResult EcoObject()
        {
            RGEContext db = null;
            ViewBag.EGHLayout = "RGE.EcoObject";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new RGEContext();
                ViewBag.msg = "Соединение с базой данных установлено";
                view = View("EcoObject", db);

                if (menuitem.Equals("EcoObject.Create"))
                {

                    view = View("EcoObjectCreate");

                }
                else if (menuitem.Equals("EcoObject.Delete"))
                {
                    string id = this.HttpContext.Request.Params["type_code"];
                    if (id != null)
                    {
                        int c = 0;
                        if (int.TryParse(id, out c))
                        {
                            EGH01DB.Objects.EcoObject eo = new EGH01DB.Objects.EcoObject();
                            if (EGH01DB.Objects.EcoObject.GetById(db, c, ref eo))
                            {
                                view = View("EcoObjectDelete", eo);
                            }
                        }
                    }
                }
                else if (menuitem.Equals("EcoObject.Update"))
                {
                    string id = this.HttpContext.Request.Params["type_code"];

                    if (id != null)
                    {
                        int c = 0;
                        if (int.TryParse(id, out c))
                        {
                            EGH01DB.Objects.EcoObject eo = new EGH01DB.Objects.EcoObject();
                            if (EGH01DB.Objects.EcoObject.GetById(db, c, ref eo))
                            {
                                view = View("EcoObjectUpdate", eo);
                            }
                        }
                    }
                }
                //else if (menuitem.Equals("GroundType.Excel"))
                //{
                //    EGH01DB.Objects.RiskObject.RiskObjectList list = new EGH01DB.Objects.RiskObject.RiskObjectList();
                //    XmlNode node = list.toXmlNode();
                //    XmlDocument doc = new XmlDocument();
                //    XmlNode nnode = doc.ImportNode(node, true);
                //    doc.AppendChild(nnode);
                //    doc.Save(Server.MapPath("~/App_Data/RiskObject.xml"));
                //    view = View("Index");

                //    view = File(Server.MapPath("~/App_Data/RiskObject.xml"), "text/plain", "RiskObject.xml");


                //}

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
        public ActionResult EcoObjectCreate(EGH01.Models.EGHRGE.EcoObjectView eo)
        {
            RGEContext db = null;
            ViewBag.EGHLayout = "RGE";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new RGEContext();
                view = View("EcoObject", db);
                if (menuitem.Equals("EcoObject.Create.Create"))
                {

                    int id = -1;
                    if (EGH01DB.Objects.EcoObject.GetNextId(db, out id))
                    {
                        String name = eo.name;
                        CadastreType type_cadastre = new CadastreType();
                        if (EGH01DB.Types.CadastreType.GetByCode(db, eo.list_cadastre, out type_cadastre))
                        {
                            EcoObjectType eco_type = new EcoObjectType();
                            if (EGH01DB.Types.EcoObjectType.GetByCode(db, eo.list_ecoType, out eco_type))
                            {
                                bool iswaterobject = eo.iswaterobject;
                                string strlat_s = this.HttpContext.Request.Params["lat_s"] ?? "Empty";
                                string strlng_s = this.HttpContext.Request.Params["lng_s"] ?? "Empty";
                                string strwaterdeep = this.HttpContext.Request.Params["waterdeep"] ?? "Empty";
                                string strheight = this.HttpContext.Request.Params["height"] ?? "Empty";
                                float lat_s = 0.0f;
                                float lng_s = 0.0f;
                                float waterdeep = 0.0f;
                                float height = 0.0f;
                                if (!Helper.FloatTryParse(strlat_s, out lat_s))
                                {
                                    lat_s = 0.0f;
                                }
                                if (!Helper.FloatTryParse(strlng_s, out lng_s))
                                {
                                    lng_s = 0.0f;
                                }
                                if (!Helper.FloatTryParse(strwaterdeep, out waterdeep))
                                {
                                    waterdeep = 0.0f;
                                }
                                if (!Helper.FloatTryParse(strheight, out height))
                                {
                                    height = 0.0f;
                                }
                                Coordinates coordinates = new Coordinates(eo.latitude, eo.lat_m, lat_s, eo.lngitude, eo.lng_m, lng_s);
                                EGH01DB.Types.GroundType ground_type = new EGH01DB.Types.GroundType();
                                if (EGH01DB.Types.GroundType.GetByCode(db, eo.list_groundType, out ground_type))
                                {
                                    Point point = new Point(coordinates, ground_type, waterdeep, height);
                                    EGH01DB.Objects.EcoObject eco_object = new EGH01DB.Objects.EcoObject(id, point, eco_type, type_cadastre, name, iswaterobject);
                                    if (EGH01DB.Objects.EcoObject.Create(db, eco_object))
                                    {
                                        view = View("EcoObject", db);
                                    }
                                }
                            }
                        }
                        else if (menuitem.Equals("EcoObject.Create.Cancel")) view = View("EcoObject", db);
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
        public ActionResult EcoObjectDelete(int type_code)
        {
            RGEContext db = null;
            ViewBag.EGHLayout = "RGE";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new RGEContext();

                if (menuitem.Equals("EcoObject.Delete.Delete"))
                {
                    if (EGH01DB.Objects.EcoObject.DeleteById(db, type_code))
                        view = View("EcoObject", db);
                }
                else if (menuitem.Equals("EcoObject.Delete.Cancel"))
                    view = View("EcoObject", db);

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
        public ActionResult EcoObjectUpdate(EcoObjectView eov)
        {
            RGEContext db = null;
            ViewBag.EGHLayout = "RGE";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new RGEContext();
                view = View("EcoObject", db);
                if (menuitem.Equals("EcoObject.Update.Update"))
                {

                    //int id = ah.id;
                    //int lat = ah.Lat_d;
                    //Coordinates coordinates = new Coordinates(ah.Lat_d, ah.lat_m, ah.lat_s, ah.lngitude, ah.lng_m, ah.lng_s);
                    //float waterdeep = 0.0f;
                    //int list_cadastre = ah.list_cadastre;
                    //float height = 0.0f;
                    //string strheight = this.HttpContext.Request.Params["height"] ?? "Empty";
                    //if (!Helper.FloatTryParse(strheight, out height))
                    //{
                    //    height = 0.0f;
                    //}
                    //string strwaterdeep = this.HttpContext.Request.Params["waterdeep"] ?? "Empty";
                    //if (!Helper.FloatTryParse(strwaterdeep, out waterdeep))
                    //{
                    //    waterdeep = 0.0f;
                    //}

                    //EGH01DB.Types.GroundType ground_type = new EGH01DB.Types.GroundType();
                    //if (EGH01DB.Types.GroundType.GetByCode(db, ah.list_groundType, out ground_type))
                    //{

                    //    Point point = new Point(coordinates, ground_type, waterdeep, height);

                    //    CadastreType type_cadastre = new CadastreType();
                    //    if (EGH01DB.Types.CadastreType.GetByCode(db, ah.list_cadastre, out type_cadastre))
                    //    {
                    //        EGH01DB.Points.AnchorPoint anchor_point = new EGH01DB.Points.AnchorPoint(id, point, type_cadastre);


                    //        if (EGH01DB.Points.AnchorPoint.Update(db, anchor_point))
                    //        {
                    //            view = View("EcoObject", db);
                    //        }
                    //    }

                    //}
                    //else if (menuitem.Equals("EcoObject.Update.Cancel")) view = View("EcoObject", db);
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


    }
}