var Consultas = (function () {
    "use strict";
    var grid = '#jqxgridConsul';    
    var urlToConsultas = "/Servicios/Archivos/wsDocumentos.asmx/Gets";
    var urlToSubSeries = "/Servicios/Archivos/wsSubSeries.asmx/GetSubSeries";
    var urlToSubDependencias = "/Servicios/Archivos/wsDependencias.asmx/GetDependencias";
    var urlToTipos = "../../../DatosBasicosG/RelacionDocumental/GesRelacionDocumental.aspx";
    var urlToVigencias = "/Servicios/Archivos/wsVigencia.asmx/GetVigenciasCbo";
    var _addHandlers = function () {

        $("#tiposButton").click(function () {
            var dataRecord = Consultas.getRecord();
            var target = urlToTipos + "?Id=" + dataRecord.idUnidadDocumental;
            byaPage.AbrirPagina(target);
           
        });
        $("#BtnBuscar").click(function () {
          
            _createGrid();
            $("#Reporte").show();
            $("#Rotulo").show();
        });
        $("#BtnNuevo").click(function () {
           
            _verVentana();
        });
        Checks();

    };
    var ActualizarDataPicker = function () {
        var f = new Date();

        $("#TextFecDoc").datepicker({
            weekStart: 1,
            endDate: (f.getMonth() + 1) + "/" + f.getDate() + "/" + f.getFullYear(),
            todayHighlight: true,
            autoclose: true,
            format: 'mm/dd/yyyy',
        });
        $("#TextFextIni").datepicker({
            weekStart: 1,
            endDate: (f.getMonth() + 1) + "/" + f.getDate() + "/" + f.getFullYear(),
            todayHighlight: true,
            autoclose: true,
            format: 'mm/dd/yyyy',
        });
        $("#TextFextFin").datepicker({
            weekStart: 1,
            endDate: (f.getMonth() + 1) + "/" + f.getDate() + "/" + f.getFullYear(),
            todayHighlight: true,
            autoclose: true,
            format: 'mm/dd/yyyy',
        });

        $("#TextFecDocFin").datepicker({
            weekStart: 1,
            endDate: (f.getMonth() + 1) + "/" + f.getDate() + "/" + f.getFullYear(),
            todayHighlight: true,
            autoclose: true,
            format: 'mm/dd/yyyy',
        });
        $("#TextFextIniFin").datepicker({
            weekStart: 1,
            endDate: (f.getMonth() + 1) + "/" + f.getDate() + "/" + f.getFullYear(),
            todayHighlight: true,
            autoclose: true,
            format: 'mm/dd/yyyy',
        });
        $("#TextFextFin2").datepicker({
            weekStart: 1,
            endDate: (f.getMonth() + 1) + "/" + f.getDate() + "/" + f.getFullYear(),
            todayHighlight: true,
            autoclose: true,
            format: 'mm/dd/yyyy',
        });
    };
    var _Validaciones = function () {
        $("#Reporte").hide();
        $("#Rotulo").hide();
        $("#CboSubSeries").byaSetHabilitar(false);
        $("#CboDep").byaSetHabilitar(false);
        $("#TextFolios").byaSetHabilitar(false);
        $('#TextFoliosF').byaSetHabilitar(false);
        $("#TextCaja").byaSetHabilitar(false);
        $("#TextCarpeta").byaSetHabilitar(false);
        $("#TextEntidad").byaSetHabilitar(false);
        $("#TextFecDoc").byaSetHabilitar(false);
        $("#TextFextIni").byaSetHabilitar(false);
        $("#TextFextFin").byaSetHabilitar(false);
        $("#TextFecDocFin").byaSetHabilitar(false);
        $("#TextFextIniFin").byaSetHabilitar(false);
        $("#TextFextFin2").byaSetHabilitar(false);
        $("#TextEstante").byaSetHabilitar(false);
        $("#CboFrecuencia").byaSetHabilitar(false);
        $("#CboVigencia").byaSetHabilitar(false);

    };
    var Checks = function () {

        $("#CheckSubSeries").click(function () {
            if ($("#CheckSubSeries").is(':checked')) {
                $("#CboSubSeries").byaSetHabilitar(true);
            } else {
                $("#CboSubSeries").val("Seleccione");
                $("#CboSubSeries").byaSetHabilitar(false);
            }
        });
        $("#CheckDep").click(function () {
            if ($("#CheckDep").is(':checked')) {
                $("#CboDep").byaSetHabilitar(true);
            } else {
                $("#CboDep").val("Seleccione");
                $("#CboDep").byaSetHabilitar(false);
            }
        });
        $("#CheckFolios").click(function () {
            if ($("#CheckFolios").is(':checked')) {
                $("#TextFolios").byaSetHabilitar(true);
                $("#TextFoliosF").byaSetHabilitar(true);
            } else {
                $("#TextFolios").val("");
                $("#TextFoliosF").val("");
                $("#TextFolios").byaSetHabilitar(false);
                $("#TextFoliosF").byaSetHabilitar(false);
            }
        });
        $("#CheckCaja").click(function () {
            if ($("#CheckCaja").is(':checked')) {
                $("#TextCaja").byaSetHabilitar(true);
            } else {
                $("#TextCaja").val("");
                $("#TextCaja").byaSetHabilitar(false);
            }
        });
        $("#CheckCarpeta").click(function () {
            if ($("#CheckCarpeta").is(':checked')) {
                $("#TextCarpeta").byaSetHabilitar(true);
            } else {
                $("#TextCarpeta").val("");
                $("#TextCarpeta").byaSetHabilitar(false);
            }
        });
        $("#CheckEntidad").click(function () {
            if ($("#CheckEntidad").is(':checked')) {
                $("#TextEntidad").byaSetHabilitar(true);
            } else {
                $("#TextEntidad").val("");
                $("#TextEntidad").byaSetHabilitar(false);
            }
        });
        $("#CheckCreacion").click(function () {
            if ($("#CheckCreacion").is(':checked')) {
                $("#TextFecDoc").byaSetHabilitar(true);
                $("#TextFecDocFin").byaSetHabilitar(true);
            } else {
                $("#TextFecDoc").val("");
                $("#TextFecDoc").byaSetHabilitar(false);
                $("#TextFecDocFin").val("");
                $("#TextFecDocFin").byaSetHabilitar(false);
            }
        });
        $("#CheckInicial").click(function () {
            if ($("#CheckInicial").is(':checked')) {
                $("#TextFextIni").byaSetHabilitar(true);
                $("#TextFextIniFin").byaSetHabilitar(true);
            } else {
                $("#TextFextIni").val("");
                $("#TextFextIni").byaSetHabilitar(false);
                $("#TextFextIniFin").val("");
                $("#TextFextIniFin").byaSetHabilitar(false);
            }
        });
        $("#CheckFinal").click(function () {
            if ($("#CheckFinal").is(':checked')) {
                $("#TextFextFin").byaSetHabilitar(true);
                $("#TextFextFin2").byaSetHabilitar(true);
            } else {
                $("#TextFextFin").val("");
                $("#TextFextFin").byaSetHabilitar(false);
                $("#TextFextFin2").val("");
                $("#TextFextFin2").byaSetHabilitar(false);
            }
        });
        $("#CheckEstante").click(function () {
            if ($("#CheckEstante").is(':checked')) {
                $("#TextEstante").byaSetHabilitar(true);
            } else {
                $("#TextEstante").val("");
                $("#TextEstante").byaSetHabilitar(false);
            }
        });
        $("#CheckFrecuencia").click(function () {
            if ($("#CheckFrecuencia").is(':checked')) {
                $("#CboFrencuencia").byaSetHabilitar(true);
            } else {
                $("#CboFrencuencia").val("Seleccione");
                $("#CboFrencuencia").byaSetHabilitar(false);
            }
        });
        $("#CheckVigencia").click(function () {
            if ($("#CheckVigencia").is(':checked')) {
                $("#CboVigencia").byaSetHabilitar(true);
              
            } else {
                $("#CboVigencia").val("Seleccione");
                $("#CboVigencia").byaSetHabilitar(false);
               
            }
        });
      

    };
    var _createElements = function () {

        ActualizarDataPicker();
        var sourcePla = byaPage.getSource(urlToSubSeries);
        $("#CboSubSeries").byaCombo({ DataSource: sourcePla, Value: "idSubSeries", Display: "SubSerie" });
        var sourcePla = byaPage.getSource(urlToSubDependencias);
        $("#CboDep").byaCombo({ DataSource: sourcePla, Value: "idDependencia", Display: "Dependencia" });
        var sourcePla = byaPage.getSource(urlToVigencias);
        $("#CboVigencia").byaCombo({ DataSource: sourcePla, Value: "Vigencia", Display: "Vigencia" });
    };
    var getDataAdapter = function () {

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
                    { name: 'SoporteFisico', type: 'bool' },
                    { name: 'SoporteDigital', type: 'bool' },
                    { name: 'Frecuencia' },
                    { name: 'Identificacion' }


            ],
            async: true,
            record: 'Table',
            url: urlToConsultas,
            data: { 'Filtro': JSON.stringify(getDatos()) }
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
                  { text: 'Codigo', datafield: 'Codigo', width: 140 },
                  { text: 'Tema    ', datafield: 'Tema', width: 150 },
                  { text: 'Nombre Documento', datafield: 'Nombre', width: 150 },
                  { text: 'Identificacion    ', datafield: 'Identificacion', width: 150 },
                  { text: 'Palabras Claves         ', datafield: 'PalabrasClave', width: 150 },
                  { text: 'Fecha de Creacion    ', datafield: 'FechaCreacion', columntype: 'datetimeinput', cellsformat: 'd', width: 150 },
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
                  { text: 'Frecuencia    ', datafield: 'Frecuencia', width: 90 }
             
                 
                ]
            });

    };
    var getDatos = function () {
        var Cons = {};
        Cons.idSubSeries = $('#CboSubSeries').val();
        Cons.DependenciaId = $('#CboDep').val();
        Cons.NroFolioInicial = $('#TextFolios').val();
        Cons.NroFolioFinal = $('#TextFoliosF').val();
        Cons.GabetaNo = $('#TextCaja').val();
        Cons.ArchivadorNo = $("#TextCarpeta").val();
        Cons.EntidadProductora = $('#TextEntidad').val();
        Cons.FechaCreacion = $('#TextFecDoc').val();
        Cons.FechaExtInicial = $("#TextFextIni").val();
        Cons.FechaExtFinal = $('#TextFextFin').val();
        return Cons;
    };
    var _cerrarVentana = function () {

        $('#modalTerceros').modal('hide');
       
    };
    var _verVentana = function () {

        $('#modalTerceros').modal('show');
        var dataRecord = Consultas.getRecord();
      //  var prew = "<embed src='/ashx/ashxDoc.ashx?codigo="+dataRecord.Codigo + ' width='100%' height='375'>";
        var prew = "<embed src='../../Docs/OK/" + dataRecord.Codigo + ".pdf' width='100%' height='375'>";
        $("#Pdf").html(prew);
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
            _Validaciones();
            _createElements();
            //   _HabilitarE();


        }
    };


}());



$(function () {
    byaSite.SetModuloP({ TituloForm: "Consulta Documental", Modulo: "Documentos", urlToPanelModulo: "Consultas.aspx", Cod_Mod: "DOCU", Rol: "DOCU_CON" });
   
    Consultas.config.theme = byaSite.tema
    Consultas.init();
});
