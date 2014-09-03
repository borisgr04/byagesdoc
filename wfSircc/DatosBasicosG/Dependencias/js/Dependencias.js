﻿var Dependencias = (function () {
    "use strict";
    var urlToInsert = "/Servicios/Archivos/wsDependencias.asmx/Insert";
    var urlToUpdate = "/Servicios/Archivos/wsDependencias.asmx/Update";
    var urlToAbrir2 = "/Servicios/Archivos/wsDependencias.asmx/Get";
    var byaRpta;
    var idDependencia;
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
            limpiar();
        });



    };
    var Update = function () {
        var jsonData = "{'Reg':" + JSON.stringify(getDatos()) + "}";
        byaPage.POST_Sync(urlToUpdate, jsonData, function (result) {
            byaRpta = byaPage.retObj(result.d);
            $(msgPpal).msgBox({ titulo: "Actualizar Dependencias", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
            if (!byaRpta.Error) {

            }
        });
    }
    var _Validaciones = function () {

    };
    var MultiplesAjax = function () {

    }
    var _createElements = function () {
        // $("#TextIdSerie").byaFormatInput('0123456789');      

    };
    var _Abrir = function (idDependencia) {

        var parametrosJSON = { "Dependencia": idDependencia };
        $.ajax({
            type: "GET",
            url: urlToAbrir2,
            data: parametrosJSON,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (result) {

                var Dep = byaPage.retObj(result.d);
                if (Dep != undefined) {
                    $('#TextIdDependencia').val(Dep.idDependencia);
                    $('#TextDependencia').val(Dep.Dependencia);                   
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
        var Dep = {};
        Dep.idDependencia = $('#TextIdDependencia').val();
        Dep.Dependencia = $('#TextDependencia').val();
       
        return Dep;
    }
    var Insert = function () {

        var jsonData = "{'Reg':" + JSON.stringify(getDatos()) + "}";
        byaPage.POST_Sync(urlToInsert, jsonData, function (result) {
            byaRpta = byaPage.retObj(result.d);
            $(msgPpal).msgBox({ titulo: "Registrar Dependencias", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
            if (!byaRpta.Error) {

            }
        });


    }
    var Controls = function () {
        $(msgPpal).html("");
        $("#TextIdDependencia").byaSetHabilitar(true);
        $("#TextDependencia").byaSetHabilitar(true);       
        $("#TextIdDependencia").val("");
        $("#TextDependencia").val("");
       
        Editar = "No";

    };
    var limpiar = function () {
        $(msgPpal).html("");
        $("#TextIdDependencia").byaSetHabilitar(false);
        $("#TextDependencia").byaSetHabilitar(false);
        $("#TextIdDependencia").val("");
        $("#TextDependencia").val("");
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
            idDependencia = $.getUrlVar('idDependencia');

            if (idDependencia != null) {
                _Abrir(idDependencia);
            } else {
                limpiar();
            }

        }
    };
}());




$(function () {
    byaSite.SetModuloP({ TituloForm: "Series", Modulo: "", urlToPanelModulo: "#", Cod_Mod: "", Rol: "" });
    Dependencias.config.theme = byaSite.tema
    Dependencias.init();


});