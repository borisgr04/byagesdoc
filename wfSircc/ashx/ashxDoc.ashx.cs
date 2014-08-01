using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades;
using BLL.Gestion;
using System.Net;
using ByAPdf;
using System.IO;
using ByA;

namespace wfSircc.ashx
{
    /// <summary>
    /// Descripción breve de ashxDoc
    /// </summary>
    public class ashxDoc : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string doc = context.Request.QueryString["doc"].ToString();
            
            mConfiguracion mc = new mConfiguracion();
            configuracionDto BOK = mc.Get("ObligUpload");

            
            string FilePath = context.Server.MapPath(BOK.Valor+doc+".pdf");
            Byte[] FileBuffer = ByAUtil.ConvertirFileToByteArray(FilePath);
            FileBuffer=PdfManipulation2.ExtractPdfPage(FileBuffer, 1, 2); 
            
            if (FileBuffer != null)
            {
                context.Response.ContentType = "application/pdf";

                string Adjunto = String.Format("inline; filename=Documento_{0}.pdf", doc);
                context.Response.AddHeader("content-disposition", Adjunto);

                context.Response.AddHeader("content-length", FileBuffer.Length.ToString());
                context.Response.BinaryWrite(FileBuffer);
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