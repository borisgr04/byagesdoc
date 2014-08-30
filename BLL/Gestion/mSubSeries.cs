using AutoMapper;
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
             Mapper.CreateMap<subseries, subseriesDto>();
         }

         public List<subseriesDto> Gets()
         {
             List<subseriesDto> lstT = new List<subseriesDto>();
             using (ctx = new trdEntities())
          {
              List<subseries> lstO = ctx.subseries.ToList();
              Mapper.Map(lstO, lstT);
          }
          return lstT;
      }
         public List<subseriesDto> Gets(string serieId)
         {
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
          subseriesDto objT = new subseriesDto();
          using (ctx = new trdEntities())
          {
              subseries objO = ctx.subseries.Find(subserieId);
              Mapper.Map(objO, objT);
          }
          return objT;
      }
      
      
    }
}
