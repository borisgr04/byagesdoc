var theme;

var masterP = (function ($) {
    var ServicioMenu = "/Servicios/ControlFlujo/wsMenu.asmx/GetMenu";
    var urlToGetVigencias = "/Servicios/wsDatosBasicos.asmx/GetvVigencias";
    var idNav = "#MenuIzq";

    var Modulos = [
       { codigo: "ADMIN", nombre: "Administración", icono: "icon-book" },
       { codigo: "GESDOC", nombre: "Datos Básicos", icono: "icon-briefcase" },
       { codigo: "DOCU", nombre: "Documentos", icono: "icon-briefcase" },
       { codigo: "SEGU", nombre: "Seguridad", icono: "icon-briefcase" }
     /* ,  { codigo: "CONT4", nombre: "Contratos", icono: "icon-edit" },
       ,
       { codigo: "ADMI4", nombre: "Administración", icono: "icon-dashboard" }*/
    ];
    var _addHandlers = function () {
        $(".classVigencias").click(function () {

            var vig = $(this).prop("id");
            if (byaSite.getVigencia() != vig) {
                byaMsgBox.confirm("¿ Desea cambiar a la Vigencia " + vig + " ? ", function (result) {
                    if (result) {
                        byaSite.setVigencia(vig);
                        $("#mpVigencia").text(vig);
                        window.location.reload();
                    } else {
                        $("#mpVigencia").val(byaSite.getVigencia());
                    }
                });
            }

        });
        $('#BtnFullScreenMaster').click(function () {
            byaSite.launchFullScreen(document.documentElement);
            $(gridCon).jqxGrid({ height: 600 });
        });

    };
    var _createWidgets = function () {
        $("#mpVigencia").text(byaSite.getVigencia()); //mostrar vigencia
        $("#mpUserName").text(byaSite.getUsuario());//mostrar usuario
        //$("#mpUserName").text("Boris Arturo González");//mostrar usuario

        /*
        var sourceVig = byaPage.getSource(urlToGetVigencias);
        var items = "";
        $.each(sourceVig, function (index, item) {
            items += '<li><a href="#" class="classVigencias" id="' + item.YEAR_VIG + '"><i class=""></i>' + item.YEAR_VIG + '</a></li></ul>';
        });
        $("#mpLstVigencias").append(items);
        */
    };

    var _createMenu = function () {
        var modulo = byaSite.getModulo();
        //$("#HeadModulo").text($("#" + modulo).text());
        var arbol = _cargarTree(modulo);
        //$(idNav).html('');
        $.each(arbol, function (index, item) {
            //var opcion = "<li><a href='" + item.value.url + "' target='" + item.value.target + "' title='" + item.value.descripcion + "'><i class='" + item.value.icono + "'></i>" + item.text + "</a></li>";
            var opcion = "<li><a href='" + item.value.url + "' target='" + item.value.target + "' title='" + item.value.descripcion + "'>";
            opcion += "<i class='" + item.value.icono + "'></i><span class='menu-text'>" + item.text + "</span></a></li>";

            $(idNav).append(opcion);
        });
    };

    var _createMenu2 = function (Modulo) {

        var arbol = _cargarTree(Modulo.codigo);
        var opcion;
        var claseModulo = "";

        //if (!byaSite.ModuloP) {
        claseModulo = Modulo.codigo == byaSite.ModuloP.Cod_Mod ? "active open" : "";
        //}
        opcion = '<li id="' + Modulo.codigo + '" class="' + claseModulo + '"><a href="#" class="dropdown-toggle" >';
        opcion += '<i class="' + Modulo.icono + '"></i>';
        opcion += '<span class="menu-text">' + Modulo.nombre + ' </span>';
        opcion += '<b class="arrow icon-angle-down"></b>';
        opcion += '</a>';
        opcion += '<ul class="submenu">';
        if (arbol != null) {
            $.each(arbol, function (index, item) {
                var icono = "icon-double-angle-right";
                //item.value.icono
                var claseOpcion = "";
                //if (!byaSite.ModuloP) {
                claseOpcion = item.value.roles == byaSite.ModuloP.Rol ? "active" : "";
                //}
                opcion += "<li class='" + claseOpcion + "'><a href='" + item.value.url + "' target='" + item.value.target + "' title='" + item.value.descripcion + "'>";
                opcion += "<i class='" + icono + "'></i><span class='menu-text'>" + item.text + "</span></a></li>";
            });
        }
        opcion += '</ul></li>';
        $(idNav).append(opcion);
    };
    var _cargarTree = function (modulo) {
        var param = "{modulo:'" + modulo + "',usuario:'" + byaSite.getUsuario() + "'}";
        var data = byaPage.postSource(ServicioMenu, param);
        var source =
        {
            datatype: "json",
            datafields: [
                { name: 'id' },
                { name: 'parentid' },
                { name: 'text' },
                { name: 'value' }
            ],
            id: 'id',
            localdata: data
        };
        var dataAdapter = new $.jqx.dataAdapter(source);
        dataAdapter.dataBind();
        var records = dataAdapter.getRecordsHierarchy('id', 'parentid', 'items', [{ name: 'text', map: 'label' }]);
        return records;
    };
    var _crearNaviagation = function () {
        $(idNav).html('');
        $.each(Modulos, function (index, item) {
            _createMenu2(item);
        });
    };
    var config = {
        selectedIndex: -1
    };
    var _setTituloPagina = function () {
        //if (!byaSite.ModuloP) {
        $("#dvdModulo").html('<a href="' + byaSite.ModuloP.urlToPanelModulo + '">' + byaSite.ModuloP.Modulo + '</a>');
        $("#dvdPagina").html(byaSite.ModuloP.TituloForm);
        /*} else {
            console.log("La pagina actual, no tiene configurado la opción y módulo");
        }*/
    }
    return {
        init: function () {
            _setTituloPagina();
            _createWidgets();
            _addHandlers();
            _crearNaviagation();
        }
    }

}(jQuery));

$(document).ready(function () {
    $.data(document.body, 'theme', byaSite.tema);
    theme = getDemoTheme();
    masterP.init();
    $('.btn').toggleClass('no-border');
    $('.btn').addClass('btn-sm');
    /*
    $(document).ajaxStart(
        function () {
            $.blockUI({
                css: {
                    border: 'none',
                    padding: '15px',
                    backgroundColor: '#000',
                    '-webkit-border-radius': '10px',
                    '-moz-border-radius': '10px',
                    opacity: .5,
                    color: '#fff'
                },
                 message: '<h1> Espere un Momento...</h1>' 
            })
        });
    $(document).ajaxStop($.unblockUI);
    */
});

