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
        public string Nombre_Dep { get; set; }
        public string DependenciaId { get; set; }
    }
}
