using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wfSircc.ashx
{
    /// <summary>
    /// Descripción breve de GetPDF
    /// </summary>
    public class GetPDF : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {


            if (context.Request.QueryString["codigo"].ToString() != null)
            {

                int Longitud = context.Request.QueryString["codigo"].ToString().Length-4;
                string id = context.Request.QueryString["codigo"].ToString().Substring(0, Longitud);
                context.Response.ContentType = id;
                mGenerar mg = new mGenerar();
                ArchivosDto b = mg.GetByte(id);
                string Adjunto = String.Format("inline; filename=Documento_{0}.pdf", b.NomArchivo);
                context.Response.AddHeader("content-disposition", Adjunto);
                context.Response.ContentType = "application/pdf";
                context.Response.AddHeader("content-length", b.SoporteB.Length.ToString());
                context.Response.BinaryWrite(b.SoporteB);
            }
          
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