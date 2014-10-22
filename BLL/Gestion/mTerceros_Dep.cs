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
    public class mTerceros_Dep:absBLL
    {

        public mTerceros_Dep()
         {

             Mapper.CreateMap<terceros_depDto, terceros_dep>();
             Mapper.CreateMap<terceros_dep, terceros_depDto>();
         }

        public ByARpt Insert(List<terceros_depDto> Reg)
        {

            List<terceros_dep> r = new List<terceros_dep>();
            Mapper.Map(Reg, r);
            cmdInsert o = new cmdInsert { reg = r };
            return o.Enviar();
        }
        public ByARpt Update(List<terceros_depDto> Reg)
         {
             List<terceros_dep> r = new List<terceros_dep>();
             Mapper.Map(Reg, r);
             cmdUpdate o = new cmdUpdate { reg = r };
             return o.Enviar();
         }
        public List<string> Gets(string terceroId)
      {
          List<string> objT = new List<string>();
          using (ctx = new trdEntities())
          {
              objT = ctx.terceros_dep.Where(t => t.IdTerceros == terceroId).Select(t => t.IdDependencias).ToList();
            
          }
          return objT;
      }
        class cmdInsert : absTemplate{


            public List<terceros_dep> reg { get; set; }
             protected internal override bool esValido()
             {
                 return true;
             }
             protected internal override void Antes()
             {

                 foreach (var r in reg) {
                     r.Estado = "AC";
                     ctx.terceros_dep.Add(r);
                 }
                 
                
             }


         }
        class cmdUpdate : absTemplate
          {

              public List<terceros_dep> found { get; set; }
              public List<terceros_dep> reg { get; set; }
              protected internal override bool esValido()
              {
                string Tercero=reg.Select(t=>t.IdTerceros).FirstOrDefault();

                found = ctx.terceros_dep.Where(t => t.IdTerceros == Tercero).ToList();
                 
                  if (found != null)
                  {
                      return true;
                  }
                  else
                  {
                      byaRpt.Mensaje = "No se encontro El Tercero";
                      byaRpt.Error = true;
                      return !byaRpt.Error;
                  }


              }
              protected internal override void Antes()
              {

                  foreach (var item in found)
                  {
                      ctx.terceros_dep.Remove(item);         
                  }
                  foreach (var r in reg)
                  {
                      if (r.IdDependencias != null)
                      {

                          r.Estado = "AC";
                          ctx.terceros_dep.Add(r);
                      }
                  }
                  
                 
              }


          }


    }
}
