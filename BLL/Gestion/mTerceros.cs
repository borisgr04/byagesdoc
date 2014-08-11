using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ByA;
using DAL;
using Entidades;

namespace BLL.Gestion
{
  public  class mTerceros
    {
      public trdEntities ctx { get; set; }

      public mTerceros() {
          Mapper.CreateMap<fc_tercerosDto, fc_terceros>();
          Mapper.CreateMap<fc_terceros, fc_tercerosDto>();
      }

      public List<fc_tercerosDto> Gets() {
          
          List<fc_tercerosDto> lstT= new List<fc_tercerosDto>();
          using (ctx = new trdEntities())
          {
              List<fc_terceros> lstO = ctx.fc_terceros.ToList();
              Mapper.Map(lstO, lstT);
          }
          return lstT;
      }

      public fc_tercerosDto Gets(string terceroId)
      {
          fc_tercerosDto objT = new fc_tercerosDto();
          using (ctx = new trdEntities())
          {
              fc_terceros objO = ctx.fc_terceros.Find(terceroId);
              Mapper.Map(objO, objT);
          }
          return objT;
      }
      
      public ByARpt Insert(fc_tercerosDto Reg)
      {
            cmdInsert o = new cmdInsert();
            o.oDto = Reg;
            return o.Enviar();
      }

      public ByARpt Update(fc_tercerosDto Reg)
        {
            cmdUpdate o = new cmdUpdate();
            o.oDto = Reg;
            return o.Enviar();
        }

      class cmdInsert : absTemplate
        {
            public fc_tercerosDto oDto {get; set;}
            fc_terceros Dto{get; set;}

            #region ImplementaciónMetodosAbstractos
            protected internal override bool esValido()
            {
                fc_terceros objO = ctx.fc_terceros.Where( t=> t.terceroId==oDto.terceroId).FirstOrDefault();
                if (objO == null) return true;
                else {
                    byaRpt.Mensaje = "Ya se encuentra el tercero con ese número de identificación";
                    byaRpt.Error = true;
                    byaRpt.id = oDto.terceroId;
                    return false;
                }
            }
            protected internal override void Antes()
            {
                Dto = new fc_terceros();
                Mapper.Map(oDto, Dto);
                ctx.fc_terceros.Add(Dto);
                byaRpt.id = Dto.terceroId.ToString();
            }
            #endregion
        }


      class cmdUpdate: absTemplate
      {
          public fc_tercerosDto oDto { get; set; }
          fc_terceros Dto { get; set; }

          #region ImplementaciónMetodosAbstractos
          protected internal override bool esValido()
          {
              Dto = ctx.fc_terceros.Find(oDto.terceroId);
              if (Dto != null) return true;
              else
              {
                  byaRpt.Mensaje = "No se encuentra el tercero con ese número de identificación";
                  byaRpt.Error = true;
                  return false;
              }
          }

          protected internal override void Antes()
          {
              Dto.correo = oDto.correo;
              Dto.direccion = oDto.direccion;
              Dto.nombre = oDto.nombre;
              Dto.telefono = oDto.telefono;
              Dto.tipodoc = oDto.tipodoc;
              Dto.tipoper = oDto.tipoper;
              Dto.lugarexpe = oDto.lugarexpe;

              byaRpt.id = Dto.terceroId.ToString();
          }
          #endregion
      }

    }

    


}
