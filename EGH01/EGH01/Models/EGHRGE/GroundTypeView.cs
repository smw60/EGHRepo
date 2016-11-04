using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EGH01.Models.EGHRGE
{
    public class GroundTypeView
    {
        public int      type_code {get; set;}    // код типа инцидента 
        public string   name { get; set;}        // Наименование типа 
        public float porosity { get; set; }   // пористость     >0    <1, безразмерная , доля застрявшего  в грунте нефтепрдукта       
        public float soilmoisture { get; set; }   // влажность грунта (от 0 до 1)
        public float watercapacity { get; set; }   // капиллярная влагоемкость (от 0 до 1)
        public float holdmigration { get; set; }   // коэфф. задержки миграции нефтепродуктов 
        public float waterfilter { get; set; }   // коэфф. фильтрации воды  
        public float аveryanovfactor { get; set; }   // коэффициент Аверьянова (от 4 до 9)
    }

    


}