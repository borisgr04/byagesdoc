using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ByAPdf;
using System.IO;
using System.Collections;
using BLL.IO;
using BLL.Gestion;
using Entidades;

namespace wfSircc.DatosBasicosG.Prueba
{
    public partial class Prueba : System.Web.UI.Page
    {

        Directorios d ;
          
        protected void Page_Load(object sender, EventArgs e)
        {
            mConfiguracion mc = new mConfiguracion();

            configuracionDto BE = mc.Get("BandejaE");
            configuracionDto BOK = mc.Get("BandejaOK");

            d = new Directorios(Server.MapPath(BE.Valor), Server.MapPath(BOK.Valor));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Mostrar Archivos

            //string FilePath = Server.MapPath("/Docs/POOJava.pdf");
            //WebClient User = new WebClient();
            //Byte[] FileBuffer = User.DownloadData(FilePath);
            
            //FileBuffer=PdfManipulation2.ExtractPdfPage(FileBuffer, 1, 2); 
            
            ////TextBox1.Text = "Hola Mundo";

            ////string FilePath = Server.MapPath("/Docs/POOJava.pdf");
            ////WebClient User = new WebClient();
            ////Byte[] FileBuffer = User.DownloadData(FilePath);
            
            //if (FileBuffer != null)
            //{
            //    Response.ContentType = "application/pdf";
            //    Response.AddHeader("content-length", FileBuffer.Length.ToString());
            //    Response.BinaryWrite(FileBuffer);
            //}
        }


        protected void Button3_Click(object sender, EventArgs e)
        {
            List<BandejaEntrada> lBE =d.ObtenerBE();
            d.MoverArchivos(lBE);
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
          ChkBE.DataSource = d.ObtenerBE();
          ChkBE.DataTextField = "Archivo";
          ChkBE.DataValueField = "Archivo";
          ChkBE.DataBind();

           
        }

        protected void BtnMoverArchivos_Click(object sender, EventArgs e)
        {
          // 
            
            BandejaEntrada be;
            List<BandejaEntrada> lBE = new List<BandejaEntrada>();
            foreach( ListItem elem in ChkBE.Items)
            {
              if(elem.Selected){
                  be = new BandejaEntrada();
                  be.Archivo= (elem.Value);
                  lBE.Add(be);
              }
            }
            d.MoverArchivos(lBE);
            ChkOK.DataSource = lBE;
            ChkOK.DataTextField = "Archivo";
            ChkOK.DataValueField = "Archivo";
            ChkOK.DataBind();

        }
    }
   
}