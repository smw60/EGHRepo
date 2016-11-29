using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml;
using EGH01DB.Objects;
using EGH01DB.Blurs;
using EGH01DB.Primitives;


namespace EGH01DB
{
    public  partial class CEQContext : IDBContext
    {

        public  partial class ECOEvalution: RGEContext.ECOForecast
        {

            public float excessgroundconcentration { get; set; }      // отношение значения средней конентрации в грунте к ПДК  
            private string errormssageformat = "ECOEvalution: Ошибка в данных. {0}";
            public GroundPollutionList groundpollutionlist   {get; set;}
            public WaterPollutionList waterpolutionlist      { get; set; }

            public ECOEvalution(RGEContext.ECOForecast  forecast): base (forecast)
            {
                CEQContext db = new CEQContext();    // заглушка, выставить правильный контекст //blinova
                //if (this.groundblur.spreadpoint.cadastretype.pdk_coef <= 0)
                //throw new EGHDBException(string.Format(errormssageformat, "Значение предельно-дупустимой концентрации не может быть  меньше или равно нулю"));

                if (this.groundblur.spreadpoint.cadastretype.pdk_coef > 0) this.excessgroundconcentration = this.groundblur.concentrationinsoil / this.groundblur.spreadpoint.cadastretype.pdk_coef;
                else this.excessgroundconcentration = 0.0f;

                this.groundpollutionlist = new GroundPollutionList (this.groundblur.groundpolutionlist.Where(p => p.pointtype == Points.Point.POINTTYPE.ECO).ToList());

                this.waterpolutionlist = new WaterPollutionList();
                foreach(WaterPollution p in this.waterblur.watepollutionlist)
                {
                     if (p.distance >this.groundblur.radius && p.distance < this.waterblur.radius)
                     {
                         this.waterpolutionlist.Add(p);
                     }
                }

           }
            
            public XmlNode toXmlNode(string comment = "")
            { 
                  XmlDocument doc = new XmlDocument();
                  XmlElement rc = doc.CreateElement("ECOEvalution");
                  if (!string.IsNullOrEmpty(comment)) rc.SetAttribute("comment", comment);
                  rc.SetAttribute("excessgroundconcentration",  this.excessgroundconcentration.ToString());
                  {
                    XmlNode n = this.groundpollutionlist.toXmlNode();
                    rc.AppendChild(doc.ImportNode(n, true));
                  }                
                  {
                    XmlNode n = this.waterpolutionlist.toXmlNode();
                    rc.AppendChild(doc.ImportNode(n, true));
                  }  
                  {
                    XmlNode n = base.toXmlNode();
                    rc.AppendChild(doc.ImportNode(n, true));
                  }  

                  return (XmlNode)doc; 
            }


        }


        



     }        


}




        //public XmlNode toXmlNode(string comment = "")
        //{
        //    XmlDocument doc = new XmlDocument();
        //    XmlElement rc = doc.CreateElement("EcoObject");
        //    if (!String.IsNullOrEmpty(comment)) rc.SetAttribute("comment", comment);
        //    rc.SetAttribute("id", this.id.ToString());
        //    XmlNode n = base.toXmlNode("");
        //    rc.AppendChild(doc.ImportNode(n, true));
        //    rc.AppendChild(doc.ImportNode(this.ecoobjecttype.toXmlNode(), true));
        //    rc.AppendChild(doc.ImportNode(this.cadastretype.toXmlNode(), true));
        //    rc.SetAttribute("name", this.name.ToString());
        //    rc.SetAttribute("iswaterobject", this.iswaterobject.ToString());
        //    rc.SetAttribute("angle", this.angle.ToString());
        //    rc.SetAttribute("pollutionecoobject", this.pollutionecoobject.ToString());
           
        //    return (XmlNode)rc;
        //}