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
            InicializarForm();
            if (!Page.IsPostBack) {
                ActualizarBandejaEntrada();
            }
        }

        private void InicializarForm()
        {
            mConfiguracion mc = new mConfiguracion();

            configuracionDto BE = mc.Get("BandejaE");
            configuracionDto BOK = mc.Get("BandejaOK");

            d = new Directorios(Server.MapPath(BE.Valor), Server.MapPath(BOK.Valor));

         
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //byte[] FileBuffer;
            //FileBuffer=PdfManipulation2.ExtractPdfPage(FileBuffer, 1, 2); 
            
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
            ActualizarBandejaEntrada();

           
        }
        protected void BtnMoverArchivos_Click(object sender, EventArgs e)
        {
            // 

            MoverArchivosFromBandejaEntradaTemporalToBandejaEntradaOK();
            ActualizarBandejaEntrada();

        }

        private void ActualizarBandejaEntrada()
        {
            ChkBE.DataSource = d.ObtenerBE();
            ChkBE.DataTextField = "Archivo";
            ChkBE.DataValueField = "Archivo";
            ChkBE.DataBind();
        }

        

        private void MoverArchivosFromBandejaEntradaTemporalToBandejaEntradaOK()
        {
            BandejaEntrada be;
            List<BandejaEntrada> lBE = new List<BandejaEntrada>();
            foreach (ListItem elem in ChkBE.Items)
            {
                if (elem.Selected)
                {
                    be = new BandejaEntrada();
                    be.Archivo = (elem.Value);
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