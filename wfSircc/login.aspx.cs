using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entidades;

namespace wfSircc
{
    public partial class login : System.Web.UI.Page
    {
        
          protected void Page_Load(object sender, EventArgs e)
          {
              if (!IsPostBack)
              {
                  
                      
                 
                  if (Request.QueryString["opt"] == "logout")
                  {
                      Session.Abandon();
                      FormsAuthentication.SignOut();
                      lbMsg.Text = "Su sesión se ha cerrado correctamente.";
                      lbMsg.ForeColor = System.Drawing.Color.Green;
                  }
                  if (!String.IsNullOrEmpty(Request.QueryString["ReturnUrl"])) { 
                      lbMsg.Text = "No tiene autorización a la opción seleccionada ";
                      lbMsg.Text += "<a href='javascript:history.go(-1)'>Atrás</a>";
                      lbMsg.ForeColor = System.Drawing.Color.Red;
                  }
                
                
              }
            
          }
          /*
            [WebMethod]
            public static string Validar(string user, string pwd)
            {
                if (Membership.ValidateUser(user, pwd))
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
          */
        
          private void SetCookieUser(string usuario, string vig)
          {
              DateTime now = DateTime.Now;

              HttpCookie myCookie;

              myCookie = new HttpCookie("sigesdoc_user");
              myCookie.Value = usuario;
              myCookie.Expires = now.AddHours(8);
              HttpContext.Current.Response.Cookies.Add(myCookie);

              myCookie = new HttpCookie("sigesdoc_vig");
              myCookie.Value = vig;
              myCookie.Expires = now.AddHours(8);
              HttpContext.Current.Response.Cookies.Add(myCookie);

          }
         
        protected void BtnIniciar_Click1(object sender, EventArgs e)
        {
          
            string user = this.txtUserName.Value;
            string pwd = this.txtPassword.Value;
           
            if (Membership.ValidateUser(user, pwd))
            {
                SetCookieUser(user, "2014");
                FormsAuthentication.RedirectFromLoginPage(user, false);
            }
            else {
                lbMsg.Text = "El nombre de usuario o la contraseña que ingresaste es incorrecto.";
                lbMsg.ForeColor = System.Drawing.Color.Red;
            }

           
           
        }
    }
}