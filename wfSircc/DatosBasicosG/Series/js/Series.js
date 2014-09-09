var Series = (function () {
    "use strict";
    var urlToInsert = "/Servicios/Archivos/wsSeries.asmx/Insert";
    var urlToUpdate = "/Servicios/Archivos/wsSeries.asmx/Update";
    var urlToAbrir2 = "/Servicios/Archivos/wsSeries.asmx/GetSeries2";
    var byaRpta;
    var idSeries;
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
            $(msgPpal).msgBox({ titulo: "Actualizar Series", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
            if (!byaRpta.Error) {

            }
        });
    }
    var _Validaciones = function () {
       
    };   
    var MultiplesAjax = function () {

    }
    var _createElements = function () {       
        $("#TextIdSerie").byaFormatInput('0123456789');

    };
    var _Abrir = function (idSeries) {
      
       
        var parametrosJSON = { "idSeries": idSeries };
        $.ajax({
            type: "GET",
            url: urlToAbrir2,
            data: parametrosJSON,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,            
            success: function (result) {

                var ser = byaPage.retObj(result.d);
                if (ser != undefined) {
                    $('#TextIdSerie').val(ser.idSerie);
                    $('#TextSerie').val(ser.Serie);
                    $('#TextPro').val(ser.Procedimiento);
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
        var Ser = {};
        Ser.idSerie = $('#TextIdSerie').val();
        Ser.Serie = $('#TextSerie').val();
        Ser.Procedimiento = $("#TextPro").val();      
        return Ser;
    }
    var Insert = function () {

        var jsonData = "{'Reg':" + JSON.stringify(getDatos()) + "}";
        byaPage.POST_Sync(urlToInsert, jsonData, function (result) {
            byaRpta = byaPage.retObj(result.d);
            $(msgPpal).msgBox({ titulo: "Registrar Series", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
            if (!byaRpta.Error) {

            }
        });


    }
    var Controls = function () {
        $(msgPpal).html("");     
        $("#TextIdSerie").byaSetHabilitar(true);
        $("#TextSerie").byaSetHabilitar(true);
        $("#TextPro").byaSetHabilitar(true);
        $("#TextIdSerie").val("");
        $("#TextSerie").val("");
        $("#TextPro").val("");
        Editar = "No";

    };
    var limpiar = function () {
        $("#TextIdSerie").byaSetHabilitar(false);
        $("#TextSerie").byaSetHabilitar(false);
        $("#TextPro").byaSetHabilitar(false);
        $("#TextIdSerie").val("");
        $("#TextSerie").val("");
        $("#TextPro").val("");
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
            idSeries = $.getUrlVar('idSerie');
           
            if (idSeries != null) {
                _Abrir(idSeries);
            } else {
                limpiar();
            }
          
        }
    };
}());




$(function () {
    byaSite.SetModuloP({ TituloForm: "Series", Modulo: "Consulta Series", urlToPanelModulo: "GesSeries.aspx", Cod_Mod: "GESDOC", Rol: "AD_SER" });
    Series.config.theme = byaSite.tema
    Series.init();
  

});
