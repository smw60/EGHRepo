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
using EGH01DB.Objects;
using EGH01DB.Blurs;
using EGH01DB.Primitives;


namespace EGH01DB
{
    public  partial class CEQContext : IDBContext
    {

        public class ECOEvalution: RGEContext.ECOForecast
        {

            public float excessgroundconcentration { get; set; }      // отношение значения средней конентрации к ПДК  
            private string errormssageformat = "ECOEvalution: Ошибка в данных. {0}";
            public GroundPollutionList groundpollutionlist   {get; set;}
            public WaterPollutionList waterpolutionlist      { get; set; }

            public ECOEvalution(RGEContext.ECOForecast  forecast): base (forecast)
            {
                CEQContext db = new CEQContext();    // заглушка, выставить правильный контекст //blinova
                if (this.groundblur.spreadpoint.cadastretype.pdk_coef <= 0)
                throw new EGHDBException(string.Format(errormssageformat, "Значение предельно-дупустимой концентрации не может быть  меньше или равно нулю"));

                this.excessgroundconcentration = this.groundblur.concentrationinsoil/this.groundblur.spreadpoint.cadastretype.pdk_coef;
                this.groundpollutionlist = new GroundPollutionList (this.groundblur.groundpolutionlist.Where(p => p.pointtype == Points.Point.POINTTYPE.ECO).ToList());

                this.waterpolutionlist = new WaterPollutionList();
                foreach(WaterPollution p in this.waterblur.watepollutionlist)
                {
                     if (p.distance >this.groundblur.radius && p.distance < this.waterblur.radius)
                     {
                         this.waterpolutionlist.Add(p);
                     }
                
                }

                 

                   
               
                
                
                
                //  this.waterpolutionlist = new WaterPollutionList(this.waterblur.watepollutionlist.Where(p => p.pointtype == Points.Point.POINTTYPE.ECO).ToList());
                
                       
                      
                      //(GroundPollutionList)this.groundblur.groundpolutionlist.Where(p => p.pointtype == Points.Point.POINTTYPE.ECO).ToList();  





            }

        }





     }        


}




