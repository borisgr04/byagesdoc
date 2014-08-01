var GesUsuarios = (function () {
    "use strict";
    var tema;
    var filasxPagina=50;
    var urlModulo = "/Seguridad/GesUsuarios.aspx";
    var TituloModulo = "Seguridad";
    var TituloForm = "Gestión de Usuarios <small > Seguridad</small>";
    var gridCon = '#jqxgridSol';

    var urlToGridCon = "/Servicios/wsSecurity.asmx/GetUsuarios";
    var urlToGuardarNuevo = "/Servicios/wsSecurity.asmx/InsUsuarios";

    var urlToGuardarActivar = "/Servicios/wsSecurity.asmx/ActivarUsuario";
    var urlToGuardarInactivar = "/Servicios/wsSecurity.asmx/InactivarUsuario";
    var urlToGuardarDesbloquear = "/Servicios/wsSecurity.asmx/DesbloquearUsuario";
    var urlToGuardarForzarPass = "/Servicios/wsSecurity.asmx/Forzar_Cambio_Clave";
    var urlToGuardar;
    
    var urlToTercero = '/Servicios/wsDatosBasicos.asmx/GetvTercerosPk';
    var urlToDetContratos = "GesDetContratos.aspx";
    var urlToFiltro = '/Servicios/wsContratosGestionC.asmx/GetDepContratos';
    var urlToRoles = "PerfilxUsuario.aspx";
    
    var activarValidar = true;
    
    var _addHandlers = function () {
        $(".validar").blur(function () {
            _esValido();
        });
        $('#BtnConsulta').click(function () {
            //_createGridCon();
            
            $(gridCon).jqxGrid({ source: getDataSource() });
            
        });
        $('#BtnNuevo').click(function () {
            _nuevo();
        });
        $("#BtnClave").click(function () {
            _changePass();
        });
        $("#modalNuevo").on('shown.bs.modal', function () {
            $(this).find("[autofocus]:first").focus();
        });
        
        $('#BtnBuscar').click(function () {
            $('#modalNuevo').modal('hide');
            ModTer.showWindow(function (ter) {
                $("#txtNom").val(ter.NOMBRE);
                $("#txtIde").val(ter.IDE_TER);
                $('#modalNuevo').modal('show');
            });
           
        });
        $('#txtIde').change(function () {
            _changeId();
        });
        $("#BtnActivar").click(function () {
            _guardarActivar();
        });
        $("#BtnInactivar").click(function () {
            _guardarInactivar();
        });
        $("#BtnDesbloq").click(function () {
            _guardarDesbloquear();
        });
        $("#BtnRoles").click(function () {
            byaSite.AbrirPagina(urlToRoles+"?username=" + $("#txtIde").val()  );
        });
        $(gridCon).on('rowselect', function (event) {
            var row = event.args.rowindex;
            // @param row id
            var rowid = $(gridCon).jqxGrid('getrowid', row);
            var dataRecord = $(gridCon).jqxGrid('getrowdatabyid', rowid);
            
            $("#BtnActivar").byaSetHabilitar(dataRecord.ISAPPROVED == false);
            $("#BtnInactivar").byaSetHabilitar(dataRecord.ISAPPROVED == true);
            $("#BtnDesbloq").byaSetHabilitar(dataRecord.ISLOCKEDOUT == true);

            $("#BtnClave").byaSetHabilitar(true);
            $("#BtnRoles").byaSetHabilitar(true);
                 
            
            if (dataRecord.USERNAME == 'admin') {
                $("#BtnInactivar").byaSetHabilitar(false);
            }
            $("#txtIde").val(dataRecord.USERNAME);
        });
        
        $(gridCon).on('rowdoubleclick', function (event) {
            _Detalle();
        });
        
        $('#BtnGuardarNuevo').click(function () {
            _guardarNuevo();
        });

        

        
    };

    var _nuevo = function () {
        $("#txtIde").val('');
        $("#H1").text('Registro de Nuevo Usuario');
        $('#modalNuevo').modal('show');
        $("#txtIde").byaSetHabilitar(true);
        urlToGuardar = urlToGuardarNuevo;
    };
    var _changePass = function () {
        urlToGuardar = urlToGuardarForzarPass;
        $("#H1").text('Forzar Cambio de Contraseña');
        $("#txtIde").byaSetHabilitar(false);
        _changeId();
        $('#modalNuevo').modal('show');
    };
    var _changeId = function () {
        var source = byaPage.getSource(urlToTercero, { ide_ter: $('#txtIde').val() });
        if (source != null) {
            $('#txtNom').val(source.NOMBRE);
        }
        else {
            $('#txtNom').val("No encontrado");
        }
    };

    var _ocultarNuevo = function () {
        $('#modalNuevo').modal('hide');
    };

    var _guardarActivar = function () {
        var Reg = {};
        Reg.USERNAME = $("#txtIde").val();
        var jsonData = "{'Reg':" + JSON.stringify(Reg) + "}";
        byaPage.POST_Sync(urlToGuardarActivar, jsonData, function (result) {
                var byaRpta = byaPage.retObj(result.d);

                byaMsgBox.alert(byaRpta.Mensaje);

                _createGridCon();
                _ocultarNuevo();
            });
    };
    var _guardarInactivar = function () {
        var Reg = {};
        Reg.USERNAME = $("#txtIde").val();
        var jsonData = "{'Reg':" + JSON.stringify(Reg) + "}";
        byaPage.POST_Sync(urlToGuardarInactivar, jsonData, function (result) {
            var byaRpta = byaPage.retObj(result.d);

            byaMsgBox.alert(byaRpta.Mensaje);

            _createGridCon();
            _ocultarNuevo();
        });
    };
    var _guardarDesbloquear = function () {
        var Reg = {};
        Reg.USERNAME = $("#txtIde").val();
        var jsonData = "{'Reg':" + JSON.stringify(Reg) + "}";
        byaPage.POST_Sync(urlToGuardarDesbloquear, jsonData, function (result) {
            var byaRpta = byaPage.retObj(result.d);

            byaMsgBox.alert(byaRpta.Mensaje);

            _createGridCon();
            _ocultarNuevo();
        });
    };
    var _guardarNuevo = function () {
        var Reg = {};
        Reg.USERNAME = $("#txtIde").val();
        Reg.PASSWORD = $("#txtPassword1").val();
        Reg.PASSWORD2 = $("#txtPassword2").val();
        if (Reg.PASSWORD != Reg.PASSWORD2) {
            byaMsgBox.alert("Las Contraseñas no coinciden");
        } else {
            var jsonData = "{'Reg':" + JSON.stringify(Reg) + "}";

            byaPage.POST_Sync(urlToGuardar, jsonData, function (result) {
                var byaRpta = byaPage.retObj(result.d);
                
                byaMsgBox.alert(byaRpta.Mensaje);

                _createGridCon();
                _ocultarNuevo();
            });
        }
    };

    var _createElements = function () {
        $("#HeadRutaModulo").html("<a href='" + urlModulo + "'><i class='icon-dashboard'></i>" + TituloModulo + "</a>");
        $("#HeadRutaPagina").html("<i class='icon-file-alt'></i>" + TituloForm);
        $("#TituloForm").html(TituloForm);
        tema = GesUsuarios.config.theme;
        //var sourceFil = byaPage.getSource(urlToFiltro);
        //$("#CboFil").byaCombo({ DataSource: sourceFil, Value: "COD_DEP", Display: "NOM_DEP" });
    };

    var getDataSource = function () {
        var jsfiltro = { filtro: "'" + $("#txtFiltro").val() + "'" };
        var source = {
            datatype: "xml",
            datafields: [
                    { name: 'USERNAME' },
                    { name: 'TERCERO' },
                    { name: 'ISAPPROVED', type: 'bool' },
                    { name: 'ISLOCKEDOUT', type: 'bool' },
                    { name: 'LASTACTIVITYDATE', type: 'date' },
                    { name: 'LASTLOGINDATE', type: 'date' },
                    { name: 'LASTPASSWORDCHANGEDDATE', type: 'date' },
                    { name: 'LASTLOCKOUTDATE', type: 'date' },
                    { name: 'CREATEDATE', type: 'date' },
                    { name: 'FAILEDPWDATTEMPTCOUNT', type: 'number' },
                    { name: 'FAILEDPWDATTEMPTWINSTART', type: 'date' },
                    { name: 'FAILEDPWDANSWERATTEMPTWINSTART', type: 'date' }
            ],
            async: true,
            record: 'Table',
            pagesize: 20,
            url: urlToGridCon,
            data: jsfiltro
        };
        var dataAdapter = new $.jqx.dataAdapter(source, { contentType: 'application/json; charset=utf-8' });
        return dataAdapter;
    };

    //crea GridTipos
    var addfilter = function () {
        var filtergroup = new $.jqx.filter();
        var filter_or_operator = 1;
        var filtervalue = 'Beate';
        var filtercondition = 'contains';
        var filter1 = filtergroup.createfilter('stringfilter', filtervalue, filtercondition);
        filtervalue = 'Andrew';
        filtercondition = 'starts_with';
        var filter2 = filtergroup.createfilter('stringfilter', filtervalue, filtercondition);

        filtergroup.addfilter(filter_or_operator, filter1);
        filtergroup.addfilter(filter_or_operator, filter2);
        // add the filters.
        $("#jqxgrid").jqxGrid('addfilter', 'firstname', filtergroup);
        // apply the filters.
        $("#jqxgrid").jqxGrid('applyfilters');
    };

    var _esValido = function () {
        var error = false;
        if (activarValidar) {
            alert($("#txtPassword2").val() +","+ $("#txtPassword1").val())
            if ($("#txtPassword2").val() != $("#txtPassword1").val()) {
                $("#pw2").addClass("has-error");
                $("#pw1").addClass("has-error");
                $("#BtnGuardarNuevo").byaSetHabilitar(false);
                error = true;
            }
            else {
                $("#pw2").removeClass("has-error");
                $("#pw1").removeClass("has-error");
                $("#BtnGuardarNuevo").byaSetHabilitar(true);
            }
        }
        return error;
    };
    var _createGridCon = function () {
        
        $(gridCon).jqxGrid(
                    {
                        width: '100%',
                        source: getDataSource(),
                        theme: GesUsuarios.config.theme,
                        localization: byaPage.getLocalization(),
                        height: 600,
                        sortable: true,
                        showfilterrow: true,
                        altrows: true,
                        pageable: true,
                        filterable: true,
                        enabletooltips: true,
                        columns: [
                        { text: 'USERNAME', datafield: 'USERNAME', width: 150 },
                        { text: 'TERCERO', datafield: 'TERCERO', width: 150 },
                        { text: 'ACTIVO', datafield: 'ISAPPROVED', columntype: 'checkbox', filtertype: 'bool',  width: 150,  },
                        { text: 'BLOQUEADO', datafield: 'ISLOCKEDOUT',columntype: 'checkbox', filtertype: 'bool',  width: 150},
                        { text: 'ULT. ACTIVIDAD', datafield: 'LASTACTIVITYDATE', columntype: 'datetimeinput', cellsformat: 'd', width: 150 },
                        { text: 'FECHA CREACIÓN', datafield: 'CREATEDATE', columntype: 'datetimeinput', cellsformat: 'd', width: 150 },
                        { text: 'ULT. LOGIN', datafield: 'LASTLOGINDATE', columntype: 'datetimeinput', cellsformat: 'd', width: 150 },
                        { text: 'ULT. CAMBIO PASSWORD', datafield: 'LASTPASSWORDCHANGEDDATE', columntype: 'datetimeinput', cellsformat: 'd', width: 150 },
                        { text: 'ULT. BLOQUEO', datafield: 'LASTLOCKOUTDATE', columntype: 'datetimeinput', cellsformat: 'd', width: 150 },
                        { text: 'FAILEDPWDATTEMPTCOUNT', datafield: 'FAILEDPWDATTEMPTCOUNT', columntype: 'datetimeinput', cellsformat: 'd', width: 150 },
                        { text: 'FAILEDPWDATTEMPTWINSTART', datafield: 'FAILEDPWDATTEMPTWINSTART', columntype: 'datetimeinput', cellsformat: 'd', width: 150 },
                        { text: 'FAILEDPWDANSWERATTEMPTWINSTART', datafield: 'FAILEDPWDANSWERATTEMPTWINSTART', columntype: 'datetimeinput', cellsformat: 'd', width: 150 }
                        ]
                    });
        };
    return {
        editedRows: null,
        config: {
            theme: null
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
            _createElements();
            _addHandlers();
            _createGridCon();
        }
    };
} ());

$(function () {
    byaSite.SetModuloP({ TituloForm: "Panel de Administración", Modulo: "Seguridad", urlToPanelModulo: "PanelAdmin.aspx", Cod_Mod: "ADMI4", Rol: "AD_SEC_USUARIO" });
    GesUsuarios.config.theme = byaSite.tema;
    GesUsuarios.init();
});