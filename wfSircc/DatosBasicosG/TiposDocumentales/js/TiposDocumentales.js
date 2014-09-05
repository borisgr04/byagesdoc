var TiposDocumentales = (function () {
    "use strict";
    var urlToInsert = "/Servicios/Archivos/wsTiposDocumentales.asmx/Insert";
    var urlToUpdate = "/Servicios/Archivos/wsTiposDocumentales.asmx/Update";
    var urlToAbrir2 = "/Servicios/Archivos/wsTiposDocumentales.asmx/Get";
    var urlToSubSeries = "/Servicios/Archivos/wsSubSeries.asmx/GetSubSeries";
    var byaRpta;
    var TiposDocumentales;
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
            $(msgPpal).msgBox({ titulo: "Actualizar TiposDocumentales", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
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
        var sourcePla = byaPage.getSource(urlToSubSeries);
        $("#CboSubSeries").byaCombo({ DataSource: sourcePla, Value: "idSubSeries", Display: "SubSerie" });
    };
    var _Abrir = function (TiposDocumentales) {
        var parametrosJSON = { "idTipoDocumentales": TiposDocumentales };
        $.ajax({
            type: "GET",
            url: urlToAbrir2,
            data: parametrosJSON,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (result) {

                var TipD = byaPage.retObj(result.d);             
                if (TipD != undefined) {
                    $('#TextIdDocumental').val(TipD.idTipDocumentales);
                    $('#TextNombre').val(TipD.Nombe);
                    $('#TextTdOriginal').val(TipD.TD_Original);
                    $('#TextTdCopia').val(TipD.TD_Copia);
                    $('#CboSubSeries').val(TipD.SubSerieId);
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
        var TipD = {};
        TipD.idTipDocumentales = $('#TextIdDocumental').val();
        TipD.Nombe = $('#TextNombre').val();
        TipD.TD_Original = $('#TextTdOriginal').val();
        TipD.TD_Copia = $('#TextTdCopia').val();
        TipD.SubSerieId = $('#CboSubSeries').val();
        return TipD;
    }
    var Insert = function () {

        var jsonData = "{'Reg':" + JSON.stringify(getDatos()) + "}";
        byaPage.POST_Sync(urlToInsert, jsonData, function (result) {
            byaRpta = byaPage.retObj(result.d);
            $(msgPpal).msgBox({ titulo: "Registrar TiposDocumentales", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
            if (!byaRpta.Error) {

            }
        });


    }
    var Controls = function () {
        $(msgPpal).html("");
        $('#TextIdDocumental').byaSetHabilitar(true);
        $('#TextNombre').byaSetHabilitar(true);
        $('#TextTdOriginal').byaSetHabilitar(true);
        $('#TextTdCopia').byaSetHabilitar(true);
        $('#CboSubSeries').byaSetHabilitar(true);
        $('#TextIdDocumental').val("");
        $('#TextNombre').val("");
        $('#TextTdOriginal').val("");
        $('#TextTdCopia').val("");
        $('#CboSubSeries').val("");
        Editar = "No";

    };
    var limpiar = function () {
        $('#TextIdDocumental').byaSetHabilitar(false);
        $('#TextNombre').byaSetHabilitar(false);
        $('#TextTdOriginal').byaSetHabilitar(false);
        $('#TextTdCopia').byaSetHabilitar(false); 
        $('#CboSubSeries').byaSetHabilitar(false);
        $('#TextIdDocumental').val("");
        $('#TextNombre').val("");
        $('#TextTdOriginal').val("");
        $('#TextTdCopia').val("");    
        $('#CboSubSeries').val("");
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
            TiposDocumentales = $.getUrlVar('idTipDocumentales');
            if (TiposDocumentales != null) {
                _Abrir(TiposDocumentales);
            } else {
                limpiar();
            }

        }
    };
}());




$(function () {
    byaSite.SetModuloP({ TituloForm: "TiposDocumentales", Modulo: "", urlToPanelModulo: "#", Cod_Mod: "", Rol: "" });
    TiposDocumentales.config.theme = byaSite.tema
    TiposDocumentales.init();


});
