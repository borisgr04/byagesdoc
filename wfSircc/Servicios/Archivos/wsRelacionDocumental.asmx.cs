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
    /// Descripción breve de wsRelacionDocumental
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class wsRelacionDocumental : System.Web.Services.WebService
    {

        UnidadD_TipoDocBLL Manager;
        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod(EnableSession = true)]
        public ByARpt Insert(UnidadD_TipoDocDto Reg)
        {
            Manager = new UnidadD_TipoDocBLL();
            return Manager.Insert(Reg);
        }

        [WebMethod(EnableSession = true)]
        public ByARpt Update(UnidadD_TipoDocDto Reg)
        {
            Manager = new UnidadD_TipoDocBLL();
            return Manager.Update(Reg);
        }

        [WebMethod(EnableSession = true)]
        public ByARpt Anular(UnidadD_TipoDocDto Reg)
        {
            Manager = new UnidadD_TipoDocBLL();
            return Manager.Anular(Reg);
        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Xml)]
        public string Gets()
        {
            Manager = new UnidadD_TipoDocBLL();
            return ByAUtil.convertListToXML(Manager.Gets());

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public UnidadD_TipoDocDto Get(string idUnidadD_TipoDoc)
        {
            Manager = new UnidadD_TipoDocBLL();
            return Manager.Get(idUnidadD_TipoDoc);

        }
    }
}
