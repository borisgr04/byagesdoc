using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.Http;
using wfSircc;
using BLL.Menu;
using System.Diagnostics;

namespace wfSircc
{
    public class Global : HttpApplication
    {
        private string  Nom_App="SIRCC4";
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciarse la aplicación
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();

            RouteTable.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = System.Web.Http.RouteParameter.Optional }
                );
            GenerarRoles();

        }
        
        private  void GenerarRoles(){
            try
            {
                //CtrSeguridad cs = new CtrSeguridad();
                genRoles m = new genRoles();
                MembershipUserCollection mc = Membership.FindUsersByName(genRoles._ADMIN);
                if (mc.Count == 0)
                {
                    Membership.CreateUser(genRoles._ADMIN, "fc2014.");
                    EventLog.WriteEntry(Nom_App, "Se crea usuario admin, no existia", EventLogEntryType.Information);
                    //cs.CrearUsuario(genRoles._ADMIN, "orion2013.");
                }
                string roles = m.GenerarRoles();
                EventLog.WriteEntry(Nom_App, roles, EventLogEntryType.Information);
            }
            catch
            {

            }
        }
        
        void Application_End(object sender, EventArgs e)
        {
            //  Código que se ejecuta al cerrarse la aplicación

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Código que se ejecuta cuando se produce un error sin procesar

        }
        
    }
}
