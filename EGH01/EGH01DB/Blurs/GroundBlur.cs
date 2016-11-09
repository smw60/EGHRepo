using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGH01DB.Objects;
using EGH01DB.Types;
using EGH01DB.Points;
using EGH01DB.Primitives;


// температура 

namespace EGH01DB.Blurs
{
    public class GroundBlur              //  пятно  наземное нефтеродукта  
    {
        public SpreadPoint spreadpoint {get;  private set;}   //разлив нефтеродута 
        public CoordinatesList bordercoordinateslist { get; private set; }   // координаты граничных точек  пятна
        
        public SpreadingCoefficient spreadingcoefficient {get; private set;}       // коэффициент разлива (1/м) 
        public float                square               {get; private set;}       // площадь (м2)     
        public float                radius               {get; private set;}       // радиус наземного пятна (м)     
        public float                totalmass            {get; private set;}       // масса пролива (кг)    
        public float                limitadsorbedmass    {get; private set;}       // максиальная маса нефтепродукта, кот. может быть адсорбирована грунтом (кг) 
        public float                avgheight            {get; private set;}       // средняя глубина грунтовых вод по опорным точкам (м) 
            
        public  AnchorPointList     anchorpointlist      {get; private set;}       // список опорных точек, попаших в наземное пятно загрязнения    
        
        public EcoObjectsList       ecoobjecstlist       {get; private set; }      // список объектов в т.ч. заглавный которые попали в наземное пятно    
        public GroundPollutionList pollutionlist { get; private set; }   // загрязнение в точках  

        public GroundBlur(SpreadPoint spreadpoint)
        {
            this.spreadpoint = spreadpoint;
            

            
            SpreadingCoefficient  x = null;
            this.spreadingcoefficient = x = new SpreadingCoefficient();
            if (SpreadingCoefficient.GetByParms(this.spreadpoint.groundtype,this.spreadpoint.volume, 0.0f, out x))
            {
                this.spreadingcoefficient = x;
            }

            this.square = this.spreadpoint.volume * this.spreadingcoefficient.koef;                  // площадь  пятна 
            
            this.radius = (float)Math.Sqrt(square/Math.PI);                                           // радиус  пятна 

            this.totalmass  = this.spreadpoint.volume * this.spreadpoint.petrochemicaltype.density;   // масса пролива 

            this.limitadsorbedmass = 0.0f;                                                            // максиальная маса нефтепродукта, кот. может быть адсорбирована грунтом (кг) 

            this.avgheight = 0.0f;                                                                   // средняя глубина грунтовых вод по опорным точкам (м) 


            this.ecoobjecstlist = EcoObjectsList.CreateEcoObjectsList(spreadpoint,  radius);
            this.pollutionlist = GroundPollutionList.CreateGroundPollutionList(spreadpoint, radius);
        }

        //public float square { get { return SpreadingCoefficient.GetByData(EGH01DB.IDBContext dbcontext, spreadpoint.groundtype, spreadpoint.volume, 0.0f) * spreadpoint.volume; } }   // площадь наземного пятна (м)  считаем  F * volume (F = 
        // blinova
        // riskobjecstlist - из БД    pollutionlist - из БД по AnchorList
    
        
        
        
        private CoordinatesList createbordercoordinateslist() // построение граничных точек пятна загрязнения 
        {

            return new CoordinatesList();
        }
        private float calcradius()  // вычисление радиуса
        {
            return 0.0f;
        }
        private float calcsquare()   // вычисление площади загрязнения 
        {
            return 0.0f;
        }
        private EcoObjectsList createecoobjectslist()  // формирование списка природоохранных объектов
        {
            return new EcoObjectsList();
        }
        private GroundPollutionList creategroundpolutionlist() // формирование списка наземных точек загрязнения объектов
        {
            return new GroundPollutionList();
        }

    }
}
