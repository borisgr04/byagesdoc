using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using ByA;
using System.Web.Security;
using DAL;

namespace BLL.Security
{
    public class gesMenuAdapter
    {

        public  trdEntities  ctx { get; set; }
        public ByARpt byaRpt { get; set; }

        public List<dataTree> getOpciones(string modulo)
        {
            List<dataTree> lt;
            using (ctx = new trdEntities())
            {

                lt = ctx.fc_menu.Where(t => t.fc_modulo == modulo && t.fc_menuid!=t.fc_padreid ).Select(t => new dataTree
                {
                    id = t.fc_menuid,
                    text = t.fc_titulo,
                    value = new valueTree { icono = t.fc_icono, descripcion = t.fc_descripcion, target = t.fc_target, url = t.fc_url, roles = t.fc_url },
                    parentid = t.fc_menuid == t.fc_padreid ? "-1" : t.fc_padreid
                    ,roles = t.fc_roles
                }
                ).ToList();
                //lt=lt.Where(t=> (t.parentid == "-1") || (Roles.IsUserInRole(t.roles))).ToList();
                //lt = lt.Where(t => (t.parentid == "-1") || (Roles.IsUserInRole(t.roles))).ToList();
            return lt;
            }

        }
    }
    public class valueTree { 

        public string target {get;set;}
        public string url { get; set; }
        public string icono { get; set; }
        public string descripcion { get; set; }
        public string roles { get; set; }
        

    }
    public class dataTree
    {
        public string id { get; set; }
        public string parentid { get; set; }
        public string text { get; set; }
        public string roles { get; set; }
        public valueTree value { get; set; }
        
    }
}
