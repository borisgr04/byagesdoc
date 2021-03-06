﻿using AutoMapper;
using ByA;
using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Gestion
{
    public class mUnidadD_TipoDoc:absBLL
    {

        public mUnidadD_TipoDoc()
         {

             Mapper.CreateMap<UnidadD_TipoDocDto, unidadd_tipodoc>();
             Mapper.CreateMap<unidadd_tipodoc, UnidadD_TipoDocDto>().ForMember(dest => dest.NombreTipoDoc, opt => opt.MapFrom(src => src.tiposdocumentales.Nombe)); 
         }

        public ByARpt Insert(UnidadD_TipoDocDto Reg)
         {
             unidadd_tipodoc r = new unidadd_tipodoc();
             Mapper.Map(Reg, r);
             cmdInsert o = new cmdInsert { reg = r };
             return o.Enviar();
         }
        public ByARpt Update(UnidadD_TipoDocDto Reg)
         {
             unidadd_tipodoc r = new unidadd_tipodoc();
             Mapper.Map(Reg, r);
             cmdUpdate o = new cmdUpdate { reg = r };
             return o.Enviar();
         }
        public ByARpt Anular(UnidadD_TipoDocDto Reg)
         {
             unidadd_tipodoc r = new unidadd_tipodoc();
             Mapper.Map(Reg, r);
             cmdAnular o = new cmdAnular { reg = r };
             return o.Enviar();
         }

        public List<UnidadD_TipoDocDto> Gets(unidaddocumentalDto Reg)
         {
             List<UnidadD_TipoDocDto> lstT = new List<UnidadD_TipoDocDto>();
             using (ctx = new trdEntities())
          {
              List<unidadd_tipodoc> lstO = ctx.unidadd_tipodoc.Where(t=>t.IdUnidadDoc==Reg.idUnidadDocumental).ToList();
              Mapper.Map(lstO, lstT);
          }
          return lstT;
      }
        public UnidadD_TipoDocDto Get(string Id)
      {
          UnidadD_TipoDocDto objT = new UnidadD_TipoDocDto();
          using (ctx = new trdEntities())
          {
              unidadd_tipodoc objO = ctx.unidadd_tipodoc.Find(Id);
              Mapper.Map(objO, objT);
          }
          return objT;
      }

         class cmdInsert : absTemplate
         {

             public unidadd_tipodoc found { get; set; }
             public unidadd_tipodoc reg { get; set; }
             protected internal override bool esValido()
             {
                 return true;
             }
             protected internal override void Antes()
             {

                 ctx.unidadd_tipodoc.Add(reg);

             }


         }
         class cmdUpdate : absTemplate
         {

             public unidadd_tipodoc reg { get; set; }
             public unidadd_tipodoc found { get; set; }
             protected internal override bool esValido()
             {
                 found = ctx.unidadd_tipodoc.Where(t => t.IdTipoDoc == reg.IdTipoDoc && t.IdUnidadDoc==reg.IdUnidadDoc).FirstOrDefault();
                 if (found != null)
                 {
                     found.Codigo = reg.Codigo;
                     found.Descripcion = reg.Descripcion;
                     found.FechaDoc = reg.FechaDoc;
                     found.CantidadPag = reg.CantidadPag;
                     found.PagIni = reg.PagIni;                 
                   
                   
                
                     return true;
                 }
                 else
                 {
                     byaRpt.Mensaje = "No se encontro El TipoDocumental o la Unidad Documental";
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

             public unidadd_tipodoc found { get; set; }
             public unidadd_tipodoc reg { get; set; }
             protected internal override bool esValido()
             {
                 found = ctx.unidadd_tipodoc.Where(t => t.IdTipoDoc == reg.IdTipoDoc && t.IdUnidadDoc == reg.IdUnidadDoc).FirstOrDefault();
                 if (found != null)
                 {
                     //found.Estado = "AN";
                     return true;
                 }
                 else
                 {
                     byaRpt.Mensaje = "No se encontro El TipoDocumental o la Unidad Documental";
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
