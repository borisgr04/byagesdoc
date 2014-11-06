using BLL.Gestion;
using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wfSircc.DatosBasicosG.Consultas
{
    public partial class Consultas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
          
        }
 

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            mGenerar mg = new mGenerar();
            ArchivosDto b = mg.DescargarZip((unidaddocumentalDto)Session["Filtro"]);
            Response.ContentType = b.Content;
            string Adjunto = String.Format("inline; filename=Documento_{0}.zip", b.NomArchivo);
            Response.AddHeader("content-disposition", Adjunto);
            Response.AddHeader("content-length", b.SoporteB.Length.ToString());
            Response.BinaryWrite(b.SoporteB);

        }

        protected void BtnReporte_Click(object sender, EventArgs e)     
        {
          
           
         
        }
     
    }
}