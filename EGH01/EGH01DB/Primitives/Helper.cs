using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.Xml.Xsl;
using EGH01DB.Types;
using EGH01DB.Objects;
using EGH01DB.Points;
using EGH01DB.Primitives;
using EGH01DB.Blurs;

namespace EGH01DB.Primitives
{
    public partial class Helper
    {

        static public bool GetListIncidentType(EGH01DB.IDBContext dbcontext, ref List<IncidentType> list_type)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetIncidentTypeList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    list_type = new List<IncidentType>();
                    while (reader.Read())
                    {
                        list_type.Add(new IncidentType((int)reader["КодТипа"], (string)reader["Наименование"]));
                    }
                    rc = list_type.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;

            }
        }
        static public IncidentTypeList GetListIncidentType(EGH01DB.IDBContext dbcontext)
        {
            List<IncidentType> list = new List<IncidentType>();
            IncidentTypeList rc = new IncidentTypeList(list);
            if (Helper.GetListIncidentType(dbcontext, ref list)) 
            {
                rc = new IncidentTypeList(list);
            }
            return rc;
        }
        static public EGH01DB.Objects.RiskObjectsList GetListRiskObject(EGH01DB.IDBContext dbcontext)
        {
            List<RiskObject> list = new List<RiskObject>();
            EGH01DB.Objects.RiskObjectsList rc = new EGH01DB.Objects.RiskObjectsList(list);
            if (Helper.GetListRiskObject(dbcontext, ref list))
            {
                rc = new EGH01DB.Objects.RiskObjectsList(list);
            }
            return rc;
        }
        static public EGH01DB.Types.PetrochemicalTypeList GetListPetrochemicalType(EGH01DB.IDBContext dbcontext)
        {
            List<PetrochemicalType> list = new List<PetrochemicalType>();
            EGH01DB.Types.PetrochemicalTypeList rc = new EGH01DB.Types.PetrochemicalTypeList(list);
            if (Helper.GetListPetrochemicalType(dbcontext, ref list))
            {
                rc = new EGH01DB.Types.PetrochemicalTypeList(list);
            }
            return rc;
        }
        static public EGH01DB.Types.CadastreTypeList GetListCadastreType(EGH01DB.IDBContext dbcontext)
        {
            List<CadastreType> list = new List<CadastreType>();
            EGH01DB.Types.CadastreTypeList rc = new EGH01DB.Types.CadastreTypeList(list);
            if (Helper.GetListCadastreType(dbcontext, ref list))
            {
                rc = new EGH01DB.Types.CadastreTypeList(list);
            }
            return rc;
        }
        //static public EGH01DB.Blurs.GroundPollutionList GetListGroundPollution(EGH01DB.IDBContext dbcontext)
        //{
        //    List<GroundPollution> list = new List<GroundPollution>();
        //    EGH01DB.Blurs.GroundPollutionList rc = new EGH01DB.Blurs.GroundPollutionList(list);
        //    if (Helper.GetListGroundPollution(dbcontext, ref list))
        //    {
        //        rc = new EGH01DB.Blurs.GroundPollutionList(list);
        //    }
        //    return rc;
        //}
        static public EGH01DB.Objects.EcoObjectsList GetListEcoObject(EGH01DB.IDBContext dbcontext)
        {
            List<EcoObject> list = new List<EcoObject>();
            EGH01DB.Objects.EcoObjectsList rc = new EGH01DB.Objects.EcoObjectsList(list);
            if (Helper.GetListEcoObject(dbcontext, ref list))
            {
                rc = new EGH01DB.Objects.EcoObjectsList(list);
            }
            return rc;
        }
        static public EGH01DB.Types.EcoObjectTypeList GetListEcoObjectType(EGH01DB.IDBContext dbcontext)
        {
            List<EcoObjectType> list = new List<EcoObjectType>();
            EGH01DB.Types.EcoObjectTypeList rc = new EGH01DB.Types.EcoObjectTypeList(list);
            if (Helper.GetListEcoObjectType(dbcontext, ref list))
            {
                rc = new EGH01DB.Types.EcoObjectTypeList(list);
            }
            return rc;
        }
        static public EGH01DB.Types.GroundTypeList GetListGroundType(EGH01DB.IDBContext dbcontext)
        {
            List<GroundType> list = new List<GroundType>();
            EGH01DB.Types.GroundTypeList rc = new EGH01DB.Types.GroundTypeList(list);
            if (Helper.GetListGroundType(dbcontext, ref list))
            {
                rc = new EGH01DB.Types.GroundTypeList(list);
            }
            return rc;
        }
        static public EGH01DB.Types.SoilPollutionCategoriesList GetListSoilPollutionCategories(EGH01DB.IDBContext dbcontext)
        {
            List<SoilPollutionCategories> list = new List<SoilPollutionCategories>();
            EGH01DB.Types.SoilPollutionCategoriesList rc = new EGH01DB.Types.SoilPollutionCategoriesList(list);
            if (Helper.GetListSoilPollutionCategories(dbcontext, ref list))
            {
                rc = new EGH01DB.Types.SoilPollutionCategoriesList(list);
            }
            return rc;
        }
        static public EGH01DB.Primitives.WaterPropertiesList GetListWaterProperties(EGH01DB.IDBContext dbcontext)
        {
            List<WaterProperties> list = new List<WaterProperties>();
            EGH01DB.Primitives.WaterPropertiesList rc = new EGH01DB.Primitives.WaterPropertiesList(list);
            if (Helper.GetListWaterProperties(dbcontext, ref list))
            {
                rc = new EGH01DB.Primitives.WaterPropertiesList(list);
            }
            return rc;
        }
        static public EGH01DB.Primitives.SpreadingCoefficientList GetListSpreadingCoefficient(EGH01DB.IDBContext dbcontext)
        {
            List<SpreadingCoefficient> list = new List<SpreadingCoefficient>();
            EGH01DB.Primitives.SpreadingCoefficientList rc = new EGH01DB.Primitives.SpreadingCoefficientList(list);
            if (Helper.GetListSpreadingCoefficient(dbcontext, ref list))
            {
                rc = new EGH01DB.Primitives.SpreadingCoefficientList(list);
            }
            return rc;
        }
        static public EGH01DB.Points.AnchorPointList GetListAnchorPoint(EGH01DB.IDBContext dbcontext)
        {
            List<AnchorPoint> list = new List<AnchorPoint>();
            EGH01DB.Points.AnchorPointList rc = new EGH01DB.Points.AnchorPointList(list);
            if (Helper.GetListAnchorPoint(dbcontext, ref list))
            {
                rc = new EGH01DB.Points.AnchorPointList(list);
            }
            return rc;
        }
        static public bool GetListGroundType(EGH01DB.IDBContext dbcontext, ref List<GroundType> list_type)
        { 
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetGroundTypeList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    list_type = new List<GroundType>();
                    while (reader.Read())
                    {
                        int code = (int)reader["КодТипаГрунта"];
                        string name = (string)reader["НаименованиеТипаГрунта"];
                        float porosity = (float)reader["КоэфПористости"];
                        float holdmigration = (float)reader["КоэфЗадержкиМиграции"];
                        float waterfilter = (float)reader["КоэфФильтрацииВоды"];
                        float diffusion = (float)reader["КоэфДиффузии"];
                        float distribution = (float)reader["КоэфРаспределения"];
                        float sorption = (float)reader["КоэфСорбции"];

                        float watercapacity = (float)reader["КоэфКапВлагоемкости"];
                        float soilmoisture = (float)reader["ВлажностьГрунта"];
                        float аveryanovfactor = (float)reader["КоэфАверьянова"];
                        float permeability = (float)reader["Водопроницаемость"];
                        float density = (float)reader["СредняяПлотностьГрунта"];

                        list_type.Add(new GroundType((int)code, 
                                                    (string)name, 
                                                    (float)porosity, 
                                                    (float)holdmigration, 
                                                    (float)waterfilter, 
                                                    (float)diffusion, 
                                                    (float)distribution, 
                                                    (float)sorption,
                                                    (float)watercapacity,
                                                    (float)soilmoisture,
                                                    (float)аveryanovfactor,
                                                    (float)permeability,
                                                    (float)density));
                    }
                    rc = list_type.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        
        }
        static public bool GetListCadastreType(EGH01DB.IDBContext dbcontext, ref List<CadastreType> list_type) 
        { 
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetLandRegistryTypeList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    list_type = new List<CadastreType>();
                    while (reader.Read())
                    {
                        int ground_category_code = (int)reader["КодКатегорииЗагрязненияГрунта"];
                        string ground_category_name = (string)reader["НаименованиеКатегорииЗагрязненияГрунта"];
                        float min = (float)reader["МинДиапазон"];
                        float max = (float)reader["МаксДиапазон"];
                        SoilPollutionCategories soilpollutioncategory = new SoilPollutionCategories(ground_category_code, ground_category_name, min, max);
                        list_type.Add(new CadastreType((int)reader["КодНазначенияЗемель"], 
                                                        (string)reader["НаименованиеНазначенияЗемель"], 
                                                        (float)reader["ПДК"],
                                                        (float)reader["ПДКВоды"],
                                                        (string)reader["НормДокументЗемля"],
                                                        (string)reader["НормДокументВода"],
                                                        soilpollutioncategory));
                    }
                    rc = list_type.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;

            }
        }
        static public bool GetListWaterProperties(EGH01DB.IDBContext dbcontext, ref List<WaterProperties> list)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetWaterPropertiesList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    list = new List<WaterProperties>();
                    while (reader.Read())
                    {
                        list.Add(new WaterProperties((int)reader["КодПоказателяВоды"],
                                                        (float)reader["Температура"],
                                                        (float)reader["Вязкость"],
                                                        (float)reader["Плотность"],
                                                       (float)reader["КоэфПовНат"]));
                    }
                    rc = list.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;

            }
        }
        static public bool GetListEcoObjectType(EGH01DB.IDBContext dbcontext, ref List<EcoObjectType> list_type)
        { 
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetEcoObjectTypeList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    EcoObjectType eco_object_type = new EcoObjectType();
                    list_type = new List<EcoObjectType>();
                    while (reader.Read())
                    {
                        int code = (int)reader["КодТипаПриродоохранногоОбъекта"];
                        string name = (string)reader["НаименованиеТипаПриродоохранногоОбъекта"];
                        int? cat_water_name;
                        cat_water_name = (reader["КатегорияВодоохрТер"] == DBNull.Value) ? null : (int?)reader["КатегорияВодоохрТер"];
                        if (cat_water_name != null)
                        {
                            int category_code = (int)reader["КодТипаКатегории"];
                            string category_name = (string)reader["НаименованиеКатегории"];
                            WaterProtectionArea waterprotectionarea = new WaterProtectionArea(category_code, category_name);
                            eco_object_type = new EcoObjectType(code, name, waterprotectionarea);
                        }
                        else eco_object_type = new EcoObjectType(code, name, null);
                        list_type.Add(eco_object_type);
                    }
                    rc = list_type.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }
        static public bool GetListPetrochemicalType(EGH01DB.IDBContext dbcontext, ref List<PetrochemicalType> list_type) 
        { 
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetPetrochemicalTypeList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    list_type = new List<PetrochemicalType>();
                    while (reader.Read())
                    {
                        int code = (int)reader["КодТипаНефтепродукта"];
                        string name = (string)reader["НаименованиеТипаНефтепродукта"];
                        float boilingtemp = (float)reader["ТемператураКипения"];
                        float density = (float)reader["Плотность"];
                        float viscosity = (float)reader["КинематическаяВязкость"];
                        float solubility = (float)reader["Растворимость"];
                        float tension = (float)reader["КоэфНатяжения"];
                        float dynamicviscosity = (float)reader["ДинамическаяВязкость"];
                        float diffusion = (float)reader["КоэфДиффузии"];
                        int petrochemicalcategories = (int)reader["КодКатегорииНефтепродукта"];
                        string petrochemicalcategoriesname = (string)reader["НаименованиеКатегорииНефтепродукта"];
                        PetrochemicalCategories petro_cat = new PetrochemicalCategories(petrochemicalcategories, petrochemicalcategoriesname);
                        list_type.Add(new PetrochemicalType((int)code, 
                                                            (string)name, 
                                                            (float)boilingtemp, 
                                                            (float)density, 
                                                            (float)viscosity, 
                                                            (float)solubility, 
                                                            (float)tension,
                                                            (float)dynamicviscosity,
                                                            (float)diffusion, petro_cat));
                    }
                    rc = list_type.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }
        static public bool GetListRegion(EGH01DB.IDBContext dbcontext, ref List<Region> list_region)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetRegionList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    list_region = new List<Region>();
                    while (reader.Read())
                    {
                        list_region.Add(new Region((int)reader["КодОбласти"], (string)reader["Область"]));
                    }
                    rc = list_region.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;

            }
        }
        static public bool GetListDistrict(EGH01DB.IDBContext dbcontext, int region_code, ref List<District> list_district)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetDistrictList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@Область", SqlDbType.Int);
                    parm.Value = region_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@exitrc", SqlDbType.Int);
                    parm.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(parm);
                }
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    list_district = new List<District>();
                    while (reader.Read())
                    {
                        Region region = new Region((int)reader["КодОбласти"], (string)reader["Область"]);
                        District district = new District((int)reader["КодРайона"], region, (string)reader["Район"]);
                        list_district.Add(district);
                    }
                    rc = list_district.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;

            }
        }
        static public bool GetListDistrict(EGH01DB.IDBContext dbcontext, ref List<District> list_district)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetDistrictListFull", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@exitrc", SqlDbType.Int);
                    parm.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(parm);
                }
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    list_district = new List<District>();
                    while (reader.Read())
                    {
                        Region region = new Region((int)reader["КодОбласти"], (string)reader["Область"]);
                        District district = new District((int)reader["КодРайона"], region, (string)reader["Район"]);
                        list_district.Add(district);
                    }
                    rc = list_district.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;

            }
        }
        static public bool GetListRiskObjectType(EGH01DB.IDBContext dbcontext, ref List<RiskObjectType> list_type)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetRiskObjectTypeList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    list_type = new List<RiskObjectType>();
                    while (reader.Read())
                    {
                        list_type.Add(new RiskObjectType((int)reader["КодТипаТехногенногоОбъекта"],
                                                         (string)reader["НаименованиеТипаТехногенногоОбъекта"]));
                    }
                    rc = list_type.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }
        static public bool GetListRiskObject(EGH01DB.IDBContext dbcontext, ref List<RiskObject> risk_objects)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetRiskObjectList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    risk_objects = new List<RiskObject>();
                    while (reader.Read())
                    {
                        int id = (int)reader["IdТехногенногоОбъекта"];
                        float x = (float)reader["ШиротаГрад"];
                        float y = (float)reader["ДолготаГрад"];
                        Coordinates coordinates = new Coordinates((float)x, (float)y);
                        string ground_type_name = (string)reader["НаименованиеТипаГрунта"];
                        float porosity = (float)reader["КоэфПористости"];
                        float holdmigration = (float)reader["КоэфЗадержкиМиграции"];
                        float waterfilter = (float)reader["КоэфФильтрацииВоды"];
                        float diffusion = (float)reader["КоэфДиффузии"];
                        float distribution = (float)reader["КоэфРаспределения"];
                        float sorption = (float)reader["КоэфСорбции"];
                        float watercapacity = (float)reader["КоэфКапВлагоемкости"];
                        float soilmoisture = (float)reader["ВлажностьГрунта"];
                        float аveryanovfactor = (float)reader["КоэфАверьянова"];
                        float permeability = (float)reader["Водопроницаемость"];
                        float density = (float)reader["СредняяПлотностьГрунта"];
                        GroundType ground_type = new GroundType((int)reader["ТипГрунта"],
                                                                    (string)ground_type_name,
                                                                    (float)porosity,
                                                                    (float)holdmigration,
                                                                    (float)waterfilter,
                                                                    (float)diffusion,
                                                                    (float)distribution,
                                                                    (float)sorption,
                                                                    (float)watercapacity,
                                                                    (float)soilmoisture,
                                                                    (float)аveryanovfactor,
                                                                    (float)permeability,
                                                                    (float)density);
                        float waterdeep = (float)reader["ГлубинаГрунтовыхВод"];
                        float height = (float)reader["ВысотаУровнемМоря"];

                        int district_code = (int)reader["РайонТехногенногоОбъекта"];
                        string district_name = (string)reader["Район"];

                        int region_code = (int)reader["ОбластьТехногенногоОбъекта"];
                        string region_name = (string)reader["Область"];
                        Region region = new Region(region_code, region_name);
                        District district = new District(district_code, region, district_name);

                        string ownership = (string)reader["Принадлежность"];
                        string phone = (string)reader["Телефон"];
                        string fax = (string)reader["Факс"];
                        string email = (string)reader["EMail"];

                        DateTime foundationdate = (DateTime)reader["ДатаВводаЭкспл"];
                        DateTime reconstractiondate = (DateTime)reader["ДатаПоследнейРеконструкции"];
                        
                        int numberofrefuel = (int)reader["КолВоЗаправокСут"];
                        int volume = (int)reader["ОбъемХранения"];

                        float groundtank = (float)reader["ЕмкостьНаземногоРезервуара"];
                        float undergroundtank = (float)reader["ЕмкостьПодземногоРезервуара"];

                        bool watertreatment = (bool)reader["ОчистнДождСток"];
                        bool watertreatmentcollect = (bool)reader["ОчистнСборПроливов"];

                        string fueltype = (string)reader["ТипТоплива"];
                        int numberofthreads = (int)reader["КоличествоНиток"];
                        float productivity = (float)reader["Производительность"];
                        float tubediameter = (float)reader["ДиаметрТрубы"];
                        string geodescription = (string)reader["ГеографическоеОписание"];
					
                        byte[] map = new byte[0]; // карта!

                        Point point = new Point(coordinates, ground_type, (float)waterdeep, (float)height);
                        string risk_object_type_name = (string)reader["НаименованиеТипаТехногенногоОбъекта"];
                        RiskObjectType risk_object_type = new RiskObjectType((int)reader["КодТипаТехногенногоОбъекта"], (string)risk_object_type_name);
                        string cadastre_type_name = (string)reader["НаименованиеНазначенияЗемель"];
                        float pdk = (float)reader["ПДК"];
                        float water_pdk_coef = (float)reader["ПДКводы"];
                        string ground_doc_name = (string)reader["НормДокументЗемля"];
                        string water_doc_name = (string)reader["НормДокументВода"];
                        
                        int ground_category_code = (int)reader["КодКатегорииЗагрязненияГрунта"];
                        string ground_category_name = (string)reader["НаименованиеКатегорииЗагрязненияГрунта"];
                        float min = (float)reader["МинДиапазон"];
                        float max = (float)reader["МаксДиапазон"];
                        SoilPollutionCategories soilpollutioncategory = new SoilPollutionCategories(ground_category_code, ground_category_name, min, max);

                        string name = (string)reader["НаименованиеТехногенногоОбъекта"];
                        string address = (string)reader["АдресТехногенногоОбъекта"];
                        CadastreType cadastre_type = new CadastreType((int)reader["КодТипаНазначенияЗемель"], (string)cadastre_type_name,
                                                                        (float)pdk, (float)water_pdk_coef,
                                                                        (string)ground_doc_name, (string)water_doc_name, soilpollutioncategory);
                        RiskObject risk_object = new RiskObject(id, point, risk_object_type, cadastre_type,
                                                                name, district, region, address, ownership, phone, fax, email, 
                                                                foundationdate, reconstractiondate,
                                                                numberofrefuel, volume,
                                                                watertreatment, watertreatmentcollect, map,
                                                                groundtank, undergroundtank, fueltype, numberofthreads, (float)tubediameter, (float)productivity, geodescription);
                        
                        risk_objects.Add(risk_object);
                    }
                    rc = risk_objects.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }
        static public bool GetListSpreadingCoefficient(EGH01DB.IDBContext dbcontext, ref List<SpreadingCoefficient> spreading_coefficient)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetSpreadingCoefficientList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    spreading_coefficient = new List<SpreadingCoefficient>();
                    while (reader.Read())
                    {
                        int ground_type_code = (int)reader["ТипГрунта"];
                        string ground_type_name = (string)reader["НаименованиеТипаГрунта"];

                        float porosity = (float)reader["КоэфПористости"];
                        float holdmigration = (float)reader["КоэфЗадержкиМиграции"];
                        float waterfilter = (float)reader["КоэфФильтрацииВоды"];
                        float diffusion = (float)reader["КоэфДиффузииГрунта"];
                        float distribution = (float)reader["КоэфРаспределения"];
                        float sorption = (float)reader["КоэфСорбции"];
                        float watercapacity = (float)reader["КоэфКапВлагоемкости"];
                        float soilmoisture = (float)reader["ВлажностьГрунта"];
                        float аveryanovfactor = (float)reader["КоэфАверьянова"];
                        float permeability = (float)reader["Водопроницаемость"];
                        float density = (float)reader["СредняяПлотностьГрунта"];
                        GroundType ground_type = new GroundType ((int)ground_type_code,
                                                    (string)ground_type_name, 
                                                    (float)porosity, 
                                                    (float)holdmigration, 
                                                    (float)waterfilter, 
                                                    (float)diffusion, 
                                                    (float)distribution, 
                                                    (float)sorption,
                                                    (float)watercapacity,
                                                    (float)soilmoisture,
                                                    (float)аveryanovfactor,
                                                    (float)permeability,
                                                    (float)density);
                        int code = (int)reader["КодКоэффициентаРазлива"];
                        float min_volume = (float)reader["МинПролива"];
                        float max_volume = (float)reader["МаксПролива"];
                        float min_angle = (float)reader["МинУклона"];
                        float max_angle = (float)reader["МаксУклона"];
                        double koef = (double)reader["КоэффициентРазлива"];

                        int petrochemical_type_code = (int)reader["КодТипаНефтепродукта"];
                        string name = (string)reader["НаименованиеТипаНефтепродукта"];
                        float boilingtemp = (float)reader["ТемператураКипения"];
                        float petrochemical_density = (float)reader["Плотность"];
                        float viscosity = (float)reader["КинематическаяВязкость"];
                        float solubility = (float)reader["Растворимость"];
                        float tension = (float)reader["КоэфНатяжения"];
                        float dynamicviscosity = (float)reader["ДинамическаяВязкость"];
                        float petrochemical_diffusion = (float)reader["КоэфДиффузииНП"];
                        int petrochemicalcategories = (int)reader["КодКатегорииНефтепродукта"];
                        string petrochemicalcategoriesname = (string)reader["НаименованиеКатегорииНефтепродукта"];
                        PetrochemicalCategories petro_cat = new PetrochemicalCategories(petrochemicalcategories, petrochemicalcategoriesname);
                        PetrochemicalType petrochemical_type = new PetrochemicalType(petrochemical_type_code,
                                                                                     name,
                                                                                     (float)boilingtemp,
                                                                                     (float)petrochemical_density,
                                                                                     (float)viscosity,
                                                                                     (float)solubility,
                                                                                     (float)tension,
                                                                                     (float)dynamicviscosity,
                                                                                     (float)petrochemical_diffusion, petro_cat);

                        spreading_coefficient.Add(new SpreadingCoefficient(code, ground_type, petrochemical_type,
                                                        (float)min_volume,
                                                        (float)max_volume,
                                                        (float)min_angle,
                                                        (float)max_angle,
                                                        (float)koef));
                    }
                    rc = spreading_coefficient.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;

            }
        }
        static public bool GetListAnchorPoint(EGH01DB.IDBContext dbcontext, ref List<AnchorPoint> anchor_points)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetAnchorPointList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    anchor_points = new List<AnchorPoint>();
                    while (reader.Read())
                    {
                        int id = (int)reader["IdОпорнойГеологическойТочки"];
                        float x = (float)reader["ШиротаГрад"];
                        float y = (float)reader["ДолготаГрад"];
                        Coordinates coordinates = new Coordinates((float)x, (float)y);

                        string ground_type_name = (string)reader["НаименованиеТипаГрунта"];
                        float porosity = (float)reader["КоэфПористости"];
                        float holdmigration = (float)reader["КоэфЗадержкиМиграции"];
                        float waterfilter = (float)reader["КоэфФильтрацииВоды"];
                        float diffusion = (float)reader["КоэфДиффузии"];
                        float distribution = (float)reader["КоэфРаспределения"];
                        float sorption = (float)reader["КоэфСорбции"];
                        float watercapacity = (float)reader["КоэфКапВлагоемкости"];
                        float soilmoisture = (float)reader["ВлажностьГрунта"];
                        float аveryanovfactor = (float)reader["КоэфАверьянова"];
                        float permeability = (float)reader["Водопроницаемость"];
                        float density = (float)reader["СредняяПлотностьГрунта"];
                        GroundType ground_type = new GroundType((int)reader["ТипГрунта"],
                                                                    (string)ground_type_name,
                                                                    (float)porosity,
                                                                    (float)holdmigration,
                                                                    (float)waterfilter,
                                                                    (float)diffusion,
                                                                    (float)distribution,
                                                                    (float)sorption,
                                                                    (float)watercapacity,
                                                                    (float)soilmoisture,
                                                                    (float)аveryanovfactor,
                                                                    (float)permeability,
                                                                    (float)density);
                        float waterdeep = (float)reader["ГлубинаГрунтовыхВод"];
                        float height = (float)reader["ВысотаУровнемМоря"];
                        Point point = new Point(coordinates, ground_type, (float)waterdeep, (float)height);

                        string cadastre_type_name = (string)reader["НаименованиеНазначенияЗемель"];
                        float pdk = (float)reader["ПДК"];
                        float water_pdk_coef = (float)reader["ПДК"];
                        string ground_doc_name = (string)reader["НормДокументЗемля"];
                        string water_doc_name = (string)reader["НормДокументВода"];

                        int ground_category_code = (int)reader["КодКатегорииЗагрязненияГрунта"];
                        string ground_category_name = (string)reader["НаименованиеКатегорииЗагрязненияГрунта"];
                        float min = (float)reader["МинДиапазон"];
                        float max = (float)reader["МаксДиапазон"];
                        SoilPollutionCategories soilpollutioncategory = new SoilPollutionCategories(ground_category_code, ground_category_name, min, max);

                        CadastreType cadastre_type = new CadastreType((int)reader["КодНазначенияЗемель"], (string)cadastre_type_name,
                                                                        (float)pdk, (float)water_pdk_coef,
                                                                        (string)ground_doc_name, (string) water_doc_name, soilpollutioncategory);
                        AnchorPoint anchor_point = new AnchorPoint(id, point, cadastre_type);

                        anchor_points.Add(anchor_point);
                    }
                    rc = anchor_points.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }
        static public bool GetListEcoObject(EGH01DB.IDBContext dbcontext, ref List<EcoObject> ecoobjects)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetEcoObjectList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    ecoobjects = new List<EcoObject>();
                    while (reader.Read())
                    {
                        int id = (int)reader["IdПриродоохранногоОбъекта"];
                        float x = (float)reader["ШиротаГрад"];
                        float y = (float)reader["ДолготаГрад"];
                        Coordinates coordinates = new Coordinates((float)x, (float)y);

                        string ground_type_name = (string)reader["НаименованиеТипаГрунта"];
                        float porosity = (float)reader["КоэфПористости"];
                        float holdmigration = (float)reader["КоэфЗадержкиМиграции"];
                        float waterfilter = (float)reader["КоэфФильтрацииВоды"];
                        float diffusion = (float)reader["КоэфДиффузии"];
                        float distribution = (float)reader["КоэфРаспределения"];
                        float sorption = (float)reader["КоэфСорбции"];
                        float watercapacity = (float)reader["КоэфКапВлагоемкости"];
                        float soilmoisture = (float)reader["ВлажностьГрунта"];
                        float аveryanovfactor = (float)reader["КоэфАверьянова"];
                        float permeability = (float)reader["Водопроницаемость"];
                        float density = (float)reader["СредняяПлотностьГрунта"];
                        GroundType ground_type = new GroundType((int)reader["ТипГрунта"],
                                                                    (string)ground_type_name,
                                                                    (float)porosity,
                                                                    (float)holdmigration,
                                                                    (float)waterfilter,
                                                                    (float)diffusion,
                                                                    (float)distribution,
                                                                    (float)sorption,
                                                                    (float)watercapacity,
                                                                    (float)soilmoisture,
                                                                    (float)аveryanovfactor,
                                                                    (float)permeability,
                                                                    (float)density);
                        float waterdeep = (float)reader["ГлубинаГрунтовыхВод"];
                        float height = (float)reader["ВысотаУровнемМоря"];
                        Point point = new Point(coordinates, ground_type, (float)waterdeep, (float)height);
                        int cadastre_type_code = (int)reader["КодТипаНазначенияЗемель"];
                        string cadastre_type_name = (string)reader["НаименованиеНазначенияЗемель"];
                        float pdk = (float)reader["ПДК"];
                        float water_pdk_coef = (float)reader["ПДКводы"];
                        string ground_doc_name = (string)reader["НормДокументЗемля"];
                        string water_doc_name = (string)reader["НормДокументВода"];

                        
                        int ground_category_code = (int)reader["КодКатегорииЗагрязненияГрунта"];
                        string ground_category_name = (string)reader["НаименованиеКатегорииЗагрязненияГрунта"];
                        float min = (float)reader["МинДиапазон"];
                        float max = (float)reader["МаксДиапазон"];
                        SoilPollutionCategories soilpollutioncategory = new SoilPollutionCategories(ground_category_code, ground_category_name, min, max);

                        CadastreType cadastre_type = new CadastreType(cadastre_type_code,cadastre_type_name,
                                                                        (float)pdk, (float)water_pdk_coef,
                                                                        ground_doc_name, water_doc_name, soilpollutioncategory);
                       
                        bool iswaterobject;
                        int cat_water_name = (int)reader["КатегорияВодоохрТер"];
                        string category_name = (string)reader["НаименованиеКатегории"];

                        if (cat_water_name==0 ) iswaterobject = true; else iswaterobject= false;
                        WaterProtectionArea waterprotectionarea = new WaterProtectionArea(cat_water_name, category_name);
                        EcoObjectType eco_object_type = new EcoObjectType(cat_water_name, category_name, waterprotectionarea);
                          
                        string ecoobject_name = (string)reader["НаименованиеПриродоохранногоОбъекта"];

                        EcoObject ecoobject = new EcoObject(id, point, eco_object_type, cadastre_type, ecoobject_name, iswaterobject);

                        ecoobjects.Add(ecoobject);
                    }
                    rc = ecoobjects.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }
        static public bool GetListECOForecast(EGH01DB.IDBContext dbcontext, ref List<RGEContext.ECOForecast> list_eco_forecast)
        {
            bool rc = false;
            list_eco_forecast =   new List<RGEContext.ECOForecast>();   //   new RGEContext.ECOForecastlist();
            using (SqlCommand cmd = new SqlCommand("EGH.GetEcoForecastList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@exitrc", SqlDbType.Int);
                    parm.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(parm);
                }
                try
                {
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                       
                        string stage = (string)reader["Стадия"];
                         int report_id = (int)reader ["IdОтчета"];
                         DateTime date = (DateTime)reader["ДатаОтчета"];   
                         int predator = (int)reader["Родитель"];
                        
                         string xmlContent = (string)reader["ТекстОтчета"];
                         if (!xmlContent.Trim().Equals(""))
                         {
                          XmlDocument doc = new XmlDocument();
                          doc.LoadXml(xmlContent);
                          XmlNode newNode = doc.DocumentElement;
                          list_eco_forecast.Add(new RGEContext.ECOForecast (newNode));
                         //comment = (string)reader["Комментарий"];
                         }
                    }
                    rc = ((int)cmd.Parameters["@exitrc"].Value >0);
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };

            }
            return rc;
        }
        static public bool GetListECOEvalution(EGH01DB.IDBContext dbcontext, ref List<CEQContext.ECOEvalution> list_ecoevalution)
        {
            bool rc = false;
            list_ecoevalution =   new List<CEQContext.ECOEvalution>();   //   new RGEContext.ECOForecastlist();
            using (SqlCommand cmd = new SqlCommand("EGH.GetECOEvalutionList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@exitrc", SqlDbType.Int);
                    parm.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(parm);
                }
                try
                {
                    // cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                       
                        string stage = (string)reader["Стадия"];
                         int report_id = (int)reader ["IdОтчета"];
                         DateTime date = (DateTime)reader["ДатаОтчета"];   
                         int predator = (int)reader["Родитель"];
                        
                         string xmlContent = (string)reader["ТекстОтчета"];
                         if (!xmlContent.Trim().Equals(""))
                         {
                          XmlDocument doc = new XmlDocument();
                          doc.LoadXml(xmlContent);
                          XmlNode newNode = doc.DocumentElement;
                          list_ecoevalution.Add(new CEQContext.ECOEvalution(newNode));
                         }
                    }
                    rc = true;   //   ((int)cmd.Parameters["@exitrc"].Value >0);
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };

            }
            return rc;
        } 
        static public bool GetListReport(EGH01DB.IDBContext dbcontext, ref List<Report> list)
        {
            bool rc = false;
            list = new List<Report>();  
            using (SqlCommand cmd = new SqlCommand("EGH.GetReportList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@exitrc", SqlDbType.Int);
                    parm.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(parm);
                }
                try
                {
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                            string stage = (string)reader["Стадия"];
                            int report_id = (int)reader["IdОтчета"];
                            DateTime date = (DateTime)reader["ДатаОтчета"];
                            int predator = (int)reader["Родитель"];
                            Report parent_Report = new Report(predator);
                            string comment = (string)reader["Комментарий"];

                            string xmlContent = (string)reader["ТекстОтчета"];
                            xmlContent = xmlContent.TrimEnd();
                            xmlContent = xmlContent.TrimStart();
                   
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(xmlContent);
                            XmlNode xml_Content_Node = doc.DocumentElement;
                         
                            string xlst_Content = (string)reader["СтильОтчета"];
                            xlst_Content = xmlContent.TrimEnd();
                            xlst_Content = xmlContent.TrimStart();
                            //if (!xlst_Content.Trim().Equals(""))
                           // {
                                XmlDocument doc_xlst = new XmlDocument();
                                doc_xlst.LoadXml(xlst_Content);
                                XmlNode xlst_Content_Node = doc_xlst.DocumentElement;
                           // }
                                list.Add(new Report(report_id, parent_Report, stage, date, xml_Content_Node, xlst_Content_Node, comment));
 
                    }
                    rc = ((int)cmd.Parameters["@exitrc"].Value > 0);
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };

            }
            return rc;
        }
        static public bool GetListSoilCleaningMethods(EGH01DB.IDBContext dbcontext, ref List<SoilCleaningMethod> list_soil_clean_method)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetSoilCleaningMethodsList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    list_soil_clean_method = new List<SoilCleaningMethod>();
                    while (reader.Read())
                    {
                        int code = (int)reader["КодТипаКатегории"];
                        string name = (string)reader["НаименованиеКатегории"];
                        string method = (string)reader["ОписаниеМетода"];

                        list_soil_clean_method.Add(new SoilCleaningMethod(code, name, method));
                    }
                    rc = list_soil_clean_method.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }
        static public bool GetListWaterCleaningMethods(EGH01DB.IDBContext dbcontext, ref List<WaterCleaningMethod> list_water_clean_method)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetWaterCleaningMethodsList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    list_water_clean_method = new List<WaterCleaningMethod>();
                    while (reader.Read())
                    {
                        int code = (int)reader["КодТипаКатегории"];
                        string name = (string)reader["НаименованиеКатегории"];
                        string method = (string)reader["ОписаниеМетода"];

                        list_water_clean_method.Add(new WaterCleaningMethod(code, name, method));
                    }
                    rc = list_water_clean_method.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }
        static public bool GetListWaterPollutionCategories(EGH01DB.IDBContext dbcontext, ref List<WaterPollutionCategories> list_water_pollution_categories)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetWaterPollutionCategoriesList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    list_water_pollution_categories = new List<WaterPollutionCategories>();
                    while (reader.Read())
                    {
                        int code = (int)reader["КодКатегорииЗагрязненияГВ"];
                        string name = (string)reader["НаименованиеКатегорииЗагрязненияГВ"];
                        float min = (float)reader["МинДиапазон"];
                        float max = (float)reader["МаксДиапазон"];

                        list_water_pollution_categories.Add(new WaterPollutionCategories(code, name, min, max));
                    }
                    rc = list_water_pollution_categories.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }
        static public bool GetListSoilPollutionCategories(EGH01DB.IDBContext dbcontext, ref List<SoilPollutionCategories> list_soil_pollution_categories)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetSoilPollutionCategoriesList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    list_soil_pollution_categories = new List<SoilPollutionCategories>();
                    while (reader.Read())
                    {
                        int code = (int)reader["КодКатегорииЗагрязненияГрунта"];
                        string name = (string)reader["НаименованиеКатегорииЗагрязненияГрунта"];
                        float min = (float)reader["МинДиапазон"];
                        float max = (float)reader["МаксДиапазон"];

                        list_soil_pollution_categories.Add(new SoilPollutionCategories(code, name, min, max));
                    }
                    rc = list_soil_pollution_categories.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }
        static public bool GetListEmergencyClass(EGH01DB.IDBContext dbcontext, ref List<EmergencyClass> emergency_class)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetEmergencyClassList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    emergency_class = new List<EmergencyClass>();
                    while (reader.Read())
                    {
                        int code = (int)reader["КодТипаАварии"];
                        string name = (string)reader["НаименованиеТипаАварии"];
                        float min = (float)reader["МинМасса"];
                        float max = (float)reader["МаксМасса"];

                        emergency_class.Add(new EmergencyClass(code, name, min, max));
                    }
                    rc = emergency_class.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }
        static public bool GetListPenetrationDepth(EGH01DB.IDBContext dbcontext, ref List<PenetrationDepth> penetration_depth)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetPenetrationDepthList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    penetration_depth = new List<PenetrationDepth>();
                    while (reader.Read())
                    {
                        int code = (int)reader["КодТипаКатегории"];
                        string name = (string)reader["НаименованиеТипаКатегории"];
                        float min = (float)reader["МинДиапазон"];
                        float max = (float)reader["МаксДиапазон"];

                        penetration_depth.Add(new PenetrationDepth(code, name, min, max));
                    }
                    rc = penetration_depth.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }
        static public bool GetListPetrochemicalCategories(EGH01DB.IDBContext dbcontext, ref List<PetrochemicalCategories> list)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetPetrochemicalCategoriesList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    list = new List<PetrochemicalCategories>();
                    while (reader.Read())
                    {
                        list.Add(new PetrochemicalCategories((int)reader["КодКатегорииНефтепродукта"], (string)reader["НаименованиеКатегорииНефтепродукта"]));
                    }
                    rc = list.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }
        static public bool GetListWaterProtectionArea(EGH01DB.IDBContext dbcontext, ref List<WaterProtectionArea> list)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetWaterProtectionAreaList", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    list = new List<WaterProtectionArea>();
                    while (reader.Read())
                    {
                        list.Add(new WaterProtectionArea((int)reader["КодТипаКатегории"], (string)reader["НаименованиеКатегории"]));
                    }
                    rc = list.Count > 0;
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;

            }
        }
        static public float     GetFloatAttribute(XmlNode n, string name, float errorvalue = 0.0f)
        {
            float rc = errorvalue;
            if (n.Attributes[name] != null)  if (!float.TryParse(n.Attributes[name].Value, out rc)) rc = errorvalue;
            return rc;
        }
        static public int       GetIntAttribute(XmlNode n, string name, int errorvalue = -1)
        {
            int rc = errorvalue;
            if (n.Attributes[name] != null) if (!int.TryParse(n.Attributes[name].Value, out rc)) rc = errorvalue;
            return rc;
        }
        static public string    GetStringAttribute(XmlNode n, string name, string  errorvalue = "")
        {
            string rc = errorvalue;
            if (n.Attributes[name] != null) rc = n.Attributes[name].Value;
            return rc;
        }
        static public bool      GetBoolAttribute(XmlNode n, string name, bool errorvalue = false)
        {
            bool rc = errorvalue;
            if (n.Attributes[name] != null) if (!bool.TryParse(n.Attributes[name].Value, out rc)) rc = errorvalue;
            return rc;
        }
        static public DateTime  GetDateTimeAttribute(XmlNode n, string name, DateTime errorvalue)
        {
            DateTime rc = errorvalue;
            if (n.Attributes[name] != null) if (!DateTime.TryParse(n.Attributes[name].Value, out rc)) rc = errorvalue;
            return rc;
        }
        
    }
}
