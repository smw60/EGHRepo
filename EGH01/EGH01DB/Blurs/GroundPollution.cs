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
       public string name                        { get; private set; }          // наименование 
       public POINTTYPE  pointtype               { get; private set; }          // тип точки 

       private readonly string comment_format = "{0}-{1}:";         // тип-id:              
       
       public GroundPollution(AnchorPoint anchorpoint,   float distance, float angle, PetrochemicalType petrochemicatype, float concentration = 0.0f, float watertime = 0.0f)
           : base(anchorpoint) 
       {
           this.pointtype = POINTTYPE.ANCHOR;  
           this.comment = string.Format(comment_format,AnchorPoint.PREFIX, anchorpoint.id);
           this.watertime = watertime;
           this.concentration = concentration;
           this.petrochemicatype = petrochemicatype;
           this.cadastretype = anchorpoint.cadastretype;
           this.distance = distance;
           this.angle = angle;
           this.name = this.comment;

       }
       public GroundPollution(EcoObject ecojbject, float distance, float angle, PetrochemicalType petrochemicatype, float concentration = 0.0f, float watertime = 0.0f)
           : base(ecojbject)
       {
           this.pointtype = POINTTYPE.ECO; 
           this.comment = string.Format(comment_format, EcoObject.PREFIX,  ecojbject.id);
           this.watertime = watertime;
           this.concentration = concentration;
           this.petrochemicatype = petrochemicatype;
           this.cadastretype = ecojbject.cadastretype;
           this.distance = distance;
           this.angle = angle;
           this.name = ecojbject.name;
       }
       public GroundPollution(SpreadPoint  spreadpoint, float concentration = 0.0f, float watertime = 0.0f)
           : base(spreadpoint)
       {
           this.pointtype = POINTTYPE.RISK; 
           this.comment = string.Format(comment_format, RiskObject.PREFIX, (spreadpoint.isriskobject? spreadpoint.riskobject.id: 0));
           this.watertime = watertime;
           this.concentration = concentration;
           this.petrochemicatype = spreadpoint.petrochemicaltype;
           this.cadastretype = spreadpoint.cadastretype;
           this.distance = 0.0f;
           this.angle = 0.0f;
           this.name = spreadpoint.isriskobject? spreadpoint.riskobject.name: this.comment;
       }
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
