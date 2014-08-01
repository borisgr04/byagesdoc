var Terceros = (function () {
    "use strict";
    var TituloForm = "Gestión de Terceros <small > Listado </small>";
    var gridCon = '#jqxgridSol';
    var urlToGridCon = "/Servicios/DatosBasicosG/wsTerceros.asmx/Gets";
    var urlToNuevo = "Terceros.aspx";
    var id;
    var idEP;

    var _addHandlers = function () {
        $('#BtnConsulta').click(function () {
            var rows = $(gridCon).jqxGrid('getboundrows');
        });
        $('#BtnNuevo').click(function () {
            byaPage.AbrirPagina(urlToNuevo);
        });
        $('#BtnEditar').click(function () {
            var dataRecord = Terceros.getRecord();
            byaPage.AbrirPagina(urlToNuevo + "?terceroId=" + dataRecord.terceroId);
        });
    };

    var _createElements = function () {
        $("#TituloForm").html(TituloForm);
//        var sourceDep = byaPage.getSource(urlToGetvDEPENDENCIAD);
//        $("#CboDepDel").byaCombo({ DataSource: sourceDep, Value: "COD_DEP", Display: "NOM_DEP", placeHolder: "Seleccione Dependencia" });
    };

    var getDataAdapter = function () {
        //var dep_sol = "'" + $("#CboDepDel").val() + "'";
        var source = {
            datatype: "xml",
            datafields: [
	                { name: 'terceroId' },
                    { name: 'tipodoc' },
                    { name: 'tipoper' },
                    { name: 'nombre' },
                    { name: 'direccion' },
                    { name: 'telefono' },
                    { name: 'correo' }
            ],
            async: true,
            record: 'Table',
            url: urlToGridCon
        };
        //,data: { 'dep_psol': dep_sol, 'Vig_Sol': Terceros.Vigencia() }

        var dataAdapter = new $.jqx.dataAdapter(source, { contentType: 'application/json; charset=utf-8' });
        //alert(JSON.stringify(dataAdapter));
        return dataAdapter;
    };
    //crea GridTipos
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
                        { text: 'Identificación ', datafield: 'terceroId', width: 150 },
                        { text: 'Tipo Documento', datafield: 'tipodoc', width: 150 },
                        { text: 'Tipo Persona', datafield: 'tipoper', width: 150 },
                        { text: 'Nombre/Razón Social', datafield: 'nombre', width: 150 },
                        { text: 'Dirección', datafield: 'direccion', width: 150 },
                        { text: 'Telefono', datafield: 'telefono', width: 150 },
                        { text: 'Correo', datafield: 'correo', width: 150 }
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
    byaSite.SetModuloP({ TituloForm: "Administración", Modulo: "Registro de Terceros", urlToPanelModulo: "Terceros.aspx", Cod_Mod: "ADMIN", Rol: "AD_TERC" });
    Terceros.config.theme = byaSite.tema
    Terceros.init();
});