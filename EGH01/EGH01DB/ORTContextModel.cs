using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGH01DB.Types;
using EGH01DB.Primitives;

namespace EGH01DB
{
    public partial class  ORTContext: IDBContext
    {

     public partial class ECORehabilitation: GEAContext.ECOClassification
     {

         public ECORehabilitation(GEAContext.ECOClassification ecoclassification):base(ecoclassification) 
         {
               
             ORTContext db = new ORTContext(); 
             List<RehabilitationMethod>  source =  new List<RehabilitationMethod>();
             List<RehabilitationMethod>  result =  new List<RehabilitationMethod>();
             if (Helper.GetListRehabilitationMethod(db, ref source))
             {
               foreach (RehabilitationMethod rm in source)
               {
                bool rc = true;
                 
                RiskObjectType               riskjbjecttype           = rm.riskobjecttype;
                CadastreType                 cadastretype             = rm.cadastretype;
                PetrochemicalCategories      petrochemicalcategories  = rm.petrochemicalcategory;
                EmergencyClass               emergencyclass           = rm.emergencyclass;
                PenetrationDepth             penetrationdepth         = rm.penetrationdepth;
                SoilPollutionCategories      soilpollutioncategories  = rm.soilpollutioncategories; 
                bool                         waterachieved            = rm.waterachieved;  
                WaterPollutionCategories     waterpollutioncategories = rm.waterpollutioncategories;
                WaterProtectionArea          waterprotectionarea      = rm.waterprotectionarea;              
                
                if (rc)
                {
                 if ( this.groundblur.spreadpoint.isriskobject)
                 {
                  if (riskjbjecttype.type_code  > 0 ) rc &= (riskjbjecttype.type_code  == this.groundblur.spreadpoint.riskobject.type.type_code);  
                 }
                 

                 if (cadastretype.type_code    > 0 ) rc &= ( cadastretype.type_code == this.groundblur.spreadpoint.cadastretype.type_code);

                } 
     



              //    waterachieved,



                   

               }

             }        
    
         }

     }  

    


    }


}


  //rehabilitation_method = new RehabilitationMethod(code,
  //                                                                          risk_object_type,
  //                                                                          cadastre_type,
  //                                                                          petrochemical_category,
  //                                                                          emergency_class,
  //                                                                          penetration_depth,
  //                                                                          soilpollution_categories,
  //                                                                          waterachieved,
  //                                                                          water_pollution_categories,
  //                                                                          water_protection_area,
  //                                                                          soil_cleaning_method, 
  //                                                                          water_cleaning_method);

