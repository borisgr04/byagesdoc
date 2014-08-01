var PanelAdmin = (function () {
    "use strict";
    var tema;
    //var urlToGridCon = "/Servicios/wsProcesos.asmx/GetMisProcesos";
    
  
    var _addHandlers = function () {

        
    };
    var _createElements = function () {
      
        tema = PanelAdmin.config.theme;
    };


    return {
        editedRows: null,
        config: {
            theme: null
        },
        init: function () {
            _createElements();
            _addHandlers();
            //_createGridCon();
        }
    };
} ());

$(function () {
    byaSite.SetModuloP({ TituloForm: "Panel de Administración", Modulo: "Seguridad", urlToPanelModulo: "PanelAdmin.aspx", Cod_Mod: "ADMI4", Rol: "AD_SEC_USUARIO" });
    PanelAdmin.config.theme = byaSite.tema;
    PanelAdmin.init();
});
