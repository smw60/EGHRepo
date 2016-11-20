using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGH01DB.Points;
using EGH01DB.Types;
using EGH01DB.Primitives;
using System.Data.SqlClient;
using System.Data;
using System.Xml;

namespace EGH01DB
{

    public partial class RGEContext
    {
        public partial class ECOForecast         //  модель прогнозирования 
        {

            public static bool Create(IDBContext dbcontext, ECOForecast ecoforecast)
            {
                bool rc = false;
                using (SqlCommand cmd = new SqlCommand("EGH.CreateReport", dbcontext.connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    {
                        SqlParameter parm = new SqlParameter("@IdОтчета", SqlDbType.Int);
            
                    int new_report_id = 0;
                    if (GetNextId(dbcontext, out new_report_id)) ecoforecast.id = new_report_id;
                    parm.Value = ecoforecast.id;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ДатаОтчета", SqlDbType.DateTime);
                    parm.Value = ecoforecast.date;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Стадия", SqlDbType.NChar);
                    parm.Value = "П";
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Родитель", SqlDbType.Int);
                    parm.IsNullable = true;
                    parm.Value = null;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ТекстОтчета", SqlDbType.Xml);
                    parm.IsNullable = true; // сериализация!
                    parm.Value = null;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@Комментарий", SqlDbType.NVarChar);
                    parm.Value = "";
                    cmd.Parameters.Add(parm);
                }
                
                try
                {
                    cmd.ExecuteNonQuery();
                    rc = ((int)cmd.Parameters["@exitrc"].Value == ecoforecast.id);
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }

            }
            static public bool GetNextId(EGH01DB.IDBContext dbcontext, out int next_id)
            {
                bool rc = false;
                next_id = -1;
                using (SqlCommand cmd = new SqlCommand("EGH.GetNextReportId", dbcontext.connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    {
                        SqlParameter parm = new SqlParameter("@IdОтчета", SqlDbType.Int);
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
                        next_id = (int)cmd.Parameters["@IdОтчета"].Value;
                        rc = (int)cmd.Parameters["@exitrc"].Value > 0;
                    }
                    catch (Exception e)
                    {
                        rc = false;
                    };
                    return rc;
                }
            }
            public static bool GetById(IDBContext db, int id, out  ECOForecast ecoforecast)
            {
                ecoforecast = new ECOForecast();

                return true;
            }
            public static bool DeleteById(IDBContext db, int id)
            {
              
                return true;
            }
          
                    
        }

       
        public class ECOForecastlist : List<ECOForecast>
        {
         
          public static  bool  Get(IDBContext db, out ECOForecastlist ecoforecastlist)
          {
              ecoforecastlist = new ECOForecastlist();


              return true;
          }

          

        
        }
     }
}
