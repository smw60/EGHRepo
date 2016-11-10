using System;
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

        public ActionResult SpreadingCoefficient()
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
                //else if (menuitem.Equals("SpreadingCoefficient.Delete"))
                //{
                //    string type_code_item = this.HttpContext.Request.Params["type_code"];
                //    if (type_code_item != null)
                //    {
                //        int c = 0;
                //        if (int.TryParse(type_code_item, out c))
                //        {
                //            SpreadingCoefficient pt = new SpreadingCoefficient();
                //            if (EGH01DB.Primitives.SpreadingCoefficient.GetByData(db, c, ref pt))
                //            {
                //                view = View("SpreadingCoefficientDelete", pt);
                //            }
                //        }
                //    }
                //}
                //else if (menuitem.Equals("SpreadingCoefficient.Update"))
                //{
                //    string type_code_item = this.HttpContext.Request.Params["type_code"];

                //    if (type_code_item != null)
                //    {
                //        int c = 0;
                //        if (int.TryParse(type_code_item, out c))
                //        {
                //            EGH01DB.Primitives.SpreadingCoefficient pt = new EGH01DB.Primitives.SpreadingCoefficient();
                //            if (EGH01DB.Primitives.SpreadingCoefficient.GetByData(db, c, ref pt))
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
                    //int id = -1;
                    //if (EGH01DB.Primitives.SpreadingCoefficient.GetNextCode(db, out id))
                    //{
                        GroundType ground_type = scv.ground_type;


                        string strmin_angle = this.HttpContext.Request.Params["min_angle"] ?? "Empty";
                        float min_angle = 0.0f;
                        Helper.FloatTryParse(strmin_angle, out min_angle);

                        string strmax_angle = this.HttpContext.Request.Params["max_angle"] ?? "Empty";
                        float max_angle = 0.0f;
                        Helper.FloatTryParse(strmax_angle, out max_angle);

                        string strmin_volume = this.HttpContext.Request.Params["min_volume"] ?? "Empty";
                        float min_volume = 0.0f;
                        Helper.FloatTryParse(strmin_volume, out min_volume);

                        string strmax_volume = this.HttpContext.Request.Params["max_volume "] ?? "Empty";
                        float max_volume = 0.0f;
                        Helper.FloatTryParse(strmax_volume, out max_volume);

                        string strkoef = this.HttpContext.Request.Params["koef"] ?? "Empty";
                        float koef = 0.0f;
                        Helper.FloatTryParse(strkoef, out koef);



                        SpreadingCoefficient sc = new EGH01DB.Primitives.SpreadingCoefficient((GroundType)ground_type, (float)min_volume, (float)max_volume, (float)min_angle, (float)max_angle, (float)koef);
                      //  PetrochemicalType pt = new PetrochemicalType((int)type_code, (string)name, (float)boilingtemp, (float)density,
                       //     (float)viscosity, (float)solubility, (float)tension, (float)dynamicviscosity, (float)diffusion);
                        if (EGH01DB.Primitives.SpreadingCoefficient.Create(db, sc))
                        {
                            view = View("SpreadingCoefficient", db);
                        }
                        else if (menuitem.Equals("SpreadingCoefficient.Create.Cancel")) view = View("SpreadingCoefficient", db);
                    //}
                }
                else if (menuitem.Equals("SpreadingCoefficient.Create.Cancel")) view = View("SpreadingCoefficient", db);
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
