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
             Mapper.CreateMap<unidaddocumental, unidaddocumentalDto>()
                 .ForMember(dest => dest.Nombre_Sub, opt => opt.MapFrom(src => src.subseries.SubSerie))
                 .ForMember(dest => dest.Nombre_Dep, opt => opt.MapFrom(src => src.dependencias.Dependencia))
                 .ForMember(dest => dest.Nombre_Serie, opt => opt.MapFrom(src => src.subseries.series.Serie))
                 .ForMember(dest => dest.idSeries, opt => opt.MapFrom(src => src.subseries.series.idSerie));

         }
         public ByARpt Insert(unidaddocumentalDto Reg)
         {
             unidaddocumental r = new unidaddocumental();
             Mapper.Map(Reg, r);
             cmdInsert o = new cmdInsert { reg = r };
             return o.Enviar();
         }
         public ByARpt Insert(List<unidaddocumentalDto> Reg)
         {
             List<unidaddocumental> r = new List<unidaddocumental>();
             Mapper.Map(Reg, r);
             cmdInsertList o = new cmdInsertList { ListReg = r };
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
         public unidaddocumentalDto Get(string  Codigo)
         {

             unidaddocumentalDto objT = new unidaddocumentalDto();
             using (ctx = new trdEntities())
             {
                 unidaddocumental objO = ctx.unidaddocumental.Where(t=>t.Codigo==Codigo).FirstOrDefault();
                 Mapper.Map(objO, objT);

             }
             return objT;
         }
         public unidaddocumentalDto GetID(string id)
         {

             unidaddocumentalDto objT = new unidaddocumentalDto();
             using (ctx = new trdEntities())
             {
                 unidaddocumental objO = ctx.unidaddocumental.Where(t => t.idUnidadDocumental == id).FirstOrDefault();
                 Mapper.Map(objO, objT);

             }
             return objT;
         }
         public List<unidaddocumentalDto> Gets(unidaddocumentalDto Filtro)
         {

          List<unidaddocumentalDto> lstT = new List<unidaddocumentalDto>();
          using (ctx = new trdEntities())         
          {
              
              
              string cFiltro = " Where Estado!='AN' ";
              if (Filtro != null)
              {
                  cFiltro += AddFiltro("idSubSeries", Filtro.idSubSeries);
                  cFiltro += AddFiltro("DependenciaId", Filtro.DependenciaId);
                  cFiltro += AddFiltro("NroFolioInicial", Filtro.NroFolioInicial);
                  cFiltro += AddFiltro("NroFolioFinal", Filtro.NroFolioFinal);
                  cFiltro += AddFiltro("GabetaNo", Filtro.GabetaNo);                
                  cFiltro += AddFiltro("ArchivadorNo", Filtro.ArchivadorNo);
                  cFiltro += AddFiltro("EntidadProductora", Filtro.EntidadProductora);
                  cFiltro += AddFiltro("Estante", Filtro.Estante);
                  cFiltro += AddFiltro("Frecuencia", Filtro.Frecuencia);
                  cFiltro += AddFiltro("Vigencia", Filtro.Vigencia);
                  cFiltro += AddFiltro("SoporteFisico", Filtro.SoporteFisico);
                  cFiltro += AddFiltro("SoporteDigital", Filtro.SoporteDigital);
                  if ((Filtro.FechaCreacion.HasValue) && (Filtro.FechaCreacion2.HasValue))
                  {
                      cFiltro += AddFiltro("FechaCreacion", Filtro.FechaCreacion.Value, Filtro.FechaCreacion2.Value);
                  }
                  if ((Filtro.FechaExtInicial.HasValue) && (Filtro.FechaExtInicial2.HasValue))
                  {
                      cFiltro += AddFiltro("FechaExtInicial", Filtro.FechaExtInicial.Value, Filtro.FechaExtInicial2.Value);
                  }
                  if ((Filtro.FechaExtFinal.HasValue) && (Filtro.FechaExtFinal2.HasValue))
                  {
                      cFiltro += AddFiltro("FechaExtFinal", Filtro.FechaExtFinal.Value, Filtro.FechaExtFinal2.Value);
                  }

             
              }             
                  
                      string Sql = "SELECT * FROM unidaddocumental " + cFiltro;
                      List<unidaddocumental> lstO = ctx.unidaddocumental.SqlQuery(Sql).ToList();
                     // List<unidaddocumental> lstO = ctx.unidaddocumental.Where(t => t.Estado != "AN").ToList();
                      Mapper.Map(lstO, lstT);                 
                  
             
             
          }
          return lstT;
      }



        
         private static string AddFiltro(string Campo, string Value)
         {
             string cFiltro="";
             if (!String.IsNullOrEmpty(Value))
             {
                 cFiltro = String.Format(" And {0} = {1}", Campo, Value);
             }
             return cFiltro;
         }
         private static string AddFiltro(string Campo, int? Value)
         {
             string cFiltro = "";
             if (Value !=null)
             {
                 cFiltro = String.Format(" And {0}  = {1}", Campo, Value);
             }
             return cFiltro;
         }
         private  string AddFiltro(string Campo, DateTime Value,DateTime Value2)
         {
             string cFiltro = "";
             if (Value != null)       
             {
            
                
                 cFiltro = String.Format(" And {0} >= {1} And {0} <= {2} ", Campo, "'"+Value.Year+"-"+Value.Month+"-"+Value.Day+"'","'"+Value2.Year+"-"+Value2.Month+"-"+Value2.Day+"'");
             }
             return cFiltro;
         }


         class cmdInsert : absTemplate
         {

            
             public unidaddocumental reg { get; set; }
             protected internal override bool esValido()
             {
                 reg.idUnidadDocumental =Convert.ToString(Convert.ToInt32(ctx.unidaddocumental.Select(t => t.idUnidadDocumental).Count()) + 1);
                 return true;
             }
             protected internal override void Antes()
             {
                 reg.Codigo = reg.Codigo + "." + reg.idUnidadDocumental;
                 reg.Estado = "AC";
                 ctx.unidaddocumental.Add(reg);

             }


         }
         class cmdInsertList : absTemplate
         {


             public List<unidaddocumental> ListReg { get; set; }
             public int ContadorId;
             protected internal override bool esValido()
             {

                 return true;
             }
             protected internal override void Antes()
             {
                 ContadorId = Convert.ToInt32(ctx.unidaddocumental.Select(t => t.idUnidadDocumental).Count());
                 foreach (var item in ListReg)
                 {
                     ContadorId = ContadorId + 1;
                     item.idUnidadDocumental = ContadorId.ToString();                     
                     item.Estado = "AC";
                     item.Codigo = item.Codigo + "." + ContadorId;
                     ctx.unidaddocumental.Add(item);
                     
                 }

              
                

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
                     found.NroFolioInicial = reg.NroFolioInicial;
                     found.NroFolioFinal = reg.NroFolioFinal;
                     found.EntidadProductora = reg.EntidadProductora;
                     found.ArchivadorNo = reg.ArchivadorNo;
                     found.GabetaNo = reg.GabetaNo;
                     found.ArchivadorNo = reg.ArchivadorNo;
                     found.GabetaNo = reg.GabetaNo;
                     found.FechaExtInicial = reg.FechaExtInicial;
                     found.FechaExtFinal = reg.FechaExtFinal;
                     found.Tema = reg.Tema;
                     found.Vigencia = reg.Vigencia;
                     found.SoporteFisico = reg.SoporteFisico;
                     found.SoporteDigital = reg.SoporteDigital;
                     found.Frecuencia = reg.Frecuencia;
                     found.Identificacion = reg.Identificacion;
                     found.Estante = reg.Estante;
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
