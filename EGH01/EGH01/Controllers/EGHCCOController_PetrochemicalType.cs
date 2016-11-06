using System;
using System.Web.Mvc;
using EGH01DB.Types;
using EGH01.Models.EGHCCO;
using EGH01DB;
using System.Xml;
using System.Globalization;
using EGH01DB.Primitives;



namespace EGH01.Controllers
{
    public partial class EGHCCOController : Controller
    {
        public ActionResult PetrochemicalType()
        {
            CCOContext db = null;
            ViewBag.EGHLayout = "CCO";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new CCOContext();
                ViewBag.msg = "Соединение с базой данных установлено";
                view = View("PetrochemicalType", db);


                if (menuitem.Equals("PetrochemicalType.Create"))
                {

                    view = View("PetrochemicalTypeCreate");

                }
                else if (menuitem.Equals("PetrochemicalType.Delete"))
                {
                    string type_code_item = this.HttpContext.Request.Params["type_code"];
                    if (type_code_item != null)
                    {
                        int c = 0;
                        if (int.TryParse(type_code_item, out c))
                        {
                            PetrochemicalType pt = new PetrochemicalType();
                            if (EGH01DB.Types.PetrochemicalType.GetByCode(db, c, ref pt))
                            {
                                view = View("PetrochemicalTypeDelete", pt);
                            }
                        }
                    }
                }
                else if (menuitem.Equals("PetrochemicalType.Update"))
                {
                    string type_code_item = this.HttpContext.Request.Params["type_code"];

                    if (type_code_item != null)
                    {
                        int c = 0;
                        if (int.TryParse(type_code_item, out c))
                        {
                            EGH01DB.Types.PetrochemicalType pt = new EGH01DB.Types.PetrochemicalType();
                            if (EGH01DB.Types.PetrochemicalType.GetByCode(db, c, ref pt))
                            {
                                view = View("PetrochemicalTypeUpdate", pt);
                            }
                        }
                    }
                }
                else if (menuitem.Equals("PetrochemicalType.Excel"))
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
        public ActionResult PetrochemicalTypeCreate(PetrochemicalTypeView ptv)
        {
            CCOContext db = null;
            ViewBag.EGHLayout = "CCO";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new CCOContext();
                view = View("PetrochemicalType", db);
                if (menuitem.Equals("PetrochemicalType.Create.Create"))
                {
                    int id = -1;
                    if (EGH01DB.Types.PetrochemicalType.GetNextCode(db, out id))
                    {
                        int    type_code = ptv.code_type;
                        string name = ptv.name;

                        string strboilingtemp = this.HttpContext.Request.Params["boilingtemp"] ?? "Empty";
                        float boilingtemp = 0.0f;
                        Helper.FloatTryParse(strboilingtemp, out boilingtemp);

                        string strdensity = this.HttpContext.Request.Params["density"] ?? "Empty";
                        float density = 0.0f;
                        Helper.FloatTryParse(strdensity, out density);

                        string strviscosity = this.HttpContext.Request.Params["viscosity"] ?? "Empty";
                        float  viscosity = 0.0f;
                        Helper.FloatTryParse(strviscosity, out viscosity);

                        string strsolubility = this.HttpContext.Request.Params["solubility"] ?? "Empty";
                        float solubility = 0.0f;
                        Helper.FloatTryParse(strsolubility, out solubility);

                        string strtension = this.HttpContext.Request.Params["tension"] ?? "Empty";
                        float tension = 0.0f;
                        Helper.FloatTryParse(strtension, out tension);

                        string strdynamicviscosity = this.HttpContext.Request.Params["dynamicviscosity"] ?? "Empty";
                        float dynamicviscosity = 0.0f;
                        Helper.FloatTryParse(strdynamicviscosity, out dynamicviscosity);

                        string strdiffusion = this.HttpContext.Request.Params["diffusion"] ?? "Empty";
                        float diffusion = 0.0f;
                        Helper.FloatTryParse(strdiffusion, out diffusion);

                        //PetrochemicalType pt = new PetrochemicalType((int)type_code, (string)name, (float)boilingtemp, (float)density, (float)viscosity, (float)solubility) ;// закрыла пустышкой
                        PetrochemicalType pt = new PetrochemicalType((int)type_code, (string)name, (float)boilingtemp, (float)density, 
                            (float)viscosity, (float)solubility, (float)tension, (float)dynamicviscosity, (float)diffusion);
                        if (EGH01DB.Types.PetrochemicalType.Create(db, pt))
                        {
                            view = View("PetrochemicalType", db);
                        }
                        else if (menuitem.Equals("PetrochemicalType.Create.Cancel")) view = View("PetrochemicalType", db);
                    }
                }
                else if (menuitem.Equals("PetrochemicalType.Create.Cancel")) view = View("PetrochemicalType", db);
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
        public ActionResult PetrochemicalTypeDelete(int type_code)
        {
            CCOContext db = null;
            ViewBag.EGHLayout = "CCO";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new CCOContext();
                if (menuitem.Equals("PetrochemicalType.Delete.Delete"))
                {
                    if (EGH01DB.Types.PetrochemicalType.DeleteByCode(db, type_code)) view = View("PetrochemicalType", db);
                }
                else if (menuitem.Equals("PetrochemicalType.Delete.Cancel")) view = View("PetrochemicalType", db);

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
        public ActionResult PetrochemicalTypeUpdate(PetrochemicalTypeView ptv)
        {
            CCOContext db = null;
            ViewBag.EGHLayout = "CCO";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new CCOContext();
                if (menuitem.Equals("PetrochemicalType.Update.Update"))
                {

                    int type_code = ptv.code_type;
                    string name = ptv.name;
                    //float boilingtemp = ptv.boilingtemp;
                    string strboilingtemp = this.HttpContext.Request.Params["boilingtemp"] ?? "Empty";
                    float boilingtemp = 0.0f;
                    if (!float.TryParse(strboilingtemp, NumberStyles.Any, new CultureInfo("en-US"), out boilingtemp))
                    {
                        boilingtemp = 0.0f;
                    }
                    //
                    float density = ptv.density;
                    float viscosity = ptv.viscosity;
                    float solubility = ptv.solubility;
                    float tension = ptv.tension;
                    float dynamicviscosity = ptv.dynamicviscosity;
                    float diffusion = ptv.diffusion;     
                    //PetrochemicalType pt = new PetrochemicalType((int)type_code, (string)name, (float)boilingtemp, (float)density, (float)viscosity, (float)solubility);// закрыла пустышкой
                    PetrochemicalType pt = new PetrochemicalType((int)type_code, (string)name, (float)boilingtemp, (float)density, (float)viscosity, (float)solubility, (float)tension, (float)dynamicviscosity, (float)diffusion);
                    if (EGH01DB.Types.PetrochemicalType.Update(db, pt))
                        view = View("PetrochemicalType", db);
                }
                else if (menuitem.Equals("PetrochemicalType.Update.Cancel")) view = View("PetrochemicalType", db);
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