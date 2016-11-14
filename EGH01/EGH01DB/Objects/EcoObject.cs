using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGH01DB.Points;
using EGH01DB.Types;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using EGH01DB.Primitives;


namespace EGH01DB.Objects
{

    public class EcoObject : Point  // природоохранные объекты 
    {
        public int           id             {get; private set;}    // идентификатор 
        public EcoObjectType ecoobjecttype  {get; private set;}    // тип природохранного объекта 
        public CadastreType  cadastretype   {get; private set; }   // кадастровый тип земли
        public string name { get; private set; }  // наименование природоохранного объекта 
        public bool iswaterobject { get; private set; }    // является ли водным объектом 

        public EcoObject()
        {
            this.id = -1;
            this.ecoobjecttype = new EcoObjectType();
            this.cadastretype = new CadastreType();
            this.name = string.Empty;
            this.iswaterobject = false;
        }
        public EcoObject(int id)
        {
            this.id = id;
            this.ecoobjecttype = new EcoObjectType();
            this.cadastretype = new CadastreType();
            this.name = string.Empty;
            this.iswaterobject = false;
        }
        public EcoObject(int id, Point point, EcoObjectType ecoobjecttype, CadastreType cadastretype, string name, bool iswaterobject)
            : base(point)
        {
            this.id = id;
            this.ecoobjecttype = ecoobjecttype;
            this.cadastretype = cadastretype;
            this.name = name;
            this.iswaterobject = iswaterobject;
        }
        //static public bool Create(EGH01DB.IDBContext dbcontext, EcoObject ecoobject)
        //{
        //    bool rc = false;
        //    using (SqlCommand cmd = new SqlCommand("EGH.CreateEcoObject", dbcontext.connection))
        //    {
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        {
        //            SqlParameter parm = new SqlParameter("@IdОпорнойГеологическойТочки", SqlDbType.Int);
        //            int ecoobject_id = 0;
        //            if (GetNextId(dbcontext, out new_ecoobject_id)) ecoobject.id = new_ecoobject_id;
        //            parm.Value = ecoobject.id;
        //            cmd.Parameters.Add(parm);
        //        }
        //        {
        //            SqlParameter parm = new SqlParameter("@ШиротаГрад", SqlDbType.Real);
        //            parm.Value = ecoobject.coordinates.latitude;
        //            cmd.Parameters.Add(parm);
        //        }
        //        {
        //            SqlParameter parm = new SqlParameter("@ДолготаГрад", SqlDbType.Real);
        //            parm.Value = ecoobject.coordinates.lngitude;
        //            cmd.Parameters.Add(parm);
        //        }
        //        {
        //            SqlParameter parm = new SqlParameter("@ТипГрунта", SqlDbType.Int);
        //            parm.Value = ecoobject.groundtype.type_code;
        //            cmd.Parameters.Add(parm);
        //        }
        //        {
        //            SqlParameter parm = new SqlParameter("@ГлубинаГрунтовыхВод", SqlDbType.Real);
        //            parm.Value = ecoobject.waterdeep;
        //            cmd.Parameters.Add(parm);
        //        }
        //        {
        //            SqlParameter parm = new SqlParameter("@ВысотаУровнемМоря", SqlDbType.Real);
        //            parm.Value = ecoobject.height;
        //            cmd.Parameters.Add(parm);
        //        }
        //        {
        //            SqlParameter parm = new SqlParameter("@КодНазначенияЗемель", SqlDbType.Int);
        //            parm.Value = ecoobject.cadastretype.type_code;
        //            cmd.Parameters.Add(parm);
        //        }
        //        {
        //            SqlParameter parm = new SqlParameter("@exitrc", SqlDbType.Int);
        //            parm.Direction = ParameterDirection.ReturnValue;
        //            cmd.Parameters.Add(parm);
        //        }
        //        try
        //        {
        //            cmd.ExecuteNonQuery();
        //            rc = ((int)cmd.Parameters["@exitrc"].Value == ecoobject.id);
        //        }
        //        catch (Exception e)
        //        {
        //            rc = false;
        //        };
        //        return rc;
        //    }
        //}
        //static public bool GetNextId(EGH01DB.IDBContext dbcontext, out int next_id)
        //{
        //    bool rc = false;
        //    next_id = -1;
        //    using (SqlCommand cmd = new SqlCommand("EGH.GetNextAnchorPointId", dbcontext.connection))
        //    {
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        {
        //            SqlParameter parm = new SqlParameter("@IdОпорнойГеологическойТочки", SqlDbType.Int);
        //            parm.Direction = ParameterDirection.Output;
        //            cmd.Parameters.Add(parm);
        //        }
        //        {
        //            SqlParameter parm = new SqlParameter("@exitrc", SqlDbType.Int);
        //            parm.Direction = ParameterDirection.ReturnValue;
        //            cmd.Parameters.Add(parm);
        //        }
        //        try
        //        {
        //            cmd.ExecuteNonQuery();
        //            next_id = (int)cmd.Parameters["@IdОпорнойГеологическойТочки"].Value;
        //            rc = (int)cmd.Parameters["@exitrc"].Value > 0;
        //        }
        //        catch (Exception e)
        //        {
        //            rc = false;
        //        };
        //        return rc;
        //    }
        //}
        //static public bool Delete(EGH01DB.IDBContext dbcontext, AnchorPoint anchor_point)
        //{
        //    bool rc = false;
        //    using (SqlCommand cmd = new SqlCommand("EGH.DeleteAnchorPoint", dbcontext.connection))
        //    {
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        {
        //            SqlParameter parm = new SqlParameter("@IdОпорнойГеологическойТочки", SqlDbType.Int);
        //            parm.Value = anchor_point.id;
        //            cmd.Parameters.Add(parm);
        //        }

        //        {
        //            SqlParameter parm = new SqlParameter("@exitrc", SqlDbType.Int);
        //            parm.Direction = ParameterDirection.ReturnValue;
        //            cmd.Parameters.Add(parm);
        //        }
        //        try
        //        {
        //            cmd.ExecuteNonQuery();
        //            rc = (int)cmd.Parameters["@exitrc"].Value > 0;
        //        }
        //        catch (Exception e)
        //        {
        //            rc = false;
        //        };
        //    }
        //    return rc;
        //}
        //static public bool DeleteById(EGH01DB.IDBContext dbcontext, int id)
        //{
        //    return Delete(dbcontext, new AnchorPoint(id));
        //}
        //static public bool Update(EGH01DB.IDBContext dbcontext, AnchorPoint anchor_point)
        //{
        //    bool rc = false;
        //    using (SqlCommand cmd = new SqlCommand("EGH.UpdateAnchorPoint", dbcontext.connection))
        //    {
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        {
        //            SqlParameter parm = new SqlParameter("@IdОпорнойГеологическойТочки", SqlDbType.Int);
        //            parm.Value = anchor_point.id;
        //            cmd.Parameters.Add(parm);
        //        }
        //        {
        //            SqlParameter parm = new SqlParameter("@ШиротаГрад", SqlDbType.Real);
        //            parm.Value = anchor_point.coordinates.latitude;
        //            cmd.Parameters.Add(parm);
        //        }
        //        {
        //            SqlParameter parm = new SqlParameter("@ДолготаГрад", SqlDbType.Real);
        //            parm.Value = anchor_point.coordinates.lngitude;
        //            cmd.Parameters.Add(parm);
        //        }
        //        {
        //            SqlParameter parm = new SqlParameter("@ТипГрунта", SqlDbType.Int);
        //            parm.Value = anchor_point.groundtype.type_code;
        //            cmd.Parameters.Add(parm);
        //        }
        //        {
        //            SqlParameter parm = new SqlParameter("@ГлубинаГрунтовыхВод", SqlDbType.Real);
        //            parm.Value = anchor_point.waterdeep;
        //            cmd.Parameters.Add(parm);
        //        }
        //        {
        //            SqlParameter parm = new SqlParameter("@ВысотаУровнемМоря", SqlDbType.Real);
        //            parm.Value = anchor_point.height;
        //            cmd.Parameters.Add(parm);
        //        }
        //        {
        //            SqlParameter parm = new SqlParameter("@КодНазначенияЗемель", SqlDbType.Int);
        //            parm.Value = anchor_point.cadastretype.type_code;
        //            cmd.Parameters.Add(parm);
        //        }
        //        {
        //            SqlParameter parm = new SqlParameter("@exitrc", SqlDbType.Int);
        //            parm.Direction = ParameterDirection.ReturnValue;
        //            cmd.Parameters.Add(parm);
        //        }
        //        try
        //        {
        //            cmd.ExecuteNonQuery();
        //            rc = (int)cmd.Parameters["@exitrc"].Value > 0;
        //        }
        //        catch (Exception e)
        //        {
        //            rc = false;
        //        };
        //    }
        //    return rc;
        //}
        //static public bool GetById(EGH01DB.IDBContext dbcontext, int id, ref AnchorPoint anchor_point)
        //{
        //    bool rc = false;
        //    using (SqlCommand cmd = new SqlCommand("EGH.GetAnchorPointByID", dbcontext.connection))
        //    {
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        {
        //            SqlParameter parm = new SqlParameter("@IdОпорнойГеологическойТочки", SqlDbType.Int);
        //            parm.Value = id;
        //            cmd.Parameters.Add(parm);
        //        }
        //        {
        //            SqlParameter parm = new SqlParameter("@exitrc", SqlDbType.Int);
        //            parm.Direction = ParameterDirection.ReturnValue;
        //            cmd.Parameters.Add(parm);
        //        }
        //        try
        //        {
        //            cmd.ExecuteNonQuery();
        //            SqlDataReader reader = cmd.ExecuteReader();
        //            if (reader.Read())
        //            {
        //                float x = (float)reader["ШиротаГрад"];
        //                float y = (float)reader["ДолготаГрад"];
        //                Coordinates coordinates = new Coordinates((float)x, (float)y);

        //                string ground_type_name = (string)reader["НаименованиеТипаГрунта"];
        //                float porosity = (float)reader["КоэфПористости"];
        //                float holdmigration = (float)reader["КоэфЗадержкиМиграции"];
        //                float waterfilter = (float)reader["КоэфФильтрацииВоды"];
        //                float diffusion = (float)reader["КоэфДиффузии"];
        //                float distribution = (float)reader["КоэфРаспределения"];
        //                float sorption = (float)reader["КоэфСорбции"];
        //                float watercapacity = (float)reader["КоэфКапВлагоемкости"];
        //                float soilmoisture = (float)reader["ВлажностьГрунта"];
        //                float аveryanovfactor = (float)reader["КоэфАверьянова"];
        //                float permeability = (float)reader["Водопроницаемость"];
        //                float density = (float)reader["СредняяПлотностьГрунта"];

        //                GroundType ground_type = new GroundType((int)reader["ТипГрунта"],
        //                                                            (string)ground_type_name,
        //                                                            (float)porosity,
        //                                                            (float)holdmigration,
        //                                                            (float)waterfilter,
        //                                                            (float)diffusion,
        //                                                            (float)distribution,
        //                                                            (float)sorption,
        //                                                            (float)watercapacity,
        //                                                            (float)soilmoisture,
        //                                                            (float)аveryanovfactor,
        //                                                            (float)permeability,
        //                                                            (float)density);
        //                float waterdeep = (float)reader["ГлубинаГрунтовыхВод"];
        //                float height = (float)reader["ВысотаУровнемМоря"];
        //                Point point = new Point(coordinates, ground_type, (float)waterdeep, (float)height);

        //                string cadastre_type_name = (string)reader["НаименованиеНазначенияЗемель"];
        //                int pdk = (int)reader["ПДК"];

        //                CadastreType cadastre_type = new CadastreType((int)reader["КодНазначенияЗемель"], (string)cadastre_type_name, (int)pdk, 0.0f);// blinova

        //                anchor_point = new AnchorPoint(id, point, cadastre_type);
        //            }
        //            reader.Close();
        //            rc = (int)cmd.Parameters["@exitrc"].Value > 0;
        //        }
        //        catch (Exception e)
        //        {
        //            rc = false;
        //        };

        //        return rc;
        //    }

        //}
    }
     

    public class EcoObjectsList : List<EcoObject>      // список объектов  с координами 
    {
        public static EcoObjectsList CreateEcoObjectsList(Point center, float distance)
        {

            return new EcoObjectsList()
            {
                // найти все объекты на расстоянии < distance


            };
        }
        public static EcoObjectsList CreateEcoObjectsList(Point center, float distance1, float distance2 )
        {

            return new EcoObjectsList()
            {
                // найти все объекты на расстоянии > distance1 и <  distance2


            };
        }


    }



}
