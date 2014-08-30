using BLL.Gestion;
using BLL.IO;
using ByA;
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
        ByARpt byaRpt = new ByARpt();
        public string sourcePath { get; set; }
        public string targetPath { get; set; }

        Directorios d;

        public BandejaEntBLL(string sourcePath, string targetPath)
        { 
            this.sourcePath=sourcePath;
            this.targetPath=targetPath;
            
        }
        

        public ByARpt MoverArchivos(List<BandejaEntrada> lBE)
        {
            
            mGDocumentos m = new mGDocumentos();
            gdocumentosDto dto; 

            foreach (BandejaEntrada be in lBE)
            {
                d = new Directorios(sourcePath, targetPath,be);
                if (Validar(be))
                {
                    
                    // Use Path class to manipulate file and directory paths.
                    dto = new gdocumentosDto();
                    dto.estado = "SA";
                    //dto.idGDocumentos
                    dto.tipo =d.GetExtension();
                    dto.documento = d.GetBytes();
                    dto.longitud = dto.documento.Length;
                    dto.nombre = be.Archivo;
                    ByARpt rpt =m.Insert(dto);
                    if (!rpt.Error)
                    {
                        d.MoverArchivos();
                    }
                    else {
                        byaRpt.Mensaje += String.Format("El Documento {0} no se pudo cargar: {1} <br/>", be.Archivo, rpt.Mensaje);
                    }
                }
            }
            return byaRpt;
        }

        private bool Validar(BandejaEntrada be)
        {
            if (be.Archivo.EndsWith(".pdf", StringComparison.Ordinal))
            {
                mDocumentos mDoc = new mDocumentos();
                unidaddocumentalDto doc = mDoc.Get(d.GetFileName());
                if (doc.idUnidadDocumental == null)
                {
                    byaRpt.Mensaje += String.Format("No existe la Unidad documental Código {0} <br/>", be.Archivo);
                    return false;
                }
                else {
                    return true;
                }
            }
            else {
                byaRpt.Mensaje += String.Format("El Documento {0} no es un archivo (*.pdf) <br/>", be.Archivo);
                return false;
            }
        }

    }
}
