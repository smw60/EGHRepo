using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using EGH01DB.Primitives;

namespace EGH01DB
{
      /// EGHGEA/ClassificationEvalution

   public partial  class GEAContext: IDBContext
   {
        public class  ECOClassification: CEQContext.ECOEvalution
        {
              public int                  id   {get; set;}
              public DateTime             date {get; set;}  
              private string errormssageformat = "ECOClassification: Ошибка в данных. {0}";
              public string               line { get
                                                  {
                                                   return  string.Format("{0}-C-{1:yyyy-MM-dd}/{2}-Р-{3:yyyy-MM-dd}", this.id, this.date,base.id, base.date) 
                                                   + string.Format(": {0}, {1}, {2}", this.incident.volume, this.incident.petrochemicaltype.name, this.incident.riskobject.name);
                                                  }
                                                } 
             public ECOClassification(CEQContext.ECOEvalution ecoevalution):base (ecoevalution)
             { 
                   this.id = 0;
                   this.date = DateTime.Now; 
             }
             public ECOClassification(XmlNode node):base (node.SelectSingleNode(".//ECOEvalution"))
             { 
               this.id =   Helper.GetIntAttribute(node, "id"); 
               this.date = Helper.GetDateTimeAttribute(node,"date", DateTime.Now);
             }                
             public new XmlNode toXmlNode(string comment="")
             { 
                  XmlDocument doc = new XmlDocument();
                  XmlElement rc = doc.CreateElement("ECOClassification");
                  if (!string.IsNullOrEmpty(comment)) rc.SetAttribute("comment", comment);
                  rc.SetAttribute("id",this.id.ToString()); 
                  rc.SetAttribute("date", this.date.ToString());

                  {
                    XmlNode n = base.toXmlNode();
                    rc.AppendChild(doc.ImportNode(n, true));
                  }  
                  return (XmlNode)rc;
             } 
         }
   }

       
}
