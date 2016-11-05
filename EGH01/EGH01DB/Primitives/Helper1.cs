using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.Globalization;
using EGH01DB.Types;
using EGH01DB.Objects;
using EGH01DB.Points;

namespace EGH01DB.Primitives
{
    public partial class  Helper
    {

        static public bool FloatTryParse(string s, out float f)
        {

            return float.TryParse(s, NumberStyles.Any, new CultureInfo("en-US"), out f); 
        }
        
         // smw60 - не законченный код 
        static public bool GetListRiskObjectByLike(EGH01DB.IDBContext dbcontext, string findstring, ref List<RiskObject> list_type)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetRisOJbjectListByLike", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                {
                    //SqlParameter parm = new SqlParameter("@IdТехногенногоОбъекта", SqlDbType.Int);
                    
                    //parm.DbType = DbType.String;
                    //parm.Value = findstring;
                    //cmd.Parameters.Add(parm);
                }

            
            }         





            return rc;

        
        }









        //static public bool GetListGroundType(EGH01DB.IDBContext dbcontext, ref List<GroundType> list_type)
        //{
        //    bool rc = false;
        //    using (SqlCommand cmd = new SqlCommand("EGH.GetGroundTypeList", dbcontext.connection))
        //    {
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        try
        //        {
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            list_type = new List<GroundType>();
        //            while (reader.Read())
        //            {
        //                int code = (int)reader["КодТипаГрунта"];
        //                string name = (string)reader["НаименованиеТипаГрунта"];
        //                double porosity = (double)reader["КоэфПористости"];
        //                double holdmigration = (double)reader["КоэфЗадержкиМиграции"];
        //                double waterfilter = (double)reader["КоэфФильтрацииВоды"];
        //                double diffusion = (double)reader["КоэфДиффузии"];
        //                double distribution = (double)reader["КоэфРаспределения"];
        //                double sorption = (double)reader["КоэфСорбции"];

        //                double watercapacity = (double)reader["КоэфКапВлагоемкости"];
        //                double soilmoisture = (double)reader["ВлажностьГрунта"];
        //                double аveryanovfactor = (double)reader["КоэфАверьянова"];
        //                double permeability = (double)reader["Водопроницаемость"];

        //                list_type.Add(new GroundType((int)code,
        //                                            (string)name,
        //                                            (float)porosity,
        //                                            (float)holdmigration,
        //                                            (float)waterfilter,
        //                                            (float)diffusion,
        //                                            (float)distribution,
        //                                            (float)sorption,
        //                                            (float)watercapacity,
        //                                            (float)soilmoisture,
        //                                            (float)аveryanovfactor,
        //                                            (float)permeability));
        //            }
        //            rc = list_type.Count > 0;
        //            reader.Close();
        //        }
        //        catch (Exception e)
        //        {
        //            rc = false;
        //        };
        //        return rc;
        //    }

        //}
    
    }
    
 }