var UploadMasivo = (function () {


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
    byaSite.SetModuloP({ TituloForm: "Carga Masiva", Modulo: "Documentos", urlToPanelModulo: "UploadMasivo.aspx", Cod_Mod: "DOCU", Rol: "DOCU_UP" });
    UploadMasivo.config.theme = byaSite.tema
    UploadMasivo.init();


});