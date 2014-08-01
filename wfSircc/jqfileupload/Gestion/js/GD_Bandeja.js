var Pag = (function () {
    "use strict";
    var tema;
    var codCon;
    var urlModulo     = "/ControlPagos/Contabilidad/Panel.aspx";
    var TituloModulo  = "Gestión de Documentos";
    var TituloForm    = "Bandeja de Entrada <small > Gestión de Documentos</small>";
    var urlToGridCon = "/Servicios/wsGD_Documentos.asmx/GetBandeja";

    var urlToUpdateRpOp = "/Servicios/wsControlPagosC.asmx/UpdateRpOp";

    var gridCon = '#jqxgrid';

    var urlToSfOp = "/Servicios/wsFinanciero.asmx/GetOp";

    //var urlToGuardarNuevo = "/Servicios/wsContratosGestionS.asmx/InsertActaParcialIM";
    //var urlToGuardarMod = "/Servicios/wsContratosGestionS.asmx/UpdatePSolicitud";
    
    var msgPpal = "#LbMsg";
    
    var byaRpta;
    var jsonData;
    var ejecutar;
    var dataAdapter;
    //Adding event listeners
    var _addHandlers = function () {
        $("#BtnTramitar").click(function (event) {
            _guardarTramitar();
        });
        $(gridCon).on('cellvaluechanged', function (event) {

            var column = args.datafield; var row = args.rowindex;
            var value = args.newvalue; var oldvalue = args.oldvalue;
            
            // @param bound index. Bound index is the row's index in the array returned by the "getboundrows" method.
            var rowid = $(gridCon).jqxGrid('getrowid', row);
            // @param row id
            var data = $(gridCon).jqxGrid('getrowdatabyid', rowid);
            var Source = byaPage.retObj(byaPage.getSource(urlToSfOp, { nro_op: value, vigencia: byaSite.getVigencia() }));
            if (Source != null) {
                data.VAL_OP = Source.VAL_TOTAL;
                data.FEC_OP =byaPage.converJSONDate(Source.FEC_APROBACION);
                var value = $(gridCon).jqxGrid('updaterow', rowid, data);
            }
            
        });
};
    
    var _guardarTramitar = function () {
        var rows = $(gridCon).jqxGrid('getboundrows');
        jsonData = "{'lst':" + JSON.stringify(rows) + ",id_ctrdoc:" + Pag.getIdCtrDoc() + "}";
        byaPage.POST_Sync(urlToUpdateRpOp, jsonData, function (result) {
            byaRpta = byaPage.retObj(result.d);
            if (!byaRpta.Error) {
                $(msgPpal).msgBox({ titulo: "Recepción de Documentos", mensaje: byaRpta.Mensaje + " N°: <b>" + byaRpta.id + "</b>", tipo: !byaRpta.Error });
                Pag.editedRows.splice(0, Pag.editedRows.length);
                Abrir();
            } else {
                $(msgPpal).msgBox({ titulo: "Recepción de Documentos", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
            }
        });
    };
  
    var _cancelar = function () {
        byaMsgBox.confirm("Desea cancelar el proceso?", function (result) {
            if (result) {
                Pag.config.oper = 'cancelar';
                _reset();
            }
        });
    };
    var Abrir = function () {
        _createGridCon();
    };
    
    var _iniElements = function () {
       var user = Pag.getUser();
       codCon = Pag.getCodCon();
       _createGridCon();
       
   };
    var _createElements = function () {
       codCon = Pag.getCodCon();
       $("#HeadRutaModulo").html("<a href='" + urlModulo + codCon + "'><i class='icon-dashboard'></i>" + TituloModulo + "</a>");
       $("#HeadRutaPagina").html("<i class='icon-file-alt'></i>" + TituloForm);
       $("#TituloForm").html(TituloForm);
       tema = Pag.config.theme;
    };
  
    var _createGridCon = function () {
        var source = {
            datatype: "xml",
            datafields: [
	                { name: 'ID' },
                    { name: 'NOMBRE' },
                    { name: 'LONGITUD', type: 'number' },
                    { name: 'TYPE' },
                    { name: 'FEC_REG', type: 'date' },
                    { name: 'ESTADO' }
            ],
            updaterow: function (rowid, rowdata, commit) {
                var rowindex = $(gridCon).jqxGrid('getrowboundindexbyid', rowid);
                Pag.editedRows.push({ index: rowindex, data: rowdata });
                commit(true);
            },
            pagesize: 20,
            async: false,
            record: 'Table',
            url: urlToGridCon
        };
        //data: { 'IdGD': IdGD }
        var cellclass = function (row, datafield, value, rowdata) {
            for (var i = 0; i < Pag.editedRows.length; i++) {
                if (Pag.editedRows[i].index == row) {

                    return "editedRow";
                }
            }
        };
        dataAdapter = new $.jqx.dataAdapter(source, { contentType: 'application/json; charset=utf-8' });
        // initialize jqxGrid  selectionmode:'singlecell',

        /*showfilterrow: true,
        filterable: true,
        showstatusbar: true,*/
        $(gridCon).jqxGrid(
                    {
                        width: '100%',
                        source: dataAdapter,
                        theme: Pag.config.theme,
                        localization: byaPage.getLocalization(),
                        sortable: true,
                        altrows: true,
                        enabletooltips: true,
                        editable: true,
                        editmode: byaPage.editGrid,
                        pageable: true,
                        columnsresize: true,
                        columns: [
                        { text: 'ID', datafield: 'ID', width: 30, editable: false },
                        { text: 'NOMBRE', datafield: 'NOMBRE', editable: false },
                        { text: 'LONGITUD', datafield: 'LONGITUD', width: 100, columntype: 'numberinput', cellsalign: 'right', cellsformat: 'n2', cellclassname: cellclass, editable: Pag.editarOp  },
                        
                        ]
                    });
        //{ text: 'FEC_REG', datafield: 'FEC_REG', width: 150, columntype: 'datetimeinput', cellsformat: 'd', cellclassname: cellclass, editable: Pag.editarOp }
        //{ text: 'TYPE', datafield: 'TYPE', width: 80, editable: false },
    };
    // display selected row index.
    $(gridCon).on('rowselect', function (event) {
        var row = args.rowindex;
        $("#selectrowindex").text(event.args.rowindex);
    // @param bound index. Bound index is the row's index in the array returned by the "getboundrows" method.
        var rowid = $(gridCon).jqxGrid('getrowid', row);
        // @param row id
        var data = $(gridCon).jqxGrid('getrowdatabyid', rowid);
        cambiarPDF(data.ID);
        $("#InfoFile").html("<b>"+data.NOMBRE + "</b>,Tamaño:" + data.LONGITUD + ",Tipo de Contenido:" + data.TYPE);
    });
    var cambiarPDF = function (i) {
        var url = 'http://localhost:1476/ashx/ashxDoc.ashx?id=' + i + '#toolbar=0';
        var doc = "<embed src='" + url + "' width='500' height='375'>";
        $('#dvdemb').html(doc);
    };
    
   return {
       formulario: '#form1',
       editedRows: null,
       editarOp:false,
       config: {
           theme: null,
           oper: null
       },
       getCodCon: function () {
           return $.getUrlVar('cod_con');
       },
       getUser: function () {
           return byaSite.getUsuario();
       },
       init: function () {
           this.editedRows = new Array();
           _createElements();
           _addHandlers();
           _iniElements();
       }
     
   }
} ());


$(document).ready(function () {
    Pag.config.theme = byaSite.tema;
    Pag.init();
});
