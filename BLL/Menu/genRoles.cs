using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByA;
using Entidades;
using System.Web.Security;
using DAL;


namespace BLL.Menu
{
    public class genRoles
    {
        
        public static string _ADMIN="admin";
        
        public string GenerarRoles()
        {
           using (trdEntities ctx = new trdEntities ())
           {
                string strrole = "";
                List<fc_menu> lm = ctx.fc_menu.ToList();
                foreach (fc_menu im in lm)
                {
                    string rol = im.fc_roles;
                    if (!String.IsNullOrEmpty(rol) && (!Roles.RoleExists(rol)))
                    {
                        Roles.CreateRole(rol);
                        Roles.AddUserToRole(_ADMIN, rol);
                        strrole = strrole + rol + "<br>";
                    }
                    else if (!String.IsNullOrEmpty(rol) && (Roles.RoleExists(rol)) && (!Roles.IsUserInRole(_ADMIN, rol)))
                    {
                        Roles.AddUserToRole(_ADMIN, rol);
                        strrole = strrole + rol + "<br>";
                    }
                }
                return strrole;
                
            return "";
           }

        }
    }
}
