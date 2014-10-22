using BLL;
using ByA;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace wfSircc.Servicios.Archivos
{
    /// <summary>
    /// Descripción breve de wsDependencias
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class wsDependencias : System.Web.Services.WebService
    {

        DependenciasBLL Manager;
        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod(EnableSession = true)]
        public ByARpt Insert(dependenciasDto Reg)
        {
            Manager = new DependenciasBLL();
            return Manager.Insert(Reg);
        }
        [WebMethod(EnableSession = true)]
        public ByARpt Update(dependenciasDto Reg)
        {
            Manager = new DependenciasBLL();
            return Manager.Update(Reg);
        }
        [WebMethod(EnableSession = true)]
        public ByARpt Anular(dependenciasDto Reg)
        {
            Manager = new DependenciasBLL();
            return Manager.Anular(Reg);
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public List<dependenciasDto> GetDependencias()
        {
           
            Manager = new DependenciasBLL();
            return Manager.Gets(this.User.Identity.Name);

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Xml)]
        public string Gets()
        {
            Manager = new DependenciasBLL();
            return ByAUtil.convertListToXML(Manager.Gets());

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public dependenciasDto Get(string Dependencia)
        {
            Manager = new DependenciasBLL();
            return Manager.Get(Dependencia);

        }
    }
}
