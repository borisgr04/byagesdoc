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
    /// Descripción breve de wsTiposDocumentales
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class wsTiposDocumentales : System.Web.Services.WebService
    {

        TiposDocumentalesBLL Manager;
        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod(EnableSession = true)]
        public ByARpt Insert(tiposdocumentalesDto Reg)
        {
            Manager = new TiposDocumentalesBLL();
            return Manager.Insert(Reg);
        }

        [WebMethod(EnableSession = true)]
        public ByARpt Update(tiposdocumentalesDto Reg)
        {
            Manager = new TiposDocumentalesBLL();
            return Manager.Update(Reg);
        }

        [WebMethod(EnableSession = true)]
        public ByARpt Anular(tiposdocumentalesDto Reg)
        {
            Manager = new TiposDocumentalesBLL();
            return Manager.Anular(Reg);
        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Xml)]
        public string Gets()
        {
            Manager = new TiposDocumentalesBLL();
            return ByAUtil.convertListToXML(Manager.Gets());

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public tiposdocumentalesDto Get(string idTipoDocumentales)
        {
            Manager = new TiposDocumentalesBLL();
            return Manager.Get(idTipoDocumentales);

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public List<tiposdocumentalesDto> GetsCbo()
        {
            Manager = new TiposDocumentalesBLL();
            return Manager.Gets();

        }
    }
}
