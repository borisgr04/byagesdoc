using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wfSircc.ashx
{
    /// <summary>
    /// Descripción breve de ashXLS
    /// </summary>
    public class ashXLS : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "application/vnd.ms-excel";
            //context.Response.AddHeader("content-disposition", " filename=ficheroExcel.xls");
            //context.Response.Write(context.Request.QueryString["datos"]);

            string data = context.Request.Form["datos"];
            data = HttpUtility.UrlDecode(data);
            context.Response.Clear();
            context.Response.AddHeader("content-disposition", "attachment;filename=report.xls");
            context.Response.Charset = "";
            context.Response.ContentType = "application/excel";
            HttpContext.Current.Response.Write(data);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
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