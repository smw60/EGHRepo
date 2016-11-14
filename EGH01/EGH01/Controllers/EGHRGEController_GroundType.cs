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
            ViewBag.EGHLayout = "RGE.GroundType";
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
                                view = View("GroundTypeUpdate", gt);
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
                    float diffusion;
                    string strdiffusion = this.HttpContext.Request.Params["diffusion"] ?? "Empty";
                    if (!Helper.FloatTryParse(strdiffusion, out diffusion))
                    {
                        diffusion = 0.0f;
                    }
                    float distribution;
                    string strdistribution = this.HttpContext.Request.Params["distribution"] ?? "Empty";
                    if (!Helper.FloatTryParse(strdistribution, out distribution))
                    {
                        distribution = 0.0f;
                    }
                    float sorption = 0.0f;
                    string strsorption = this.HttpContext.Request.Params["sorption"] ?? "Empty";
                    if (!Helper.FloatTryParse(strsorption, out sorption))
                    {
                        sorption = 0.0f;
                    }
                    float permeability = 0.2f;
                    string strpermeability = this.HttpContext.Request.Params["permeability"] ?? "Empty";
                    if (!Helper.FloatTryParse(strpermeability, out permeability))
                    {
                        permeability = 0.0f;
                    }
                    String name = gt.name;
                    string strporosity = this.HttpContext.Request.Params["porosity"] ?? "Empty";
                    float porosity = 0.1f;
                    if (!Helper.FloatTryParse(strporosity, out porosity))
                    {
                        porosity = 0.0f;
                    }
                    string strsoilmoisture = this.HttpContext.Request.Params["soilmoisture"] ?? "Empty";
                    float soilmoisture = 0.1f;//влажность
                    if (!Helper.FloatTryParse(strsoilmoisture, out soilmoisture))
                    {
                        soilmoisture = 0.0f;
                    }
                    string strwatercapacity = this.HttpContext.Request.Params["watercapacity"] ?? "Empty";
                    float watercapacity = 0.1f;//влагоемкость
                    if (!Helper.FloatTryParse(strwatercapacity, out watercapacity))
                    {
                        watercapacity = 0.0f;
                    }
                    string strholdmigration = this.HttpContext.Request.Params["holdmigration"] ?? "Empty";
                    float holdmigration = 0.1f;//задержки
                    if (!Helper.FloatTryParse(strholdmigration, out holdmigration))
                    {
                        holdmigration = 0.0f;
                    }
                    string strwaterfilter = this.HttpContext.Request.Params["waterfilter"] ?? "Empty";
                    float waterfilter = 0.1f;//фильтрации
                    if (!Helper.FloatTryParse(strwaterfilter, out waterfilter))
                    {
                        waterfilter = 0.0f;
                    }
                    string strаveryanovfactor = this.HttpContext.Request.Params["аveryanovfactor"] ?? "Empty";
                    float аveryanovfactor = 0.1f;//аверьянова коэф
                    if (!Helper.FloatTryParse(strаveryanovfactor, out аveryanovfactor))
                    {
                        аveryanovfactor = 0.0f;
                    }

                    string strdensity = this.HttpContext.Request.Params["density"] ?? "Empty";
                    float density = 0.1f;
                    if (!Helper.FloatTryParse(strdensity, out density))
                    {
                        density = 0.0f;
                    }

               //     EGH01DB.Types.GroundType ground_type = new EGH01DB.Types.GroundType(type_code, name, porosity, holdmigration, waterfilter, diffusion, distribution, sorption, watercapacity, soilmoisture, аveryanovfactor, permeability);

                    EGH01DB.Types.GroundType ground_type = new EGH01DB.Types.GroundType(type_code, name, porosity, holdmigration, waterfilter, diffusion, distribution, sorption, watercapacity, soilmoisture, аveryanovfactor, permeability, density); // blinova



                    if (EGH01DB.Types.GroundType.Create(db, ground_type))
                    {
                        view = View("GroundType", db);
                    }
                }

                //}
                else if (menuitem.Equals("GroundType.Create.Cancel")) view = View("GroundType", db);
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
        [HttpPost]
        public ActionResult GroundTypeUpdate(GroundTypeView gt)
        {
            RGEContext db = null;
            ViewBag.EGHLayout = "RGE";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new RGEContext();
                view = View("GroundType", db);
                if (menuitem.Equals("GroundType.Update.Update"))
                {

                        int type_code = gt.type_code;
                    float diffusion;
                    string strdiffusion = this.HttpContext.Request.Params["diffusion"] ?? "Empty";
                    if (!Helper.FloatTryParse(strdiffusion, out diffusion))
                    {
                        diffusion = 0.0f;
                    }
                    float distribution;
                    string strdistribution = this.HttpContext.Request.Params["distribution"] ?? "Empty";
                    if (!Helper.FloatTryParse(strdistribution, out distribution))
                    {
                        distribution = 0.0f;
                    }
                    float sorption = 0.0f;
                    string strsorption = this.HttpContext.Request.Params["sorption"] ?? "Empty";
                    if (!Helper.FloatTryParse(strsorption, out sorption))
                    {
                        sorption = 0.0f;
                    }
                    float permeability = 0.2f;
                    string strpermeability = this.HttpContext.Request.Params["permeability"] ?? "Empty";
                    if (!Helper.FloatTryParse(strpermeability, out permeability))
                    {
                        permeability = 0.0f;
                    }
                    String name = gt.name;
                        string strporosity = this.HttpContext.Request.Params["porosity"] ?? "Empty";
                        float porosity = 0.1f;
                        if (!Helper.FloatTryParse(strporosity, out porosity))
                        {
                            porosity = 0.0f;
                        }
                        string strsoilmoisture = this.HttpContext.Request.Params["soilmoisture"] ?? "Empty";
                        float soilmoisture = 0.1f;//влажность
                        if (!Helper.FloatTryParse(strsoilmoisture, out soilmoisture))
                        {
                            soilmoisture = 0.0f;
                        }
                        string strwatercapacity = this.HttpContext.Request.Params["watercapacity"] ?? "Empty";
                        float watercapacity = 0.1f;//влагоемкость
                        if (!Helper.FloatTryParse(strwatercapacity, out watercapacity))
                        {
                            watercapacity = 0.0f;
                        }
                        string strholdmigration = this.HttpContext.Request.Params["holdmigration"] ?? "Empty";
                        float holdmigration = 0.1f;//задержки
                        if (!Helper.FloatTryParse(strholdmigration, out holdmigration))
                        {
                            holdmigration = 0.0f;
                        }
                        string strwaterfilter = this.HttpContext.Request.Params["waterfilter"] ?? "Empty";
                        float waterfilter = 0.1f;//фильтрации
                        if (!Helper.FloatTryParse(strwaterfilter, out waterfilter))
                        {
                            waterfilter = 0.0f;
                        }
                    string strаveryanovfactor = this.HttpContext.Request.Params["аveryanovfactor"] ?? "Empty";
                    float аveryanovfactor = 0.1f;//аверьянова коэф
                    if (!Helper.FloatTryParse(strаveryanovfactor, out аveryanovfactor))
                    {
                        аveryanovfactor = 0.0f;
                    }
                    string strdensity = this.HttpContext.Request.Params["density"] ?? "Empty";
                    float density = 0.1f;
                    if (!Helper.FloatTryParse(strdensity, out density))
                    {
                        density = 0.0f;
                    }
                    GroundType gti = new GroundType((int)type_code,
                                                    (string)name,
                                                    (float)porosity,
                                                    (float)holdmigration,
                                                    (float)waterfilter,
                                                    (float)diffusion,
                                                    (float)distribution,
                                                    (float)sorption,
                                                    (float)watercapacity,
                                                    (float)soilmoisture,
                                                    (float)аveryanovfactor,
                                                    (float)permeability,
                                                    (float)density); 
                    if (EGH01DB.Types.GroundType.Update(db, gti))
                    {
                        view = View("GroundType", db);
                    }
                }
                else if (menuitem.Equals("GroundType.Update.Cancel")) view = View("GroundType", db);
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