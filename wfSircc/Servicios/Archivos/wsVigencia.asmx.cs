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
    /// Descripción breve de wsVigencia
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class wsVigencia : System.Web.Services.WebService
    {
        VigenciaBLL Manager;
        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod(EnableSession = true)]
        public ByARpt Insert(VigenciaDto Reg)
        {
            Manager = new VigenciaBLL();
            return Manager.Insert(Reg);
        }

        [WebMethod(EnableSession = true)]
        public ByARpt Update(VigenciaDto Reg)
        {
            Manager = new VigenciaBLL();
            return Manager.Update(Reg);
        }

        [WebMethod(EnableSession = true)]
        public ByARpt Anular(VigenciaDto Reg)
        {
            Manager = new VigenciaBLL();
            return Manager.Anular(Reg);
        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Xml)]
        public string GetVigencias()
        {
            Manager = new VigenciaBLL();
            return ByAUtil.convertListToXML(Manager.Gets());

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public VigenciaDto GetVigencias2(string idVigencia)
        {
            Manager = new VigenciaBLL();
            return Manager.Gets(idVigencia);

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public List<VigenciaDto> GetVigenciasCbo()
        {
            Manager = new VigenciaBLL();
            return Manager.Gets();

        }
    }
}
