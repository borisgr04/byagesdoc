//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class fc_transaccionesDto
    {
        public int TransaccionesId { get; set; }
        public Nullable<int> CupoId { get; set; }
        public string Tipo { get; set; }
        public Nullable<System.DateTime> FechaTrans { get; set; }
        public Nullable<decimal> Debito { get; set; }
        public Nullable<decimal> Credito { get; set; }
    
        //public virtual fc_clientesentidad fc_clientesentidad { get; set; }
    }
}
