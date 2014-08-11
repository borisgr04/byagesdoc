var ModTer = (function () {
    var ventana = '#winTer';
    var grid = "#jqxgridTEr";
    var msgPopup = "#msgTer";
    var gridCon = '#jqxgridTer';
    var urlToGridCon = "/Servicios/DatosBasicosG/wsTerceros.asmx/Gets";

    //Creating the demo window
    function _createWindow() {
        $(ventana).jqxWindow({ autoOpen: false,
            showCollapseButton: true, maxHeight: 700, maxWidth: 900, minHeight: 300, minWidth: 200, height: 500, width: 750, isModal:true,
            theme: ModTer.config.theme
        });
    };
    //crea GridTipos
    function _createGridCon() {
        var source = {
            datatype: "xml",
            datafields: [
	                { name: 'terceroId', type: 'string' },
                    { name: 'nombre' }
                 ],
            async: false,
            record: 'Table',
            url: urlToGridCon
        };
        var cellsrendererNOM = function (row, column, value) {
            return '<div style="margin-left: 5px;margin-top: 5px; font-size: 11px">' + value + '</div>';
        }
        var cellsrendererIDE = function (row, column, value) {
            return '<div style="margin-left: 5px;margin-top: 5px; font-size: 11px">' + value + '</div>';

        }
        var dataAdapter = new $.jqx.dataAdapter(source, { contentType: 'application/json; charset=utf-8' });
        // initialize jqxGrid

        $(gridCon).jqxGrid(
                    {
                        width: 700,
                        source: dataAdapter,
                        theme: ModTer.config.theme,
                        localization: byaPage.getLocalization(),
                        height: 350,
                        sortable: true,
                        altrows: true,
                        showfilterrow: true,
                        filterable: true,
                        pageable: true,
                        enabletooltips: true,
                        
                        columns: [
                      { text: 'Identificación', datafield: 'terceroId', width: 150, cellsformat: 'd', cellsalign: 'right', filtertype: 'textbox' },
                      { text: 'Apellidos y Nombre', datafield: 'nombre', width: 550, cellsrenderer: cellsrendererNOM }
                    ]
                    });
        
        //rowselect
        $(gridCon).bind('rowdoubleclick', function (event) {
            var selectedRowIndex = event.args.rowindex;
            var datarow = {};
            var cell = $(gridCon).jqxGrid('getcell', selectedRowIndex, 'terceroId');
            datarow["terceroId"] = cell.value;
            var cell = $(gridCon).jqxGrid('getcell', selectedRowIndex, 'nombre');
            datarow["nombre"] = cell.value;
            ModTer.fnresultado(datarow);
            $(ventana).jqxWindow('close');
        });

    }
    return {
        id_ep: null,
        fnresultado: null,
        editedRows: null,
        config: {
            dragArea: null,
            theme: null
        },
        init: function () {
            _createWindow();
        },
        showWindow: function (fnresultado) {
            this.fnresultado = fnresultado;
            $(ventana).jqxWindow('open');
            _createGridCon();
        }
    };
} ());


$(function () {
    ModTer.config.theme = byaSite.tema;
    ModTer.init();
});
