﻿

var RelacionDocumentalList = (function () {
    "use strict";
    var grid = '#jqxgridHisto';
    var urlToGrid = "/Servicios/Archivos/wsRelacionDocumental.asmx/Gets";
    var urlToAnular = "/Servicios/Archivos/wsRelacionDocumental.asmx/Anular";
    var urlToNombreUnidad = "/Servicios/Archivos/wsDocumentos.asmx/GetID";
    var byaRpta;
    var msgPpal = "#LbMsg";
    var urlToNuevo = "RelacionDocumental.aspx"
    var IdDocumental;
    var _addHandlers = function () {
        $("#nuevoButton").click(function () {
            byaPage.AbrirPagina(urlToNuevo);
        });
        $("#editarButton").click(function () {

            var dataRecord = RelacionDocumentalList.getRecord();           
            if (dataRecord != undefined) {
                var target = urlToNuevo + "?IdUnidadDoc=" + dataRecord.IdUnidadDoc;
                byaPage.AbrirPagina(target);
            } else { alert("Debe Selecionar una fila de la tabla"); }
        });
        $("#anularButton").click(function () {
            byaMsgBox.confirm("Desea Anular el Item Seleccionado?", function (result) {
                if (result) {
                    Anular();
                }
            });
        });
        $("#vistaButton").click(function () {
           
            _verVentana();
        });

    };   
    var Anular = function () {
        var dataRecord = RelacionDocumentalList.getRecord();
        if (dataRecord == undefined) {
            alert("Debe Selecionar Una Fila");
        }
        else {
            var jsonData = "{'Reg':" + JSON.stringify(dataRecord) + "}";
            byaPage.POST_Sync(urlToAnular, jsonData, function (result) {
                byaRpta = byaPage.retObj(result.d);
                RelacionDocumentalList.refresh();
                $(msgPpal).msgBox({ titulo: "Anulacion de Relaciones Documentales", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
                if (!byaRpta.Error) {

                }

            });
        }
    };
    var MultiplesAjax = function () {
        //Llamado de Items de Contratos
        var Reg = {};
        Reg.idUnidadDocumental = $.getUrlVar('Id');
        $.ajax({
            type: "GET",
            url: urlToNombreUnidad,
            data: { 'Reg': JSON.stringify(Reg) },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (result) {
                var result = (typeof result.d) == 'string' ? eval('(' + result.d + ')') : result.d;
                
                $("#TituloUnidad").html(result.Nombre);




            },
            error: function (jqXHR, status, error) {
                alert(error + "-" + jqXHR.responseText);
            }
        });




    };
    var _createElements = function () {
        _createGrid();
        MultiplesAjax();
    };
    var getDataAdapter = function () {
        var Reg = {};
        Reg.idUnidadDocumental = $.getUrlVar('Id');
        var source = {

            datatype: "xml",
            datafields: [
	                { name: 'IdUnidadDoc', type: "String" },
                    { name: 'NombreUnidadDoc', type: "String" },
                    { name: 'IdTipoDoc', type: "String" },
                    { name: 'NombreTipoDoc', type: "String" },
                    { name: 'Codigo', type: "String" },
                    { name: 'FechaDoc', type: "date" },
                    { name: 'PagIni' },
                    { name: 'CantidadPag' },
                    { name: 'Descripcion' }

            ],
            async: true,
            record: 'Table',
            url: urlToGrid,
            data: { 'Reg': JSON.stringify(Reg) }
        };
        var dataAdapter = new $.jqx.dataAdapter(source, { contentType: 'application/json; charset=utf-8' });
        return dataAdapter;
    };
    var _createGrid = function () {

        $(grid).jqxGrid(
            {
                width: '100%',
                source: getDataAdapter(),
                theme: RelacionDocumentalList.config.theme,
                altrows: true,
                editable: false,
                sortable: true,
                showfilterrow: true,
                autoheight: true,
                autorowheight: true,
                filterable: true,
                pageable: true,
                enabletooltips: true,
                localization: byaPage.getLocalization(),
                columns: [
                 
                  { text: 'Id Tipo Documental  ', datafield: 'IdTipoDoc', width: 150 },
                  { text: 'Nombre de Tipo Documental  ', datafield: 'NombreTipoDoc', width: 250 },
                  { text: 'Codido', datafield: 'Codigo', width: 200 },
                  { text: 'Fecha Documento', datafield: 'FechaDoc', columntype: 'datetimeinput', cellsformat: 'd', align: 'right', cellsalign: 'right' },
                  { text: 'Pagina Inicial', datafield: 'PagIni', width: 250 },
                  { text: 'Cantidad Paginas', datafield: 'CantidadPag', width: 200 },
                  { text: 'Id Unidad Documental', datafield: 'IdUnidadDoc', width: 250 },
                  { text: 'Descripciòn', datafield: 'Descripcion', width: 250 }




                ]
            });

    };
    var _cerrarVentana = function () {

        $('#modalTerceros').modal('hide');

    };
    var _verVentana = function () {
        $('#modalTerceros').modal('show');
        //var dataRecord = Consultas.getRecord();
        //var prew = "<embed src='../../Docs/OK/" + dataRecord.Codigo + ".pdf' width='100%' height='375'>";
        //$("#Pdf").html(prew);
    };
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
            var selectedrowindex = $(grid).jqxGrid('getselectedrowindex');
            var dataRecord = $(grid).jqxGrid('getrowdata', selectedrowindex);
            return dataRecord;
        },
        refresh: function () {
            $(grid).jqxGrid({ source: getDataAdapter() });
        },
        init: function () {
            _addHandlers();
            _createElements();


        }
    };

}());

$(function () {
    byaSite.SetModuloP({ TituloForm: "Consulta de Relacion Documental", Modulo: "Unidad Documental", urlToPanelModulo: "", Cod_Mod: "", Rol: "" });
    RelacionDocumentalList.config.theme = byaSite.tema
    RelacionDocumentalList.init();

});
