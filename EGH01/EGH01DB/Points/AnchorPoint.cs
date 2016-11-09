using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGH01DB.Primitives;
using EGH01DB.Types;
using EGH01DB.Points;
using System.Data.SqlClient;
using System.Data;
using System.Xml;

namespace EGH01DB.Points
{
    public class AnchorPoint:Point   // опорная геологическая точка   
    {
        public int          id           {get; private set;}  
        public CadastreType cadastretype {get; private set;}   // кадастровый тип земли

        public AnchorPoint()
        {
            this.id = -1;
            this.cadastretype = new CadastreType ();
        }
        public AnchorPoint(int id, Point point, CadastreType cadastretype):base (point)
        {
            this.id = id;
            this.cadastretype = cadastretype;
        }
        public AnchorPoint(int id)
        {
            this.id = id;
            this.cadastretype = new CadastreType ();
        }

        static public bool Create(EGH01DB.IDBContext dbcontext, AnchorPoint anchor_point)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.CreateAnchorPoint", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@IdОпорнойГеологическойТочки", SqlDbType.Int);
                    int new_anchor_point_id = 0;
                    if (GetNextId(dbcontext, out new_anchor_point_id)) anchor_point.id = new_anchor_point_id;
                    parm.Value = anchor_point.id;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ШиротаГрад", SqlDbType.Float);
                    parm.Value = anchor_point.coordinates.latitude;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ДолготаГрад", SqlDbType.Float);
                    parm.Value = anchor_point.coordinates.lngitude;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ТипГрунта", SqlDbType.Int);
                    parm.Value = anchor_point.groundtype.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ГлубинаГрунтовыхВод", SqlDbType.Float);
                    parm.Value = anchor_point.waterdeep;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ВысотаУровнемМоря", SqlDbType.Float);
                    parm.Value = anchor_point.height;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КодНазначенияЗемель", SqlDbType.Int);
                    parm.Value = anchor_point.cadastretype.type_code;
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
                    rc = ((int)cmd.Parameters["@exitrc"].Value == anchor_point.id);
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
            using (SqlCommand cmd = new SqlCommand("EGH.GetNextAnchorPointId", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@IdОпорнойГеологическойТочки", SqlDbType.Int);
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
                    next_id = (int)cmd.Parameters["@IdОпорнойГеологическойТочки"].Value;
                    rc = (int)cmd.Parameters["@exitrc"].Value > 0;
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }
        static public bool Delete(EGH01DB.IDBContext dbcontext, AnchorPoint anchor_point)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.DeleteAnchorPoint", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@IdОпорнойГеологическойТочки", SqlDbType.Int);
                    parm.Value = anchor_point.id;
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
        static public bool DeleteById(EGH01DB.IDBContext dbcontext, int id)
        {
            return Delete(dbcontext, new AnchorPoint(id));
        }
        static public bool Update(EGH01DB.IDBContext dbcontext, AnchorPoint anchor_point)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.UpdateAnchorPoint", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@IdОпорнойГеологическойТочки", SqlDbType.Int);
                    parm.Value = anchor_point.id;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ШиротаГрад", SqlDbType.Float);
                    parm.Value = anchor_point.coordinates.latitude;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ДолготаГрад", SqlDbType.Float);
                    parm.Value = anchor_point.coordinates.lngitude;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ТипГрунта", SqlDbType.Int);
                    parm.Value = anchor_point.groundtype.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ГлубинаГрунтовыхВод", SqlDbType.Float);
                    parm.Value = anchor_point.waterdeep;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ВысотаУровнемМоря", SqlDbType.Float);
                    parm.Value = anchor_point.height;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КодНазначенияЗемель", SqlDbType.Int);
                    parm.Value = anchor_point.cadastretype.type_code;
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
        static public bool GetById(EGH01DB.IDBContext dbcontext, int id, ref AnchorPoint anchor_point)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetAnchorPointByID", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@IdОпорнойГеологическойТочки", SqlDbType.Int);
                    parm.Value = id;
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
                        double x = (double)reader["ШиротаГрад"];
                        double y = (double)reader["ДолготаГрад"];
                        Coordinates coordinates = new Coordinates((float)x, (float)y);

                        string ground_type_name = (string)reader["НаименованиеТипаГрунта"];
                        double porosity = (double)reader["КоэфПористости"];
                        double holdmigration = (double)reader["КоэфЗадержкиМиграции"];
                        double waterfilter = (double)reader["КоэфФильтрацииВоды"];
                        double diffusion = (double)reader["КоэфДиффузии"];
                        double distribution = (double)reader["КоэфРаспределения"];
                        double sorption = (double)reader["КоэфСорбции"];
                        double watercapacity = (double)reader["КоэфКапВлагоемкости"];
                        double soilmoisture = (double)reader["ВлажностьГрунта"];
                        double аveryanovfactor = (double)reader["КоэфАверьянова"];
                        double permeability = (double)reader["Водопроницаемость"];
                        
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
                                                                    (float)permeability);
                        double waterdeep = (double)reader["ГлубинаГрунтовыхВод"];
                        double height = (double)reader["ВысотаУровнемМоря"];
                        Point point = new Point(coordinates, ground_type, (float)waterdeep, (float)height);

                        string cadastre_type_name = (string)reader["НаименованиеНазначенияЗемель"];
                        int pdk = (int)reader["ПДК"];
                        CadastreType cadastre_type = new CadastreType((int)reader["КодНазначенияЗемель"], (string)cadastre_type_name, (int)pdk);

                        anchor_point = new AnchorPoint(id, point, cadastre_type);
                    }
                    reader.Close();
                    rc = (int)cmd.Parameters["@exitrc"].Value > 0;
                }
                catch (Exception e)
                {
                    rc = false;
                };

                return rc;
            }

        }
    }
    public class AnchorPointList : List<AnchorPoint>   // список  опорных точек 
    {
        public AnchorPointList() : base()
        {

        }
        //  найти список точек в заданном радиусе 
        public static AnchorPointList CreateNear(Coordinates center, float radius)
        {
                         
            return new AnchorPointList()
            {
               new AnchorPoint()

            };

        }

        public static AnchorPointList CreateNear(Coordinates center, float radius1, float radius2)
        {

            // отладка 
            return new AnchorPointList()
            {


            };

        }

        //  найти  список точек в заданном полигоне 
        public static AnchorPointList CreateNear(Coordinates center, CoordinatesList border)
        {

            // отладка 
            return new AnchorPointList()
            {


            };

        }


    }







}
