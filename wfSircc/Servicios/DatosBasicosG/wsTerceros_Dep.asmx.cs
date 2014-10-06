using BLL;
using ByA;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace wfSircc.Servicios.DatosBasicosG
{
    /// <summary>
    /// Descripción breve de wsTerceros_Dep
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class wsTerceros_Dep : System.Web.Services.WebService
    {

        Terceros_DepBLL Manager;
        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod(EnableSession = true)]
        public ByARpt Insert(List<terceros_depDto> Reg)
        {
            Manager = new Terceros_DepBLL();
            return Manager.Insert(Reg);
        }
        [WebMethod(EnableSession = true)]
        public ByARpt Update(List<terceros_depDto> Reg)
        {
            Manager = new Terceros_DepBLL();
            return Manager.Update(Reg);
        }
       

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public List<string> Gets(string IdTercero)
        {
            Manager = new Terceros_DepBLL();
            return Manager.Gets(IdTercero);

        }
    }
}
