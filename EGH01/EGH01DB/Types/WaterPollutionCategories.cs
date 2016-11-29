using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using EGH01DB.Primitives;

// Категории загрязнения грунтовых вод

namespace EGH01DB.Types
{
    public class WaterPollutionCategories
    {
        public int code { get; private set; }   // код категории
        public string name { get; private set; }   // наименование категории
        public float min { get; private set; }   // минимальное значение диапазона
        public float max { get; private set; }   // максимальное значение диапазона

        static public WaterPollutionCategories defaulttype { get { return new WaterPollutionCategories (0, "Не определен", 0.0f, 0.0f); } }  // выдавать при ошибке  
      
        public WaterPollutionCategories()
        {
            this.code = -1;
            this.name = string.Empty;
            this.min = 0.0f;
            this.max = 0.0f;
        }
        public WaterPollutionCategories(int code)
        {
            this.code = code;
            this.name = string.Empty;
            this.min = 0.0f;
            this.max = 0.0f;
        }
    
        public WaterPollutionCategories(int code, String name, float min, float max)
        {
            this.code = code;
            this.name = name;
            this.min = min;
            this.max = max;
        }
        public WaterPollutionCategories(XmlNode node)
        {
            this.code = Helper.GetIntAttribute(node, "code", -1);
            this.name = Helper.GetStringAttribute(node, "name", "");
            this.min = Helper.GetFloatAttribute(node, "min", 0.0f);
            this.max = Helper.GetFloatAttribute(node, "max", 0.0f);
        }
        static public bool GetNextCode(EGH01DB.IDBContext dbcontext, out int code)
        {
            bool rc = false;
            code = -1;
            using (SqlCommand cmd = new SqlCommand("EGH.GetNextWaterPollutionCategoriesCode", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодКатегорииЗагрязненияГВ", SqlDbType.Int);
                    parm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@exitrc", SqlDbType.Int);
                    parm.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(parm);
                }
                try
                {
                    cmd.ExecuteNonQuery();
                    code = (int)cmd.Parameters["@КодКатегорииЗагрязненияГВ"].Value;
                    rc = (int)cmd.Parameters["@exitrc"].Value > 0;
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }
        static public bool Create(EGH01DB.IDBContext dbcontext, WaterPollutionCategories water_pollution_categories)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.CreateWaterPollutionCategories", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    int new_type_code = 0;
                    if (GetNextCode(dbcontext, out new_type_code)) water_pollution_categories.code = new_type_code;
                    SqlParameter parm = new SqlParameter("@КодКатегорииЗагрязненияГВ", SqlDbType.Int);
                    parm.Value = water_pollution_categories.code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@НаименованиеКатегорииЗагрязненияГВ", SqlDbType.NVarChar);
                    parm.Value = water_pollution_categories.name;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@МинДиапазон", SqlDbType.Real);
                    parm.Value = water_pollution_categories.min;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@МаксДиапазон", SqlDbType.Real);
                    parm.Value = water_pollution_categories.max;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@exitrc", SqlDbType.Int);
                    parm.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(parm);
                }
                try
                {
                    cmd.ExecuteNonQuery();
                    rc = (int)cmd.Parameters["@exitrc"].Value > 0;
                }
                catch (Exception e)
                {
                    rc = false;
                };
            }
            return rc;
        }
        static public bool Update(EGH01DB.IDBContext dbcontext, WaterPollutionCategories water_pollution_categories)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.UpdateWaterPollutionCategories", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодКатегорииЗагрязненияГВ", SqlDbType.Int);
                    parm.Value = water_pollution_categories.code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@НаименованиеКатегорииЗагрязненияГВ", SqlDbType.VarChar);
                    parm.Value = water_pollution_categories.name;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@МинДиапазон", SqlDbType.Real);
                    parm.Value = water_pollution_categories.min;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@МаксДиапазон", SqlDbType.Real);
                    parm.Value = water_pollution_categories.max;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@exitrc", SqlDbType.Int);
                    parm.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(parm);
                }
                try
                {
                    cmd.ExecuteNonQuery();
                    rc = (int)cmd.Parameters["@exitrc"].Value > 0;
                }
                catch (Exception e)
                {
                    rc = false;
                };

            }

            return rc;
        }
        static public bool DeleteByCode(EGH01DB.IDBContext dbcontext, int code)
        {
            return Delete(dbcontext, new WaterPollutionCategories(code));
        }
        static public bool Delete(EGH01DB.IDBContext dbcontext, WaterPollutionCategories water_pollution_categories)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.DeleteWaterPollutionCategories", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодКатегорииЗагрязненияГВ", SqlDbType.Int);
                    parm.Value = water_pollution_categories.code;
                    cmd.Parameters.Add(parm);
                }

                {
                    SqlParameter parm = new SqlParameter("@exitrc", SqlDbType.Int);
                    parm.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(parm);
                }
                try
                {
                    cmd.ExecuteNonQuery();
                    rc = (int)cmd.Parameters["@exitrc"].Value > 0;
                }
                catch (Exception e)
                {
                    rc = false;
                };

            }

            return rc;
        }
        static public bool GetByCode(EGH01DB.IDBContext dbcontext, int code, out WaterPollutionCategories water_pollution_categories)
        {
            bool rc = false;
            water_pollution_categories = new WaterPollutionCategories();
            using (SqlCommand cmd = new SqlCommand("EGH.GetWaterPollutionCategoriesByCode", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодКатегорииЗагрязненияГВ", SqlDbType.Int);
                    parm.Value = code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@exitrc", SqlDbType.Int);
                    parm.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(parm);
                }
                try
                {
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int re_code = (int)reader["КодКатегорииЗагрязненияГВ"];
                        string name = (string)reader["НаименованиеКатегорииЗагрязненияГВ"];
                        float min = (float)reader["МинДиапазон"];
                        float max = (float)reader["МаксДиапазон"];
                        if (rc = (int)cmd.Parameters["@exitrc"].Value > 0) water_pollution_categories = new WaterPollutionCategories(code, name, min, max);

                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = false;
                };

            }
            return rc;
        }
        
        public XmlNode toXmlNode(string comment = "")
        {
            XmlDocument doc = new XmlDocument();
            XmlElement rc = doc.CreateElement("WaterPollutionCategories");
            if (!String.IsNullOrEmpty(comment)) rc.SetAttribute("comment", comment);
            rc.SetAttribute("code", this.code.ToString());
            rc.SetAttribute("name", this.name.ToString());
            rc.SetAttribute("min", this.min.ToString());
            rc.SetAttribute("max", this.max.ToString());
            return (XmlNode)rc;
        }
    }
}
