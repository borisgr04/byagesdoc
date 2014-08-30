using BLL.Gestion;
using ByA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace wfSircc.Servicios
{
    /// <summary>
    /// Descripción breve de wsConsultas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class wsConsultas : System.Web.Services.WebService
    {
        mDocumentos md;
        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Xml)]
        public string Gets(string Filtro)        {

            md = new mDocumentos();
            return ByAUtil.convertListToXML(md.Gets(Filtro));
        }
    }
}
