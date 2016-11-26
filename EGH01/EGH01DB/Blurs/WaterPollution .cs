using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGH01DB.Types;
using EGH01DB.Objects;
using EGH01DB.Primitives;
using EGH01DB.Points;
using System.Xml;

namespace EGH01DB.Blurs
{
    public partial  class WaterPollution : Point   //загрязнение в точке
    {

        public PetrochemicalType petrochemicatype { get; private set; }          // нефтепрдукт
        public CadastreType cadastretype { get; private set; }          // кадастровый тип земли
        public float distance { get; private set; }          // расстояние до центра разлива 
        public float maxconcentration { get; set; }                  // максимальная концентрация нефтепродукта
        public float timemaxconcentration { get; private set; }          // время достижения  максимальной концентрация нефтепродукта
        public DateTime datemaxconcentration { get; set; }                  // дата достижения  максимальной концентрация нефтепродукта
        public float speedhorizontal { get; private set; }          // горизонтальная скорость 
        public float angle { get; private set; }          // гидравлический угол наклона  
        public string comment { get; private set; }          // комментарий 
        public string name { get; private set; }          // наименование 
        
        public POINTTYPE pointtype { get; private set; }          // тип точки 
        private readonly string comment_format = "{0}-{1}:";         // тип-id:


        public WaterPollution()
        {
            this.petrochemicatype = new PetrochemicalType();
            this.cadastretype = new CadastreType();
            this.distance = 0.0f;
            this.maxconcentration = 0.0f;
            this.timemaxconcentration = 0.0f;
            this.datemaxconcentration = DateTime.Parse("1900-01-01 01:01:01"); 
            this.speedhorizontal = 0.0f;
            this.angle = 0.0f;
            this.name = String.Empty;
            this.comment = String.Empty;
            this.pointtype = POINTTYPE.UNDEF;
        }
        public WaterPollution(XmlNode node)
        {
            XmlNode petrochemical_type = node.SelectSingleNode(".//PetrochemicalType");
            if (petrochemical_type != null) this.petrochemicatype = new PetrochemicalType(petrochemical_type);
            else this.petrochemicatype = null;

            XmlNode cadastre_type = node.SelectSingleNode(".//CadastreType");
            if (cadastre_type != null) this.cadastretype = new CadastreType(cadastre_type);
            else this.cadastretype = null;

            this.distance = Helper.GetFloatAttribute(node, "distance");
            this.maxconcentration = Helper.GetFloatAttribute(node, "maxconcentration");
            this.timemaxconcentration = Helper.GetFloatAttribute(node, "timemaxconcentration");
            this.datemaxconcentration = Helper.GetDateTimeAttribute(node, "datemaxconcentration", DateTime.Parse("1900-01-01 01:01:01"));
            this.speedhorizontal = Helper.GetFloatAttribute(node, "speedhorizontal");
            this.angle = Helper.GetFloatAttribute(node, "angle");
            this.comment = Helper.GetStringAttribute(node, "comment");
                      
        }

        public WaterPollution(EcoObject ecojbject, float distance, float angle, PetrochemicalType petrochemicatype, float speedhorizontal, float maxconcentration = 0.0f, float timemaxconcentration = 0.0f)
            : base(ecojbject)
        {
            this.pointtype = POINTTYPE.ECO;
            this.comment = string.Format(comment_format, EcoObject.PREFIX, ecojbject.id);
            this.petrochemicatype = petrochemicatype;
            this.cadastretype = ecojbject.cadastretype;
            this.distance = distance;
            this.angle = angle;
            this.name = ecojbject.name;
            this.speedhorizontal = speedhorizontal;
            this.maxconcentration = maxconcentration;
            this.timemaxconcentration = timemaxconcentration;
            this.datemaxconcentration = Const.DATE_INFINITY;
        }
        
        
        public XmlNode toXmlNode(string comment = "")
        {
            XmlDocument doc = new XmlDocument();
            XmlElement rc = doc.CreateElement("WaterPollution");
            if (!String.IsNullOrEmpty(comment)) rc.SetAttribute("comment", comment);
            rc.AppendChild(doc.ImportNode(this.petrochemicatype.toXmlNode(), true));
            rc.AppendChild(doc.ImportNode(this.cadastretype.toXmlNode(), true));
            rc.SetAttribute("distance", this.distance.ToString());
            rc.SetAttribute("maxconcentration", this.maxconcentration.ToString());
            rc.SetAttribute("timemaxconcentration", this.timemaxconcentration.ToString());
            rc.SetAttribute("datemaxconcentration", this.datemaxconcentration.ToString());
            rc.SetAttribute("speedhorizontal", this.speedhorizontal.ToString());

            XmlNode n = base.toXmlNode("");
            rc.AppendChild(doc.ImportNode(n, true));

            rc.SetAttribute("angle", this.angle.ToString());
            rc.SetAttribute("name", this.name.ToString());
            rc.SetAttribute("comment", this.comment.ToString());
            rc.SetAttribute("pointtype", this.pointtype.ToString());
            return (XmlNode)rc;
        }

    }
    public class WaterPollutionList : List<WaterPollution>    //  загрязнение во всех точках  в  водном радиусе 
    {
          public bool Add(WaterPollution waterpollution)
          {
               base.Add(waterpollution);
               return true;
           }
          public static WaterPollutionList CreateWaterPollutionList(XmlNode node)
          {
              WaterPollutionList water_pollution_list = new WaterPollutionList();
              foreach (XmlElement x in node)
              {
                  if (x.Name.Equals("WaterPollution")) water_pollution_list.Add(new WaterPollution(x));    
              }
              return water_pollution_list;
          }
          public XmlNode toXmlNode(string comment = "")
          {
              XmlDocument doc = new XmlDocument();
              XmlElement rc = doc.CreateElement("WaterPollutionList");
              if (!String.IsNullOrEmpty(comment)) rc.SetAttribute("comment", comment);
              this.ForEach(m => rc.AppendChild(doc.ImportNode(m.toXmlNode(), true)));
              return (XmlNode)rc;
          }

      }
    
}