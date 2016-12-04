using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml;
using System.Data.SqlClient;
using System.Data;
using EGH01DB.Objects;
using EGH01DB.Blurs;
using EGH01DB.Primitives;


namespace EGH01DB
{
    public  partial class CEQContext : IDBContext
    {

        public  partial class ECOEvalution: RGEContext.ECOForecast
        {
            public int id   {get; set;}
            public DateTime date {get; set;}  
            public float excessgroundconcentration { get; set; }      // отношение значения средней конентрации в грунте к ПДК  
            private string errormssageformat = "ECOEvalution: Ошибка в данных. {0}";
            public GroundPollutionList groundpollutionlist   {get; set;}
            public WaterPollutionList waterpolutionlist      {get; set;}
           
           
            public string line { get
                                    {
                                     return  string.Format("{0}-Р-{1:yyyy-MM-dd}-{2}-П-{3:yyyy-MM-dd}", this.id, this.date,base.id, base.date) 
                                           + string.Format(": {0}, {1}, {2}", this.incident.volume, this.incident.petrochemicaltype.name, this.incident.riskobject.name);
                                    }
                                } 

            public ECOEvalution(RGEContext.ECOForecast  forecast): base (forecast)
            {
                //CEQContext db = new CEQContext();    // заглушка, выставить правильный контекст //blinova
                //if (this.groundblur.spreadpoint.cadastretype.pdk_coef <= 0)
                //throw new EGHDBException(string.Format(errormssageformat, "Значение предельно-дупустимой концентрации не может быть  меньше или равно нулю"));

                this.date = DateTime.Now;
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
            
          
            public ECOEvalution(XmlNode node): base(node.SelectSingleNode(".//ECOForecast"))
            { 
               this.id = Helper.GetIntAttribute(node, "id"); 
               this.date = Helper.GetDateTimeAttribute(node,"date", DateTime.Now);
               this.excessgroundconcentration = Helper.GetFloatAttribute(node, "excessgroundconcentration", 0.0f);
               {
                XmlNode x = node.SelectSingleNode(".//GroundPollutionList");
                if (x != null) this.groundpollutionlist = GroundPollutionList.Create(x);
                else this.groundpollutionlist = null;
               } 
               {
                XmlNode x = node.SelectSingleNode(".//WaterPollutionList");
                if (x != null) this.groundpollutionlist = GroundPollutionList.Create(x);
                else this.waterpolutionlist = null;
               } 
            }

            public XmlNode toXmlNode(string comment = "")
            { 
                  XmlDocument doc = new XmlDocument();
                  XmlElement rc = doc.CreateElement("ECOEvalution");
                  if (!string.IsNullOrEmpty(comment)) rc.SetAttribute("comment", comment);
                  rc.SetAttribute("id",this.id.ToString()); 
                  rc.SetAttribute("date", this.date.ToString());
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

                  return (XmlNode)rc; 
            }


            public static ECOEvalution GetById(IDBContext db, int id)
            { 
               ECOEvalution rc = null;
               using (SqlCommand cmd = new SqlCommand("EGH.GetECOEvalutionById", db.connection))
               {
                        cmd.CommandType = CommandType.StoredProcedure;
                        {
                            SqlParameter parm = new SqlParameter("@IdОтчета", SqlDbType.Int);
                            parm.Value = id;
                            cmd.Parameters.Add(parm);
                        }
                        try
                        {
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                 string xmlContent = (string)reader["ТекстОтчета"];
                                 if (!xmlContent.Trim().Equals(""))
                                 {
                                   XmlDocument doc = new XmlDocument();
                                   doc.LoadXml(xmlContent);
                                   rc =  new CEQContext.ECOEvalution(doc.DocumentElement);
                                 }
                            } 
                            reader.Close();
                         } catch (Exception e) { rc = null;};
                }
                return rc;
            } 
              
         }
      }
    
  }        


 //public class ECOEvalutionList: List<ECOEvalution>
 //       { 
        
         

 //       }

