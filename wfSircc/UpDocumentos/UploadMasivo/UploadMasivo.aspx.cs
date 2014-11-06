﻿using BLL;
using Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wfSircc.UpDocumentos.UploadMasivo
{
    public partial class UploadMasivo : System.Web.UI.Page
    {
        List<unidaddocumentalDto> lstM;
        List<unidaddocumentalDto> lstS  = new List<unidaddocumentalDto>();
        DocumentosBLL Manager;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnPlano_Click(object sender, EventArgs e)
        {
            Manager = new DocumentosBLL();
            if (lstS.Count != 0)
            {
                LbMsg.CssClass = "alert alert-success col-md-12";
                LbMsg.Text = Manager.Insert(lstS).Mensaje;
            }
            else
            {
                LbMsg.CssClass = "alert alert-danger col-md-12";
                LbMsg.Text = "Debe Cargar el archivo plano antes de guardarlo";
            }
        }
        private List<unidaddocumentalDto> LeesMovimientos(byte[] filas)
        {
            lstM = new List<unidaddocumentalDto>();
            ArrayList arrText = LeerArchivoToArray(filas);            
            foreach (string sOutput in arrText)
            {
                string[] campos = sOutput.Split(';');               
                    unidaddocumentalDto m = MapearArrayToMovimiento(campos);
                    lstM.Add(m);                  
                
            }
            return lstM;
        }
        private unidaddocumentalDto MapearArrayToMovimiento(string[] campos)
        {
            
            unidaddocumentalDto m = new unidaddocumentalDto();
            m.Codigo = campos[16]+"."+campos[1]+"."+campos[2];
            m.DependenciaId = campos[0];
            m.idSubSeries = campos[1];
            m.Tema = campos[2];
            m.Nombre = campos[3];
            m.Identificacion = campos[4];
            if ((campos[6] != "") && (campos[7]!=""))
            {
                m.FechaCreacion = Convert.ToDateTime("01/01/"+campos[5]);
                m.FechaExtInicial = Convert.ToDateTime("01/01/" + campos[6]);
                m.FechaExtFinal = Convert.ToDateTime("31/12/" + campos[7]);
            }          
            m.NroFolioInicial = campos[8];
            m.NroFolioFinal = campos[9];
            m.ArchivadorNo = Convert.ToInt32(campos[10]);
            m.GabetaNo = Convert.ToInt32(campos[11]);
            m.Estante = campos[12];
            m.SoporteFisico = campos[13];
            m.SoporteDigital = campos[14];
            m.Frecuencia = campos[15];
            m.Vigencia = Convert.ToInt32(campos[16]);
           
            return m;
        }
        private static ArrayList LeerArchivoToArray(byte[] filas)
        {
            //StreamReader objReader = new StreamReader("c:\\planos\\EM2013.txt");
            StreamReader objReader = new StreamReader(new MemoryStream(filas));
            string sLine = "";
            ArrayList arrText = new ArrayList();
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    arrText.Add(sLine);
            }
            objReader.Close();
            return arrText;
        }
        protected void BtnCargar_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
               Manager = new DocumentosBLL();
             
               lstS = LeesMovimientos(FileUpload1.FileBytes);
               GridPlano.DataSource = lstS;
               GridPlano.DataBind();

            }
        }
    }
}