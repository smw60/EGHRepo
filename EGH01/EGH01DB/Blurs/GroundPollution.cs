using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGH01DB.Types;
using EGH01DB.Points;
using EGH01DB.Objects;
using EGH01DB.Primitives;

namespace EGH01DB.Blurs
{
    public class GroundPollution : Point   //загрязнение  в точке 
    {
       public float watertime                    { get; private set; }          // время достижения грунтовых вод (с)  
       public float concentration                { get; private set; }          // концентрация нефтепрдуктов в грунте    (кг/кг)
       public PetrochemicalType petrochemicatype { get; private set; }          // нефтепрдукт
       public CadastreType cadastretype          { get; private set; }          // кадастровый тип земли
       public float distance                     { get; private set; }          // расстояние до центра разлива 
       public float angle                        { get; private set; }          // гидравлический угол наклона  
       public string comment                     { get; private set; }          // комментарий 
       private string comment_format = "{0}-{1}:";         // тип-id:              
       public GroundPollution(AnchorPoint anchorpoint,   float distance, float angle, PetrochemicalType petrochemicatype, float concentration = 0.0f, float watertime = 0.0f)
           : base(anchorpoint) 
       {
           this.comment = string.Format(comment_format,"ОТ", anchorpoint.id);
           this.watertime = watertime;
           this.concentration = concentration;
           this.petrochemicatype = petrochemicatype;
           this.cadastretype = anchorpoint.cadastretype;
           this.distance = distance;
           this.angle = angle;

       }
       public GroundPollution( EcoObject ecojbject, float distance, float angle, PetrochemicalType petrochemicatype, float concentration = 0.0f, float watertime = 0.0f)
           : base(ecojbject)
       {
           this.comment = string.Format(comment_format, "ПО",  ecojbject.id);
           this.watertime = watertime;
           this.concentration = concentration;
           this.petrochemicatype = petrochemicatype;
           this.cadastretype = ecojbject.cadastretype;
           this.distance = distance;
           this.angle = angle;

       }
       public GroundPollution(SpreadPoint  spreadpoint, float concentration = 0.0f, float watertime = 0.0f)
           : base(spreadpoint)
       {
           this.comment = string.Format(comment_format, "OО", (spreadpoint.isriskobject? spreadpoint.riskobject.id: 0));
           this.watertime = watertime;
           this.concentration = concentration;
           this.petrochemicatype = spreadpoint.petrochemicaltype;
           this.cadastretype = spreadpoint.cadastretype;
           this.distance = 0.0f;
           this.angle = 0.0f;

       }



        
       // public GroundPollution(Incident incident, float concentration, float watertime)
       //    : base(incident)   
       //{
       //}
       //public GroundPollution(Point point, CadastreType cadastretype,  PetrochemicalType petrochemicatype, float concentration, float watertime)
       //    : base(point)
       //{
       //}  

    
    }

    public class GroundPollutionList : List<GroundPollution>    //  загрязнение во всех точках   в наземном радиусе
    {

       public GroundPollutionList(SpreadPoint center, float concentration = 0.0f, float watertime = 0.0f)
       {
            this.Add(new GroundPollution(center, concentration, watertime));
       }
       public GroundPollutionList(Point center, AnchorPointList list, PetrochemicalType petrochemicaltype, float concentration = 0.0f, float watertime = 0.0f)
       {
            this.AddRange(center, list, petrochemicaltype, concentration, watertime);
       }
       public GroundPollutionList(Point center, EcoObjectsList list, PetrochemicalType petrochemicaltype, float concentration = 0.0f, float watertime = 0.0f)
       {
            this.AddRange(center, list, petrochemicaltype, concentration, watertime);
       }
       public bool AddRange(Point center, AnchorPointList list, PetrochemicalType petrochemicaltype, float concentration = 0.0f, float watertime = 0.0f)
       {

            list.ForEach(p => this.Add(new GroundPollution(p,
                                                         p.coordinates.Distance(center.coordinates),
                                                         Helper.GeoAngle(center, p),
                                                         petrochemicaltype,
                                                         concentration,
                                                         watertime
                                                         )));

            return true;
        }
        public bool AddRange(Point center, EcoObjectsList list, PetrochemicalType petrochemicaltype, float concentration = 0.0f, float watertime = 0.0f)
        {

            list.ForEach(p => this.Add(new GroundPollution(p,
                                                         p.coordinates.Distance(center.coordinates),
                                                         Helper.GeoAngle(center, p),
                                                         petrochemicaltype,
                                                         concentration,
                                                         watertime
                                                         )));
                                    
            return true;
        }

        public bool Add(SpreadPoint center, float concentration = 0.0f, float watertime = 0.0f)
        {
           this.Add(new GroundPollution(center, concentration, watertime));
            return true;
        }

    }

}
