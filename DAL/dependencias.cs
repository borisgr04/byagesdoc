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
    
    public partial class dependencias
    {
        public dependencias()
        {
            this.unidaddocumental = new HashSet<unidaddocumental>();
        }
    
        public string idDependencia { get; set; }
        public string Dependencia { get; set; }
        public string Estado { get; set; }
        public string Padre { get; set; }
    
        public virtual ICollection<unidaddocumental> unidaddocumental { get; set; }
    }
}
