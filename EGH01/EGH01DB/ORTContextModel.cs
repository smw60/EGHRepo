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
      public DateTime date {get; set;}
      public partial class ECORehabilitation: GEAContext.ECOClassification
     {

         //RiskObjectType              riskobjecttype           {get{ return this.groundblur.spreadpoint.riskobject.type;}}
         //CadastreType                cadastretype             {get{ return this.groundblur.spreadpoint.cadastretype;}}
         //PetrochemicalCategories     petrochemicalcategories  {get{ return this.groundblur.spreadpoint.petrochemicaltype.petrochemicalcategories;}}
         //EmergencyClass              emergencyclass           {get; private set;}
         //PenetrationDepth            penetrationdepth         {get; private set;}
         //SoilPollutionCategories     soilpollutioncategories  {get; private set;}
         //bool                        waterachieved            {get{ return this.groundblur.totalmass >= this.groundblur.adsorbedmass;}}
         //WaterPollutionCategories    waterpollutioncategories {get; private set;}
         //WaterProtectionArea         waterprotectionarea      {get; private set;}
          public List<RehabilitationMethod>  rehabilitationlist =     new List<RehabilitationMethod>();   // перечень технологий и методов реабилитации     

         public ECORehabilitation(GEAContext.ECOClassification ecoclassification):base(ecoclassification) 
         {
             this.date = DateTime.Now;
  
             int mk = 0;
             ORTContext db = new ORTContext(); 
             List<RehabilitationMethod>  source =  new List<RehabilitationMethod>();
             if (Helper.GetListRehabilitationMethod(db, ref source))
             {
               bool rc = true;
             
               foreach (RehabilitationMethod rm in source)
               {
                
                RiskObjectType               riskjbjecttype           = rm.riskobjecttype;
                CadastreType                 cadastretype             = rm.cadastretype;
                PetrochemicalCategories      petrochemicalcategories  = rm.petrochemicalcategory;
                EmergencyClass               emergencyclass           = rm.emergencyclass;
                PenetrationDepth             penetrationdepth         = rm.penetrationdepth;
                SoilPollutionCategories      soilpollutioncategories  = rm.soilpollutioncategories; 
                bool                         waterachieved            = rm.waterachieved;  
                WaterPollutionCategories     waterpollutioncategories = rm.waterpollutioncategories;
                WaterProtectionArea          waterprotectionarea      = rm.waterprotectionarea;              
                
                 rc = true;
                               
                 bool r1 = ( this.groundblur.spreadpoint.isriskobject &&  riskjbjecttype.type_code  > 0 && riskjbjecttype.type_code  == this.groundblur.spreadpoint.riskobject.type.type_code);  
                 
                 
                 bool r2 = (cadastretype.type_code    > 0  && cadastretype.type_code == this.groundblur.spreadpoint.cadastretype.type_code);

                 bool r3 = (emergencyclass.type_code  > 0  && this.groundblur.totalmass >= emergencyclass.minmass  &&  this.groundblur.totalmass <=  emergencyclass.maxmass);      
                   
                 bool r4 = (penetrationdepth.type_code > 0 && this.groundblur.depth >= penetrationdepth.mindepth   &&  this.groundblur.depth <= penetrationdepth.maxdepth); 
                
                 bool r5 = (soilpollutioncategories.code  == this.soilpollutioncategories.code);
               
                 bool r6 = (waterpollutioncategories.code == this.waterpollutioncategories.code);
                   
                 bool r7 = ( waterachieved == (this.groundblur.totalmass >= this.groundblur.adsorbedmass));   
                              
                 int k = (r1?1:0)  + (r2?1:0) + (r3?1:0) + (r3?1:0) + (r4?1:0) +(r5?1:0) + (r6?1:0) + (r7?1:0);

                 mk = k > mk?k:mk; 

                // if (r1 && r2 && r3 && r4 && r5 && r6 && r7 ) rehabilitationlist.Add(rm);
                if (k >= 6) rehabilitationlist.Add(rm);
              
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

