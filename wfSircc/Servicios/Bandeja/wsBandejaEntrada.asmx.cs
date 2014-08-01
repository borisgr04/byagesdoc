using BLL.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace wfSircc.Servicios.Bandeja
{
    /// <summary>
    /// Descripción breve de wsBandejaEntrada
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class wsBandejaEntrada : System.Web.Services.WebService
    {

        [WebMethod]
        public List<BandejaEntrada> GetBandejaEntrada()
        {
            Directorios d = new Directorios(Server.MapPath("/Docs/BE"), Server.MapPath("/Docs/OK"));
            List<BandejaEntrada> lBE = d.ObtenerBE();
            return lBE;
        }

        
    }
}