//public GroundBlur(XmlNode node)
 //       {
 //           {
 //            XmlNode x = node.SelectSingleNode(".//SpreadPoint");
 //            if (x != null) this.spreadpoint = new SpreadPoint(x);
 //            else this.spreadpoint = null;
 //           } 
           

 //           XmlNode coordinates_list = node.SelectSingleNode(".//CoordinatesList");
 //           if (coordinates_list != null) this.bordercoordinateslist = CoordinatesList.CreateCoordinatesList(coordinates_list);
 //           else this.bordercoordinateslist = null;

 //           XmlNode spreading_coef = node.SelectSingleNode(".//SpreadingCoefficient");
 //           if (spreading_coef != null) this.spreadingcoefficient = new SpreadingCoefficient(spreading_coef);
 //           else this.spreadingcoefficient = null;

 //           this.square = Helper.GetFloatAttribute(node, "square", 0.0f);
 //           this.radius = Helper.GetFloatAttribute(node, "radius", 0.0f);
 //           this.totalmass = Helper.GetFloatAttribute(node, "totalmass", 0.0f);
 //           this.limitadsorbedmass = Helper.GetFloatAttribute(node, "limitadsorbedmass", 0.0f);

 //           this.avgdeep = Helper.GetFloatAttribute(node, "avgdeep", 0.0f);
 //           this.petrochemicalheight = Helper.GetFloatAttribute(node, "petrochemicalheight", 0.0f);
 //           this.adsorbedmass = Helper.GetFloatAttribute(node, "adsorbedmass", 0.0f);
 //           this.restmass = Helper.GetFloatAttribute(node, "restmass", 0.0f);

 //           this.depth = Helper.GetFloatAttribute(node, "depth", 0.0f);
 //           this.concentrationinsoil = Helper.GetFloatAttribute(node, "concentrationinsoil", 0.0f);
 //           this.timeconcentrationinsoil = Helper.GetFloatAttribute(node, "timeconcentrationinsoil", 0.0f);
 //           this.speedvertical = Helper.GetFloatAttribute(node, "speedvertical", 0.0f);

 //           this.timewatercomletion = Helper.GetFloatAttribute(node, "timewatercomletion", 0.0f);
 //           this.dtimemaxwaterconc = Helper.GetFloatAttribute(node, "dtimemaxwaterconc", 0.0f);
 //           this.timemaxwaterconc = Helper.GetFloatAttribute(node, "timemaxwaterconc", 0.0f);
 //           this.maxconcentrationwater = Helper.GetFloatAttribute(node, "maxconcentrationwater", 0.0f);
 //           this.ozcorrection = Helper.GetFloatAttribute(node, "ozcorrection", 0.0f);
 //           this.ecoobjectsearchradius = Helper.GetFloatAttribute(node, "ecoobjectsearchradius", 0.0f);

 //           { 
 //              XmlNode x = node.SelectSingleNode(".//AnchorPointList");
 //              if (x != null) this.anchorpointlist = AnchorPointList.CreateAnchorPointList(x);
 //              else this.anchorpointlist = null;
 //           }
 //           {
 //            XmlNode x = node.SelectSingleNode(".//GroundPollutionList");
 //            if (x != null) this.groundpolutionlist =  GroundPollutionList.Create(x);
 //            else this.groundpolutionlist = null;
 //           }
 //           {
 //             XmlNode x = node.SelectSingleNode(".//WaterProperties"      );
 //             if (x != null) this.waterproperties = new WaterProperties(x);
 //             else this.waterproperties = null;
 //           }
 //           {
 //             XmlNode x = node.SelectSingleNode(".//EcoObjectsList");
 //             if (x != null) this.ecoobjecstlist = EcoObjectsList.CreateEcoObjectsList(x);
 //             else this.ecoobjecstlist = null;
 //           }
 
           
 //       }



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