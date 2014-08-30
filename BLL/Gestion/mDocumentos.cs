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
   public class mDocumentos:absBLL
    {        
       

         public mDocumentos()
         {

             Mapper.CreateMap<unidaddocumentalDto, unidaddocumental>();
             Mapper.CreateMap<unidaddocumental, unidaddocumentalDto>();
         }
         public ByARpt Insert(unidaddocumentalDto Reg)
         {
             unidaddocumental r = new unidaddocumental();
             Mapper.Map(Reg, r);
             cmdInsert o = new cmdInsert { reg = r };
             return o.Enviar();
         }
         public unidaddocumentalDto Get(string Codigo)
         {

             unidaddocumentalDto objT = new unidaddocumentalDto();
             using (ctx = new trdEntities())
             {
                 unidaddocumental objO = ctx.unidaddocumental.Find(Codigo);
                 Mapper.Map(objO, objT);

             }
             return objT;
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


         class cmdInsert : absTemplate
         {

            
             public unidaddocumental reg { get; set; }
             protected internal override bool esValido()
             {
                 reg.idUnidadDocumental = ctx.unidaddocumental.Select(t => t.idUnidadDocumental).Max() + 1;
                 return true;
             }
             protected internal override void Antes()
             {

                 ctx.unidaddocumental.Add(reg);

             }


         }
    }
}
