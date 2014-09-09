var SubSeriesList = (function () {
    "use strict";
    var grid = '#jqxgridHisto';
    var urlToGrid = "/Servicios/Archivos/wsSubSeries.asmx/Gets";
    var urlToAnular = "/Servicios/Archivos/wsSubSeries.asmx/Anular";
    var byaRpta;
    var msgPpal = "#LbMsg";
    var urlToNuevo = "SubSeries.aspx"
    var _addHandlers = function () {
        $("#nuevoButton").click(function () {
            byaPage.AbrirPagina(urlToNuevo);
        });
        $("#editarButton").click(function () {

            var dataRecord = SubSeriesList.getRecord();
            if (dataRecord != undefined) {
                var target = urlToNuevo + "?idSubSerie=" + dataRecord.idSubSeries;
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
        var dataRecord = SubSeriesList.getRecord();
        if (dataRecord == undefined) {
            alert("Debe Selecionar Una Fila");
        }
        else {
            var jsonData = "{'Reg':" + JSON.stringify(dataRecord) + "}";
            byaPage.POST_Sync(urlToAnular, jsonData, function (result) {
                byaRpta = byaPage.retObj(result.d);
                SubSeriesList.refresh();
                $(msgPpal).msgBox({ titulo: "Anulación de SubSeries", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
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
	                { name: 'idSubSeries', type: "String" },
                    { name: 'SubSerie' },
                    { name: 'RetencionAG' },
                    { name: 'DisposicionA' },
                    { name: 'DisposicionCT' },
                    { name: 'DisposicionE' },
                    { name: 'DisposicionMD' },
                    { name: 'DisposicionS' },
                    { name: 'Series_idSerie' }
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
                theme: SubSeriesList.config.theme,
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
                  { text: 'Id', datafield: 'idSubSeries', width: 150 },
                  { text: 'Nombre Serie ', datafield: 'SubSerie', width: 200 },
                  { text: 'RetencionAG', datafield: 'RetencionAG', width: 150 },
                  { text: 'DisposicionA', datafield: 'DisposicionA', width: 150 },
                  { text: 'DisposicionCT', datafield: 'DisposicionCT', width: 150 },
                  { text: 'DisposicionE', datafield: 'DisposicionE', width: 150 },
                  { text: 'DisposicionMD', datafield: 'DisposicionMD', width: 150 },
                  { text: 'DisposicionS', datafield: 'DisposicionS', width: 150 },
                  { text: 'Series_idSerie ', datafield: 'Series_idSerie', width: 150 },
               
              

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
    byaSite.SetModuloP({ TituloForm: "Consulta de SubSeries", Modulo: "Datos Basicos", urlToPanelModulo: "GesSubSeries.aspx", Cod_Mod: "GESDOC", Rol: "GESDOC_SUB" });
    SubSeriesList.config.theme = byaSite.tema
    SubSeriesList.init();

});
