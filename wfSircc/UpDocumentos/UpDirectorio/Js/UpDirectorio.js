var UnidadDoc = (function () {
   

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
        init: function () {
          


        }
    };
}());




$(function () {
    byaSite.SetModuloP({ TituloForm: "Cargar Documentos", Modulo: "Documentos", urlToPanelModulo: "UpDirectorio.aspx", Cod_Mod: "DOCU", Rol: "DOCU_DIR" });
    UnidadDoc.config.theme = byaSite.tema
    UnidadDoc.init();


});
