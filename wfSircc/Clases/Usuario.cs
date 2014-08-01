using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Sircc4.Clases
{
    public class Usuario
    {
        public static string  UserName { 
           get{
               //return "admin";
               return Membership.GetUser().UserName;
           }
        }
    }
}