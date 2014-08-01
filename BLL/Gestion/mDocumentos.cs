using AutoMapper;
using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Gestion
{
   public class mDocumentos
    {
        
         public trdEntities ctx { get; set; }

         public mDocumentos()
         {

             Mapper.CreateMap<unidaddocumentalDto, unidaddocumental>();
             Mapper.CreateMap<unidaddocumental, unidaddocumentalDto>();
         }

         public List<unidaddocumentalDto> Gets()
         {

             List<unidaddocumentalDto> lstT = new List<unidaddocumentalDto>();
          using (ctx = new trdEntities())
          {
              List<unidaddocumental> lstO = ctx.unidaddocumental.ToList();
              Mapper.Map(lstO, lstT);
          }
          return lstT;
      }

    }
}
