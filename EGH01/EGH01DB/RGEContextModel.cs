using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using EGH01DB.Objects;
using EGH01DB.Blurs;
using EGH01DB.Types;
using EGH01DB.Primitives;
using EGH01DB.Points;
namespace EGH01DB
{
   
    public partial class RGEContext
    {
        public class ECOForecast         //  модель прогнозирования 
        {
            public int           id                  {get; private set;}          // идентификатор прогноза 
            public DateTime      date                {get; private set;}          // дата формирования отчета 
            public Incident      incident            {get; private set;}          // описание ицидента 
            public GroundBlur    groundblur          {get; private set;}          // наземное пятно 
            public WaterBlur     waterblur           {get; private set;}          // пятно  загрязнения грунтвых вод 
            public DateTime      datewatercompletion {get; private set;}          // дата достижения загрянения грунтовых вод 
            public DateTime      datemaxwaterconc    {get; private set; }         // дата достижения  иаксимального загрянения г на уровне рунтовых вод 
            public string        errormessage        {get; private set; }         // сообщение об ошибке 
            public ECOForecast(Incident incident)
            {
                this.errormessage = string.Empty;
                try
                {

                    this.incident = incident;
                    this.groundblur = new GroundBlur(this.incident);
                    this.waterblur = new WaterBlur(this.groundblur);
                    this.date = DateTime.Now;
                    this.datewatercompletion = incident.date.AddSeconds(this.groundblur.timewatercomletion);
                    this.datemaxwaterconc = incident.date.AddSeconds(this.groundblur.timewaxwaterconc); 
                
                }
                catch(EGHDBException e )
                {
                    this.errormessage = e.ehgmessage;
                
                }

                

                

            }
            public bool toXML()   //  сериализация  в XML 
            {
                return true;
            }
            public static ECOForecast Create()   //десериализация из  XML
            {
                return new ECOForecast(new Incident());
            }

        
       }    
    }
    
 }

