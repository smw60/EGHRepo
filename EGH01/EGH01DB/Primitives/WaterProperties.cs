using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGH01DB.Primitives
{
    public class WaterProperties  // физико-химичексие свойства воды при 20С
    {
        public float viscocity {get; private set;}    // вязкость , кг/м с 
        public float density   {get; private set;}    // плотность, кг/м3
        public float tension   {get; private set;}    // коэф. поаерхностного натяжения , кг/с2 


        public static bool Get(float t,               // температура            
                               out  WaterProperties waterproperties
                                )
        {
            waterproperties = new WaterProperties();
            waterproperties.viscocity = 1006f;
            waterproperties.tension =72.5f;
            waterproperties.density = 0.998f;
            return true; 
        }
    }
}
