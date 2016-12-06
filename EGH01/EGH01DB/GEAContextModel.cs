using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using EGH01DB.Primitives;
using EGH01DB.Types;
using EGH01DB.Blurs;

namespace EGH01DB
{
      /// EGHGEA/ClassificationEvalution

   public partial  class GEAContext: IDBContext
   {
        public class  ECOClassification: CEQContext.ECOEvalution
        {
              public int                  id   {get; set;}
              public DateTime             date {get; set;}  
              public SoilPollutionCategories  soilpollutioncategories  {get; set;}
              public WaterPollutionCategories waterpollutioncategories {get; set;}
             

              private string errormssageformat = "ECOClassification: Ошибка в данных. {0}";
              public string               line { get
                                                  {
                                                   return  string.Format("{0}-C-{1:yyyy-MM-dd}/{2}-Р-{3:yyyy-MM-dd}", this.id, this.date,base.id, base.date) 
                                                   + string.Format(": {0}, {1}, {2}", this.incident.volume, this.incident.petrochemicaltype.name, this.incident.riskobject.name);
                                                  }
                                                } 


             public ECOClassification(CEQContext.ECOEvalution ecoevalution):base (ecoevalution)
             { 
                     GEAContext db = new GEAContext(); 
                     this.id = 0;
                     this.date = DateTime.Now; 
                     {
                           SoilPollutionCategories spc =  this.soilpollutioncategories =  null;
                           if (SoilPollutionCategories.GetByVolume_Cadastre(db, this.excessgroundconcentration, this.groundblur.spreadpoint.cadastretype.type_code,  out spc))              
                           {
                             this.soilpollutioncategories = spc;
                           }
                     }
                
                    { 
  
                         WaterPollutionCategories wpc = this.waterpollutioncategories = null;
                         if (WaterPollutionCategories.GetByExcess_Cadastre(db, this.exesswaterconcentration, this.groundblur.spreadpoint.cadastretype.type_code,  out wpc))              
                         {
                            this.waterpollutioncategories = wpc;
                         }
                     }
                    
                    foreach(WaterPollution wp in this.waterpolutionlist)
                    {
                    //     wp.waterpollutioncategories =
                      WaterPollutionCategories x = null;  
                      if (WaterPollutionCategories.GetByExcess_Cadastre(db, wp.excessconcentration,wp.cadastretype.type_code, out x))  wp.waterpollutioncategories = x   ;

                    }  
                   

             }
             public ECOClassification(XmlNode node):base (node.SelectSingleNode(".//ECOEvalution"))
             { 
               this.id =   Helper.GetIntAttribute(node, "id"); 
               this.date = Helper.GetDateTimeAttribute(node,"date", DateTime.Now);
                {
                    XmlNode x = node.SelectSingleNode(".//SoilPollutionCategories");
                    if (x != null) this.soilpollutioncategories =  new  SoilPollutionCategories(x);
                    else this.soilpollutioncategories = null;
                }  
                {
                    XmlNode x = node.SelectSingleNode(".//WaterPollutionCategories");
                    if (x != null) this.waterpollutioncategories =  new  WaterPollutionCategories(x);
                    else this.waterpollutioncategories = null;
                } 
    




             }                
             public new XmlNode toXmlNode(string comment="")
             { 
                  XmlDocument doc = new XmlDocument();
                  XmlElement rc = doc.CreateElement("ECOClassification");
                  if (!string.IsNullOrEmpty(comment)) rc.SetAttribute("comment", comment);
                  rc.SetAttribute("id",this.id.ToString()); 
                  rc.SetAttribute("date", this.date.ToString());
                  {
                    XmlNode n = this.soilpollutioncategories.toXmlNode();
                    rc.AppendChild(doc.ImportNode(n, true));
                  }    
                  {
                    XmlNode n = base.toXmlNode();
                    rc.AppendChild(doc.ImportNode(n, true));
                  }  
                  return (XmlNode)rc;
             } 
            // Create

         }
   }

       
}
