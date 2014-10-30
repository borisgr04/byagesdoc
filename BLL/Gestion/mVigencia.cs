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
   public class mVigencia:absBLL
    {
        public mVigencia()
         {

             Mapper.CreateMap<VigenciaDto, vigencia>();
             Mapper.CreateMap<vigencia, VigenciaDto>();
         }
        public ByARpt Insert(VigenciaDto Reg)
         {
             vigencia r = new vigencia();
             Mapper.Map(Reg, r);
             cmdInsert o = new cmdInsert { reg = r };
             return o.Enviar();
         }
        public ByARpt Update(VigenciaDto Reg)
         {
             vigencia r = new vigencia();
             Mapper.Map(Reg, r);
             cmdUpdate o = new cmdUpdate { reg = r };
             return o.Enviar();
         }
        public ByARpt Anular(VigenciaDto Reg)
         {
             vigencia r = new vigencia();
             Mapper.Map(Reg, r);
             cmdAnular o = new cmdAnular { reg = r };
             return o.Enviar();
         }

        public List<VigenciaDto> Gets()
         {

             List<VigenciaDto> lstT = new List<VigenciaDto>();
          using (ctx = new trdEntities())
          {
              List<vigencia> lstO = ctx.vigencia.Where(t=>t.Estado!="AN").ToList();
              Mapper.Map(lstO, lstT);
          }
          return lstT;
      }
        public VigenciaDto Gets(string terceroId)
      {
          VigenciaDto objT = new VigenciaDto();
          using (ctx = new trdEntities())
          {
              vigencia objO = ctx.vigencia.Find(terceroId);
              Mapper.Map(objO, objT);
          }
          return objT;
      }




          class cmdInsert : absTemplate
          {
         
             public vigencia found { get; set; }
             public vigencia reg { get; set; }
             protected internal override bool esValido()
             {
                 return true;
             }
             protected internal override void Antes()
             {
                 reg.Estado = "AC";
                 ctx.vigencia.Add(reg);
                
             }


         }
          class cmdUpdate : absTemplate
          {

              public vigencia found { get; set; }
              public vigencia reg { get; set; }
              protected internal override bool esValido()
              {
                  found = ctx.vigencia.Where(t => t.Vigencia == reg.Vigencia).FirstOrDefault();
                  if (found != null)
                  {
                      found.Vigencia = reg.Vigencia;
                    
                   
                      return true;
                  }
                  else
                  {
                      byaRpt.Mensaje = "No se encontro La Vigencia";
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

              public vigencia found { get; set; }
              public vigencia reg { get; set; }
              protected internal override bool esValido()
              {
                  found = ctx.vigencia.Where(t => t.Vigencia == reg.Vigencia).FirstOrDefault();
                  if (found != null)
                  {
                      found.Estado = "AN";
                      return true;
                  }
                  else
                  {
                      byaRpt.Mensaje = "No se encontro La Vigencia";
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
