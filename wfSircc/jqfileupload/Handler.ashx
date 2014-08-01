<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Web.Script.Serialization;
using Entidades;
using BLL.DOC;
using  Sircc4.Clases;

public class Handler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";//"application/json";
        var r = new System.Collections.Generic.List<ViewDataUploadFilesResult>();
        JavaScriptSerializer js = new JavaScriptSerializer();
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
            string savedFileName = "c:\\tmp\\" + FileName;
           
            System.IO.BinaryReader b = new System.IO.BinaryReader(hpf.InputStream);
            byte[] DocBinario = b.ReadBytes(hpf.ContentLength);


            GD_DOCUMENTOSDTO a = new GD_DOCUMENTOSDTO();
            a.DOCUMENTO = DocBinario;
            a.TYPE = hpf.ContentType;
            a.LONGITUD = hpf.ContentLength;
            a.NOMBRE = FileName;
            a.USUARIO = Usuario.UserName;
            a.DESCRIPCION = "";
            
            GestionDOC gd = new GestionDOC();
            string msg=gd.Guardar(a);
            
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