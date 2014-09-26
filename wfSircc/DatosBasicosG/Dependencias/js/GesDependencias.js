var DepenList = (function () {
    "use strict";
    var grid = '#jqxgridHisto';
    var urlToGrid = "/Servicios/Archivos/wsDependencias.asmx/Gets";
    var urlToAnular = "/Servicios/Archivos/wsDependencias.asmx/Anular";
    var byaRpta;
    var msgPpal = "#LbMsg";
    var urlToNuevo = "Dependencias.aspx"
    var _addHandlers = function () {
        $("#nuevoButton").click(function () {
            byaPage.AbrirPagina(urlToNuevo);
        });
        $("#editarButton").click(function () {

            var dataRecord = DepenList.getRecord();
            if (dataRecord != undefined) {
                var target = urlToNuevo + "?idDependencia=" + dataRecord.idDependencia;
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
        var dataRecord = DepenList.getRecord();
        if (dataRecord == undefined) {
            alert("Debe Selecionar Una Fila");
        }
        else {
            var jsonData = "{'Reg':" + JSON.stringify(dataRecord) + "}";
            byaPage.POST_Sync(urlToAnular, jsonData, function (result) {
                byaRpta = byaPage.retObj(result.d);
                DepenList.refresh();
                $(msgPpal).msgBox({ titulo: "Anulación de Dependencias", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
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
	                { name: 'idDependencia', type: "String" },
                    { name: 'Dependencia' },
                    { name: 'Padre' }
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
                theme: DepenList.config.theme,
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
                  { text: 'Id Dependencia     ', datafield: 'idDependencia' },
                  { text: 'Nombre Dependencia ', datafield: 'Dependencia' },
                  { text: 'Seccion', datafield: 'Padre' }

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
    byaSite.SetModuloP({ TituloForm: "Registro de Dependencias", Modulo: "Datos Basicos", urlToPanelModulo: "GesDependencias.aspx", Cod_Mod: "GESDOC", Rol: "GESDOC_DEP" });
    DepenList.config.theme = byaSite.tema
    DepenList.init();

});
