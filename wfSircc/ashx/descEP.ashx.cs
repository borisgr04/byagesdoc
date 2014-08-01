using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;

namespace Sircc4.ashx
{
    /// <summary>
    /// Summary description for descEP
    /// </summary>
    public class descEP : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            GenEstudioPrevio ep = new GenEstudioPrevio();
            //nombre variable, 
            // si es pdf
            // y numeor por parametros
            //context.Response.AddHeader("content-disposition", "attachment; filename=doc.doc");
            decimal id_ep = Convert.ToDecimal(context.Request.QueryString["id_ep"]);
            if (isValido()) { 
                context.Response.AddHeader("content-disposition", "inline; filename=EstudioPrevio_" + id_ep.ToString() + ".pdf");
                context.Response.ContentType = "application/pdf";
                context.Response.BinaryWrite(ep.imprimir(id_ep));
                context.Response.End();
            }
        }

        private bool isValido()
        {
            return true;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}