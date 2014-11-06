var VigenciasList = (function () {
    "use strict";
    var grid = '#jqxgridHisto';
    var urlToGridVigencia = "/Servicios/Archivos/wsVigencia.asmx/GetVigencias";
    var urlToAnular = "/Servicios/Archivos/wsVigencia.asmx/Anular";
    var byaRpta;
    var msgPpal = "#LbMsg";
    var _addHandlers = function () {     
      
        $("#anularButton").click(function () {
            byaMsgBox.confirm("Desea Anular el Item Seleccionado?", function (result) {
                if (result) {
                    Anular();
                }
            });
        });


    };
    var Anular = function () {
        var dataRecord = VigenciasList.getRecord();
        if (dataRecord == undefined) {
            alert("Debe Selecionar Una Fila");
        }
        else {
            var jsonData = "{'Reg':" + JSON.stringify(dataRecord) + "}";
            byaPage.POST_Sync(urlToAnular, jsonData, function (result) {
                byaRpta = byaPage.retObj(result.d);
                VigenciasList.refresh();
                $(msgPpal).msgBox({ titulo: "Anulación de Vigencias", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
                if (!byaRpta.Error) {

                }

            });
        }
    };
    var _createElements = function () {
        _createGrid();
    };
    var getDataAdapter = function () {
        var source = {

            datatype: "xml",
            datafields: [
	                { name: 'Vigencia', type: "String" }
            ],
            async: true,
            record: 'Table',
            url: urlToGridVigencia,
            data: {}
        };
        var dataAdapter = new $.jqx.dataAdapter(source, { contentType: 'application/json; charset=utf-8' });
        return dataAdapter;
    };
    var _createGrid = function () {

        $(grid).jqxGrid(
            {
                width: '35%',
                source: getDataAdapter(),
                theme: VigenciasList.config.theme,
                altrows: true,
                editable: false,
                sortable: true,
                showfilterrow: true,
                autoheight: true,
                autorowheight: true,
                filterable: true,               
                enabletooltips: true,
                localization: byaPage.getLocalization(),
                columns: [
                  { text: 'Listado', datafield: 'Vigencia', width: 150 }

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
var Vigencia = (function () {
    "use strict";
    var urlToInsert = "/Servicios/Archivos/wsVigencia.asmx/Insert";   
    var byaRpta;
    var idSeries;
    var msgPpal = "#LbMsg";
  
    var _addHandlers = function () {

        $("#nuevoButton").click(function () {
            Controls();
        });
        $("#guardarButton").click(function () {          
                Insert();          
        });
        $("#cancelarButton").click(function () {
            byaMsgBox.confirm("Desea cancelar el proceso?", function (result) {
                if (result) {
                    limpiar();
                }
            });

        });



    };
   
    var _Validaciones = function () {

    };
    var MultiplesAjax = function () {

    }
    var _createElements = function () {
        $("#TextVigencia").byaFormatInput('0123456789');

    };
   
    var getDatos = function () {
        var Vig = {};
        Vig.Vigencia = $('#TextVigencia').val();       
        return Vig;
    }
    var Insert = function () {

        var jsonData = "{'Reg':" + JSON.stringify(getDatos()) + "}";
        byaPage.POST_Sync(urlToInsert, jsonData, function (result) {
            byaRpta = byaPage.retObj(result.d);
            VigenciasList.refresh();
            $(msgPpal).msgBox({ titulo: "Registrar Vigencias", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
            if (!byaRpta.Error) {

            }
        });


    }
    var Controls = function () {
        $(msgPpal).html("");
        $("#TextVigencia").byaSetHabilitar(true);       
        $("#TextVigencia").val("");      

    };
    var limpiar = function () {
        $("#TextVigencia").val("");
        $("#LbMsg").html("");
      
    }

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
        init: function () {
            _addHandlers();
            _Validaciones();
            _createElements();
           

        }
    };
}());




$(function () {
    byaSite.SetModuloP({ TituloForm: "Vigencias", Modulo: "Registro de Vigencias", urlToPanelModulo: "Vigencias.aspx", Cod_Mod: "GESDOC", Rol: "GES_VIG" });
    Vigencia.config.theme = byaSite.tema
    Vigencia.init();
    VigenciasList.config.theme = byaSite.tema
    VigenciasList.init();


});
