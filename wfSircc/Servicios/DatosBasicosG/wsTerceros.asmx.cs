using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using ByA;
using Entidades;
using Sircc4.Clases;
using System.Web.Script.Services;
using BLL.Gestion;

namespace wfSircc.Servicios.DatosBasicosG
{
    /// <summary>
    /// Descripción breve de wsTerceros
    /// </summary>
    [WebService(Namespace = "http://www.byasystems.com.co/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class wsTerceros : System.Web.Services.WebService
    {
        
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ByARpt Update(fc_tercerosDto Reg)
        {
            mTerceros oTer = new mTerceros();
            //Reg.USAP = Usuario.UserName;
            ByARpt rpt = oTer.Update(Reg);
            return rpt;
        }
        
        
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ByARpt Insert(fc_tercerosDto Reg)
        {
            mTerceros oTer = new mTerceros();
           // Reg.USAP = Usuario.UserName;
            return oTer.Insert(Reg);
        }
        

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Xml)]
        public string Gets()
        {
            mTerceros m = new mTerceros();
            string strXml = ByAUtil.convertListToXML(m.Gets());
            return strXml;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public fc_tercerosDto Get(string tercerosId)
        {
            mTerceros m = new mTerceros();
            return m.Gets(tercerosId);
        }

    }
}
