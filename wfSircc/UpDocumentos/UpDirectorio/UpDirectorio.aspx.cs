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
using BLL;

namespace wfSircc.UpDocumentos.UpDirectorio
{
    public partial class UpDirectorio : System.Web.UI.Page
    {
        Directorios d;

        protected void Page_Load(object sender, EventArgs e)
        {
            InicializarForm();
            if (!Page.IsPostBack)
            {
                ActualizarBandejaEntrada();
            }
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
            mConfiguracion mc = new mConfiguracion();

            configuracionDto BE = mc.Get("BandejaE");
            configuracionDto BOK = mc.Get("BandejaOK");

            d = new Directorios(Server.MapPath(BE.Valor), Server.MapPath(BOK.Valor));

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

        }

        private void InicializarForm()
        {
            mConfiguracion mc = new mConfiguracion();

            configuracionDto BE = mc.Get("BandejaE");
            configuracionDto BOK = mc.Get("BandejaOK");

            d = new Directorios(Server.MapPath(BE.Valor), Server.MapPath(BOK.Valor));


        }

        private void Mover()
        {
            mConfiguracion mc = new mConfiguracion();
            configuracionDto BE = mc.Get("BandejaE");
            configuracionDto BOK = mc.Get("BandejaOK");

            BandejaEntBLL bll = new BandejaEntBLL(Server.MapPath(BE.Valor), Server.MapPath(BOK.Valor));

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

            lbLog.Text = bll.MoverArchivos(lBE);

            ActualizarBandejaEntrada();
        }

        protected void BtnMover_Click1(object sender, EventArgs e)
        {
            Mover();
        }

        protected void BtnAceptar_Click1(object sender, EventArgs e)
        {
            MoverArchivosFromBandejaEntradaTemporalToBandejaEntradaOK();
        }

    }

}