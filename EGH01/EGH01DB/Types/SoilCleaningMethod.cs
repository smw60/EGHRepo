using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using EGH01DB.Primitives;

// Категории методов ликвидации загрязнения грунта (SoilCleaningMethods)

namespace EGH01DB.Types
{
    public class SoilCleaningMethod
    {
        public int                 type_code                 {get; private set; }   // код категории
        public string              name                      {get; private set; }   // наименование категории
        public string              method_description        {get; private set; }   // описание метода


        static public SoilCleaningMethod defaulttype { get { return new SoilCleaningMethod(0, "Не определен", "Не определен"); } }  // выдавать при ошибке  
      
        public SoilCleaningMethod()
        {
            this.type_code = -1;
            this.name = string.Empty;
            this.method_description = string.Empty;
        }
        public SoilCleaningMethod(int code)
        {
            this.type_code = code;
            this.name = string.Empty;
            this.method_description = string.Empty;
        }
        public SoilCleaningMethod(String name)
        {
            this.type_code = -1;
            this.name = name;
            this.method_description = string.Empty;
        }
        public SoilCleaningMethod(int code, String name, String method_description)
        {
            this.type_code = code;
            this.name = name;
            this.method_description = method_description;
        }
        public SoilCleaningMethod(XmlNode node)
        {
            this.type_code = Helper.GetIntAttribute(node, "type_code", -1);
            this.name = Helper.GetStringAttribute(node, "name", "");
            this.method_description = Helper.GetStringAttribute(node, "method_description", "");
        }
        static public bool GetNextCode(EGH01DB.IDBContext dbcontext, out int code)
        {
            bool rc = false;
            code = -1;
            using (SqlCommand cmd = new SqlCommand("EGH.GetNextSoilCleaningMethodsCode", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипаКатегории", SqlDbType.Int);
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
                    code = (int)cmd.Parameters["@КодТипаКатегории"].Value;
                    rc = (int)cmd.Parameters["@exitrc"].Value > 0;
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }
        static public bool Create(EGH01DB.IDBContext dbcontext, SoilCleaningMethod method)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.CreateSoilCleaningMethods", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    int new_method_type_code = 0;
                    if (GetNextCode(dbcontext, out new_method_type_code)) method.type_code = new_method_type_code;
                    SqlParameter parm = new SqlParameter("@КодТипаКатегории", SqlDbType.NVarChar);
                    parm.Value = method.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@НаименованиеКатегории", SqlDbType.NVarChar);
                    parm.Value = method.name;
                    cmd.Parameters.Add(parm);
                }
                {
                   SqlParameter parm = new SqlParameter("@ОписаниеМетода", SqlDbType.NVarChar);
                   parm.Value = method.method_description;
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
        static public bool Update(EGH01DB.IDBContext dbcontext, SoilCleaningMethod method)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.UpdateSoilCleaningMethods", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипаКатегории", SqlDbType.Int);
                    parm.Value = method.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@НаименованиеКатегории", SqlDbType.NVarChar);
                    parm.Value = method.name;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ОписаниеМетода", SqlDbType.NVarChar);
                    parm.Value = method.method_description;
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
        static public bool DeleteByCode(EGH01DB.IDBContext dbcontext, int type_code)
        {
            return Delete(dbcontext, new SoilCleaningMethod(type_code));
        }
        static public bool Delete(EGH01DB.IDBContext dbcontext, SoilCleaningMethod method)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.DeleteSoilCleaningMethods", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипаКатегории", SqlDbType.Int);
                    parm.Value = method.type_code;
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
        static public bool GetByCode(EGH01DB.IDBContext dbcontext, int code, out SoilCleaningMethod method)
        {
            bool rc = false;
            method = new SoilCleaningMethod();
            using (SqlCommand cmd = new SqlCommand("EGH.GetSoilCleaningMethodsByCode", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодТипаКатегории", SqlDbType.Int);
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
                        int method_code = (int)reader["КодТипаКатегории"];
                        string name = (string)reader["НаименованиеКатегории"];
                        string method_description = (string)reader["ОписаниеМетода"];
                        if (rc = (int)cmd.Parameters["@exitrc"].Value > 0) method = new SoilCleaningMethod(method_code, name, method_description);

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
            XmlElement rc = doc.CreateElement("SoilCleaningMethod");
            if (!String.IsNullOrEmpty(comment)) rc.SetAttribute("comment", comment);
            rc.SetAttribute("type_code", this.type_code.ToString());
            rc.SetAttribute("name", this.name.ToString());
            rc.SetAttribute("method_description", this.method_description.ToString());
            return (XmlNode)rc;
        }
    }
}
