using BLL.Gestion;
using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class mGenerar : absBLL
    {

        mDocumentos DocManager = new mDocumentos();
        //public static unidaddocumentalDto filtro;
        public ArchivosDto DescargarZip(unidaddocumentalDto filtro)
       {
           
           mConfiguracion mc = new mConfiguracion();           
           mGenerarZip.Ruta_Zip = mc.Get("BandejaOK").Valor;
           List<ArchivosDto> list = new List<ArchivosDto>();
           using (ctx = new trdEntities())         
          {
              foreach (var item in DocManager.Gets(filtro))
           {
               foreach (var item2 in ctx.gdocumentos.Where(t => t.id == item.idUnidadDocumental).Select(t => t.gddocumentos).ToList())
               {
                   ArchivosDto p = new ArchivosDto();
                   p.NomArchivo = item2.gdocumentos.nombre;
                   p.SoporteB = item2.documento;
                   list.Add(p);
               } 
              
           }
          return  mGenerarZip.Generar_Zip_Byte(DateTime.Now.ToString(), list); 
           
                  
          }
          
       }
        public ArchivosDto GetByte(string Codigo)
        {
            return DocManager.GetByte(Codigo);
        }
    }
    
}
