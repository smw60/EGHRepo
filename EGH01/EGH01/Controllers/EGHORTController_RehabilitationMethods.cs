using EGH01.Models.EGHORT;
using EGH01DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EGH01.Controllers
{
    public partial class EGHORTController: Controller
    {
     
        public ActionResult RehabilitationMethods()
        {
            ORTContext db = null;
            ViewBag.EGHLayout = "ORT.RehabilitationMethods";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new ORTContext(this);
                ViewBag.msg = "Соединение с базой данных установлено";
                view = View("RehabilitationMethods", db);

                if (menuitem.Equals("RehabilitationMethods.Create"))
                {

                    view = View("RehabilitationMethodsCreate");

                }
                else if (menuitem.Equals("RehabilitationMethods.Delete"))
                {
                    string type_code_item = this.HttpContext.Request.Params["type_code"];
                    if (type_code_item != null)
                    {
                        int c = 0;
                        if (int.TryParse(type_code_item, out c))
                        {
                            //EGH01DB.Types.CadastreType cd = new EGH01DB.Types.CadastreType();
                            //if (EGH01DB.Types.CadastreType.GetByCode(db, c, out cd))
                            //{
                            //    view = View("RehabilitationMethodsDelete", cd);
                            //}
                        }
                    }
                }
                else if (menuitem.Equals("RehabilitationMethods.Update"))
                {
                    string type_code_item = this.HttpContext.Request.Params["type_code"];

                    if (type_code_item != null)
                    {
                        int c = 0;
                        if (int.TryParse(type_code_item, out c))
                        {
                            //EGH01DB.Types.CadastreType cd = new EGH01DB.Types.CadastreType();
                            //if (EGH01DB.Types.CadastreType.GetByCode(db, c, out cd))
                            //{
                            //    view = View("RehabilitationMethodsUpdate", cd);
                            //}
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
        public ActionResult RehabilitationMethodsCreate(RehabilitationMethodsView rm)
        {
            ORTContext db = null;
            ViewBag.EGHLayout = "ORT.RehabilitationMethods";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new ORTContext();
                view = View("RehabilitationMethods", db);
                if (menuitem.Equals("RehabilitationMethods.Create.Create"))
                {

                    int id = -1; }
                //if (EGH01DB.Objects.RehabilitationMethods.GetNextId(db, out id))
                //{                  
                //                        if (EGH01DB.Objects.RehabilitationMethods.Create(db,))
                //                        {
                //                            view = View("RehabilitationMethods", db);
                //                        }
                //                    }


                else if (menuitem.Equals("RehabilitationMethods.Create.Cancel")) view = View("RehabilitationMethods", db);
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
        public ActionResult RehabilitationMethodsDelete(int type_code)
        {
            ORTContext db = null;
            ViewBag.EGHLayout = "ORT";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new ORTContext();

                if (menuitem.Equals("RehabilitationMethods.Delete.Delete"))
                {
                    //    if (EGH01DB..DeleteById(db, type_code)) view = View("RehabilitationMethods", db);
                }
                else if (menuitem.Equals("RehabilitationMethods.Delete.Cancel")) view = View("RehabilitationMethods", db);

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
        public ActionResult RehabilitationMethodsUpdate(RehabilitationMethodsView rm)
        {
            ORTContext db = null;
            ViewBag.EGHLayout = "ORT.RehabilitationMethods";
            ActionResult view = View("Index");
            string menuitem = this.HttpContext.Request.Params["menuitem"] ?? "Empty";
            try
            {
                db = new ORTContext();
                view = View("RehabilitationMethods", db);
                if (menuitem.Equals("RehabilitationMethods.Update.Update"))
                {

                    int id = -1;
                }
                //if (EGH01DB.Objects.RehabilitationMethods.GetNextId(db, out id))
                //{                  
                //                        if (EGH01DB.Objects.RehabilitationMethods.Update(db,))
                //                        {
                //                            view = View("RehabilitationMethods", db);
                //                        }
                //                    }


                else if (menuitem.Equals("RehabilitationMethods.Update.Cancel")) view = View("RehabilitationMethods", db);
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