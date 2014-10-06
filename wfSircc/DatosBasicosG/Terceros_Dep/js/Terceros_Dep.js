var Terceros_Dep = (function () {
    "use strict";
    var grid = '#jqxgridHisto';
    var urlToGrid = "/Servicios/Archivos/wsDependencias.asmx/Gets";
    var urlToTerceros = "/Servicios/DatosBasicosG/wsTerceros.asmx/Gets";
    var urlSourceTer = "/Servicios/DatosBasicosG/wsTerceros.asmx/Get";
    var urlToInsert = "/Servicios/DatosBasicosG/wsTerceros_Dep.asmx/Insert";
    var urlToUpdate = "/Servicios/DatosBasicosG/wsTerceros_Dep.asmx/Update";
    var urlToDep = "/Servicios/DatosBasicosG/wsTerceros_Dep.asmx/Gets";

    var byaRpta;
    var msgPpal = "#LbMsg";
    var Update = "No";
    var _addHandlers = function () {
        $("#nuevoButton").click(function () {
            nuevo();
        });
        $('#TxtIdeCon').blur(function () {
            Terceros_Dep.BuscarTercero($('#TxtIdeCon'), $('#TxtNomCon'));
        });
        $("#editarButton").click(function () {
            Update = "Si";                 
            MultiplesAjax();
        });
        $("#guardarButton").click(function () {
            if (Update == "No") {
                Insert();
            }
            else {
              
                Editar();
                MultiplesAjax();
            }
        });
        $("#cancelarButton").click(function () {
            Update = "No";
        });
        $("#BtnBuscCon").click(function () {

            ModTer.showWindow(function (ter) {
                $("#TxtNomCon").val(ter.nombre);
                $("#TxtIdeCon").val(ter.terceroId);
            });
         
        });

    };  
    var getDatos = function () {
        var ArrayTer_Dep = new Array();
        var datainformations = $(grid).jqxGrid("getdatainformation");
        var rowscounts = datainformations.rowscount;
        for (var i = 0; i < rowscounts; i++) {
            var dataRecord = $(grid).jqxGrid('getrowdata', i);
            if (dataRecord.Seleccionar == true) {
                var Ter_Dep = {};
                Ter_Dep.IdTerceros = $("#TxtIdeCon").val();
                Ter_Dep.IdDependencias = dataRecord.idDependencia;
                ArrayTer_Dep.push(Ter_Dep);
            }
        }
        return ArrayTer_Dep;

    };
    var nuevo = function () {
        Update = "No";
        $(msgPpal).html("");
        $("#TxtIdeCon").val("");
        $("#TxtNomCon").val("");
        Terceros_Dep.refresh();
    }
    var Insert = function () {

        var jsonData = "{'Reg':" + JSON.stringify(getDatos()) + "}";
        byaPage.POST_Sync(urlToInsert, jsonData, function (result) {
            byaRpta = byaPage.retObj(result.d);
            $(msgPpal).msgBox({ titulo: "Registrar Dependencias a Terceros", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
            if (!byaRpta.Error) {

            }
        });


    };
    var Editar = function () {

        var jsonData = "{'Reg':" + JSON.stringify(getDatos()) + "}";
        byaPage.POST_Sync(urlToUpdate, jsonData, function (result) {
            byaRpta = byaPage.retObj(result.d);
            $(msgPpal).msgBox({ titulo: "Actualizar Dependencias a Terceros", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
            MultiplesAjax();
            if (!byaRpta.Error) {

            }
        });


    };
    var MultiplesAjax = function () {
        //Llamado de Items de Contratos

        $.ajax({
            type: "GET",
            url: urlToDep,
            data: { 'IdTercero': $("#TxtIdeCon").val() },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (result) {
                var result = (typeof result.d) == 'string' ? eval('(' + result.d + ')') : result.d;
                $.each(result, function (i, item) {                  
                    var datainformations = $(grid).jqxGrid("getdatainformation");
                    var rowscounts = datainformations.rowscount;
                    for (var i = 0; i < rowscounts; i++) {
                        var dataRecord = $(grid).jqxGrid('getrowdata', i);
                        if (dataRecord.idDependencia == item) {                         
                            $("#jqxgridHisto").jqxGrid('setcellvaluebyid', i, "Seleccionar", true);
                        }
                    }
                });



               
            },
            error: function (jqXHR, status, error) {
                alert(error + "-" + jqXHR.responseText);
            }
        });


      

    };
    var _createElements = function () {
        _createGrid();
              ModTer.init();
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
                theme: Terceros_Dep.config.theme,
                altrows: true,
                editable: true,
                sortable: true,
                showfilterrow: true,
                autoheight: true,
                autorowheight: true,
                filterable: true,
                pageable: true,
                enabletooltips: true,
                localization: byaPage.getLocalization(),
                columns: [
                  { text: 'Id Dependencia     ', datafield: 'idDependencia', editable: false },
                  { text: 'Nombre Dependencia ', datafield: 'Dependencia', editable: false },
                  { text: 'Seccion', datafield: 'Padre', editable: false },
                  { text: 'Seleccionar', datafield: 'Seleccionar', columntype: 'checkbox' }

                ]
            });

    };
    var ModTer = (function () {
        "use strict";
        var msgPopup = "#msgTer";
        var gridCon = '#jqxgridTer';
        var urlToGridCon = "/Servicios/DatosBasicosG/wsTerceros.asmx/Gets";

        //crea GridTipos
        var _createGridCon = function () {
            var source = {
                datatype: "xml",
                datafields: [
                        { name: 'terceroId', type: 'number' },
                        { name: 'nombre' }
                ],
                async: true,
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

            $(gridCon).jqxGrid(
                        {
                            width: '100%',
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
                              { text: 'Identificación', datafield: 'terceroId', width: 150, cellsformat: 'd', cellsalign: 'right' },
                              { text: 'Apellidos y Nombre', datafield: 'nombre', cellsrenderer: cellsrendererNOM }
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
                _cerrarVentana();
            });

        };
        var _cerrarVentana = function () {

            $('#modalTerceros').modal('hide');
           
            //_createGridCon();
        };
        var _verVentana = function () {

            $('#modalTerceros').modal('show');
            //_createGridCon();
        };
        return {
            fnresultado: null,
            config: {
                theme: null
            },
            init: function () {
                this.config.theme = byaSite.tema;
                _createGridCon();
            },
            showWindow: function (fnresultado) {
                this.fnresultado = fnresultado;
                _verVentana();
            }
        };
    }());



    return {
        id_ep: null,
        fnresultado: null,
        editedRows: null,
        config: {
            dragArea: null,
            theme: null
        },
        BuscarTercero: function (txtIde, txtNom) {
            var tercerosId = txtIde.val();
            if (tercerosId != "") {
                var source = byaPage.getSource(urlSourceTer, { tercerosId: "'" + tercerosId + "'" });
                if (source == "0") {
                    txtNom.val("");
                }
                else {
                    txtNom.val(source.nombre);
                }
            }
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
    byaSite.SetModuloP({ TituloForm: "Registro de Dependencias a Terceros", Modulo: "Datos Basicos", urlToPanelModulo: "Terceros_Dep.aspx", Cod_Mod: "ADMIN", Rol: "AD_DB_TERD" });
    Terceros_Dep.config.theme = byaSite.tema
    Terceros_Dep.init();

});
