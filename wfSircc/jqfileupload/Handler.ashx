<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Web.Script.Serialization;
using Entidades;
using System.Collections.Generic;
using System.IO;
using BLL;
using BLL.Gestion;
//using BLL.DOC;
//using  Sircc4.Clases;

public class Handler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";//"application/json";
        var r = new List<ViewDataUploadFilesResult>();
        JavaScriptSerializer js = new JavaScriptSerializer();
        
        mConfiguracion mc = new mConfiguracion();
        configuracionDto BE = mc.Get("BandejaE");
        string Carpeta = BE.Valor;
        
        foreach (string file in context.Request.Files)
        {
            HttpPostedFile hpf = context.Request.Files[file] as HttpPostedFile;
            string FileName = string.Empty;
            if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE")
            {
                string[] files = hpf.FileName.Split(new char[] { '\\' });
                FileName = files[files.Length - 1];
            }
            else
            {
                FileName = hpf.FileName;
            }
            if (hpf.ContentLength == 0)
                continue;
           
            BinaryReader b = new BinaryReader(hpf.InputStream);
            byte[] DocBinario = b.ReadBytes(hpf.ContentLength);

            gdocumentosDto a = new gdocumentosDto();
            a.documento = DocBinario;
            a.tipo = hpf.ContentType;
            a.longitud = hpf.ContentLength;
            a.nombre = FileName;
            //a.usu = Usuario.UserName;
            //a.de = "";

            //BandejaEntBLL gd = new BandejaEntBLL();
            //string msg=gd.Insert(a);

            
            string msg = "";
            //"c:\\Temp\\" 
            string sourcePath = System.Web.HttpContext.Current.Server.MapPath(Carpeta);
            string savedFileName = System.IO.Path.Combine(sourcePath, FileName);
            hpf.SaveAs(savedFileName);
            

            r.Add(new ViewDataUploadFilesResult()
            {
                //Thumbnail_url = savedFileName,
                Name = FileName,
                Length = hpf.ContentLength,
                Type = hpf.ContentType,
                Msg=msg
            });
            var uploadedFiles = new
            {
                files = r.ToArray()
            };
            var jsonObj = js.Serialize(uploadedFiles);
            //jsonObj.ContentEncoding = System.Text.Encoding.UTF8;
            //jsonObj.ContentType = "application/json;";
            context.Response.Write(jsonObj.ToString());
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}

public class ViewDataUploadFilesResult
{
    public string Thumbnail_url { get; set; }
    public string Name { get; set; }
    public int Length { get; set; }
    public string Type { get; set; }
    public string Msg { get; set; }
}