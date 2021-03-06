﻿using BLL;
using ByA;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace wfSircc.Servicios.Archivos
{
    /// <summary>
    /// Descripción breve de wsSeries
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class wsSeries : System.Web.Services.WebService
    {
        SeriesBLL Manager;
        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod(EnableSession = true)]
        public ByARpt Insert(seriesDto Reg)
        {
            Manager = new SeriesBLL();
            return Manager.Insert(Reg);
        }

        [WebMethod(EnableSession = true)]
        public ByARpt Update(seriesDto Reg)
        {
            Manager = new SeriesBLL();
            return Manager.Update(Reg);
        }

        [WebMethod(EnableSession = true)]
        public ByARpt Anular(seriesDto Reg)
        {
            Manager = new SeriesBLL();
            return Manager.Anular(Reg);
        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Xml)]
        public string GetSeries()
        {
            Manager = new SeriesBLL();
            return ByAUtil.convertListToXML(Manager.Gets());

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public seriesDto GetSeries2(string idSeries)
        {
            Manager = new SeriesBLL();
            return Manager.Gets(idSeries);

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public List<seriesDto> GetSeriesCbo()
        {
            Manager = new SeriesBLL();
            return Manager.Gets();

        }

    }
}
