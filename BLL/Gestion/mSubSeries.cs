using AutoMapper;
using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Gestion
{
  public  class mSubSeries
    {
         public trdEntities ctx { get; set; }

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
      
      //public ByARpt Insert(fc_tercerosDto Reg)
      //{
      //      cmdInsert o = new cmdInsert();
      //      o.oDto = Reg;
      //      return o.Enviar();
      //}

      //public ByARpt Update(fc_tercerosDto Reg)
      //  {
      //      cmdUpdate o = new cmdUpdate();
      //      o.oDto = Reg;
      //      return o.Enviar();
      //  }

      //class cmdInsert : absTemplate
      //  {
      //      public fc_tercerosDto oDto {get; set;}
      //      fc_terceros Dto{get; set;}

      //      #region ImplementaciónMetodosAbstractos
      //      protected internal override bool esValido()
      //      {
      //          fc_terceros objO = ctx.fc_terceros.Where( t=> t.terceroId==oDto.terceroId).FirstOrDefault();
      //          if (objO == null) return true;
      //          else {
      //              byaRpt.Mensaje = "Ya se encuentra el tercero con ese número de identificación";
      //              byaRpt.Error = true;
      //              return false;
      //          }
      //      }
      //      protected internal override void Antes()
      //      {
      //          Dto = new fc_terceros();
      //          Mapper.Map(oDto, Dto);
      //          ctx.fc_terceros.Add(Dto);
      //          byaRpt.id = Dto.terceroId.ToString();
      //      }
      //      #endregion
      //  }


      //class cmdUpdate: absTemplate
      //{
      //    public fc_tercerosDto oDto { get; set; }
      //    fc_terceros Dto { get; set; }

      //    #region ImplementaciónMetodosAbstractos
      //    protected internal override bool esValido()
      //    {
      //        Dto = ctx.fc_terceros.Find(oDto.terceroId);
      //        if (Dto != null) return true;
      //        else
      //        {
      //            byaRpt.Mensaje = "No se encuentra el tercero con ese número de identificación";
      //            byaRpt.Error = true;
      //            return false;
      //        }
      //    }

      //    protected internal override void Antes()
      //    {
      //        Dto.correo = oDto.correo;
      //        Dto.direccion = oDto.direccion;
      //        Dto.nombre = oDto.nombre;
      //        Dto.telefono = oDto.telefono;
      //        Dto.tipodoc = oDto.tipodoc;
      //        Dto.tipoper = oDto.tipoper;

      //        byaRpt.id = Dto.terceroId.ToString();
      //    }
      //    #endregion
      //}
    }
}
