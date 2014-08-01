using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using BLL.Security;
using System.Web.Security;
namespace wfSircc
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          //  genRoles m = new genRoles();
            //string roles = m.GenerarRoles();
            //Label1.Text = roles;

            if (Roles.IsUserInRole("PR_CONS")) {
                Response.Redirect("Solicitudes/ConsultasT/PanelConsT.aspx");
            }
        }
    }
}