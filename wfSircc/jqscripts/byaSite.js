var byaSite = new Object();
//bootstrap
var byaSite = {
    showlog: true,
    tema: 'arctic',
    usuario: 'sircc_user',
    vigencia: 'sircc_vig',
    modulo: 'modulo',
    ModuloActual: null,
    OpcionActual: null,
    ModuloP: {
        TituloForm:null,
        Modulo: null,
        UrlToPanelModulo: null,
        Cod_Mod: null,
        Rol:null
    },
    cerrarSesion: function () {
        this.setVigencia('');
        this.setUsuario('');
    },
    SetModuloP: function (value) {
        this.ModuloP = value;
    },
    setModuloActual: function (value) {
        this.ModuloActual = value;
        //alert(this.ModuloActual);
    },
    setOpcionActual: function (value) {
        this.OpcionActual = value;
    },
    getModuloActual: function () {
        return this.ModuloActual;
    },
    getOpcionActual: function () {
        return this.OpcionActual;
    },
    setUsuario: function (username) {
        $.setCookie(byaSite.usuario, username);
    },
    getUsuario: function () {
        return $.getCookie(byaSite.usuario);
    },
    setVigencia: function (vigencia) {
        $.setCookie(byaSite.vigencia, vigencia);
    },
    getVigencia: function () {
        return $.getCookie(byaSite.vigencia);
    },
    setModulo: function (modulo) {
        $.setCookie(byaSite.modulo, modulo);
    },
    getModulo: function () {
        return $.getCookie(byaSite.modulo);
    },
    getDepDel: function () {
        return "06";
    },
    NomApp: function () {
        return "SIRCC 4 Mobile.";
    },
    PiePagina: function () {
        return " B&A Systems S.A.S. ";
    },
    AbrirPagina: function (url) {
        self.location.href = url;
    },
    AbrirPaginaBlank: function (url) {
        var ventana = window.open(url, '_blank');  //abrimos una ventana vacía nueva
    },
    
    ShowLog: function (value) {
        if (this.showlog) {
            alert(value);
        }
    },
    FechaShort: function (f) {
        return f.getDate() + "-" + (f.getMonth() + 1) + "-" + f.getFullYear();
    },
    launchFullScreen:function(element) {
        if (element.requestFullScreen) {
            element.requestFullScreen();
        } else if (element.mozRequestFullScreen) {
            element.mozRequestFullScreen();
        } else if (element.webkitRequestFullScreen) {
            element.webkitRequestFullScreen();
        }
    },
    cancelFullscreen:function() {
        if (document.cancelFullScreen) {
            document.cancelFullScreen();
        } else if (document.mozCancelFullScreen) {
            document.mozCancelFullScreen();
        } else if (document.webkitCancelFullScreen) {
            document.webkitCancelFullScreen();
        }
    },

    
     printDiv:function(element){
         var objeto = document.getElementById(element);  //obtenemos el objeto a imprimir
         var ventana = window.open('', '_blank');  //abrimos una ventana vacía nueva
         //var url = "/jqwidgets/styles/jqx.metro.css";
         ventana.document.write(objeto.innerHTML);  //imprimimos el HTML del objeto en la nueva ventana
         //ventana.document.find('head').append('<link rel="stylesheet" href="' + url + '" media="screen" />');
         ventana.document.close();  //cerramos el documento
         ventana.print();  //imprimimos la ventana
         ventana.close();  //cerramos la ventana
        }
};
