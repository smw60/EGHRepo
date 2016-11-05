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

namespace EGH01.Controllers
{
    public partial class EGHRGEController : Controller
    {
        public ActionResult GroundType()
        {
            RGEContext db = null;
            ViewBag.EGHLayout = "RGE";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new RGEContext();
                ViewBag.msg = "Соединение с базой данных установлено";
                view = View("GroundType", db);

                if (menuitem.Equals("GroundType.Create"))
                {

                    view = View("GroundTypeCreate");

                }
                else if (menuitem.Equals("GroundType.Delete"))
                {
                    string type_code_item = this.HttpContext.Request.Params["type_code"];
                    if (type_code_item != null)
                    {
                        int c = 0;
                        if (int.TryParse(type_code_item, out c))
                        {
                            EGH01DB.Types.GroundType gt = new EGH01DB.Types.GroundType();
                            if (EGH01DB.Types.GroundType.GetByCode(db, c, out gt))
                            {
                                view = View("GroundTypeDelete", gt);
                            }
                        }
                    }
                }
                else if (menuitem.Equals("GroundType.Update"))
                {
                    string type_code_item = this.HttpContext.Request.Params["type_code"];

                    if (type_code_item != null)
                    {
                        int c = 0;
                        if (int.TryParse(type_code_item, out c))
                        {
                            EGH01DB.Types.GroundType gt = new EGH01DB.Types.GroundType();
                            if (EGH01DB.Types.GroundType.GetByCode(db, c, out gt))
                            {
                                view = View("GroudTypeUpdate", gt);
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
        public ActionResult GroundTypeCreate(EGH01.Models.EGHRGE.GroundTypeView gt)
        {
            RGEContext db = null;
            ViewBag.EGHLayout = "RGE";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new RGEContext();
                view = View("GroundType", db);
                if (menuitem.Equals("GroundType.Create.Create"))
                {

                    int type_code = -1;
                    //if (EGH01DB.Types.GroundType.GetNextCode(db, out type_code))
                    //{

                    float diffusion = 0.2f;
                    float distribution = 0.2f;
                    float sorption = 0.2f;
                    float permeability = 0.2f;
                    String name = gt.name;
                    string strporosity = this.HttpContext.Request.Params["porosity"] ?? "Empty";
                    float porosity = 0.1f;
                    if (!float.TryParse(strporosity, NumberStyles.Any, new CultureInfo("en-US"), out porosity))
                    {
                        porosity = 0.0f;
                    }
                    float soilmoisture = 0.2f;
                    float watercapacity = 0.2f;
                    float holdmigration = 0.2f;
                    float waterfilter = 0.2f;
                    float аveryanovfactor = 0.2f;
                    EGH01DB.Types.GroundType ground_type = new EGH01DB.Types.GroundType(type_code, name, porosity, holdmigration, waterfilter, diffusion, distribution, sorption, watercapacity, soilmoisture, аveryanovfactor,permeability);

                        if (EGH01DB.Types.GroundType.Create(db, ground_type))
                        {
                            view = View("GroundType", db);
                        }
                    }

                //}
                else if (menuitem.Equals("RiskObject.Create.Cancel")) view = View("RiskObject", db);
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
        public ActionResult GroundTypeDelete(int type_code)
        {
            RGEContext db = null;
            ViewBag.EGHLayout = "RGE";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new RGEContext();

                if (menuitem.Equals("GroundType.Delete.Delete"))
                {
                    if (EGH01DB.Types.GroundType.DeleteByCode(db, type_code)) view = View("GroundType", db);
                }
                else if (menuitem.Equals("GroundType.Delete.Cancel")) view = View("GroundType", db);

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