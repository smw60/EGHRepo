using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGH01DB.Objects;
using EGH01DB.Primitives;
namespace EGH01DB.Blurs
{

    public partial class WaterBlur              //  водное пятно -  пятно нефтеродукта c грунтовыми водами  
    { 
        public GroundBlur groudblur                 {get; private set;}  // пятно по поверхности 
        public CoordinatesList border               {get; private set;}  // координаты граничных точек водного пятна
        public float radius                         {get; private set;}  // радиус водного пятна (м)   -
        public float toobporosity                   {get; private set;}  // пористость водоносного слоя  
        public float toobheight                     {get; private set;}  // высота (мощность) водрносного слоя  
        public EcoObjectsList     ecoobjectslist    {get; private set;}  // список природоохранных объектов в водном пятне    
        public WaterPollutionList watepollutionlist {get; private set;}  // список точек в водном пятне    

        public WaterBlur(IDBContext db, GroundBlur groundblur)
        {
            this.groudblur = groundblur;
            this.toobporosity = this.groudblur.spreadpoint.groundtype.porosity / 2.0f;    // считаем такой пористость водоносного слоя          
            this.toobheight = 1.0f;                                                       // считаем мощность водоносного слоя = 1 

            this.radius = 
                    this.groudblur.restmass /                                                               // макс. радиус поиска природоохранных объектов 
                    (
                        this.toobheight *                                                                    // мощность слоя грунтовых вод (1м) 
                        2.0f * this.groudblur.radius /                                                       // площадь трубы 
                        2.0f *                                                                               // треугольник
                        this.groudblur.waterproperties.density *                                             // плотность воды  
                        this.groudblur.spreadpoint.groundtype.porosity  *                                     // пористость грунта /2 c водой
                        this.groudblur.spreadpoint.groundtype.watercapacity *                                 // капилярная влагоемкость грунта                                                      // максиальная маса нефтепродукта, кот. может быть адсорбирована грунтом (кг) 
                        (float)Math.Pow(this.groudblur.spreadpoint.petrochemicaltype.dynamicviscosity, 2) *   // динамическая вязкость ???      
                        this.groudblur.waterproperties.tension /                                              // коэфициент поверхностного натяжения воды
                        (
                        this.groudblur.spreadpoint.petrochemicaltype.tension *                                // коэфициент поверхностного натяжения нефтепрдукта 
                        (float)Math.Pow(this.groudblur.waterproperties.viscocity, 2)                           //  вязкость воды  
                        )
                     );
            
           this.ecoobjectslist = EcoObjectsList.CreateEcoObjectsList(db, this.groudblur.spreadpoint,  this.groudblur.radius,   this.radius);
           this.watepollutionlist = new WaterPollutionList();
           float sv = 0;
           foreach (EcoObject o in this.ecoobjectslist)
           {
               float h =  this.groudblur.spreadpoint.height- o.height;                             //раница высот  
               float d = this.groudblur.spreadpoint.coordinates.Distance(o.coordinates);           //растояние  
               float a = d <= 0.0f ? 0.0f : h / d;                                                 //гидравлический угол
               float v =  a<=0?0.0f:this.groudblur.spreadpoint.groundtype.waterfilter * a;         //горинтальная скорость 
               sv += v;                                                                            //сумма скоростей для нормирования 
               this.watepollutionlist.Add(new WaterPollution(o, d, a, this.groudblur.spreadpoint.petrochemicaltype, v, 0.0f, v>0.0f?d/v:Const.TIME_INFINITY));
           }

           foreach (WaterPollution p in this.watepollutionlist)
           {
               if (p.speedhorizontal > 0.0f)
               {
                   p.maxconcentration = ((p.speedhorizontal / sv) * this.groudblur.restmass) / (2.0f * this.groudblur.radius * p.distance * 1.0f);
               }
     
           }
        }
    }  
}


//this.ecoobjecstlist = EcoObjectsList.CreateEcoObjectsList(groudblur.spreadpoint, groudblur.radius, radius);
//this.pollutionlist = WaterPollutionList.CreateWaterPollutionList(groudblur.spreadpoint, groudblur.groundpolutionlist, groundblur.spreadpoint.petrochemicaltype, groudblur.radius, this.radius);