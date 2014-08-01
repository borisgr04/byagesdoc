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
            string inputData = context.Request.Form["data"];

            byte[] buffer;
            using (System.IO.FileStream fileStream = new System.IO.FileStream(@"C:\tmp\jQueryPDF\" + inputData + ".pdf", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read))
            using (System.IO.BinaryReader reader = new System.IO.BinaryReader(fileStream))
            {
                buffer = reader.ReadBytes((int)reader.BaseStream.Length);
            }
            context.Response.ContentType = "application/pdf";
            context.Response.AddHeader("Content-Length", buffer.Length.ToString());
            context.Response.AppendHeader("content-disposition", "inline; filename=test.pdf");
            context.Response.BinaryWrite(buffer);
            context.Response.End(); 
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