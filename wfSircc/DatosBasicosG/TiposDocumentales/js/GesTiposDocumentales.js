var TiposDocumentalesList = (function () {
    "use strict";
    var grid = '#jqxgridHisto';
    var urlToGrid = "/Servicios/Archivos/wsTiposDocumentales.asmx/Gets";
    var urlToAnular = "/Servicios/Archivos/wsTiposDocumentales.asmx/Anular";
    var byaRpta;
    var msgPpal = "#LbMsg";
    var urlToNuevo = "TiposDocumentales.aspx"
    var _addHandlers = function () {
        $("#nuevoButton").click(function () {
            byaPage.AbrirPagina(urlToNuevo);
        });
        $("#editarButton").click(function () {

            var dataRecord = TiposDocumentalesList.getRecord();
            if (dataRecord != undefined) {
                var target = urlToNuevo + "?idTipDocumentales=" + dataRecord.idTipDocumentales;
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
        var dataRecord = TiposDocumentalesList.getRecord();
        if (dataRecord == undefined) {
            alert("Debe Selecionar Una Fila");
        }
        else {
            var jsonData = "{'Reg':" + JSON.stringify(dataRecord) + "}";
            byaPage.POST_Sync(urlToAnular, jsonData, function (result) {
                byaRpta = byaPage.retObj(result.d);
                TiposDocumentalesList.refresh();
                $(msgPpal).msgBox({ titulo: "Anulación de Tipos Documentales", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
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
	                { name: 'idTipDocumentales', type: "String" },
                    { name: 'Nombe' },
                    { name: 'TD_Original' },
                    { name: 'TD_Copia' },
                    { name: 'SubSerieId' }
                 
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
                theme: TiposDocumentalesList.config.theme,
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
                  { text: 'Id', datafield: 'idTipDocumentales', width: 250 },
                  { text: 'Nombre  ', datafield: 'Nombe', width: 250 },
                  { text: 'TD_Original', datafield: 'TD_Original', width: 200 },
                  { text: 'TD_Copia', datafield: 'TD_Copia', width: 200 },
                  { text: 'SubSerieId', datafield: 'SubSerieId', width: 250 }



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
    byaSite.SetModuloP({ TituloForm: "Consulta de Tipos Documentales", Modulo: "Datos Basicos", urlToPanelModulo: "GesTiposDocumentales.aspx", Cod_Mod: "GESDOC", Rol: "GESDOC_TIP" });
    TiposDocumentalesList.config.theme = byaSite.tema
    TiposDocumentalesList.init();

});
