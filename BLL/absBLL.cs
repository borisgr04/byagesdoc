using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using ByA;
using DAL;

namespace BLL
{
   public abstract class absBLL
    {
       public trdEntities ctx { get; set; }
    public ByARpt byaRpt { get; set; }

    #region UPDATE
       ///// <summary>
       ///// Debe Sobre SobreEscrir el metodo AntesUpdate
       ///// </summary>
       //protected ByARpt EnviarUpdate()
       //{
       //    byaRpt = new ByARpt();

       //    using (ctx = new Entities())
       //    {
       //        if (!esValidoUpdate())
       //        {
       //            return byaRpt;
       //        }
       //        try
       //        {
       //            AntesUpdate();
       //            SaveChange();
       //            DespuesUpdate();
       //        }
       //        catch (System.Data.Entity.Validation.DbEntityValidationException ex)
       //        {
       //            ByAExcep.AdminException(byaRpt, ex);
       //        }
       //        catch (Exception ex)
       //        {
       //            ByAExcep.AdminException(byaRpt, ex);

       //        }
       //        return byaRpt;

       //    }
       //}
       /// <summary>
       /// Especifica, 
       /// byaRpt.Mensaje = "Se Actualizó el Registro";
       /// Puede SobreEscribirlo
       /// </summary>
       protected internal virtual void DespuesUpdate() {
           byaRpt.Mensaje = "Se Actualizó el Registro";
       }
       /// <summary>
       /// Debe Especificar el o los objetos a actualizar, 
       /// Debe Sobre SobreEscribirlo
       /// </summary>
       protected internal virtual void AntesUpdate() {
           throw new NotImplementedException();
       }

       protected internal virtual bool esValidoUpdate(){
           byaRpt.Mensaje = "VALIDADÓ UPDATE";
           byaRpt.Error = true;
           return byaRpt.Error;
       }

       #endregion
        
    #region DELETE
       //protected ByARpt EnviarDelete()
       //{
       //    byaRpt = new ByARpt();
       //    using (ctx = new Entities())
       //    {
       //        if (!esValidoDelete())
       //        {
       //            return byaRpt;
       //        }
       //        try
       //        {
       //            AntesDelete();
       //            SaveChange();
       //            DespuesDelete();
       //        }
       //        catch (System.Data.Entity.Validation.DbEntityValidationException ex)
       //        {
       //            ByAExcep.AdminException(byaRpt, ex);
       //        }
       //        catch (Exception ex)
       //        {
       //            ByAExcep.AdminException(byaRpt, ex);

       //        }
       //        return byaRpt;

       //    }
       //}
       
       //Puede SobreEscribirla
       protected internal virtual void DespuesDelete() {
           byaRpt.Mensaje = "Se Eliminó el Registro";
       }
       //Debe SobreEscribirla
       protected internal virtual void AntesDelete() {
           throw new NotImplementedException("Implemente: AntesDelete");
       }

       //Debe SobreEscribirla
       protected internal virtual bool esValidoDelete() {
           byaRpt.Mensaje = "VALIDADÓ";
           byaRpt.Error = true;
           return byaRpt.Error;
           
       }

#endregion

    #region INSERT
       /// <summary>
       /// 1. esValidoInsert()
       /// 2. AntesInsert(); //Especificar El objeto a Enviar
       /// 3. SaveChange(); no se deberia implementar
       //  4. DespuesInsert(); // Proceso Despues de implementar
       /// </summary>
       /// <returns></returns>
       //protected ByARpt EnviarInsert()
       //{
       //    byaRpt = new ByARpt();
       //    using (ctx = new Entities())
       //    {
       //        if (!esValidoInsert())
       //        {
       //            return byaRpt;
       //        }
       //        try
       //        {
       //            AntesInsert();
       //            SaveChange();
       //            DespuesInsert();
       //        }
       //        catch (System.Data.Entity.Validation.DbEntityValidationException ex)
       //        {
       //            ByAExcep.AdminException(byaRpt, ex);
       //        }
       //        catch (Exception ex)
       //        {
       //            ByAExcep.AdminException(byaRpt, ex);

       //        }
       //        return byaRpt;

       //    }
       //}

       protected internal virtual void DespuesInsert() {
           byaRpt.Mensaje = "Se Agregó el Registro";
       }

       protected  internal virtual void AntesInsert() {
           throw new NotImplementedException("Implemente: AntesInsert");
       }

       protected internal virtual bool esValidoInsert() {
           byaRpt.Mensaje = "VALIDADÓ INSERT"  ;
           byaRpt.Error = true;
           return byaRpt.Error;
       }

#endregion

    protected internal virtual void SaveChange()
       {
           byaRpt.Filas = ctx.SaveChanges();
           byaRpt.Error = false;
       }
    
    }
}
