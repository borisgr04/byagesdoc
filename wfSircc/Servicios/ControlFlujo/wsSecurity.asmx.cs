using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using ByA;
using BLL.Security;
using Entidades.Security;

namespace wfSircc.Servicios.ControlFlujo
{
    /// <summary>
    /// Descripción breve de wsSecurity1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
   [System.Web.Script.Services.ScriptService]
    public class wsSecurity1 : System.Web.Services.WebService
    {
        gesUsuarios gu = new gesUsuarios();

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ByARpt InsUsuarios(USUARIOS_DTO Reg)
        {
            return gu.InsUsuarios(Reg);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ByARpt Forzar_Cambio_Clave(USUARIOS_DTO Reg)
        {
            return gu.Forzar_Cambio_Clave(Reg);
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ByARpt ActivarUsuario(USUARIOS_DTO Reg)
        {
            return gu.ActivarUsuario(Reg);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ByARpt InactivarUsuario(USUARIOS_DTO Reg)
        {
            return gu.InactivarUsuario(Reg);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ByARpt DesbloquearUsuario(USUARIOS_DTO Reg)
        {
            return gu.DesbloquearUsuario(Reg);
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Xml)]
        public string GetUsuarios(string filtro)
        {
            return ByAUtil.convertListToXML(gu.GetUsuarios(filtro));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Xml)]
        public string GetRoles(string Modulo, string UserName)
        {

            return ByAUtil.convertListToXML(gu.GetRoles(Modulo, UserName));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public List<ListBoxJq> GetRolesJ(string Modulo)
        {
            return gu.GetRolesLB(Modulo);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ByARpt GuardarRoles(List<ModuloRoles> lst, string UserName)
        {
            return gu.GuardarRoles(lst, UserName);
        }
    }
}
