var UnidadDoc = (function () {
    "use strict";
    var urlToInsert = "/Servicios/Archivos/wsDocumentos.asmx/Insert";
    var urlToUpdate = "/Servicios/Archivos/wsDocumentos.asmx/Update";   
    var urlToSubSeries = "/Servicios/Archivos/wsSubSeries.asmx/GetSubSeries";
    var urlToSubDependencias = "/Servicios/Archivos/wsDependencias.asmx/GetDependencias";
    var urlToAbrir = "/Servicios/Archivos/wsDocumentos.asmx/Get";
    var byaRpta;
    var Codigo;
    var msgPpal = "#LbMsg";
    var Editar = "No";
    var _addHandlers = function () {

        $("#nuevoButton").click(function () {          
            Controls();
        });
        $("#guardarButton").click(function () {
            if (Editar == "No") {
                Insert();
            } else {
                Update()
               

            }
        });
        $("#cancelarButton").click(function () {
            byaMsgBox.confirm("Desea cancelar el proceso?", function (result) {
                if (result) {
                    limpiar();
                }
            });
        });



    };
    var ActualizarDataPicker = function () {
        var f = new Date();

        $("#TextFecDoc").datepicker({
            weekStart: 1,
            endDate: (f.getMonth() + 1) + "/" + f.getDate() + "/" + f.getFullYear(),
            todayHighlight: true,
            autoclose: true,
            format: 'mm/dd/yyyy',
        });
        $("#TextFextIni").datepicker({
            weekStart: 1,
            endDate: (f.getMonth() + 1) + "/" + f.getDate() + "/" + f.getFullYear(),
            todayHighlight: true,
            autoclose: true,
            format: 'mm/dd/yyyy',
        });
        $("#TextFextFin").datepicker({
            weekStart: 1,
            endDate: (f.getMonth() + 1) + "/" + f.getDate() + "/" + f.getFullYear(),
            todayHighlight: true,
            autoclose: true,
            format: 'mm/dd/yyyy',
        });
    };
    var Update = function () {

        var jsonData = "{'Reg':" + JSON.stringify(getDatos()) + "}";
        byaPage.POST_Sync(urlToUpdate, jsonData, function (result) {
            byaRpta = byaPage.retObj(result.d);
            $(msgPpal).msgBox({ titulo: "Actualizacion de Documentos", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
            if (!byaRpta.Error) {

            }
        });
    }
    var _Validaciones = function () {
        Codigo = $.getUrlVar('Codigo');
        
        if (Codigo != null) {
            _Abrir(Codigo);
        } else {
            limpiar();
        }
    };
    var MultiplesAjax = function () {

    }
    var _createElements = function () {
        // $("#TextIdSerie").byaFormatInput('0123456789');      
        ActualizarDataPicker();
        var sourcePla = byaPage.getSource(urlToSubSeries);
        $("#CboSubSeries").byaCombo({ DataSource: sourcePla, Value: "idSubSeries", Display: "SubSerie" });
        var sourcePla = byaPage.getSource(urlToSubDependencias);
        $("#CboDependencia").byaCombo({ DataSource: sourcePla, Value: "idDependencia", Display: "Dependencia" });
    };
    var _Abrir = function (Codigo) {
        var Doc = {};
        Doc.Codigo = Codigo;
        var parametrosJSON = { "Reg": JSON.stringify(Doc) };
        $.ajax({
            type: "GET",
            url: urlToAbrir,
            data: parametrosJSON,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (result) {
                var cod = byaPage.retObj(result.d);
                if (cod != undefined) {
                $("#TextCodDoc").val(cod.Codigo);
                $("#TextNomDoc").val(cod.Nombre);
                $("#TextPal").val(cod.PalabrasClave);
                $("#TextFecDoc").val(byaPage.converJSONDateMDY(cod.FechaCreacion));
                $("#TextNfolios").val(cod.NroFolios);
                $("#CboSubSeries").byaSetHabilitar(false);
                $("#TextEntidad").val(cod.EntidadProductora);
                $("#TextArchivador").val(cod.ArchivadorNo);
                $("#TextGabeta").val(cod.GabetaNo);
                $("#TextFextIni").val(byaPage.converJSONDateMDY(cod.FechaExtInicial));
                $("#TextFextFin").val(byaPage.converJSONDateMDY(cod.FechaExtFinal));
                $("#CboDependencia").byaSetHabilitar(false);
                    Editar = "Si";
                } else
                {

                    Editar = "No";
                }

            },
            error: function (jqXHR, status, error) {
                alert(error + "-" + jqXHR.responseText);
            }
        });

    };
    var getDatos = function () {
        var Doc = {};
        Doc.Codigo= $("#TextCodDoc").val();
        Doc.Nombre = $("#TextNomDoc").val();
        Doc.PalabrasClave = $("#TextPal").val();
        Doc.FechaCreacion = $("#TextFecDoc").val();
        Doc.NroFolios = $("#TextNfolios").val();
        Doc.idSubSeries = $("#CboSubSeries").val();
        Doc.EntidadProductora = $("#TextEntidad").val();
        Doc.ArchivadorNo = $("#TextArchivador").val();
        Doc.GabetaNo = $("#TextGabeta").val();
        Doc.FechaExtInicial = $("#TextFextIni").val();
        Doc.FechaExtFinal = $("#TextFextFin").val();
        Doc.DependenciaId = $("#CboDependencia").val();
        return Doc;
    }
    var Insert = function () {

        var jsonData = "{'Reg':" + JSON.stringify(getDatos()) + "}";
        byaPage.POST_Sync(urlToInsert, jsonData, function (result) {
            byaRpta = byaPage.retObj(result.d);
            $(msgPpal).msgBox({ titulo: "Registro de Documentos", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
            if (!byaRpta.Error) {

            }
        });


    }
    var Controls = function () {
        $(msgPpal).html("");        
        $("#TextCodDoc").byaSetHabilitar(true);
        $("#TextNomDoc").byaSetHabilitar(true);
        $("#TextPal").byaSetHabilitar(true);
        $("#TextFecDoc").byaSetHabilitar(true);
        $("#TextNfolios").byaSetHabilitar(true);
        $("#CboSubSeries").byaSetHabilitar(true);
        $("#TextEntidad").byaSetHabilitar(true);
        $("#TextArchivador").byaSetHabilitar(true);
        $("#TextGabeta").byaSetHabilitar(true);
        $("#TextFextIni").byaSetHabilitar(true);
        $("#TextFextFin").byaSetHabilitar(true);
        $("#CboDependencia").byaSetHabilitar(true);
        $("#TextCodDoc").val("");
        $("#TextNomDoc").val("");
        $("#TextPal").val("");
        $("#TextFecDoc").val("");
        $("#TextNfolios").val("");
        $("#CboSubSeries").val("Selecione");
        $("#TextEntidad").val("");
        $("#TextArchivador").val("");
        $("#TextGabeta").val("");
        $("#TextFextIni").val("");
        $("#TextFextFin").val("");
        $("#CboDependencia").val("Selecione");
        Editar = "No";

    };
    var limpiar = function () {
        $("#TextCodDoc").val("");
        $("#TextNomDoc").val("");
        $("#TextPal").val("");
        $("#TextFecDoc").val("");
        $("#TextNfolios").val("");
        $("#CboSubSeries").val("Selecione");
        $("#TextEntidad").val("");
        $("#TextArchivador").val("");
        $("#TextGabeta").val("");
        $("#TextFextIni").val("");
        $("#TextFextFin").val("");
        $("#CboDependencia").val("Selecione");
    
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
           

        }
    };
}());




$(function () {
    byaSite.SetModuloP({ TituloForm: "Registro Unidad Documental", Modulo: "Consulta Unidad Documental", urlToPanelModulo: "GesUnidadDoc.aspx", Cod_Mod: "DOCU", Rol: "AD_UNI" });
    UnidadDoc.config.theme = byaSite.tema
    UnidadDoc.init();


});
