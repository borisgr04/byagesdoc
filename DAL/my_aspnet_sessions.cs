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
    
    public partial class my_aspnet_sessions
    {
        public string SessionId { get; set; }
        public int ApplicationId { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime Expires { get; set; }
        public System.DateTime LockDate { get; set; }
        public int LockId { get; set; }
        public int Timeout { get; set; }
        public bool Locked { get; set; }
        public byte[] SessionItems { get; set; }
        public int Flags { get; set; }
    }
}
