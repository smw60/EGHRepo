using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.Threading.Tasks;
using System.IO;

namespace EGH01DB.Primitives
{

// доп. таблица    СтильОтчета  - внутренняя таблица исп. только внутреннего применения  
//   Стадия       ncahr 
//   СтильОтчета  nvarchar(max)
//
//
//
    public class Report                                       // отчет
    {
        public int       id             {get;  private set;}    // идентификатор отчета   
        public Report    predator       {get;  private set;}    // идентификатор родительского отчета
        public string    stage          {get;  private set;}    // тип отчета: П, Р, С, Т.
        public DateTime  date           {get;  private set;}    // дата формирования отчета 
        public XmlNode   xmlcontetnt    {get;  private set;}    // отчет 
        public XmlNode   xslhtmlstyle   {get;  private set;}    // xslt-стиль преобразования в html
        public string    comment        {get;  private set;}    // комментарий  
        public string    line           {get{return string.Format("{0}-{1}-{2:yyyy-MM-dd}", this.id, this.stage, this.date);}}           


        public Report()
        {
          this.id              = -1;
          this.predator        = null;
          this.stage           = string.Empty;
          this.date            = DateTime.MinValue;
          this.xmlcontetnt     = null;
          this.xslhtmlstyle    = null;  
          this.comment         = string.Empty;        
        } 
        
      
        public Report(int id, string stage,  DateTime date, XmlNode xmlcontetnt, XmlNode  xslhtmlstyle, string comment = "")
        {
          this.id              = id;
          this.predator        = null;
          this.stage           = stage;
          this.date            = date;
          this.xmlcontetnt     = xmlcontetnt;
          this.xslhtmlstyle    = xslhtmlstyle;
          this.comment         = comment;
        }   


        public Report(int id, Report predator, string stage,  DateTime date, XmlNode xmlcontetnt, XmlNode  xslhtmlstyle, string comment = "")
        {
          this.id              = id;
          this.predator        = predator;
          this.stage           = stage;
          this.date            = date;
          this.xmlcontetnt     = xmlcontetnt;
          this.xslhtmlstyle    = xslhtmlstyle;
          this.comment         = comment;
        }    

   
       
        public string ToHTML()                                // преобразование XML-XSLT->HTML  
        { 
          // примерно так - не проверил!!!
          string rc = string.Empty;
          XmlDocument xmldoc =(XmlDocument)this.xmlcontetnt;
          XslCompiledTransform xsldoc =  new XslCompiledTransform();     
          xsldoc.Load(xslhtmlstyle.OuterXml);
          StringWriter sw = new StringWriter();
          xsldoc.Transform(xmldoc.CreateNavigator(), null, sw);
          rc = sw.ToString();
          return rc;                              // HTML -строка 
        }  


        public static bool  GetById(IDBContext  context,  int id, out Report report)
        { 
          report = null;

          return false;
        }

       public static bool DeleteById(IDBContext  context, int id)
       { 
         
          return false;
       }
       public static bool SaveCommentById(IDBContext  context, int id, string comment)
       { 
         
          return false;
       }


   }

   public class ReportsList: List<Report>
   {
     
     public  bool GetByStage(IDBContext context, string stage, out ReportsList list)
     {
       list = null;

       return true;
     }   
   
   }     



}
