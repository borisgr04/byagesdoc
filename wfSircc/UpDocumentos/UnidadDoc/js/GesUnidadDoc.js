

var GesUnidadDoc = (function () {
    "use strict";
    var gridCon = '#jqxgridHisto';
    var urlToAnular=  "/Servicios/Archivos/wsDocumentos.asmx/Anular";
    var urlToConsultas = "/Servicios/Archivos/wsDocumentos.asmx/Gets";
    var urlToNuevo = "UnidadDoc.aspx"
    var urlToTipos = "../../../DatosBasicosG/RelacionDocumental/GesRelacionDocumental.aspx"
    var byaRpta;
    var _addHandlers = function () {
        $("#nuevoButton").click(function () {
            byaPage.AbrirPagina(urlToNuevo);
        });
        $("#editarButton").click(function () {
            var dataRecord = GesUnidadDoc.getRecord();
            var target = urlToNuevo + "?Codigo=" + dataRecord.Codigo;
            byaPage.AbrirPagina(target);
        });
        $("#tiposButton").click(function () {
            var dataRecord = GesUnidadDoc.getRecord();
            var target = urlToTipos + "?Id=" + dataRecord.idUnidadDocumental;
            byaPage.AbrirPagina(target);
        });        
        $("#anularButton").click(function () {
            byaMsgBox.confirm("Desea Anular el Item Seleccionado?", function (result) {
                if (result) {
                    Anular();
                }
            });
        });
        
    };
    var _Validaciones = function () {



    };
    var Anular = function () {
        var dataRecord = GesUnidadDoc.getRecord();
        if (dataRecord == undefined)
        {
            alert("Debe Selecionar Una Fila");
        }
        else {
            var jsonData = "{'Reg':" + JSON.stringify(dataRecord) + "}";
            byaPage.POST_Sync(urlToAnular, jsonData, function (result) {
                byaRpta = byaPage.retObj(result.d);
                GesUnidadDoc.refresh();
                $(msgPpal).msgBox({ titulo: "Anulación de Documentos", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
                if (!byaRpta.Error) {

                }

            });
        }
    }
    var _createElements = function () {
        _createGrid();
    };
    var getDataAdapter = function () {
        var Filtro ="";
        var source = {

            datatype: "xml",
            datafields: [
	                { name: 'idUnidadDocumental' },
                    { name: 'Codigo' },
                    { name: 'Nombre' },
                    { name: 'PalabrasClave' },
                    { name: 'FechaCreacion', type: 'date' },
                    { name: 'Nombre_Sub' },
                    { name: 'NroFolioInicial' },
                    { name: 'NroFolioFinal' },
                    { name: 'EntidadProductora' },
                    { name: 'ArchivadorNo' },
                    { name: 'GabetaNo' },
                    { name: 'FechaExtInicial', type: 'date' },
                    { name: 'FechaExtFinal', type: 'date' },
                    { name: 'Vigencia' },
                    { name: 'Tema' },
                    { name: 'Estante' },
                    { name: 'SoporteFisico' ,type:'bool'},
                    { name: 'SoporteDigital', type: 'bool' },
                    { name: 'Frecuencia' },
                    { name: 'Identificacion' }

            ],
            async: true,
            record: 'Table',
            url: urlToConsultas,
            data: { 'Filtro': Filtro }
        };
        var dataAdapter = new $.jqx.dataAdapter(source, { contentType: 'application/json; charset=utf-8' });

        return dataAdapter;
    };
    var _createGrid = function () {

        var cellsrendererNOM = function (row, column, value) {
            return '<div style="margin-left: 5px;margin-top: 5px; font-size: 11px">' + value + '</div>';
        };

        $(gridCon).jqxGrid(
            {
                width: "100%",
                source: getDataAdapter(),
                theme: GesUnidadDoc.config.theme,
                localization: byaPage.getLocalization(),
                height: 350,
                sortable: true,
                altrows: true,
                showfilterrow: true,
                filterable: true,
                pageable: true,
                enabletooltips: true,                
                columns: [
                  { text: 'Codigo', datafield: 'Codigo', width: 140 },
                  { text: 'Tema    ', datafield: 'Tema', width: 150 },
                  { text: 'Nombre Documento', datafield: 'Nombre', width: 150 },
                  { text: 'Identificacion    ', datafield: 'Identificacion', width: 150 },
                  { text: 'Palabras Claves         ', datafield: 'PalabrasClave', width: 150 },
                  { text: 'Fecha de Creacion    ', datafield: 'FechaCreacion', columntype: 'datetimeinput', cellsformat: 'd',width:150 },
                  { text: 'Subserie        ', datafield: 'Nombre_Sub', width: 150 },
                  { text: 'Folio Inicial    ', datafield: 'NroFolioInicial', width: 100 },
                  { text: 'Folio Final    ', datafield: 'NroFolioFinal', width: 100 },
                  { text: 'Entidad Productora     ', datafield: 'EntidadProductora', width: 150 },
                  { text: 'N° Archivador', datafield: 'ArchivadorNo', width: 120 },
                  { text: 'N° Gabeta', datafield: 'GabetaNo', width: 100 },
                  { text: 'Fecha Ext Inicial        ', datafield: 'FechaExtInicial', columntype: 'datetimeinput', cellsformat: 'd', width: 150 },
                  { text: 'Fecha Ext Final        ', datafield: 'FechaExtFinal', columntype: 'datetimeinput', cellsformat: 'd', width: 150 },
                  { text: 'Vigencia    ', datafield: 'Vigencia', width: 90 },                  
                  { text: 'Estante    ', datafield: 'Estante', width: 90 },
                  { text: 'SoporteFisico    ', datafield: 'SoporteFisico', width: 150, threestatecheckbox: false, columntype: 'checkbox' },
                  { text: 'SoporteDigital    ', datafield: 'SoporteDigital', width: 150, threestatecheckbox: false, columntype: 'checkbox' },
                  { text: 'Frecuencia    ', datafield: 'Frecuencia', width: 90}
                  
                 
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
            var selectedrowindex = $(gridCon).jqxGrid('getselectedrowindex');
            var dataRecord = $(gridCon).jqxGrid('getrowdata', selectedrowindex);
            return dataRecord;
        },
        refresh: function () {
            $(grid).jqxGrid({ source: getDataAdapter() });
        },

        init: function () {
            _addHandlers();
            _Validaciones();
            _createElements();
            //   _HabilitarE();


        }
    };


}());



$(function () {
    byaSite.SetModuloP({ TituloForm: "Consulta Documental", Modulo: "Documentos", urlToPanelModulo: "GesUnidadDoc.aspx", Cod_Mod: "DOCU", Rol: "DOCU_UNI" });

    GesUnidadDoc.config.theme = byaSite.tema
    GesUnidadDoc.init();
});
