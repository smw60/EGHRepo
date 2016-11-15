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
        
        public SpreadingCoefficient spreadingcoefficient  {get; private set;}       // коэффициент разлива (1/м) 
        public float                square                {get; private set;}       // площадь (м2)     
        public float                radius                {get; private set;}       // радиус наземного пятна (м)     
        public float                totalmass             {get; private set;}       // масса пролива (кг)    
        public float                limitadsorbedmass     {get; private set;}       // максиальная маса нефтепродукта, кот. может быть адсорбирована грунтом (т) 
        public float                avgdeep               {get; private set;}       // средняя глубина грунтовых вод по опорным точкам (м) 
        public float                petrochemicalheight   {get; private set;}       // высота слоя разлитого нефтепродукта (м) 
        public float                adsorbedmass          {get; private set;}       // адсобированная масса нефтепрдукта грунтом (т)  
        public float                restmass              {get; private set;}       // масса нефтепродукта достигшая грунтовых вод  (т)  
        public float                depth                 {get; private set;}       // глубина проникновения нефтепродукта в грунт (м)  
        public float                concentrationinsoil   {get; private set;}       // средняя концентрация нефтепродукта в грунте (кг/м3)   
        public float                speedvertical         {get; private set;}       // вертикальная скорость проникновения нефтепродукта в грунт (м/с)   
        public float                timewatercomletion    {get; private set;}       // время (сек) достижения  нефтепродуктом грунтовых вод   
        public float                dtimewaxwaterconc     {get; private set;}       // время (сек) достижения  максимальной концентрации  нефтепродуктом грунтовых вод  после достиженич границы грунтовых вод 
        public float                timewaxwaterconc      {get; private set;}       // время (сек) достижения  максимальной концентрации на уровне грунтовых вод
        public float                maxconcentrationwater {get; private set;}       // максимальной концентрация на уровне грунтовых вод кг/м3
        public float                ozcorrection          {get; private set;}       // OZ-поправка


        public AnchorPointList     anchorpointlist        {get; private set;}       // список опорных точек, попаших в наземное пятно загрязнения    
        public GroundPollutionList groundpolutionlist     {get; private set;}      // список точек загрязнения  
        public WaterProperties waterproperties            {get; private set;}       // физико-химические свойства воды  
        public EcoObjectsList       ecoobjecstlist        {get; private set;}       // список объектов в т.ч. заглавный которые попали в наземное пятно    
        public GroundPollutionList pollutionlist          {get; private set;}       // загрязнение в точках  
       
        private string errormssageformat = "GroundBlur: Ошибка в данных. {0}";  
     
        public GroundBlur(SpreadPoint spreadpoint)
        {
            this.spreadpoint = spreadpoint;
            RGEContext db = new RGEContext();    // заглушка, выставить правильный контекст //blinova


            if (this.spreadpoint.groundtype.watercapacity >=  this.spreadpoint.groundtype.porosity)
                throw new EGHDBException(string.Format(errormssageformat, "Влагоемкость грунта не может быть  больше или равна  пористости"));

            if (this.spreadpoint.groundtype.watercapacity >= this.spreadpoint.groundtype.soilmoisture)
                 throw new EGHDBException(string.Format(errormssageformat, "Влагоемкость грунта не может быть  больше или равна  влажности грунта"));


            
            { // коэф. разлива 

                SpreadingCoefficient x = new SpreadingCoefficient();
                this.spreadingcoefficient = x = new SpreadingCoefficient();
                if (SpreadingCoefficient.GetByParms(this.spreadpoint.groundtype, this.spreadpoint.volume, 0.0f, out x))
                {
                    this.spreadingcoefficient = x;
                }

                float k = SpreadingCoefficient.GetByData(db, this.spreadpoint.groundtype, this.spreadpoint.volume, 0.0f);
                this.spreadingcoefficient = new SpreadingCoefficient(0, this.spreadpoint.groundtype, 0.0f, this.spreadpoint.volume, 0.0f, 0.02f, k);

              }

            if (this.spreadingcoefficient.koef <= 0.0f)
                throw new EGHDBException(string.Format(errormssageformat, "Коэффициент разлива не может быть меньше или равен нулю"));

           
            
            { // свойства воды 
                WaterProperties x = new WaterProperties();
               // RGEContext db = new RGEContext();// заглушка, выставить правильный контекст //blinova
                float delta = 0.0f;
                if (WaterProperties.Get(db, 20.0f, out x, out delta))
                {
                    this.waterproperties = x;
                }
            }


            this.square = this.spreadpoint.volume * this.spreadingcoefficient.koef;                  // площадь  пятна 

            this.radius = (float)Math.Sqrt(square / Math.PI);                                        // радиус  пятна 

            this.petrochemicalheight = this.spreadpoint.volume / this.square;                        // высота слоя разлитого нефтепродукта (м)   

            this.totalmass = this.spreadpoint.volume * this.spreadpoint.petrochemicaltype.density;   // масса пролива 


            { // средняя глубина грунтовых вод по опорным точкам  и техногенному  объекту
                this.anchorpointlist = AnchorPointList.CreateNear(this.spreadpoint.coordinates, this.radius);
                this.avgdeep =
                                (
                                  anchorpointlist.sumwaterdeep +
                                  (this.spreadpoint.riskobject != null ? this.spreadpoint.waterdeep : 0.0f)
                                 ) /
                                 (anchorpointlist.Count + 1);
            }
            {  // максиальная маса нефтепродукта, кот. может быть адсорбирована грунтом (кг) 
                this.limitadsorbedmass =
                                     this.avgdeep *                                                          // средняя глубина грутовы вод 
                                     this.square *                                                             // площадь пролива 
                                     this.waterproperties.density *                                            // плотность воды  
                                     this.spreadpoint.groundtype.porosity *                                    // пористость грунта 
                                     this.spreadpoint.groundtype.watercapacity *                               // капилярная влагоемкость грунта                                                     // максиальная маса нефтепродукта, кот. может быть адсорбирована грунтом (кг) 
                                     (float)Math.Pow(this.spreadpoint.petrochemicaltype.viscosity, 2) *         // динамическая вязкость ???      
                                     this.waterproperties.tension /                                             // коэфициент поверхностного натяжения воды
                                     (
                                     this.spreadpoint.petrochemicaltype.tension *                               // коэфициент поверхностного натяжения нефтепрдукта 
                                     (float)Math.Pow(this.waterproperties.viscocity, 2)                         //  вязкость воды  
                                     );
            }

            {
                
                this.groundpolutionlist = new GroundPollutionList(this.spreadpoint, this.anchorpointlist, this.spreadpoint.petrochemicaltype);
                //this.groundpolutionlist.Add(new GroundPollution()

            }
           



            this.adsorbedmass = (limitadsorbedmass >= this.totalmass ? this.totalmass : limitadsorbedmass);             // адсорбированная масса нефтепродукта в грунте т - М1  

            this.restmass = (this.adsorbedmass >= this.totalmass ? 0 : this.totalmass - this.adsorbedmass);             // масса нефтепродукта достигшая грунтовых вод 

            this.depth = (this.restmass > 0 ? this.avgdeep : this.avgdeep * (this.totalmass / this.limitadsorbedmass)); // глубина проникновения нефтепродукта в грунт     

            this.concentrationinsoil =                                                                                  // средняя концентрация нефтепрдуктов в грунте  

                                      this.adsorbedmass /                                                               // адсорбированная масса нефтепродукта в грунте 
                                      (
                                       this.square *                                                                    // площадь  пятна   
                                       this.depth *                                                                     // глубина проникновения нефтепродукта в грунт     
                                       this.spreadpoint.groundtype.density                                              // средняя плотность грунта 
                                       );


            this.ecoobjecstlist = EcoObjectsList.CreateEcoObjectsList(spreadpoint, radius);
            


          
           
            {   //   вертикальная скорость проникновения нефтепродукта в грунт (м/с) 
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

                this.speedvertical = (ka / r);                                                     // вертикальная скорость проникновения нефтепродукта в грунт (м/с)                               
            }

            this.timewatercomletion =                                                               // время продвижения нефтепродукта до грунтовых вод 
                                     this.avgdeep /                                                 // средняя глубина грунтовых вод по опорным точкам (м) 
                                     this.speedvertical;                                            // вертикальная скорость проникновения нефтепродукта в грунт (м/с)   

            this.dtimewaxwaterconc =                                                                // время (сек) достижения  максимальной концентрации  нефтепродуктом грунтовых вод  после достиженич границы грунтовых вод
                                     this.petrochemicalheight /                                     // высота слоя разлитого нефтепродукта (м)  
                                     (
                                     this.speedvertical *                                           // вертикальная скорость проникновения нефтепродукта в грунт (м/с)   
                                     this.spreadpoint.groundtype.porosity                           // пористость грунта 
                                     );

            this.timewaxwaterconc = this.timewatercomletion + this.dtimewaxwaterconc;                // время (сек) достижения  максимальной концентрации на уровне грунтовых вод

            {
                this.ozcorrection =                                                                  // OZ-поправка  
                        this.petrochemicalheight *                                                   // высота слоя разлитого нефтепродукта (м)      
                        this.restmass /                                                              // масса нефтепродукта достигшая грунтовых вод (кг)
                        this.totalmass;                                                              // масса пролива (кг)

                this.maxconcentrationwater = (float)                                                 // максимальной концентрация на уровне грунтовых вод кг/м3
                    (
                       this.restmass /                                                               // масса нефтепродукта достигшая грунтовых вод (кг)
                       (Math.PI * this.radius*this.radius) *                                         // радиус  пятна 
                       2.0f /
                       (this.ozcorrection * Math.Sqrt(2 * Math.PI))                                   // поправка 0Z   
                    );          
            }

                      
            
        }

        



       



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
        //private GroundPollutionList creategroundpolutionlist() // формирование списка наземных точек загрязнения объектов
        //{
        //    return new GroundPollutionList();
        //}

    }
}
