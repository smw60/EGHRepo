using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGH01DB.Objects;
using EGH01DB.Primitives;
namespace EGH01DB.Blurs
{

    public class WaterBlur              //  водное пятно -  пятно нефтеродукта c грунтовыми водами  
    { 
        public GroundBlur groudblur     { get; private set; }  // пятно по поверхности 
        public CoordinatesList border   { get; private set; }  // координаты граничных точек водного пятна
        public float radius             { get; private set; }  // радиус водного пятна (м)   -
        public float toobporosity       { get; private set; }  // пористость водоносного слоя  
        public float toobheight         { get; private set; }  // высота (мощность) водрносного слоя    
        

        public WaterBlur( IDBContext db, GroundBlur groundblur)
        {
            this.groudblur = groundblur;
            this.toobporosity = this.groudblur.spreadpoint.groundtype.porosity / 2.0f;    // считаем такой пористость водоносного слоя          
            this.toobheight = 1.0f;                                                       // считаем мощность водоносного слоя = 1 

            this.radius = 
                    this.groudblur.restmass /                                                               // радиус поиска природоохранных объектов 
                    (
                        this.toobheight *                                                                    // мощность слоя грунтовых вод (1м) 
                        2.0f * this.groudblur.radius /                                                       // площадь трубы 
                        2.0f *                                                                               // треугольник
                        this.groudblur.waterproperties.density *                                             // плотность воды  
                        this.groudblur.spreadpoint.groundtype.porosity  *                                   // пористость грунта /2 c водой
                        this.groudblur.spreadpoint.groundtype.watercapacity *                                 // капилярная влагоемкость грунта                                                      // максиальная маса нефтепродукта, кот. может быть адсорбирована грунтом (кг) 
                        (float)Math.Pow(this.groudblur.spreadpoint.petrochemicaltype.dynamicviscosity, 2) *   // динамическая вязкость ???      
                        this.groudblur.waterproperties.tension /                                              // коэфициент поверхностного натяжения воды
                        (
                        this.groudblur.spreadpoint.petrochemicaltype.tension *                                // коэфициент поверхностного натяжения нефтепрдукта 
                        (float)Math.Pow(this.groudblur.waterproperties.viscocity, 2)                           //  вязкость воды  
                        )
                     );




        }
    }  
}


//this.ecoobjecstlist = EcoObjectsList.CreateEcoObjectsList(groudblur.spreadpoint, groudblur.radius, radius);
//this.pollutionlist = WaterPollutionList.CreateWaterPollutionList(groudblur.spreadpoint, groudblur.groundpolutionlist, groundblur.spreadpoint.petrochemicaltype, groudblur.radius, this.radius);