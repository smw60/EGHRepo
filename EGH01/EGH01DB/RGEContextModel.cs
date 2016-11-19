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
        public partial class ECOForecast         //  модель прогнозирования 
        {
            public int           id                      {get; private set;}          // идентификатор прогноза 
            public DateTime      date                    {get; private set;}          // дата формирования отчета 
            public Incident      incident                {get; private set;}          // описание ицидента 
            public GroundBlur    groundblur              {get; private set;}          // наземное пятно 
            public WaterBlur     waterblur               {get; private set;}          // пятно  загрязнения грунтвых вод 
            public DateTime      dateconcentrationinsoil {get; private set;}          // дата достижения загрянения грунтовых вод    
            public DateTime      datewatercompletion     {get; private set;}          // дата достижения загрянения грунтовых вод 
            public DateTime      datemaxwaterconc        {get; private set;}          // дата достижения  иаксимального загрянения г на уровне рунтовых вод 
            public string        errormessage            {get; private set;}          // сообщение об ошибке 

            public ECOForecast()
            {
            }
            public ECOForecast(Incident incident)
            {
                RGEContext db = new RGEContext();
                Init(db, incident);   
            }
                    
            public ECOForecast(IDBContext db, Incident incident)
            {
                  Init( db, incident);      
            }
           
            private bool Init(IDBContext db, Incident incident)
            {
                this.errormessage = string.Empty;
                try
                {

                    this.incident = incident;
                    this.groundblur = new GroundBlur(this.incident);
                    this.waterblur =  new WaterBlur(db, this.groundblur);
                   
                    this.date = DateTime.Now;
                    
                    if (!Const.isINFINITY(this.groundblur.timewatercomletion) && !Const.isINFINITY(this.groundblur.timewaxwaterconc))
                    {

                        this.datewatercompletion = (new DateTime(incident.date.Ticks)).AddSeconds(this.groundblur.timewatercomletion);
                        this.datemaxwaterconc = (new DateTime(incident.date.Ticks)).AddSeconds(this.groundblur.timewaxwaterconc);
                    }
                    else
                    {
                        this.datewatercompletion = Const.DATE_INFINITY;
                        this.datemaxwaterconc = Const.DATE_INFINITY;

                    }
                    if (!Const.isINFINITY(this.groundblur.timeconcentrationinsoil))
                    {
                        this.dateconcentrationinsoil = (new DateTime(incident.date.Ticks)).AddSeconds(this.groundblur.timeconcentrationinsoil);
                    }
                    else
                    {
                        this.dateconcentrationinsoil = Const.DATE_INFINITY;
                    }
                }
                catch (EGHDBException e)
                {
                    this.errormessage = e.ehgmessage;

                }




                return true;
            }



            public bool toXML()   //  сериализация  в XML 
            {
                return true;
            }

            //public static ECOForecast Create()   //десериализация из  XML
            //{
            //    return new ECOForecast(new Incident());
            //}
       }    
    }
    
 }

