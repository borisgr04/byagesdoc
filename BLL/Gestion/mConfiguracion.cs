using AutoMapper;
using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Gestion
{
   public class mConfiguracion
    {
        
         public trdEntities ctx { get; set; }

         public mConfiguracion()
         {

             Mapper.CreateMap<configuracionDto, configuracion>();
             Mapper.CreateMap<configuracion, configuracionDto>();
         }

         public List<configuracionDto> Gets()
         {

             List<configuracionDto> lstT = new List<configuracionDto>();
          using (ctx = new trdEntities())
          {
              List<configuracion> lstO = ctx.configuracion.ToList();
              Mapper.Map(lstO, lstT);
          }
          return lstT;
      }

         public configuracionDto Get(string Clave)
         {
          configuracionDto T = new configuracionDto();
          using (ctx = new trdEntities())
          {
              configuracion O = ctx.configuracion.Where(t => t.Clave == Clave).Single();
              Mapper.Map(O, T);
          }
          return T;
      }

    }
}
