﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Security
{
    
    public class USUARIOS_DTO
    {
        public int userId { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public string Password { get; set; }
        public string PasswordKey { get; set; }
        public Nullable<sbyte> PasswordFormat { get; set; }
        public string PasswordQuestion { get; set; }
        public string PasswordAnswer { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public Nullable<System.DateTime> LastActivityDate { get; set; }
        public Nullable<System.DateTime> LastLoginDate { get; set; }
        public Nullable<System.DateTime> LastPasswordChangedDate { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<bool> IsLockedOut { get; set; }
        public Nullable<System.DateTime> LastLockedOutDate { get; set; }
        public Nullable<long> FailedPasswordAttemptCount { get; set; }
        public Nullable<System.DateTime> FailedPasswordAttemptWindowStart { get; set; }
        public Nullable<long> FailedPasswordAnswerAttemptCount { get; set; }
        public Nullable<System.DateTime> FailedPasswordAnswerAttemptWindowStart { get; set; }
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
