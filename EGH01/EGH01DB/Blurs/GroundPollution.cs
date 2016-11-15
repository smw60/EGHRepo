using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGH01DB.Types;
using EGH01DB.Points;
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

       public GroundPollution(AnchorPoint anchorpoint,   float distance, float angle, PetrochemicalType petrochemicatype, float concentration = 0.0f, float watertime = 0.0f)
           : base(anchorpoint) 
       {

           this.watertime = watertime;
           this.concentration = concentration;
           this.petrochemicatype = petrochemicatype;
           this.cadastretype = anchorpoint.cadastretype;
           this.distance = distance;
           this.angle = angle;

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

        public GroundPollutionList(Point center, AnchorPointList list, PetrochemicalType petrochemicaltype, float concentration = 0.0f, float watertime = 0.0f)
        {
            list.ForEach(p => this.Add(new GroundPollution(p,
                                                         p.coordinates.Distance(center.coordinates),
                                                         p.coordinates.Distance(center.coordinates) == 0.0f ? 0 : (center.height - p.height) / p.coordinates.Distance(center.coordinates),
                                                         petrochemicaltype,
                                                         concentration,
                                                         watertime
                                                         )));

        }
    

        

    }
  



}
