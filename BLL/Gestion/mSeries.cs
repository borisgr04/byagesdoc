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
  public  class mSeries:absBLL
    {
       

         public mSeries()
         {

             Mapper.CreateMap<seriesDto, series>();
             Mapper.CreateMap<series, seriesDto>();
         }
         public ByARpt Insert(seriesDto Reg)
         {
             series r = new series();
             Mapper.Map(Reg, r);
             cmdInsert o = new cmdInsert { reg = r };
             return o.Enviar();
         }
         public ByARpt Update(seriesDto Reg)
         {
             series r = new series();
             Mapper.Map(Reg, r);
             cmdUpdate o = new cmdUpdate { reg = r };
             return o.Enviar();
         }
         public ByARpt Anular(seriesDto Reg)
         {
             series r = new series();
             Mapper.Map(Reg, r);
             cmdAnular o = new cmdAnular { reg = r };
             return o.Enviar();
         }

         public List<seriesDto> Gets()
         {

          List<seriesDto> lstT = new List<seriesDto>();
          using (ctx = new trdEntities())
          {
              List<series> lstO = ctx.series.Where(t=>t.Estado!="AN").ToList();
              Mapper.Map(lstO, lstT);
          }
          return lstT;
      }
         public seriesDto Gets(string terceroId)
      {
          seriesDto objT = new seriesDto();
          using (ctx = new trdEntities())
          {
              series objO = ctx.series.Find(terceroId);
              Mapper.Map(objO, objT);
          }
          return objT;
      }




          class cmdInsert : absTemplate
          {
         
             public series found { get; set; }
             public series reg { get; set; }
             protected internal override bool esValido()
             {
                 return true;
             }
             protected internal override void Antes()
             {
                 reg.Estado = "AC";
                 ctx.series.Add(reg);
                
             }


         }
          class cmdUpdate : absTemplate
          {

              public series found { get; set; }
              public series reg { get; set; }
              protected internal override bool esValido()
              {
                  found = ctx.series.Where(t => t.idSerie == reg.idSerie).FirstOrDefault();
                  if (found != null)
                  {
                      found.Serie = reg.Serie;
                      found.Procedimiento = reg.Procedimiento;
                   
                      return true;
                  }
                  else
                  {
                      byaRpt.Mensaje = "No se encontro La SubSerie";
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

              public series found { get; set; }
              public series reg { get; set; }
              protected internal override bool esValido()
              {
                  found = ctx.series.Where(t => t.idSerie == reg.idSerie).FirstOrDefault();
                  if (found != null)
                  {
                      found.Estado = "AN";
                      return true;
                  }
                  else
                  {
                      byaRpt.Mensaje = "No se encontro La Serie";
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
