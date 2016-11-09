using System;
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
        public ActionResult AnchorPoint()
        {
            RGEContext db = null;
            ViewBag.EGHLayout = "RGE";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new RGEContext();
                ViewBag.msg = "Соединение с базой данных установлено";
                view = View("AnchorPoint", db);

                if (menuitem.Equals("AnchorPoint.Create"))
                {

                    view = View("AnchorPointCreate");

                }
                else if (menuitem.Equals("AnchorPoint.Delete"))
                {
                    string type_code_item = this.HttpContext.Request.Params["type_code"];
                    if (type_code_item != null)
                    {
                        int c = 0;
                        if (int.TryParse(type_code_item, out c))
                        {
                            EGH01DB.Points.AnchorPoint ah = new EGH01DB.Points.AnchorPoint();
                            if (EGH01DB.Points.AnchorPoint.GetById(db, c, ref ah))
                            {
                                view = View("AnchorPointDelete", ah);
                            }
                        }
                    }
                }
                else if (menuitem.Equals("AnchorPoint.Update"))
                {
                    string type_code_item = this.HttpContext.Request.Params["type_code"];

                    if (type_code_item != null)
                    {
                        int c = 0;
                        if (int.TryParse(type_code_item, out c))
                        {
                            EGH01DB.Points.AnchorPoint ah = new EGH01DB.Points.AnchorPoint();
                            if (EGH01DB.Points.AnchorPoint.GetById(db, c, ref ah))
                            {
                                view = View("AnchorPointUpdate", ah);
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
        public ActionResult AnchorPointCreate(EGH01.Models.EGHRGE.AnchorPointView ah)
        {
            RGEContext db = null;
            ViewBag.EGHLayout = "RGE";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new RGEContext();
                view = View("AnchorPoint", db);
                if (menuitem.Equals("AnchorPoint.Create.Create"))
                {

                    int id = -1;
                    if (EGH01DB.Points.AnchorPoint.GetNextId(db, out id))
                    {


                        //float lat = EGH01DB.Primitives.Coordinates.dms_to_d(ah.latitude, ah.lat_m, ah.lat_s);
                        //float lng = EGH01DB.Primitives.Coordinates.dms_to_d(ah.lngitude, ah.lng_m, ah.lng_s);
                        Coordinates coordinates = new Coordinates(ah.Lat_d, ah.lat_m, ah.lat_s, ah.lngitude, ah.lng_m, ah.lng_s);

                        //EGH01DB.Primitives.Coordinates.d_to_dms(lat, ref lat_d, ref lat_m, ref lat_s);
                        float waterdeep = 0.0f;
                        int list_cadastre = ah.list_cadastre;
         
                        float height = 0.0f;
                        string strheight = this.HttpContext.Request.Params["height"] ?? "Empty";
                        if (!Helper.FloatTryParse(strheight, out height))
                        {
                            height = 0.0f;
                        }

                        string strwaterdeep = this.HttpContext.Request.Params["waterdeep"] ?? "Empty";
                        if (!Helper.FloatTryParse(strwaterdeep, out waterdeep))
                        {
                            waterdeep = 0.0f;
                        }
                        EGH01DB.Types.GroundType type_groud = new EGH01DB.Types.GroundType();
                        if (EGH01DB.Types.GroundType.GetByCode(db, ah.list_groundType, out type_groud))
                        {
                            GroundType ground_type = new GroundType(ah.list_groundType, type_groud.name, type_groud.porosity, type_groud.holdmigration, type_groud.waterfilter, type_groud.diffusion,
               type_groud.distribution, type_groud.sorption, type_groud.watercapacity, type_groud.soilmoisture, type_groud.аveryanovfactor, type_groud.permeability);
                            Point point = new Point(coordinates, ground_type, waterdeep, height);
                            CadastreType cadastre_type = new CadastreType();
                            if (EGH01DB.Types.CadastreType.GetByCode(db, ah.list_cadastre, out cadastre_type))
                            {
                                CadastreType type_cadastre = new CadastreType(ah.list_cadastre, cadastre_type.name, cadastre_type.pdk_coef, 0.0f); //blinova
                                EGH01DB.Points.AnchorPoint anchor_point = new EGH01DB.Points.AnchorPoint(id, point, type_cadastre);


                                if (EGH01DB.Points.AnchorPoint.Create(db, anchor_point))
                                {
                                    view = View("AnchorPoint", db);
                                }
                            }

                        }
                        else if (menuitem.Equals("AnchorPoint.Create.Cancel")) view = View("AnchorPoint", db);
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
        public ActionResult AnchorPointDelete(int id)
        {
            RGEContext db = null;
            ViewBag.EGHLayout = "RGE";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new RGEContext();

                if (menuitem.Equals("AnchorPoint.Delete.Delete"))
                {
                    if (EGH01DB.Points.AnchorPoint.DeleteById(db, id)) view = View("AnchorPoint", db);
                }
                else if (menuitem.Equals("AnchorPoint.Delete.Cancel")) view = View("AnchorPoint", db);

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
        public ActionResult AnchorPointUpdate(AnchorPointView ah)
        {
            RGEContext db = null;
            ViewBag.EGHLayout = "RGE";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new RGEContext();
                view = View("AnchorPoint", db);
                if (menuitem.Equals("AnchorPoint.Update.Update"))
                {

                    int id = ah.id;
                    //if (EGH01DB.Points.AnchorPoint.GetById(db, out id))
                    //{
                    int lat = ah.Lat_d;

                    //float lat = EGH01DB.Primitives.Coordinates.dms_to_d(ah.latitude, ah.lat_m, ah.lat_s);
                    //float lng = EGH01DB.Primitives.Coordinates.dms_to_d(ah.lngitude, ah.lng_m, ah.lng_s);
                    Coordinates coordinates = new Coordinates(ah.Lat_d, ah.lat_m, ah.lat_s, ah.lngitude, ah.lng_m, ah.lng_s);

                    //EGH01DB.Primitives.Coordinates.d_to_dms(lat, ref lat_d, ref lat_m, ref lat_s);
                    float waterdeep = 0.0f;
                    int list_cadastre = ah.list_cadastre;

                    float height = 0.0f;
                    string strheight = this.HttpContext.Request.Params["height"] ?? "Empty";
                    if (!Helper.FloatTryParse(strheight, out height))
                    {
                        height = 0.0f;
                    }

                    string strwaterdeep = this.HttpContext.Request.Params["waterdeep"] ?? "Empty";
                    if (!Helper.FloatTryParse(strwaterdeep, out waterdeep))
                    {
                        waterdeep = 0.0f;
                    }
                    EGH01DB.Types.GroundType type_groud = new EGH01DB.Types.GroundType();
                    if (EGH01DB.Types.GroundType.GetByCode(db, ah.list_groundType, out type_groud))
                    {
                        GroundType ground_type = new GroundType(ah.list_groundType, type_groud.name, type_groud.porosity, type_groud.holdmigration, type_groud.waterfilter, type_groud.diffusion,
           type_groud.distribution, type_groud.sorption, type_groud.watercapacity, type_groud.soilmoisture, type_groud.аveryanovfactor, type_groud.permeability);
                        Point point = new Point(coordinates, ground_type, waterdeep, height);
                        CadastreType cadastre_type = new CadastreType();
                        if (EGH01DB.Types.CadastreType.GetByCode(db, ah.list_cadastre, out cadastre_type))
                        {
                            CadastreType type_cadastre = new CadastreType(ah.list_cadastre, cadastre_type.name, cadastre_type.pdk_coef, 0.0f); //blinova
                            EGH01DB.Points.AnchorPoint anchor_point = new EGH01DB.Points.AnchorPoint(id, point, type_cadastre);


                            if (EGH01DB.Points.AnchorPoint.Update(db, anchor_point))
                            {
                                view = View("AnchorPoint", db);
                            }
                        }

                    }
                    else if (menuitem.Equals("GroundType.Update.Cancel")) view = View("GroundType", db);
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