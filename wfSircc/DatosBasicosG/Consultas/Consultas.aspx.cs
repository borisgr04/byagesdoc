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
  
        protected void Button1_Click(object sender, EventArgs e)
        {
            mGenerar mg = new mGenerar();         
           
                ArchivosDto b = mg.DescargarZip((unidaddocumentalDto)Session["Filtro"]);
                Response.ContentType = b.Content;
                string Adjunto = String.Format("inline; filename=Documento_{0}.zip", b.NomArchivo);
               Response.AddHeader("content-disposition", Adjunto);

                Response.AddHeader("content-length", b.SoporteB.Length.ToString());
                Response.BinaryWrite(b.SoporteB);
            
            //Response.Redirect("~/ashx/ashxZip.ashx");
            
        }

        //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //Response.Redirect("/ashx/ashxDoc.ashx?doc="+GridView1.SelectedValue.ToString());

        //    //string prew = "<embed src='/Docs/BE/" + GridView1.SelectedValue.ToString() + ".pdf' width='100%' height='375'>";

        //    //ltPrew.Text = prew;
        //}
    }
}