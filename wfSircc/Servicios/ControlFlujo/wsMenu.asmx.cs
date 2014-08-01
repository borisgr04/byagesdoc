using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using BLL.Security;

namespace wfSircc.Servicios.ControlFlujo
{
    /// <summary>
    /// Descripción breve de wsMenu
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class wsMenu : System.Web.Services.WebService
    {
        
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<dataTree> GetMenu(string modulo, string usuario)
        {
            gesMenuAdapter mg = new gesMenuAdapter();
            return mg.getOpciones(modulo);
        }
    }
}
