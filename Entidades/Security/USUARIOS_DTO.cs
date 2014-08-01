using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Security
{
    
    public class USUARIOS_DTO
    {
        public System.Guid APPLICATIONID { get; set; }
        public System.Guid USERID { get; set; }
        public string PASSWORD { get; set; }
        public decimal PASSWORDFORMAT { get; set; }
        public string PASSWORDSALT { get; set; }
        public string MOBILEPIN { get; set; }
        public string EMAIL { get; set; }
        public string LOWEREDEMAIL { get; set; }
        public string PASSWORDQUESTION { get; set; }
        public string PASSWORDANSWER { get; set; }
        public decimal ISAPPROVED { get; set; }
        public decimal ISLOCKEDOUT { get; set; }
        public System.DateTime CREATEDATE { get; set; }
        public System.DateTime LASTLOGINDATE { get; set; }
        public System.DateTime LASTPASSWORDCHANGEDDATE { get; set; }
        public System.DateTime LASTLOCKOUTDATE { get; set; }
        public decimal FAILEDPWDATTEMPTCOUNT { get; set; }
        public System.DateTime FAILEDPWDATTEMPTWINSTART { get; set; }
        public decimal FAILEDPWDANSWERATTEMPTCOUNT { get; set; }
        public System.DateTime FAILEDPWDANSWERATTEMPTWINSTART { get; set; }
        public string COMMENTS { get; set; }
        //
        public string USERNAME { get; set; }
        public string LOWEREDUSERNAME { get; set; }
        public string MOBILEALIAS { get; set; }
        public decimal ISANONYMOUS { get; set; }
        public System.DateTime LASTACTIVITYDATE { get; set; }
        //
        public string TERCERO { get; set; }
    }

    public class ModuloRoles
    {
        public bool hasRol { get; set; }
        public string Modulo { get; set; }
        public string Titulo { get; set; }
        public string Roles { get; set; }
    }

    public class ListBoxJq
    {
        public bool hasRol { get; set; }
        public string group { get; set; }
        public string label { get; set; }
        public string value { get; set; }
    }
}
