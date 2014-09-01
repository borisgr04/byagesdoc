var Consultas = (function () {
    "use strict";
    var grid = '#jqxgridConsul';
    
    var urlToConsultas = "/Servicios/Archivos/wsDocumentos.asmx/Gets";
    
   

    var _addHandlers = function () {
        $("#BtnBuscar").click(function () {
            _createGrid();
        });
    };
    var _Validaciones = function () {



    };
 
    var _createElements = function () {
       
    };
    var getDataAdapter = function () {
        var Filtro = $("#TextFiltro").val();
        var source = {        
       
            datatype: "xml",
            datafields: [
	                { name: 'idUnidadDocumental' },
                    { name: 'Nombre' },
                    { name: 'PalabrasClave' },
                    { name: 'FechaCreacion', type: 'date' },
                    { name: 'idSubSeries' },
                    { name: 'NroFolios' },
                     { name: 'EntidadProductora' },
                    { name: 'ArchivadorNo'},
                    { name: 'GabetaNo' },
                    { name: 'FechaExtInicial', type: 'date' },
                    { name: 'FechaExtFinal', type: 'date' },
                    { name: 'DependenciaId' },


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

        $(grid).jqxGrid(
            {
                width: '100%',
                source: getDataAdapter(),
                theme: Consultas.config.theme,             
                localization: byaPage.getLocalization(),
                height: 200,
                sortable: true,
                altrows: true,
                showfilterrow: true,
                filterable: true,
                pageable: true,
                enabletooltips: true,
                columns: [
                  { text: 'Nombre Documento        ', datafield: 'Nombre' },
                  { text: 'Fecha Creacion  ', datafield: 'FechaCreacion', columntype: 'datetimeinput', cellsformat: 'd', align: 'right', cellsalign: 'right' },
                  { text: 'N° Folios    ', datafield: 'NroFolios' },                 
                  { text: 'N° Archivador', datafield: 'ArchivadorNo'},
                  { text: 'N° Gabeta', datafield: 'GabetaNo' },
               {
                   text: 'Selecionar', datafield: 'Selecionar', columntype: 'button', cellsrenderer: function () {
                       return "Selecionar";
                   }, buttonclick: function (row) {
                       // open the popup window when the user clicks a button.
                       var dataRecord = $(grid).jqxGrid('getrowdata', row);
                      
                       var prew = "<embed src='/Docs/BE/" + dataRecord.idUnidadDocumental + ".pdf' width='100%' height='375'>";
                       $("#kevin").html(prew);
                     
                   }
               }
                 
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
    byaSite.SetModuloP({ TituloForm: "Consulta Documental", Modulo: " Other Pages", urlToPanelModulo: "#", Cod_Mod: "ESPR4", Rol: "EP_CREAR" });
   
    Consultas.config.theme = byaSite.tema
    Consultas.init();
});
