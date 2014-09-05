var SeriesList = (function () {
    "use strict";
    var grid = '#jqxgridHisto';
    var urlToGridSeries = "/Servicios/Archivos/wsSeries.asmx/GetSeries";
    var urlToAnular = "/Servicios/Archivos/wsSeries.asmx/Anular";
    var byaRpta;
    var msgPpal = "#LbMsg";
    var urlToNuevo="Series.aspx"
    var _addHandlers = function () {
        $("#nuevoButton").click(function () {
            byaPage.AbrirPagina(urlToNuevo);
        });
        $("#editarButton").click(function () {

            var dataRecord = SeriesList.getRecord();
            if (dataRecord != undefined) {
                var target = urlToNuevo + "?idSerie=" + dataRecord.idSerie;
                byaPage.AbrirPagina(target);
            } else { alert("Debe Selecionar una fila de la tabla");}
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
        var dataRecord = SeriesList.getRecord();
        if (dataRecord == undefined) {
            alert("Debe Selecionar Una Fila");
        }
        else {
            var jsonData = "{'Reg':" + JSON.stringify(dataRecord) + "}";
            byaPage.POST_Sync(urlToAnular, jsonData, function (result) {
                byaRpta = byaPage.retObj(result.d);
                SeriesList.refresh();
                $(msgPpal).msgBox({ titulo: "Anulación de Series", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
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
	                { name: 'idSerie', type: "String" },
                    { name: 'Serie' },
                    { name: 'Procedimiento' }
            ],
            async: true,
            record: 'Table',
            url: urlToGridSeries,
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
                theme: SeriesList.config.theme,
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
                  { text: 'Id Serie     ', datafield: 'idSerie' },
                  { text: 'Nombre Serie ', datafield: 'Serie' },
                  { text: 'Procedimiento Cesion', datafield: 'Procedimiento' }

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
    byaSite.SetModuloP({ TituloForm: "Consulta de Series", Modulo: "", urlToPanelModulo: "#", Cod_Mod: "", Rol: "" });   
    SeriesList.config.theme = byaSite.tema
    SeriesList.init();

});
