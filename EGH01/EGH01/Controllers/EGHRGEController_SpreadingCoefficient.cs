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


        //    [HttpPost]
        //    public ActionResult SpreadingCoefficientCreate(SpreadingCoefficientView scv)
        //    {
        //        RGEContext db = null;
        //        ViewBag.EGHLayout = "RGE";
        //        ActionResult view = View("Index");
        //        string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
        //        try
        //        {
        //            db = new RGEContext();
        //            view = View("SpreadingCoefficient", db);
        //            if (menuitem.Equals("SpreadingCoefficient.Create.Create"))
        //            {
        //                int id = -1;
        //                if (EGH01DB.Primitives.SpreadingCoefficient.GetNextCode(db, out id))
        //                {
        //                    int type_code = scv.code_type;
        //                    string name = scv.name;

        //                    string strboilingtemp = this.HttpContext.Request.Params["boilingtemp"] ?? "Empty";
        //                    float boilingtemp = 0.0f;
        //                    Helper.FloatTryParse(strboilingtemp, out boilingtemp);

        //                    string strdensity = this.HttpContext.Request.Params["density"] ?? "Empty";
        //                    float density = 0.0f;
        //                    Helper.FloatTryParse(strdensity, out density);

        //                    string strviscosity = this.HttpContext.Request.Params["viscosity"] ?? "Empty";
        //                    float viscosity = 0.0f;
        //                    Helper.FloatTryParse(strviscosity, out viscosity);

        //                    string strsolubility = this.HttpContext.Request.Params["solubility"] ?? "Empty";
        //                    float solubility = 0.0f;
        //                    Helper.FloatTryParse(strsolubility, out solubility);

        //                    string strtension = this.HttpContext.Request.Params["tension"] ?? "Empty";
        //                    float tension = 0.0f;
        //                    Helper.FloatTryParse(strtension, out tension);

        //                    string strdynamicviscosity = this.HttpContext.Request.Params["dynamicviscosity"] ?? "Empty";
        //                    float dynamicviscosity = 0.0f;
        //                    Helper.FloatTryParse(strdynamicviscosity, out dynamicviscosity);

        //                    string strdiffusion = this.HttpContext.Request.Params["diffusion"] ?? "Empty";
        //                    float diffusion = 0.0f;
        //                    Helper.FloatTryParse(strdiffusion, out diffusion);

        //                    PetrochemicalType pt = new PetrochemicalType((int)type_code, (string)name, (float)boilingtemp, (float)density,
        //                        (float)viscosity, (float)solubility, (float)tension, (float)dynamicviscosity, (float)diffusion);
        //                    if (EGH01DB.Types.PetrochemicalType.Create(db, pt))
        //                    {
        //                        view = View("PetrochemicalType", db);
        //                    }
        //                    else if (menuitem.Equals("PetrochemicalType.Create.Cancel")) view = View("PetrochemicalType", db);
        //                }
        //            }
        //            else if (menuitem.Equals("PetrochemicalType.Create.Cancel")) view = View("PetrochemicalType", db);
        //        }
        //        catch (RGEContext.Exception e)
        //        {
        //            ViewBag.msg = e.message;
        //        }
        //        catch (Exception e)
        //        {
        //            ViewBag.msg = e.Message;
        //        }

        //        return view;
        //    }


        //}
    }
}