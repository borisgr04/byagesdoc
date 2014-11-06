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
    /// Descripción breve de wsDocumentos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class wsDocumentos : System.Web.Services.WebService
    {

        DocumentosBLL Manager;
        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod(EnableSession = true)]
        public ByARpt Insert(unidaddocumentalDto Reg)
        {
            Manager = new DocumentosBLL();
            return Manager.Insert(Reg);
        }
        [WebMethod(EnableSession = true)]
        public ByARpt Update(unidaddocumentalDto Reg)
        {
            Manager = new DocumentosBLL();
            return Manager.Update(Reg);
        }
        [WebMethod(EnableSession = true)]
        public ByARpt Anular(unidaddocumentalDto Reg)
        {
            Manager = new DocumentosBLL();
            return Manager.Anular(Reg);
        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Xml)]
        public string Gets(unidaddocumentalDto Filtro)
        {
            Session["Filtro"] = Filtro;          
            Manager = new DocumentosBLL();
            return ByAUtil.convertListToXML(Manager.Gets(Filtro));

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public List<unidaddocumentalDto> GetsCbo()
        {
            unidaddocumentalDto Filtro = null;
            Manager = new DocumentosBLL();
            return Manager.Gets(Filtro);

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public List<unidaddocumentalDto> Reporte()
        {
                     
            Manager = new DocumentosBLL();
            return Manager.Gets((unidaddocumentalDto)Session["Filtro"]);

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public unidaddocumentalDto Get(unidaddocumentalDto Reg)
        {
            Manager = new DocumentosBLL();
            return Manager.Get(Reg.Codigo);

        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public unidaddocumentalDto GetID(unidaddocumentalDto Reg)
        {
            Manager = new DocumentosBLL();
            return Manager.GetID(Reg.idUnidadDocumental);

        }
      
       
    }
}
