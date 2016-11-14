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
        static public bool Create(EGH01DB.IDBContext dbcontext, EcoObject ecoobject)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.CreateEcoObject", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@IdПриродоохранногоОбъекта", SqlDbType.Int);
                    int new_ecoobject_id = 0;
                    if (GetNextId(dbcontext, out new_ecoobject_id)) ecoobject.id = new_ecoobject_id;
                    parm.Value = ecoobject.id;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ШиротаГрад", SqlDbType.Real);
                    parm.Value = ecoobject.coordinates.latitude;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ДолготаГрад", SqlDbType.Real);
                    parm.Value = ecoobject.coordinates.lngitude;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ТипГрунта", SqlDbType.Int);
                    parm.Value = ecoobject.groundtype.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ГлубинаГрунтовыхВод", SqlDbType.Real);
                    parm.Value = ecoobject.waterdeep;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ВысотаУровнемМоря", SqlDbType.Real);
                    parm.Value = ecoobject.height;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КодНазначенияЗемель", SqlDbType.Int);
                    parm.Value = ecoobject.cadastretype.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КодНазначенияЗемель", SqlDbType.Int);
                    parm.Value = ecoobject.cadastretype.type_code;
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
                    rc = ((int)cmd.Parameters["@exitrc"].Value == ecoobject.id);
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
            using (SqlCommand cmd = new SqlCommand("EGH.GetNextEcoObjectId", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@IdПриродоохранногоОбъекта", SqlDbType.Int);
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
                    next_id = (int)cmd.Parameters["@IdПриродоохранногоОбъекта"].Value;
                    rc = (int)cmd.Parameters["@exitrc"].Value > 0;
                }
                catch (Exception e)
                {
                    rc = false;
                };
                return rc;
            }
        }
        static public bool Delete(EGH01DB.IDBContext dbcontext, EcoObject ecoobject)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.DeleteEcoObject", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@IdПриродоохранногоОбъекта", SqlDbType.Int);
                    parm.Value = ecoobject.id;
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
            return Delete(dbcontext, new EcoObject(id));
        }
        static public bool Update(EGH01DB.IDBContext dbcontext, EcoObject ecoobject)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.UpdateEcoObject", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@IdПриродоохранногоОбъекта", SqlDbType.Int);
                    parm.Value = ecoobject.id;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ШиротаГрад", SqlDbType.Real);
                    parm.Value = ecoobject.coordinates.latitude;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ДолготаГрад", SqlDbType.Real);
                    parm.Value = ecoobject.coordinates.lngitude;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ТипГрунта", SqlDbType.Int);
                    parm.Value = ecoobject.groundtype.type_code;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ГлубинаГрунтовыхВод", SqlDbType.Real);
                    parm.Value = ecoobject.waterdeep;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@ВысотаУровнемМоря", SqlDbType.Real);
                    parm.Value = ecoobject.height;
                    cmd.Parameters.Add(parm);
                }
                {
                    SqlParameter parm = new SqlParameter("@КодНазначенияЗемель", SqlDbType.Int);
                    parm.Value = ecoobject.cadastretype.type_code;
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
        static public bool GetById(EGH01DB.IDBContext dbcontext, int id, ref EcoObject ecoobject)
        {
            bool rc = false;
            using (SqlCommand cmd = new SqlCommand("EGH.GetEcoObjectByID", dbcontext.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    SqlParameter parm = new SqlParameter("@IdПриродоохранногоОбъекта", SqlDbType.Int);
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
                        int ecoobject_type_code = (int)reader["КодТипаПриродоохранногоОбъекта"];
                        string ecoobject_type_name = (string)reader["НаименованиеТипаПриродоохранногоОбъекта"];

                        EcoObjectType ecoobjecttype = new EcoObjectType(ecoobject_type_code, ecoobject_type_name);
                        int cadastre_type_code = (int)reader["КодНазначенияЗемель"];
                        string cadastre_type_name = (string)reader["НаименованиеНазначенияЗемель"];
                        float pdk = (float)reader["ПДК"];
                        float water_pdk_coef = (float)reader["ПДКводы"];
                        string ground_doc_name = (string)reader["НормДокументЗемля"];
                        string water_doc_name = (string)reader["НормДокументВода"];

                        CadastreType cadastre_type = new CadastreType(cadastre_type_code, (string)cadastre_type_name,
                                                                        pdk, water_pdk_coef,
                                                                        ground_doc_name, water_doc_name);
                        string ecoobject_name = (string)reader["НаименованиеПриродоохранногоОбъекта"];
                        bool iswaterobject = false;
                        ecoobject = new EcoObject(id, point, ecoobjecttype, cadastre_type, ecoobject_name, iswaterobject);
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
