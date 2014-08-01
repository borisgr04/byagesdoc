using AutoMapper;
using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Gestion
{
  public  class mSeries
    {
         public trdEntities ctx { get; set; }

         public mSeries()
         {

             Mapper.CreateMap<seriesDto, series>();
             Mapper.CreateMap<series, seriesDto>();
         }

         public List<seriesDto> Gets()
         {

          List<seriesDto> lstT = new List<seriesDto>();
          using (ctx = new trdEntities())
          {
              List<series> lstO = ctx.series.ToList();
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
