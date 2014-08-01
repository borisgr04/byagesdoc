var PerfilxUsuario = (function () {
    "use strict";
    var tema;
    var filasxPagina=50;
    var urlModulo = "/Seguridad/GesUsuarios.aspx";
    var TituloModulo = "Seguridad";
    var TituloForm = "Gestión de Usuarios <small > Seguridad</small>";
    var gridCon = '#jqxgrid';

    var urlToGridCon = "/Servicios/wsSecurity.asmx/GetRoles";
    var urlToRoles = "/Servicios/wsSecurity.asmx/GetRolesJ";
    var urlToDetContratos = "GesDetContratos.aspx";
    var urlToFiltro = '/Servicios/wsContratosGestionC.asmx/GetDepContratos';
    var urlToGuardarRoles = "/Servicios/wsSecurity.asmx/GuardarRoles";
    var msgPpal = "#LbMsg";

    var _addHandlers = function () {
        $("#chkTodos").change(function () {
            var rows = $(gridCon).jqxGrid('getrows');
            var valor = $(this).is(':checked');
            $.each(rows, function (index, item) {
                item.hasRol = valor;
                 var value = $(gridCon).jqxGrid('updaterow', item.uid, item);
                
            });
        });

        $('#BtnConsulta').click(function () {
            _createGridCon();
        });
        
        $('#BtnGuardar').click(function () {
            _guardar();
        });

        
        $('#CboFil').change(function () {
            _createGridCon();
        });
        
        

    };

    var _createElements = function () {
        $("#HeadRutaModulo").html("<a href='" + urlModulo + "'><i class='icon-dashboard'></i>" + TituloModulo + "</a>");
        $("#HeadRutaPagina").html("<i class='icon-file-alt'></i>" + TituloForm);
        $("#TituloForm").html(TituloForm);
        $("#username").html(PerfilxUsuario.getUsername());
        tema = PerfilxUsuario.config.theme;
    };

    var _guardar = function () {
        var rows = $(gridCon).jqxGrid('getboundrows');
        var jsonData = "{'lst':" + JSON.stringify(rows) + ", 'UserName':'" + PerfilxUsuario.getUsername() + "'}";
        var byaRpta = {};
        byaPage.POST_Sync(urlToGuardarRoles, jsonData, function (result) {
            byaRpta = byaPage.retObj(result.d);
            if (!byaRpta.Error) {
                $(msgPpal).msgBox({ titulo: "Log de acciones de asginacíón", mensaje: byaRpta.Mensaje  + "</b>", tipo: !byaRpta.Error });
                //Acta.editedRows.splice(0, Acta.editedRows.length);
                Abrir();
            } else {
                $(msgPpal).msgBox({ titulo: "Log de acciones de asginacíón", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
            }
        });
    };

  
    //crea GridTipos
    var _createGridCon = function () {
        $(msgPpal).html('');
        var Mod = "'" + $("#CboFil").val() + "'";
        var JsonData={ Modulo: Mod, UserName:"'"+PerfilxUsuario.getUsername()+"'" };

        var source = {
            datatype: "xml",
            datafields: [
                    { name: 'hasRol', type: 'bool' },
                    { name: 'Modulo' },
                    { name: 'Titulo' },
                    { name: 'Roles' }
                    
            ],
            updaterow: function (rowid, rowdata, commit) {
                var rowindex = $(gridCon).jqxGrid('getrowboundindexbyid', rowid);
                PerfilxUsuario.editedRows.push({ index: rowindex, data: rowdata });
                commit(true);
            },
            async: true,
            record: 'Table',
            url: urlToGridCon,
            data: JsonData
        };
        //, 
        var dataAdapter = new $.jqx.dataAdapter(source, { contentType: 'application/json; charset=utf-8' });

        // initialize jqxGrid
        $(gridCon).jqxGrid(
                    {
                        source: dataAdapter,
                        width: '70%',
                        height: 500,
                        theme: PerfilxUsuario.config.theme,
                        localization: byaPage.getLocalization(),
                        editable: true,
                        columns: [
                            { text: 'Autorizado', datafield: 'hasRol', width: 150, columntype: 'checkbox' },
                            { text: 'Titulo', datafield: 'Titulo', editable: false }
                        ]
                    });
    };
    return {
        editedRows: null,
        config: {
            theme: null
        },
        getUsername: function () {
            return $.getUrlVar("username");
        },
        Vigencia: function () {
            return byaSite.getVigencia();
        },
        getRecord : function () {
            var selectedrowindex = $(gridCon).jqxGrid('getselectedrowindex');
            var dataRecord = $(gridCon).jqxGrid('getrowdata', selectedrowindex);
            return dataRecord;
        },
        init: function () {
            this.editedRows = new Array();
            _createElements();
            _addHandlers();
            _createGridCon();
        }
    };
} ());

$(function () {
    byaSite.SetModuloP({ TituloForm: "Asinación de Roles a Usuarios", Modulo: "Seguridad", urlToPanelModulo: "PanelAdmin.aspx", Cod_Mod: "ADMI4", Rol: "AD_SEC_USUARIO" });
    PerfilxUsuario.config.theme = byaSite.tema;
    PerfilxUsuario.init();
});