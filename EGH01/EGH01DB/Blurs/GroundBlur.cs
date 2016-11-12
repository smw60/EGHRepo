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
        public float                limitadsorbedmass    {get; private set;}       // максиальная маса нефтепродукта, кот. может быть адсорбирована грунтом (т) 
        public float                avgheight            {get; private set;}       // средняя глубина грунтовых вод по опорным точкам (м) 
        public float                adsorbedmass         {get; private set;}       // адсобированная масса нефтепрдукта грунтом (т)  
        public float                restmass             {get; private set;}       // масса нефтепродукта достигшая грунтовых вод  (т)  
        public float                depth                {get; private set;}       // глубина проникновения нефтепродукта в грунт (м)  
        public float                concentrationinsoil  {get; private set;}       // средняя концентрация нефтепродукта в грунт (кг/м3)   
        public int                  timewatercomletion   {get; private set;}       // время (сут) достижения  нефтепродуктом грунтовых вод   

        public  AnchorPointList     anchorpointlist      {get; private set;}       // список опорных точек, попаших в наземное пятно загрязнения    

        public WaterProperties waterproperties           { get; private set;}       // физико-химические свойства воды  
        public EcoObjectsList       ecoobjecstlist       {get; private set; }      // список объектов в т.ч. заглавный которые попали в наземное пятно    
        public GroundPollutionList pollutionlist         {get; private set; }      // загрязнение в точках  

        public GroundBlur(SpreadPoint spreadpoint)
        {
            this.spreadpoint = spreadpoint;


            { // коэф. разлива 
                SpreadingCoefficient x = new SpreadingCoefficient();
                this.spreadingcoefficient = x = new SpreadingCoefficient();
                if (SpreadingCoefficient.GetByParms(this.spreadpoint.groundtype, this.spreadpoint.volume, 0.0f, out x))
                {
                    this.spreadingcoefficient = x;
                }

            }


            { // свойства воды 
                WaterProperties x = new WaterProperties();
                RGEContext db = new RGEContext();// заглушка, выставить правильный контекст //blinova
                float delta = 0.0f;
                if (WaterProperties.Get(db, 20.0f, out x, out delta))
                {
                    this.waterproperties = x;
                }
            }


            this.square = this.spreadpoint.volume * this.spreadingcoefficient.koef;                  // площадь  пятна 

            this.radius = (float)Math.Sqrt(square / Math.PI);                                        // радиус  пятна 

            this.totalmass = this.spreadpoint.volume * this.spreadpoint.petrochemicaltype.density;   // масса пролива 


            { // средняя глубина грунтовых вод по опорным точкам 
                this.anchorpointlist = new AnchorPointList();
                this.anchorpointlist = AnchorPointList.CreateNear(this.spreadpoint.coordinates, this.radius);
                this.avgheight = anchorpointlist.avgheight;
            }
            {  // максиальная маса нефтепродукта, кот. может быть адсорбирована грунтом (кг) 
                this.limitadsorbedmass =
                                     this.avgheight *  // средняя глубина грутовы вод 
                                     this.square *  // площадь пролива 
                                     this.waterproperties.density *  // плотность воды  
                                     this.spreadpoint.groundtype.porosity *  // пористость грунта 
                                     this.spreadpoint.groundtype.watercapacity *  // капилярная влагоемкость грунта                                                     // максиальная маса нефтепродукта, кот. может быть адсорбирована грунтом (кг) 
                                     (float)Math.Pow(this.spreadpoint.petrochemicaltype.dynamicviscosity, 2) *  // динамическая вязкость ???      
                                     this.waterproperties.tension /  // коэфициент поверхностного натяжения воды
                                     (
                                     this.spreadpoint.petrochemicaltype.tension *  // коэфициент поверхностного натяжения нефтепрдукта 
                                     (float)Math.Pow(this.waterproperties.viscocity, 2)                         //  вязкость воды  
                                     );
            }

            this.adsorbedmass = (limitadsorbedmass >= this.totalmass ? this.totalmass : limitadsorbedmass);      // адсорбированная масса нефтепродукта в грунте т - М1  

            this.restmass = (this.adsorbedmass >= this.totalmass ? 0 : this.totalmass - this.adsorbedmass);  // масса нефтепродукта достигшая грунтовых вод 

            this.depth = (this.restmass > 0 ? this.avgheight : this.avgheight * (this.totalmass / this.limitadsorbedmass)); // глубина проникновения нефтепродукта в грунт     

            this.concentrationinsoil = this.adsorbedmass / (this.square * this.depth);   // средняя концентрация нефтепрдуктов в грунте  



            this.ecoobjecstlist = EcoObjectsList.CreateEcoObjectsList(spreadpoint, radius);
            this.pollutionlist = GroundPollutionList.CreateGroundPollutionList(spreadpoint, radius);

            {   // дата достижения нефтепродуктами грунтовых вод  
                float ka =                                                                       // формула аверьянова
                           this.spreadpoint.groundtype.waterfilter *                             // коэф. фильтрации воды          
                           (
                            this.spreadpoint.groundtype.soilmoisture -                           // влажность грунта 
                            this.spreadpoint.groundtype.watercapacity                            // капилярная влагоемкость грунта  
                            ) /
                            (
                            this.spreadpoint.groundtype.porosity -                                //  пористость грунта 
                            this.spreadpoint.groundtype.watercapacity                             // капилярная влагоемкость грунта
                            ); 
                float r =                                                                          // коэффициент задержки 
                            (
                            this.spreadpoint.petrochemicaltype.viscosity *                         // вязкость нефтепродукта 
                            this.waterproperties.density                                           // плотность воды                               
                            ) / 
                            (
                            this.waterproperties.viscocity *                                       // вязкость воды
                            this.spreadpoint.petrochemicaltype.density                             // плотность нефтепродукта 
                            );
                this.timewatercomletion = (int)(ka / r);                                          // время продвижения нефтепродукта до грунтовых вод 

            }  

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
