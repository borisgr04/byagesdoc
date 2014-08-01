using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByA;
using Entidades;
using AutoMapper;
using System.Data;
using System.Data.Entity;


namespace BLL
{
   public class mTerceros
    {
        public mTerceros(){
            Mapper.CreateMap<vTerceros, TERCEROS>();
        }

        //public vTerceros GetTercerobyId(string Ideter) {
           
        //   using (ctx = new Entities())
        //   {
        //       vTerceros ter = (from t in ctx.TERCEROS
        //                        where t.IDE_TER.Equals(Ideter)
        //                        select (new vTerceros
        //                        {
                                    
        //                            TIP_IDE=t.TIP_IDE,
        //                            IDE_TER = t.IDE_TER,
        //                            EXP_IDE=t.EXP_IDE,
        //                            DV_TER = t.DV_TER,
        //                            APE1_TER = t.APE1_TER,
        //                            APE2_TER = t.APE2_TER,
        //                            NOM1_TER = t.NOM1_TER,
        //                            NOM2_TER = t.NOM2_TER,
        //                            RAZ_SOC=t.RAZ_SOC,
        //                            //FEC_NAC = t.FEC_NAC,
        //                            DIR_TER=t.DIR_TER,
        //                            TEL_TER=t.TEL_TER,
        //                            EMA_TER=t.EMA_TER,
        //                            CAR_FUN=t.CAR_FUN,
        //                            DEP_NEC=t.DEP_NEC,
        //                            ESTADO=t.ESTADO,
        //                            TIPO=t.TIPO,
        //                            FEC_NAC=t.FEC_NAC,
        //                            FEC_REG=t.FEC_REG,
        //                            FEC_MOD = t.FEC_MOD,
        //                            TIP_PER=t.TIP_PER
        //                            //OBS_TER=t.OBS_TER,
                                   
                                    
        //                           // CLAS_TER=t.CLAS_TER
                                                                    
        //                        })).FirstOrDefault();
        //       return ter;
        //   }
           
        //}


       public ByARpt Insert(vTerceros Reg)
       {
           cmdInsert o = new cmdInsert();
           o.reg = Reg;
           return o.Enviar();
       }

       public ByARpt Update(vTerceros Reg)
       {
           cmdUpdate o = new cmdUpdate();
           o.reg = Reg;
           return o.Enviar();
       }
    }

   class cmdInsert : absTemplate
   {
       public vTerceros reg { get; set; }
       TERCEROS ter { get; set; }

       protected internal override bool esValido()
       {
           return true;
       }

       protected internal override void Antes()
       {
           ter = new TERCEROS();
           Mapper.Map(reg, ter);
           byaRpt.id = reg.IDE_TER;
           //ctx.TERCEROS.Add(r);
           ctx.Entry(ter).State = EntityState.Added;
       }
       //protected override void DespuesInsert();

   }


   class cmdUpdate : absTemplate
   {
       public vTerceros reg { get; set; }
       TERCEROS ter { get; set; }

       protected internal override bool esValido()
       {
            ter = ctx.TERCEROS.Where(t => t.IDE_TER==reg.IDE_TER).FirstOrDefault();
            if (ter != null)
            {
                return true;
            }
            else {
                byaRpt.Mensaje = "No se encontró el tercero";
                byaRpt.Error = true;
                return false;
            }
       }

       protected internal override void Antes()
       {
          
           ter.APE1_TER = reg.APE1_TER;
           ter.APE2_TER = reg.APE2_TER;
           ter.NOM1_TER = ter.NOM1_TER;
           ter.NOM2_TER = ter.NOM2_TER;
           ter.TIP_IDE = reg.TIP_IDE;
           ter.CAR_FUN = reg.CAR_FUN;
           ter.DEP_NEC = reg.DEP_NEC;
           ter.DIR_TER = reg.DIR_TER;
           ter.TEL_TER = reg.TEL_TER;
           ter.EMA_TER = reg.EMA_TER;
           ter.RAZ_SOC = ter.RAZ_SOC;
           ter.TIPO = reg.TIPO;
           ter.DV_TER = reg.DV_TER;
           ter.EXP_IDE = reg.EXP_IDE;
           ter.ESTADO = reg.ESTADO;
           //ter.fec_mod = DateTime.Now;
           //ter.fec_reg=
           byaRpt.id = reg.IDE_TER;
           //ctx.TERCEROS.Add(r);
           ctx.Entry(ter).State = EntityState.Modified;

       }
       //protected override void DespuesInsert();

   }
   class cmdDelete : absTemplate
   {
       public vTerceros reg { get; set; }
       TERCEROS ter { get; set; }

       protected internal override bool esValido()
       {
           ter = ctx.TERCEROS.Where(t => t.IDE_TER == reg.IDE_TER).FirstOrDefault();
           if (ter != null)
           {
               return true;
           }
           else
           {
               byaRpt.Mensaje = "No se encontró el tercero";
               byaRpt.Error = true;
               return false;
           }
       }

       protected internal override void Antes()
       {

          

           byaRpt.id = reg.IDE_TER;
           //ctx.TERCEROS.Add(r);
           ctx.Entry(ter).State = EntityState.Deleted;

       }
       //protected override void DespuesInsert();

   }
}
