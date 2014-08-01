using BLL.Gestion;
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
           

            mDocumentos md = new mDocumentos();

            GridView1.DataSource = md.Gets();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Response.Redirect("/ashx/ashxDoc.ashx?doc="+GridView1.SelectedValue.ToString());

            string prew = "<embed src='/Docs/BE/" + GridView1.SelectedValue.ToString() + ".pdf' width='100%' height='375'>";

            ltPrew.Text = prew;
        }
    }
}