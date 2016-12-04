﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using EGH01DB.Primitives;

namespace EGH01DB.Types
{
    public class CadastreType
    {
        public int    type_code { get; private set; }   // код кадастрового типа  (промзона, сельхоз земли, заповедники и пр.  ) 
        public string name     { get; private set; }   // наименование типа 
        public float pdk_coef { get; private set; }       // значение коэффициента ПДК 
        public float water_pdk_coef { get; private set; }
        public string ground_doc_name { get; private set; }   // наименование документа по земле 
        public string water_doc_name { get; private set; }   // наименование документа по воде 
        static public CadastreType defaulttype { get { return new CadastreType(0, "Не определен", 0.0f, 0.0f,"",""); } }  // выдавать при ошибке
        
        public CadastreType()
        {
            this.type_code = -1;
            this.name = string.Empty;
            this.pdk_coef = 0.0f;
            this.water_pdk_coef = 0.0f;
            this.ground_doc_name = string.Empty;
            this.water_doc_name = string.Empty;
        }

        public CadastreType(int type_code)
        {
            this.type_code = type_code;
            this.name = "";
            this.pdk_coef = 0.0f;
            this.water_pdk_coef = 0.0f;
            this.ground_doc_name = string.Empty;
            this.water_doc_name = string.Empty;
        }

        //public CadastreType(String name)
        //{
        //    this.type_code = 0;
        //    this.name = name;
        //    this.pdk_coef = 0.0f;
        //    this.water_pdk_coef = 0.0f;
        //    this.ground_doc_name = string.Empty;
        //    this.water_doc_name = string.Empty;
        //}
        public CadastreType(int type_code, String name, float pdk_coef, float water_pdk_coef, string ground_doc_name, string water_doc_name)
        {
            this.type_code = type_code;
            this.name = name;
            this.pdk_coef = pdk_coef;
            this.water_pdk_coef = water_pdk_coef;
            this.ground_doc_name = ground_doc_name;
            this.water_doc_name = water_doc_name;
        }
        public CadastreType(XmlNode node)
        {
            this.type_code = Helper.GetIntAttribute(node, "type_code", -1);
            this.name = Helper.GetStringAttribute(node, "name", "");
            this.pdk_coef = Helper.GetFloatAttribute(node, "pdk_coef", 0.0f);
            this.water_pdk_coef = Helper.GetFloatAttribute(node, "water_pdk_coef", 0.0f);
            this.ground_doc_name = Helper.GetStringAttribute(node, "ground_doc_name", "");
            this.water_doc_name = Helper.GetStringAttribute(node, "water_doc_name", "");

        }

