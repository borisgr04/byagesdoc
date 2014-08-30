var Series = (function () {
    "use strict";
    var urlToInsert = "/Servicios/Archivos/wsSeries.asmx/Insert";   
    var byaRpta;
    var msgPpal = "#LbMsg";
    var _addHandlers = function () {
      
        $("#nuevoButton").click(function () {
            ControlsSeries();
        });
        $("#guardarButton").click(function () {
            InsertSeries();
        });
        $("#editarButton").click(function () {

        });
        $("#cancelarButton").click(function () {
            limpiarSeries();
        });
       


    };
    var _Validaciones = function () {
       
    };   
    var MultiplesAjax = function () {

    }
    var _createElements = function () {       
       // $("#TextIdSerie").byaFormatInput('0123456789');      
    };  
    var getDatos = function () {
        var Ser = {};
        Ser.idSerie = $('#TextIdSerie').val();
        Ser.Serie = $('#TextSerie').val();
        Ser.Procedimiento = $("#TextPro").val();      
        return Ser;
    }
    var InsertSeries = function () {

        var jsonData = "{'Reg':" + JSON.stringify(getDatos()) + "}";
        byaPage.POST_Sync(urlToInsert, jsonData, function (result) {
            byaRpta = byaPage.retObj(result.d);
            $(msgPpal).msgBox({ titulo: "Registro de Series", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
            if (!byaRpta.Error) {

            }
        });


    }
    var ControlsSeries = function () {
        $(msgPpal).html("");     
        $("#TextIdSerie").byaSetHabilitar(true);
        $("#TextSerie").byaSetHabilitar(true);
        $("#TextPro").byaSetHabilitar(true);
        $("#TextIdSerie").val("");
        $("#TextSerie").val("");
        $("#TextPro").val("");

    };
    var limpiarSeries = function () {       
        $("#TextIdSerie").val("");
        $("#TextSerie").val("");
        $("#TextPro").val("");
        
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
var SeriesList = (function () {
    "use strict";
    var grid = '#jqxgridHisto';   
    var urlToGridSeries =  "/Servicios/Archivos/wsSeries.asmx/GetSeries";  
    var byaRpta;
    var msgPpal = "#LbMsg";
    var _addHandlers = function () {
    


    };  
    var _createElements = function () {
        _createGrid();
    };
    var getDataAdapter = function () {      
        var source = {           

            datatype: "xml",
            datafields: [
	                { name: 'idSerie' },
                    { name: 'Serie' },
                    { name: 'Procedimiento' }
            ],
            async: true,
            record: 'Table',
            url: urlToGridSeries,
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
                theme: SeriesList.config.theme,
                altrows: true,
                editable: false,
                sortable: true,
                showfilterrow: true,
                autoheight: true,
                autorowheight: true,
                filterable: true,
                pageable: true,
                enabletooltips: true,
                localization: byaPage.getLocalization(),
                columns: [
                  { text: 'Id Serie     ', datafield: 'idSerie' },
                  { text: 'Nombre Serie ', datafield: 'Serie' },
                  { text: 'Procedimiento Cesion', datafield: 'Procedimiento' }                 

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



$(function () {
    byaSite.SetModuloP({ TituloForm: "Series", Modulo: "", urlToPanelModulo: "#", Cod_Mod: "", Rol: "" });
    Series.config.theme = byaSite.tema
    Series.init();
    SeriesList.config.theme = byaSite.tema
    SeriesList.init();

});
