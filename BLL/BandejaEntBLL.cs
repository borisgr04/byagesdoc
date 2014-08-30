using BLL.Gestion;
using BLL.IO;
using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BLL
{
    public  class BandejaEntBLL
    {
        public string sourcePath { get; set; }
        public string targetPath { get; set; }

        Directorios d;

        public BandejaEntBLL(string sourcePath, string targetPath)
        { 
            this.sourcePath=sourcePath;
            this.targetPath=targetPath;
            d = new Directorios(sourcePath, targetPath);
        }
        

        public void MoverArchivos(List<BandejaEntrada> lBE)
        {
            
            mGDocumentos m = new mGDocumentos();
            gdocumentosDto dto; 

            foreach (BandejaEntrada be in lBE)
            {
                if (Validar(be))
                {
                    // Use Path class to manipulate file and directory paths.
                    dto = new gdocumentosDto();
                    dto.estado = "SA";
                    //dto.idGDocumentos
                    dto.tipo =d.GetExtension(be);
                    dto.documento = d.GetBytes(be);
                    dto.longitud = dto.documento.Length;
                    dto.nombre = be.Archivo;

                    if (m.Insert(dto))
                    {
                        d.MoverArchivos(be);
                    }
                }
            }
        }

        private bool Validar(BandejaEntrada be)
        {

            if (be.Archivo.EndsWith(".pdf", StringComparison.Ordinal))
            {
                return true;
            }
            else {
                return false;
            }
            //throw new NotImplementedException();
            //Validar que sea pdf

            //mUnindadDOcument mu= new mUnindadDOcument();
            //doc = mu.Get(be.Archivo)
            //return doc != null;
            //return true;
        }

    }
}
