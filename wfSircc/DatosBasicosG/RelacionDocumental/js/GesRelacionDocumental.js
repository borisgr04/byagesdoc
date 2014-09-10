/// <reference path="../../../UpDocumentos/UnidadDoc/GesUnidadDoc.aspx" />
/// <reference path="../../../UpDocumentos/UnidadDoc/GesUnidadDoc.aspx" />
/// <reference path="../../../UpDocumentos/UnidadDoc/GesUnidadDoc.aspx" />
/// <reference path="../../../UpDocumentos/UnidadDoc/GesUnidadDoc.aspx" />
var RelacionDocumentalList = (function () {
    "use strict";
    var grid = '#jqxgridHisto';
    var urlToGrid = "/Servicios/Archivos/wsRelacionDocumental.asmx/Gets";
    var urlToAnular = "/Servicios/Archivos/wsRelacionDocumental.asmx/Anular";
    var byaRpta;
    var msgPpal = "#LbMsg";
    var urlToNuevo = "RelacionDocumental.aspx"
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
    }
    var _createElements = function () {
        _createGrid();
    };
    var getDataAdapter = function () {
        var source = {

            datatype: "xml",
            datafields: [
	                { name: 'IdUnidadDoc', type: "String" },
                    { name: 'IdTipoDoc', type: "String" },
                    { name: 'Codigo', type: "String" },
                    { name: 'FechaDoc', type: "date" },
                    { name: 'PagIni' },
                    { name: 'CantidadPag' },
                    { name: 'Descripcion' }

            ],
            async: true,
            record: 'Table',
            url: urlToGrid,
            data: {}
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
                  { text: 'Id Unidad Documental', datafield: 'IdUnidadDoc', width: 250 },
                  { text: 'Id Tipo Documental  ', datafield: 'IdTipoDoc', width: 250 },
                  { text: 'Codido', datafield: 'Codigo', width: 200 },
                  { text: 'Fecha Documento', datafield: 'FechaDoc', columntype: 'datetimeinput', cellsformat: 'd', align: 'right', cellsalign: 'right' },
                  { text: 'Pagina Inicial', datafield: 'PagIni', width: 250 },
                  { text: 'Cantidad Paginas', datafield: 'CantidadPag', width: 200 },
                  { text: 'Descripciòn', datafield: 'Descripcion', width: 250 }




                ]
            });

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
