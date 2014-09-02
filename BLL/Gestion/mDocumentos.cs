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
         public ByARpt Update(unidaddocumentalDto Reg)
         {
             unidaddocumental r = new unidaddocumental();
             Mapper.Map(Reg, r);
             cmdUpdate o = new cmdUpdate { reg = r };
             return o.Enviar();
         }
         public ByARpt Anular(unidaddocumentalDto Reg)
         {
             unidaddocumental r = new unidaddocumental();
             Mapper.Map(Reg, r);
             cmdAnular o = new cmdAnular { reg = r };
             return o.Enviar();
         }
         public unidaddocumentalDto Get(unidaddocumentalDto Reg)
         {

             unidaddocumentalDto objT = new unidaddocumentalDto();
             using (ctx = new trdEntities())
             {
                 unidaddocumental objO = ctx.unidaddocumental.Where(t=>t.Codigo==Reg.Codigo).FirstOrDefault();
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
                                                  t.DependenciaId.ToString() == Filtro &&
                                                  t.Estado!="AN").ToList();

                  Mapper.Map(lstO, lstT);
              }
              else
              {

                  List<unidaddocumental> lstO = ctx.unidaddocumental.Where(t=>t.Estado!="AN").ToList();
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
                 reg.idUnidadDocumental =Convert.ToString(Convert.ToInt32(ctx.unidaddocumental.Select(t => t.idUnidadDocumental).Max()) + 1);
                 return true;
             }
             protected internal override void Antes()
             {

                 ctx.unidaddocumental.Add(reg);

             }


         }
         class cmdUpdate : absTemplate
         {
             public unidaddocumental reg { get; set; }
             public unidaddocumental found { get; set; }
             protected internal override bool esValido()
             {
                 found = ctx.unidaddocumental.Where(t => t.Codigo == reg.Codigo).FirstOrDefault();
                 if (found != null)
                 {
                     found.Nombre = reg.Nombre;
                     found.PalabrasClave = reg.PalabrasClave;
                     found.FechaCreacion = reg.FechaCreacion;
                     found.NroFolios = reg.NroFolios;
                     found.EntidadProductora = reg.EntidadProductora;
                     found.ArchivadorNo = reg.ArchivadorNo;
                     found.GabetaNo = reg.GabetaNo;
                     found.ArchivadorNo = reg.ArchivadorNo;
                     found.GabetaNo = reg.GabetaNo;
                     found.FechaExtInicial = reg.FechaExtInicial;
                     found.FechaExtFinal = reg.FechaExtFinal;
                     return true;
                 }
                 else
                 {
                     byaRpt.Mensaje = "No se encontro el Documento";
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

             public unidaddocumental found { get; set; }
             public unidaddocumental reg { get; set; }
             protected internal override bool esValido()
             {
                 found = ctx.unidaddocumental.Where(t => t.Codigo == reg.Codigo).FirstOrDefault();
                 if (found != null)
                 {
                     found.Estado = "AN";
                     return true;
                 }
                 else
                 {
                     byaRpt.Mensaje = "No se encontro el Documento";
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