        public string ToLine()
        {
            return String.Format("{0} {1}", this.type_code, this.name); 
        }
        static public bool Create(EGH01DB.IDBContext dbcontext, CadastreType land_type)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.CreateLandRegistryType", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодНазначенияЗемель", SqlDbType.Int);
                    int new_land_type_code = 0;
                    if (GetNextCode(dbcontext, out new_land_type_code)) land_type.type_code = new_land_type_code;
                    parm.Value = land_type.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@НаименованиеНазначенияЗемель", SqlDbType.NVarChar);
                    parm.Value = land_type.name;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ПДК", SqlDbType.Real);
                    parm.Value = land_type.pdk_coef;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ПДКводы", SqlDbType.Real);
                    parm.Value = land_type.water_pdk_coef;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@НормДокументЗемля", SqlDbType.NVarChar);
                    parm.Value = land_type.ground_doc_name;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@НормДокументВода", SqlDbType.NVarChar);
                    parm.Value = land_type.water_doc_name;
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
                    rc = (int)cmd.Parameters["@exitrc"].Value == land_type.type_code;
                }
                catch (Exception e)
                {
                    rc = false;
                };

            }

            return rc;
        }
        static public bool GetNextCode(EGH01DB.IDBContext dbcontext, out int code)
        {
            bool rc = false;
            code = -1;
            using (SqlCommand cmd = new SqlCommand("EGH.GetNextLandRegistryTypeCode", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодНазначенияЗемель", SqlDbType.Int);
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
                    code = (int)cmd.Parameters["@КодНазначенияЗемель"].Value;
                    rc = (int)cmd.Parameters["@exitrc"].Value > 0;
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }
        static public bool Update(EGH01DB.IDBContext dbcontext, CadastreType land_type)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.UpdateLandRegistryType", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодНазначенияЗемель", SqlDbType.Int);
                    parm.Value = land_type.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Наименование", SqlDbType.NVarChar);
                    parm.Value = land_type.name;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ЗначениеПДК", SqlDbType.Real);
                    parm.Value = land_type.pdk_coef;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ПДКводы", SqlDbType.Real);
                    parm.Value = land_type.water_pdk_coef;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@НормДокументЗемля", SqlDbType.NVarChar);
                    parm.Value = land_type.ground_doc_name;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@НормДокументВода", SqlDbType.NVarChar);
                    parm.Value = land_type.water_doc_name;
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
        static public bool Delete(EGH01DB.IDBContext dbcontext, CadastreType land_type)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.DeleteLandRegistryType", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодНазначенияЗемель", SqlDbType.Int);
                    parm.Value = land_type.type_code;
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
            return Delete(dbcontext, new CadastreType(code));
        }
        static public bool GetByCode(EGH01DB.IDBContext dbcontext, int type_code, out CadastreType type)
        {
            bool rc = false;
            type = new CadastreType();
            using (SqlCommand cmd = new SqlCommand("EGH.GetLandRegistryTypeByCode", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@КодНазначенияЗемель", SqlDbType.Int);
                    parm.Value = type_code;
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
                        string name = (string)reader["НаименованиеНазначенияЗемель"];
                        float pdk_coef = (float)reader["ПДК"];
                        float water_pdk_coef = (float)reader["ПДКводы"];
                        string ground_doc_name = (string)reader["НормДокументЗемля"];
                        string water_doc_name = (string)reader["НормДокументВода"];
                        if (rc = (int)cmd.Parameters["@exitrc"].Value > 0)
                            type = new CadastreType(type_code, name, (float)pdk_coef, (float)water_pdk_coef, ground_doc_name, water_doc_name); 
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
            XmlElement rc = doc.CreateElement("CadastreType");
            if (!String.IsNullOrEmpty(comment)) rc.SetAttribute("comment", comment);
            rc.SetAttribute("type_code", this.type_code.ToString());
            rc.SetAttribute("name", this.name.ToString());
            rc.SetAttribute("pdk_coef", this.pdk_coef.ToString());
            rc.SetAttribute("water_pdk_coef", this.water_pdk_coef.ToString());
            rc.SetAttribute("ground_doc_name", this.ground_doc_name.ToString());
            rc.SetAttribute("water_doc_name", this.water_doc_name.ToString());
            return (XmlNode)rc;
        }
    }
    public class CadastreTypeList : List<CadastreType>
    {
        List<EGH01DB.Types.CadastreType> list_petrochemical_type = new List<EGH01DB.Types.CadastreType>();
            public CadastreTypeList()
            {

            }
            public CadastreTypeList(List<CadastreType> list)
                : base(list)
            {

            }
            public CadastreTypeList(EGH01DB.IDBContext dbcontext)
                : base(Helper.GetListCadastreType(dbcontext))
            {

            }
        public XmlNode toXmlNode(string comment = "")
        {
            XmlDocument doc = new XmlDocument();
            XmlElement rc = doc.CreateElement("CadastreTypeList");
            if (!String.IsNullOrEmpty(comment)) rc.SetAttribute("comment", comment);
            this.ForEach(m => rc.AppendChild(doc.ImportNode(m.toXmlNode(), true)));
            return (XmlNode)rc;
        }
    }
}
