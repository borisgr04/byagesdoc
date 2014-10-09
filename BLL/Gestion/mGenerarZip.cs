using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using Ionic.Zip;
using Entidades;

namespace BLL.Gestion
{
    public class mGenerarZip
    {
        public static string Ruta_Zip {get; set;}
        
        private static bool lErrorG;

        public static string Msg;
        public static ArchivosDto Generar_Zip_Byte(string Nom_Zip, List<ArchivosDto> lstArc)
        {
            byte[] ByteZip = {
			
		};
            ArchivosDto rArc = new ArchivosDto();
            rArc.NomArchivo = Nom_Zip + ".zip";
            rArc.Content = "APPLICATION/ZIP";
            try
            {
                string RutaC = Ruta_Zip + Nom_Zip + ".zip";
               // string vRutaC = Ruta_Zip + Nom_Zip + ".zip";
                if (File.Exists(RutaC))
                {
                    File.Delete(RutaC);
                }
                ZipFile zip = new ZipFile();
                int i = 0;
                foreach (var rg in lstArc)
                {                                     
                    i += 1;
                    zip.AddEntry(i.ToString() + "-" + rg.NomArchivo, rg.SoporteB);
                }
                zip.Comment = "Export De la base de datos GESDOC";
                MemoryStream ms = new MemoryStream();
                zip.Save(ms);
                rArc.SoporteB = ms.ToArray();
                lErrorG = false;
                if (File.Exists(RutaC))
                {
                    File.Delete(RutaC);
                }
                Msg = "Se Generó El Paquete Comprimido (*.Zip)";
                // <br> <a href='" + vRutaC + "'  > Click Para Descargar</a> Generado a las: " + Now.ToString
                return rArc;
                //Se elimina despues de Creado


            }
            catch (Ionic.Zip.ZipException ex)
            {
                Msg = "zip:" + ex.Message;

                lErrorG = true;
            }
            catch (Exception ex)
            {
                Msg = "Ex:" + ex.Message;

                lErrorG = true;

            }
            finally
            {
            }

            return rArc;
        }

    }
}
