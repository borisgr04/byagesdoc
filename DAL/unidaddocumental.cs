//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class unidaddocumental
    {
        public unidaddocumental()
        {
            this.gdocumentos = new HashSet<gdocumentos>();
        }
    
        public string idUnidadDocumental { get; set; }
        public string Nombre { get; set; }
        public string PalabrasClave { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<int> NroFolios { get; set; }
        public string idSubSeries { get; set; }
        public Nullable<int> EntidadProductora { get; set; }
        public Nullable<int> ArchivadorNo { get; set; }
        public Nullable<int> GabetaNo { get; set; }
        public Nullable<System.DateTime> FechaExtInicial { get; set; }
        public Nullable<System.DateTime> FechaExtFinal { get; set; }
        public string DependenciaId { get; set; }
        public string Codigo { get; set; }
        public string Estado { get; set; }
        public string Vigencia { get; set; }
    
        public virtual dependencias dependencias { get; set; }
        public virtual subseries subseries { get; set; }
        public virtual unidadd_tipodoc unidadd_tipodoc { get; set; }
        public virtual ICollection<gdocumentos> gdocumentos { get; set; }
    }
}
