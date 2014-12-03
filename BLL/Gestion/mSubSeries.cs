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
  public  class mSubSeries:absBLL
    {
      

         public mSubSeries()
         {

             Mapper.CreateMap<subseriesDto, subseries>();
             Mapper.CreateMap<subseries, subseriesDto>().ForMember(dest => dest.Serie, opt => opt.MapFrom(src => src.series.Serie)); 
         }

         public ByARpt Insert(subseriesDto Reg)
         {
             subseries r = new subseries();
             Mapper.Map(Reg, r);
             cmdInsert o = new cmdInsert { reg = r };
             return o.Enviar();
         }
         public ByARpt Update(subseriesDto Reg)
         {
             subseries r = new subseries();
             Mapper.Map(Reg, r);
             cmdUpdate o = new cmdUpdate { reg = r };
             return o.Enviar();
         }
         public ByARpt Anular(subseriesDto Reg)
         {
             subseries r = new subseries();
             Mapper.Map(Reg, r);
             cmdAnular o = new cmdAnular { reg = r };
             return o.Enviar();
         }

         public List<subseriesDto> Gets()
         {
             List<subseriesDto> lstT = new List<subseriesDto>();
             using (ctx = new trdEntities())
          {
              List<subseries> lstO = ctx.subseries.Where(t=>t.Estado!="AN").ToList();
              Mapper.Map(lstO, lstT);
          }
          return lstT;
      }
         public List<subseriesDto> Gets(string serieId)
         {
             if (serieId.Length == 1)
             {
                 serieId = serieId.PadLeft(2, '0');
             }
             List<subseriesDto> lstT = new List<subseriesDto>();
             using (ctx = new trdEntities())
             {
                 List<subseries> lstO = ctx.subseries.Where(t=>t.Series_idSerie== serieId ) .ToList();
                 Mapper.Map(lstO, lstT);
             }
             return lstT;
         }
         public subseriesDto Get(string subserieId)
      {

          if (subserieId.Length >= 3)
          {
              subserieId = subserieId.PadLeft(subserieId.Length+1, '0');
          }
          subseriesDto objT = new subseriesDto();
          using (ctx = new trdEntities())
          {
              subseries objO = ctx.subseries.Find(subserieId);
              Mapper.Map(objO, objT);
          }
          return objT;
      }

         class cmdInsert : absTemplate
         {

             public subseries found { get; set; }
             public subseries reg { get; set; }
             protected internal override bool esValido()
             {
                 return true;
             }
             protected internal override void Antes()
             {
                 reg.Estado = "AC";
                 ctx.subseries.Add(reg);

             }


         }
         class cmdUpdate : absTemplate
         {

             public subseries reg { get; set; }
             public subseries found { get; set; }
             protected internal override bool esValido()
             {
                 found = ctx.subseries.Where(t => t.idSubSeries == reg.idSubSeries).FirstOrDefault();
                 if (found != null)
                 {
                     found.SubSerie = reg.SubSerie;
                     found.RetencionAG = reg.RetencionAG;
                     found.RetencionAC = reg.RetencionAC;
                     found.DisposicionCT = reg.DisposicionCT;
                     found.DisposicionE = reg.DisposicionE;
                     found.DisposicionMD = reg.DisposicionMD;
                     found.DisposicionS = reg.DisposicionS;
                     found.Series_idSerie = reg.Series_idSerie;
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

             public subseries found { get; set; }
             public subseries reg { get; set; }
             protected internal override bool esValido()
             {
                  found = ctx.subseries.Where(t => t.idSubSeries == reg.idSubSeries).FirstOrDefault();
                 if (found != null)
                 {
                     found.Estado = "AN";
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
      
    }
}
