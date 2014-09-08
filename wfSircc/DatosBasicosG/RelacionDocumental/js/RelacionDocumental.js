var RelacionDocumental = (function () {
    "use strict";
    var urlToInsert = "/Servicios/Archivos/wsRelacionDocumental.asmx/Insert";
    var urlToUpdate = "/Servicios/Archivos/wsRelacionDocumental.asmx/Update";
    var urlToAbrir2 = "/Servicios/Archivos/wsRelacionDocumental.asmx/Get";
    var urlToTipoDoc = "/Servicios/Archivos/wsTiposDocumentales.asmx/GetsCbo";
    var urlToUnidadDocumental = "/Servicios/Archivos/wsDocumentos.asmx/GetsCbo";
    var byaRpta;
    var RelacionDocumental;
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
        $("#CboIdUnidad").change(function () {
            alert($('#CboIdUnidad').val());
        });



    };
    var Update = function () {
        var jsonData = "{'Reg':" + JSON.stringify(getDatos()) + "}";
        byaPage.POST_Sync(urlToUpdate, jsonData, function (result) {
            byaRpta = byaPage.retObj(result.d);
            $(msgPpal).msgBox({ titulo: "Actualizar RelacionDocumental", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
            if (!byaRpta.Error) {

            }
        });
    }
    var _Validaciones = function () {

    };
    var MultiplesAjax = function () {

    }
    var ActualizarDataPicker = function () {
        var f = new Date();

        $("#TextFecDoc").datepicker({
            weekStart: 1,
            endDate: (f.getMonth() + 1) + "/" + f.getDate() + "/" + f.getFullYear(),
            todayHighlight: true,
            autoclose: true,
            format: 'mm/dd/yyyy',
        });
    }
    var _createElements = function () {
        // $("#TextIdSerie").byaFormatInput('0123456789');      
        var sourcePla = byaPage.getSource(urlToTipoDoc);
        $("#CboIdTipoDoc").byaCombo({ DataSource: sourcePla, Value: "idTipDocumentales", Display: "Nombe" });
        var sourcePla2 = byaPage.getSource(urlToUnidadDocumental);
        $("#CboIdUnidad").byaCombo({ DataSource: sourcePla2, Value: "idUnidadDocumental", Display: "Nombre" });
        ActualizarDataPicker();
    };
    var _Abrir = function (RelacionDocumental) {
        var parametrosJSON = { "idUnidadD_TipoDoc": RelacionDocumental };
        $.ajax({
            type: "GET",
            url: urlToAbrir2,
            data: parametrosJSON,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (result) {

                var Rel = byaPage.retObj(result.d);                
                if (Rel != undefined) {
                    $('#CboIdUnidad').val(Rel.IdUnidadDoc);
                    $('#CboIdTipoDoc').val(Rel.IdTipoDoc);
                    $('#TextCodigo').val(Rel.Codigo);                
                    $('#TextFecDoc').val(Rel.FechaDoc);
                    $('#TextPaginaIni').val(Rel.PagIni);
                    $('#TextCantidad').val(Rel.CantidadPag);
                    $('#TextDescripcion').val(Rel.Descripcion);
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
        var Rel = {};  
        Rel.IdUnidadDoc = $('#CboIdUnidad').val();
        Rel.IdTipoDoc = $('#CboIdTipoDoc').val();
        Rel.Codigo = $('#TextCodigo').val();
        Rel.FechaDoc = $('#TextFecDoc').val();
        Rel.PagIni = $('#TextPaginaIni').val();
        Rel.CantidadPag = $('#TextCantidad').val();
        Rel.Descripcion = $('#TextDescripcion').val();
        return Rel;
    }
    var Insert = function () {

        var jsonData = "{'Reg':" + JSON.stringify(getDatos()) + "}";
        byaPage.POST_Sync(urlToInsert, jsonData, function (result) {
            byaRpta = byaPage.retObj(result.d);
            $(msgPpal).msgBox({ titulo: "Registrar RelacionDocumental", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
            if (!byaRpta.Error) {

            }
        });


    }
    var Controls = function () {
        $(msgPpal).html("");     
        $('#CboIdUnidad').byaSetHabilitar(true);
        $('#CboIdTipoDoc').byaSetHabilitar(true);
        $('#TextCodigo').byaSetHabilitar(true);
        $('#TextFecDoc').byaSetHabilitar(true);
        $('#TextPaginaIni').byaSetHabilitar(true);
        $('#TextCantidad').byaSetHabilitar(true);
        $('#TextDescripcion').byaSetHabilitar(true);
        $('#CboIdUnidad').val("");
        $('#CboIdTipoDoc').val("");
        $('#TextCodigo').val("");
        $('#TextFecDoc').val("");
        $('#TextPaginaIni').val("");
        $('#TextCantidad').val("");
        $('#TextDescripcion').val("");
        Editar = "No";

    };
    var limpiar = function () {
        $('#CboIdUnidad').byaSetHabilitar(false);
        $('#CboIdTipoDoc').byaSetHabilitar(false);
        $('#TextCodigo').byaSetHabilitar(false);
        $('#TextFecDoc').byaSetHabilitar(false);
        $('#TextPaginaIni').byaSetHabilitar(false);
        $('#TextCantidad').byaSetHabilitar(false);
        $('#TextDescripcion').byaSetHabilitar(false);
        $('#CboIdUnidad').val("");
        $('#CboIdTipoDoc').val("");
        $('#TextCodigo').val("");
        $('#TextFecDoc').val("");
        $('#TextPaginaIni').val("");
        $('#TextCantidad').val("");
        $('#TextDescripcion').val("");
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
            RelacionDocumental = $.getUrlVar('IdUnidadDoc');
            if (RelacionDocumental != null) {
                _Abrir(RelacionDocumental);
            } else {
                limpiar();
            }

        }
    };
}());




$(function () {
    byaSite.SetModuloP({ TituloForm: "TiposDocumentales", Modulo: "", urlToPanelModulo: "#", Cod_Mod: "", Rol: "" });
    RelacionDocumental.config.theme = byaSite.tema
    RelacionDocumental.init();


});
