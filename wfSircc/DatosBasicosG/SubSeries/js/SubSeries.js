﻿var SubSeries = (function () {
    "use strict";
    var urlToInsert = "/Servicios/Archivos/wsSubSeries.asmx/Insert";
    var urlToUpdate = "/Servicios/Archivos/wsSubSeries.asmx/Update";
    var urlToAbrir2 = "/Servicios/Archivos/wsSubSeries.asmx/Get";
    var urlToSeries = "/Servicios/Archivos/wsSeries.asmx/GetSeriesCbo";
    var byaRpta;
    var idSubSeries;
    var msgPpal = "#LbMsg";
    var Editar = "No";
    var _addHandlers = function () {

        $("#nuevoButton").click(function () {          
            Controls();         
         
           
        });
        $("#guardarButton").click(function () {
            if (Editar == "No") {
                Insert();
            } else { Update() }
        });
        $("#cancelarButton").click(function () {
            byaMsgBox.confirm("Desea cancelar el proceso?", function (result) {
                if (result) {
                    limpiar();
                }
            });
        });



    };
    var Update = function () {
        var jsonData = "{'Reg':" + JSON.stringify(getDatos()) + "}";
        byaPage.POST_Sync(urlToUpdate, jsonData, function (result) {
            byaRpta = byaPage.retObj(result.d);
            $(msgPpal).msgBox({ titulo: "Actualizar SubSeries", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
            if (!byaRpta.Error) {

            }
        });
    }
    var _Validaciones = function () {

    };
    var MultiplesAjax = function () {

    }
    var _createElements = function () {
        $("#TextIdSubSerie").byaFormatInput('0123456789.');
        var sourcePla = byaPage.getSource(urlToSeries);
        $("#CboSeries").byaCombo({ DataSource: sourcePla, Value: "idSerie", Display: "Serie" });
    };
    var _Abrir = function (idSubSeries) {
        var parametrosJSON = { "idSubSeries": idSubSeries };
        $.ajax({
            type: "GET",
            url: urlToAbrir2,
            data: parametrosJSON,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (result) {

                var Subs = byaPage.retObj(result.d);
                if (Subs != undefined) {
                    $('#CboSeries').byaSetHabilitar(false);
                    $('#TextIdSubSerie').val(Subs.idSubSeries);
                    $('#TextSubSerie').val(Subs.SubSerie);
                    $('#TextAg').val(Subs.RetencionAG);
                    $('#TextA').val(Subs.RetencionAC);
                    document.getElementById("CheckCT").checked = Subs.DisposicionCT;
                    document.getElementById("CheckE").checked = Subs.DisposicionE;
                    document.getElementById("CheckMD").checked = Subs.DisposicionMD;
                    document.getElementById("CheckS").checked = Subs.DisposicionS;               
                    $('#CboSeries').val(Subs.Series_idSerie);                  
                    Editar = "Si";
                } else {
                    Editar = "No";
                }

            },
            error: function (jqXHR, status, error) {
                alert(error + "-" + jqXHR.responseText);
            }
        });

    };
    var getDatos = function () {
        var Subs = {};
        if (Editar == "No") {
            Subs.idSubSeries = $('#CboSeries').val() + "." + $('#TextIdSubSerie').val();
        } else {
            Subs.idSubSeries = $('#TextIdSubSerie').val();
        }
            
        Subs.SubSerie = $('#TextSubSerie').val();     
        Subs.RetencionAG = $('#TextAg').val();
        Subs.RetencionAC = $('#TextA').val();
        Subs.DisposicionCT = $("#CheckCT").is(":checked");
        Subs.DisposicionE = $('#CheckE').is(":checked");
        Subs.DisposicionMD = $('#CheckMD').is(":checked");
        Subs.DisposicionS = $("#CheckS").is(":checked");
        Subs.Series_idSerie = $('#CboSeries').val();
        return Subs;
    }
    var Insert = function () {

        var jsonData = "{'Reg':" + JSON.stringify(getDatos()) + "}";
        byaPage.POST_Sync(urlToInsert, jsonData, function (result) {
            byaRpta = byaPage.retObj(result.d);
            $(msgPpal).msgBox({ titulo: "Registrar SubSeries", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
            if (!byaRpta.Error) {

            }
        });


    }
    var Controls = function () {
        $(msgPpal).html("");      
        $('#TextIdSubSerie').byaSetHabilitar(true);
        $('#TextSubSerie').byaSetHabilitar(true);
        $('#TextAg').byaSetHabilitar(true);
        $('#TextA').byaSetHabilitar(true);
        $("#CheckCT").byaSetHabilitar(true);
        $('#CheckE').byaSetHabilitar(true);
        $('#CheckMD').byaSetHabilitar(true);
        $("#CheckS").byaSetHabilitar(true);
        $('#CboSeries').byaSetHabilitar(true);
        $('#TextIdSubSerie').val("");
        $('#TextSubSerie').val("");
        $('#TextAg').val("");
        $('#TextA').val("");
        $("#CheckCT").val("");
        $('#CheckE').val("");
        $('#CheckMD').val("");
        $("#CheckS").val("");
        $('#CboSeries').val("");
        Editar = "No";

    };
    var limpiar = function () {      
        $('#TextIdSubSerie').val("");
        $('#TextSubSerie').val("");
        $('#TextAg').val("");
        $('#TextA').val("");
        $("#CheckCT").val("");
        $('#CheckE').val("");
        $('#CheckMD').val("");
        $("#CheckS").val("");
        $('#CboSeries').val("");
        Editar = "No";
    }

    return {
        id_ep: null,
        fnresultado: null,
        editedRows: null,
        config: {
            dragArea: null,
            theme: null
        },
        Vigencia: function () {
            return byaSite.getVigencia();
        },
        getRecord: function () {
            var selectedrowindex = $(gridCon).jqxGrid('getselectedrowindex');
            var dataRecord = $(gridCon).jqxGrid('getrowdata', selectedrowindex);
            return dataRecord;
        },
        init: function () {
            _addHandlers();
            _Validaciones();
            _createElements();
            idSubSeries = $.getUrlVar('idSubSerie');
            if (idSubSeries != null) {
                _Abrir(idSubSeries);
            } else {
                limpiar();
            }

        }
    };
}());




$(function () {
    byaSite.SetModuloP({ TituloForm: "SubSeries", Modulo: "Consulta de SubSeries", urlToPanelModulo: "GesSubSeries.aspx", Cod_Mod: "GESDOC", Rol: "AD_SUB" });
    SubSeries.config.theme = byaSite.tema
    SubSeries.init();


});
