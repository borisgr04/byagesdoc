using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
namespace wfSircc.ashx
{
    /// <summary>
    /// Descripción breve de ashxImg
    /// </summary>
    public class ashxImg : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            EntidadBLL e = new EntidadBLL();
            context.Response.ContentType = "image/png";
            context.Response.BinaryWrite(e.GetLogo());
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