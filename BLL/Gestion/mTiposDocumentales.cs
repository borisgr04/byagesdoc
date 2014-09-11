using AutoMapper;
using ByA;
using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Gestion
{
    public class mTiposDocumentales:absBLL
    {
        public mTiposDocumentales()
         {

             Mapper.CreateMap<tiposdocumentalesDto, tiposdocumentales>();
             Mapper.CreateMap<tiposdocumentales, tiposdocumentalesDto>();
         }
       
        public ByARpt Insert(tiposdocumentalesDto Reg)
         {
             tiposdocumentales r = new tiposdocumentales();
             Mapper.Map(Reg, r);
             cmdInsert o = new cmdInsert { reg = r };
             return o.Enviar();
         }
        public ByARpt Update(tiposdocumentalesDto Reg)
         {
             tiposdocumentales r = new tiposdocumentales();
             Mapper.Map(Reg, r);
             cmdUpdate o = new cmdUpdate { reg = r };
             return o.Enviar();
         }
        public ByARpt Anular(tiposdocumentalesDto Reg)
         {
             tiposdocumentales r = new tiposdocumentales();
             Mapper.Map(Reg, r);
             cmdAnular o = new cmdAnular { reg = r };
             return o.Enviar();
         }

        public List<tiposdocumentalesDto> Gets()
         {
             List<tiposdocumentalesDto> lstT = new List<tiposdocumentalesDto>();
             using (ctx = new trdEntities())
          {
              List<tiposdocumentales> lstO = ctx.tiposdocumentales.ToList();
              Mapper.Map(lstO, lstT);
          }
          return lstT;
      }    
        public tiposdocumentalesDto Get(string Id)
      {
          tiposdocumentalesDto objT = new tiposdocumentalesDto();
          using (ctx = new trdEntities())
          {
              tiposdocumentales objO = ctx.tiposdocumentales.Find(Id);
              Mapper.Map(objO, objT);
          }
          return objT;
      }

         class cmdInsert : absTemplate
         {

             public tiposdocumentales found { get; set; }
             public tiposdocumentales reg { get; set; }
             protected internal override bool esValido()
             {
                 return true;
             }
             protected internal override void Antes()
             {
                 reg.Estado = "AC";
                 ctx.tiposdocumentales.Add(reg);

             }


         }
         class cmdUpdate : absTemplate
         {

             public tiposdocumentales reg { get; set; }
             public tiposdocumentales found { get; set; }
             protected internal override bool esValido()
             {
                 found = ctx.tiposdocumentales.Where(t => t.idTipDocumentales == reg.idTipDocumentales).FirstOrDefault();
                 if (found != null)
                 {
                     found.Nombe = reg.Nombe;
                     found.SubSerieId = reg.SubSerieId;
                     found.TD_Copia = reg.TD_Copia;
                     found.TD_Original = reg.TD_Original;
                   
                
                     return true;
                 }
                 else
                 {
                     byaRpt.Mensaje = "No se encontro El TipoDocumental";
                     byaRpt.Error = true;
                     return !byaRpt.Error;
                 }


             }
             protected internal override void Antes()
             {
                
                 ctx.Entry(found).State = System.Data.Entity.EntityState.Modified; 
             }


         }
         class cmdAnular : absTemplate
         {

             public tiposdocumentales found { get; set; }
             public tiposdocumentales reg { get; set; }
             protected internal override bool esValido()
             {
                 found = ctx.tiposdocumentales.Where(t => t.idTipDocumentales == reg.idTipDocumentales).FirstOrDefault();
                 if (found != null)
                 {
                     found.Estado = "AN";
                     return true;
                 }
                 else
                 {
                     byaRpt.Mensaje = "No se encontro el TipoDocumental";
                     byaRpt.Error = true;
                     return !byaRpt.Error;
                 }


             }
             protected internal override void Antes()
             {
                
                 ctx.Entry(found).State = System.Data.Entity.EntityState.Modified; 
             }


         }
    }
}
