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

         public List<unidaddocumentalDto> Gets(string Filtro)
         {

             List<unidaddocumentalDto> lstT = new List<unidaddocumentalDto>();
          using (ctx = new trdEntities())
          {
              if (Filtro != null)
              {
                  List<unidaddocumental> lstO = ctx.unidaddocumental.Where(t=>t.Nombre==Filtro ||
                                                  t.idUnidadDocumental==Filtro ||
                                                  t.PalabrasClave == Filtro ||
                                                  t.FechaCreacion.ToString() == Filtro ||
                                                  t.NroFolios.ToString() == Filtro ||
                                                  t.idSubSeries == Filtro ||
                                                  t.EntidadProductora.ToString() == Filtro ||
                                                  t.ArchivadorNo.ToString() == Filtro ||
                                                  t.GabetaNo.ToString() == Filtro ||
                                                  t.FechaExtInicial.ToString() == Filtro ||
                                                  t.FechaExtFinal.ToString() == Filtro ||
                                                  t.DependenciaId.ToString() == Filtro).ToList();

                  Mapper.Map(lstO, lstT);
              }
              else
              {

                  List<unidaddocumental> lstO = ctx.unidaddocumental.ToList();
                  Mapper.Map(lstO, lstT);

              }
              
          }
          return lstT;
      }

    }
}
