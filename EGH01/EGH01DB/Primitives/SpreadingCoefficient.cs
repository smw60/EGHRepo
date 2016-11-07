using EGH01DB.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using EGH01DB.Primitives;
using System.Data.SqlClient;
using System.Data;


// коэффициент растекания м2/м3
// --- грунт 
//       объем >= 500      объем <= 60      
// угол  <= 1       5         20  
// угол  >  1      12         20
// --- асфальт 
//                         объем <= 60 
//                           150  


namespace EGH01DB.Primitives
{
    public class SpreadingCoefficient
    {
        public GroundType ground_type { get; private set; }     // тип грунта 
        public float min_volume { get; private set; }           // нижняя граница диапазона пролива   
        public float max_volume { get; private set; }           // верхняя граница диапазона пролива 
        public float min_angle { get; private set; }            // книжняя граница диапазона углов наклона 
        public float max_angle { get; private set; }            // верхняя граница диапазона углов наклона 
        public float koef { get; private set; }                 // коэффициент разлива в диапазоне 

        public bool Create()        { return true; }
        public bool Update()        { return true; }
        public bool Delete()        { return true; }
        public float Get()          { return -1; }
        public float GetByData()    { return -1; }
        
        public SpreadingCoefficient()
        {
            this.ground_type = new GroundType();
            this.min_volume = 0.0f;
            this.max_volume = 0.0f;
            this.min_angle = 0.0f;
            this.max_angle = 0.0f;
            this.koef = -1.0f;
        }
        public SpreadingCoefficient(GroundType groundtype, float min_volume, float max_volume, float min_angle, float max_angle, float koef)
        {
            this.ground_type = groundtype;
            this.min_volume = min_volume;
            this.max_volume = max_volume;
            this.min_angle = min_angle;
            this.max_angle = max_angle;
            this.koef = koef;
        }
        
        // круглое пятно: грунт, объем, угол наклона 
        public static float Get(EGH01DB.IDBContext dbcontext, SpreadingCoefficient spreading_coefficient) // получить коэффициент растекания, -1 - такого нет
        {
            int rc = -1;
            float koefficient = 0.0f;
            using (SqlCommand cmd = new SqlCommand("EGH.GetSpreadingCoefficientByDelta", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@ТипГрунта", SqlDbType.Int);
                    parm.Value = spreading_coefficient.ground_type.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@МинПролива", SqlDbType.Real);
                    parm.Value = spreading_coefficient.min_volume;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@МаксПролива", SqlDbType.Real);
                    parm.Value = spreading_coefficient.max_volume;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@МинУклона", SqlDbType.Real);
                    parm.Value = spreading_coefficient.min_angle;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@МаксУклона", SqlDbType.Real);
                    parm.Value = spreading_coefficient.max_angle;
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
                        double kof = (double)reader["КоэффициентРазлива"];
                        if ((int)cmd.Parameters["@exitrc"].Value > 0)
                        {
                            rc = (int)cmd.Parameters["@exitrc"].Value;
                            koefficient = (float)kof;
                        }
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    rc = -1;
                };
            }
            return koefficient;
        }
        public static float GetByData(EGH01DB.IDBContext dbcontext, GroundType type, float volume, float angle)
        {
            float rc = -1.0f;
            using (SqlCommand cmd = new SqlCommand("EGH.GetSpreadingCoefficientByData", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@ТипГрунта", SqlDbType.Int);
                    parm.Value = type.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Объем", SqlDbType.Float);
                    parm.Value = volume;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@УголНаклона", SqlDbType.Float);
                    parm.Value = angle;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КоэффициентРазлива", SqlDbType.Float);
                    parm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@exitrc", SqlDbType.Float);
                    parm.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(parm);
                }
                try
                {
                    cmd.ExecuteNonQuery();
                    double k = (double)cmd.Parameters["@КоэффициентРазлива"].Value;
                    rc = (float)k;
                }
                catch (Exception e)
                {
                    rc = -1;
                };

            }
            return rc;
        }

        public static bool Create(EGH01DB.IDBContext dbcontext, SpreadingCoefficient spreading_coefficient)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.CreateSpreadingCoefficient", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@ТипГрунта", SqlDbType.Int);
                    parm.Value = spreading_coefficient.ground_type.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@МинПролива", SqlDbType.Float);
                    parm.Value = spreading_coefficient.min_volume;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@МаксПролива", SqlDbType.Float);
                    parm.Value = spreading_coefficient.max_volume;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@МинУклона", SqlDbType.Float);
                    parm.Value = spreading_coefficient.min_angle;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@МаксУклона", SqlDbType.Float);
                    parm.Value = spreading_coefficient.max_angle;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КоэффициентРазлива", SqlDbType.Float);
                    parm.Value = spreading_coefficient.koef;
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
                    rc = ((int)cmd.Parameters["@exitrc"].Value == 1);
                }
                catch (Exception e)
                {
                    rc = false;
                };

            }

            return rc;


        }
        static public bool Update(EGH01DB.IDBContext dbcontext, SpreadingCoefficient spreading_coefficient)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.UpdateSpreadingCoefficient", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@ТипГрунта", SqlDbType.Int);
                    parm.Value = spreading_coefficient.ground_type.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@МинПролива", SqlDbType.VarChar);
                    parm.Value = spreading_coefficient.min_volume;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@МаксПролива", SqlDbType.Float);
                    parm.Value = spreading_coefficient.max_volume;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@МинУклона", SqlDbType.Float);
                    parm.Value = spreading_coefficient.min_angle;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@МаксУклона", SqlDbType.Float);
                    parm.Value = spreading_coefficient.max_angle;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КоэффициентРазлива", SqlDbType.Float);
                    parm.Value = spreading_coefficient.koef;
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
        static public bool Delete(EGH01DB.IDBContext dbcontext, SpreadingCoefficient spreading_coefficient)
        {

            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.DeleteSpreadingCoefficient", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@ТипГрунта", SqlDbType.Int);
                    parm.Value = spreading_coefficient.ground_type.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@МинПролива", SqlDbType.Float);
                    parm.Value = spreading_coefficient.min_volume;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@МаксПролива", SqlDbType.Float);
                    parm.Value = spreading_coefficient.max_volume;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@МинУклона", SqlDbType.Float);
                    parm.Value = spreading_coefficient.min_angle;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@МаксУклона", SqlDbType.Float);
                    parm.Value = spreading_coefficient.max_angle;
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

        // другие методы определения коэффициента  
        //static float get
        // static float get
    }
}
