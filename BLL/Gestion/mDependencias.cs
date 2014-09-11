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
  public  class mDependencias
    {
         public trdEntities ctx { get; set; }

         public mDependencias()
         {

             Mapper.CreateMap<dependenciasDto, dependencias>();
             Mapper.CreateMap<dependencias, dependenciasDto>();
         }
         public ByARpt Insert(dependenciasDto Reg)
         {
             dependencias r = new dependencias();
             Mapper.Map(Reg, r);
             cmdInsert o = new cmdInsert { reg = r };
             return o.Enviar();
         }
         public ByARpt Update(dependenciasDto Reg)
         {
             dependencias r = new dependencias();
             Mapper.Map(Reg, r);
             cmdUpdate o = new cmdUpdate { reg = r };
             return o.Enviar();
         }
         public ByARpt Anular(dependenciasDto Reg)
         {
             dependencias r = new dependencias();
             Mapper.Map(Reg, r);
             cmdAnular o = new cmdAnular { reg = r };
             return o.Enviar();
         }

         public List<dependenciasDto> Gets()
         {

             List<dependenciasDto> lstT = new List<dependenciasDto>();
          using (ctx = new trdEntities())
          {
              List<dependencias> lstO = ctx.dependencias.Where(t=>t.Estado!="AN").ToList();
              Mapper.Map(lstO, lstT);
          }
          return lstT;
      }
         public dependenciasDto Gets(string terceroId)
      {
          dependenciasDto objT = new dependenciasDto();
          using (ctx = new trdEntities())
          {
              char pad = '0';
              terceroId = terceroId.ToString().PadLeft(2, pad);      
              dependencias objO = ctx.dependencias.Find(terceroId);
              Mapper.Map(objO, objT);
          }
          return objT;
      }

         class cmdInsert : absTemplate
         {

             public dependencias found { get; set; }
             public dependencias reg { get; set; }
             protected internal override bool esValido()
             {
                 return true;
             }
             protected internal override void Antes()
             {
                 reg.Estado = "AC";
                 ctx.dependencias.Add(reg);

             }


         }
         class cmdUpdate : absTemplate
         {

             public dependencias reg { get; set; }
             public dependencias found { get; set; }
             protected internal override bool esValido()
             {
                 found = ctx.dependencias.Where(t => t.idDependencia == reg.idDependencia).FirstOrDefault();
                 if (found != null)
                 {
                     found.Dependencia = reg.Dependencia;
 
          
                     return true;
                 }
                 else
                 {
                     byaRpt.Mensaje = "No se encontro La Dependencia";
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

             public dependencias found { get; set; }
             public dependencias reg { get; set; }
             protected internal override bool esValido()
             {
                 found = ctx.dependencias.Where(t => t.idDependencia == reg.idDependencia).FirstOrDefault();
                 if (found != null)
                 {
                     found.Estado = "AN";
                     return true;
                 }
                 else
                 {
                     byaRpt.Mensaje = "No se encontro La Dependencia";
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
