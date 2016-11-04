using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using EGH01DB;
using EGH01DB.Primitives;
using EGH01DB.Types;

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
                                view = View("GroudTypeDelete", gt);
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
    }









}