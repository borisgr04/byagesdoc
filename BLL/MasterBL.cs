using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace BLL
{
    public class MasterBL
    {
        Entities ctx;
        public string path{get; set;}

        private List<MENU2> FindPadres(string modulo)
        {
            var q = from c in ctx.MENU2
                    where c.PADREID == c.MENUID && c.MODULO.Equals(modulo)
                    select c;
            return q.ToList();

        }

        public string CargarMenuA(string modulo)
        {
            string StrMenu;
            using (ctx = new Entities())
            {
                List<MENU2> itemPadres = FindPadres(modulo);
                StrMenu = "<ul id=\"menu\">";
                foreach (MENU2 item in itemPadres)
                {
                    if (item.MENUID == item.PADREID)
                    {
                        StrMenu += "<li><a href=\"" + item.URL + "\" title=\"" + item.DESCRIPCION + "\">" + item.TITULO + "</a>";
                        StrMenu += "<ul>";
                        //StrMenu += AddMenuHijos(item);
                        StrMenu += "</ul>";
                        StrMenu += "</li>";
                    }
                }
            }
            StrMenu += "</ul>";
            return StrMenu;
        }

   
    
    }
}
