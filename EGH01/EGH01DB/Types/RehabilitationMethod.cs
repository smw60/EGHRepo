using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using EGH01DB.Primitives;
using EGH01DB.Types;

// Классификатор методов реабилитации - RehabilitationMethod
namespace EGH01DB.Types
{
    class RehabilitationMethod
    {
        public int type_code { get; private set; }   // код 
        public RiskObjectType riskobjecttype { get; private set; } // ---- Тип Техногенного Объекта	
        public CadastreType cadastretype  { get; private set; } // ---- Назначение Земель	
        public PetrochemicalCategories petrochemicalcategory  { get; private set; } // ---- Категория Нефтепродукта	
        public EmergencyClass emergencyclass { get; private set; } //  ---- Классификация Аварий
        public PenetrationDepth penetrationdepth  { get; private set; } // ---- Категория Проникновения Нефтепродукта
        public SoilPollutionCategories soilpollutioncategories { get; private set; } // ---- Категория Загрязнения Грунта	
        public bool waterachieved { get; private set; } // ---- Достижение Горизонта Грунтовых Вод
        public WaterPollutionCategories waterpollutioncategories { get; private set; } // ---- Категория Загрязнения Грунтовых Вод
        public WaterProtectionArea waterprotectionarea { get; private set; }   // ---- Категория Водоохранной Территории
        public SoilCleaningMethod soilcleaningmethod  { get; private set; }   // ---- Категория Методов ликвидации Загрязнения грунта
        public WaterCleaningMethod watercleaningmethod { get; private set; }   //---- Категория Методов ликвидации Загрязнения грунтовых вод

    }
}
