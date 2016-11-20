using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGH01DB.Types;
using EGH01DB.Objects;
using EGH01DB.Primitives;
using EGH01DB.Points;
namespace EGH01DB.Blurs
{
    public class WaterPollution : Point   //загрязнение в точке
    {

        public PetrochemicalType petrochemicatype { get; private set; }          // нефтепрдукт
        public CadastreType cadastretype { get; private set; }          // кадастровый тип земли
        public float distance { get; private set; }          // расстояние до центра разлива 
        public float maxconcentration { get; set; }                  // максимальная концентрация нефтепродукта
        public float timemaxconcentration { get; private set; }          // время достижения  максимальной концентрация нефтепродукта
        public DateTime datemaxconcentration { get; set; }                  // дата достижения  максимальной концентрация нефтепродукта
        public float speedhorizontal { get; private set; }          // горизонтальная скорость 
        public float angle { get; private set; }          // гидравлический угол наклона  
        public string comment { get; private set; }          // комментарий 
        public string name { get; private set; }          // наименование 



        public POINTTYPE pointtype { get; private set; }          // тип точки 


        private readonly string comment_format = "{0}-{1}:";         // тип-id:


        public WaterPollution()
        {

        }
        public WaterPollution(EcoObject ecojbject, float distance, float angle, PetrochemicalType petrochemicatype, float speedhorizontal, float maxconcentration = 0.0f, float timemaxconcentration = 0.0f)
            : base(ecojbject)
        {
            this.pointtype = POINTTYPE.ECO;
            this.comment = string.Format(comment_format, EcoObject.PREFIX, ecojbject.id);
            this.petrochemicatype = petrochemicatype;
            this.cadastretype = ecojbject.cadastretype;
            this.distance = distance;
            this.angle = angle;
            this.name = ecojbject.name;
            this.speedhorizontal = speedhorizontal;
            this.maxconcentration = maxconcentration;
            this.timemaxconcentration = timemaxconcentration;
            this.datemaxconcentration = Const.DATE_INFINITY;

        }

    }
    public class WaterPollutionList : List<WaterPollution>    //  загрязнение во всех точках  в  водном радиусе 
    {
          public bool Add(WaterPollution waterpollution)
          {
               base.Add(waterpollution);
               return true;
           }

      }
    
}