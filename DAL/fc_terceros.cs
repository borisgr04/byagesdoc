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
    
    public partial class fc_terceros
    {
        public fc_terceros()
        {
            this.terceros_dep = new HashSet<terceros_dep>();
        }
    
        public string terceroId { get; set; }
        public string tipodoc { get; set; }
        public string tipoper { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string lugarexpe { get; set; }
    
        public virtual ICollection<terceros_dep> terceros_dep { get; set; }
    }
}
