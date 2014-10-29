using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
 public   class unidaddocumentalDto
    {
        public string idUnidadDocumental { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string PalabrasClave { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<int> NroFolios { get; set; }
        public string Nombre_Sub { get; set; }
        public string idSubSeries { get; set; }
        public Nullable<int> EntidadProductora { get; set; }
        public Nullable<int> ArchivadorNo { get; set; }
        public Nullable<int> GabetaNo { get; set; }
        public Nullable<System.DateTime> FechaExtInicial { get; set; }
        public Nullable<System.DateTime> FechaExtFinal { get; set; }
        public Nullable<int> Vigencia { get; set; }
        public string Nombre_Dep { get; set; }
        public string DependenciaId { get; set; }
        public string Tema { get; set; }
        public string Estante { get; set; }
        public string SoporteFisico { get; set; }
        public string SoporteDigital { get; set; }
        public string NroFolioInicial { get; set; }
        public string NroFolioFinal { get; set; }
        public string Frecuencia { get; set; }
        public string Identificacion { get; set; }
    }
}
