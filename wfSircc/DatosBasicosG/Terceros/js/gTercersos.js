var Terceros = (function () {
    "use strict";
    var TituloForm = "Gestión de Terceros <small > Listado </small>";
    var gridCon = '#jqxgridSol';
    var urlToGridCon = "/Servicios/DatosBasicosG/wsTerceros.asmx/Gets";
    var urlToConsultaInd = "/Servicios/DatosBasicosG/wsTerceros.asmx/Get";
    var urlToNuevo = "Terceros.aspx";
    var id;
    var idEP;

    var _addHandlers = function () {
        $('#BtnConsulta').click(function () {
            $(gridCon).jqxGrid({ source: getDataAdapterConsulta() });
        });
        $('#BtnNuevo').click(function () {
            byaPage.AbrirPagina(urlToNuevo);
        });
        $('#BtnEditar').click(function () {
            var dataRecord = Terceros.getRecord();
            byaPage.AbrirPagina(urlToNuevo + "?terceroId=" + dataRecord.terceroId);            
        });
        $('#BtnEditar2').click(function () {
            var id = $("#txtConsulta").val();
            byaPage.AbrirPagina(urlToNuevo + "?terceroId=" + id);
        });
     
    };

    var _createElements = function () {
        $("#TituloForm").html(TituloForm);
    };

    var getDataAdapter = function () {
        var source = {
            datatype: "xml",
            datafields: [
	                { name: 'terceroId', type: 'string'  },
                    { name: 'tipodoc' },
                    { name: 'tipoper' },
                    { name: 'nombre' },
                    { name: 'direccion' },
                    { name: 'telefono', type: 'string' },
                    { name: 'correo' },
                    { name: 'lugarexpe' }
            ],
            async: true,
            record: 'Table',
            url: urlToGridCon
            //data: { 'tercerosId': terid }
        };
        
        var dataAdapter = new $.jqx.dataAdapter(source, { contentType: 'application/json; charset=utf-8' });
        //alert(JSON.stringify(dataAdapter));
        return dataAdapter;
    };
    
    var getDataAdapterConsulta = function () {
        var terid = "'" + $("#txtConsulta").val() + "'";
        var source = {
            datatype: "xml",
            datafields: [
	                { name: 'terceroId', type: 'string' },
                    { name: 'tipodoc' },
                    { name: 'tipoper' },
                    { name: 'nombre' },
                    { name: 'direccion' },
                    { name: 'telefono', type: 'string' },
                    { name: 'correo' },
                    { name: 'lugarexpe' }
            ],
            async: true,
            record: 'Table',
            url: urlToConsultaInd,
            data: { tercerosId : terid }
        };
        
        var dataAdapter = new $.jqx.dataAdapter(source, { contentType: 'application/json; charset=utf-8' });
        return dataAdapter;
    };

    var _createGridCon = function () {
        $(gridCon).jqxGrid(
                    {
                        width: '100%',
                        source: getDataAdapter(),
                        theme: Terceros.config.theme,
                        localization: byaPage.getLocalization(),
                        height: 350,
                        sortable: true,
                        altrows: true,
                        showfilterrow: true,
                        filterable: true,
                        pageable: true,
                        enabletooltips: true,
                        columns: [
                        { text: 'Identificación ', datafield: 'terceroId', width: 130, filtertype: 'textbox' },
                        { text: 'Tipo Documento', datafield: 'tipodoc', width: 50 },
                        { text: 'Lugar expedicion', datafield: 'lugarexpe', width: 150 },
                        { text: 'Tipo Persona', datafield: 'tipoper', width: 50 },
                        { text: 'Nombre/Razón Social', datafield: 'nombre', width: 200 },
                        { text: 'Dirección', datafield: 'direccion', width: 150 },
                        { text: 'Telefono', datafield: 'telefono', width: 130, filtertype: 'textbox' },
                        { text: 'Correo', datafield: 'correo', width: 180 }
                        ]
                    });

    };

    return {
        id_ep: null,
        editedRows: null,
        config: {
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
            $(gridCon).jqxGrid({ source: getDataAdapter() });
        },
        init: function () {
            _createElements();
            _addHandlers();
            _createGridCon();
        }
    };
}());


$(function () {
    byaSite.SetModuloP({ TituloForm: "Administración", Modulo: "Registro de Terceros", urlToPanelModulo: "gTerceros.aspx", Cod_Mod: "ADMIN", Rol: "AD_TERC" });
    Terceros.config.theme = byaSite.tema;
    Terceros.init();
});