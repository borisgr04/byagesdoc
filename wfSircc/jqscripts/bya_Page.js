var byaPage = new Object();

var byaPage = {
    IntegradoSIF: true,
    editGrid: "dblclick",
    valorCalculado: 0,
    init: function () {
        // aqui hago varias cosas
        this.valorCalculado = "hola";
        this.funcionalidad1();
    },
    container: function (img) {
        return $("<div style='overflow: hidden; position: relative; margin: 5px;'></div>");
    },
    idButton: function (img, Texto) {
        return $("<div style='float: left; margin-left: 5px;'><img style='position: relative; margin-top: -2px;' src='" + img + "'/><span style='margin-left: 4px; position: relative; top: -3px;'>" + Texto + "</span></div>");
    },
    addButton: function () {
        return byaPage.idButton("../jqwidgets/images/add.png", "Agregar");
    },
    updButton: function () {
        return byaPage.idButton("../jqwidgets/images/save.png", "Guardar");
    },
    reloadButton: function () {
        return byaPage.idButton("../jqwidgets/images/refresh.png", "Refresh");
    },
    deleteButton: function () {
        return byaPage.idButton("../jqwidgets/images/close.png", "Eliminar");
    },
    xlsButton: function () {
        return byaPage.idButton("../jqwidgets/images/xls.png", "Exportar");
    },
    funcionalidad1: function () {
        // aqui desarrollo una funcionalidad concreta
        alert("c");
    },
    JSONtoString: function (json) {
        // aqui desarrollo una funcionalidad concreta
        return JSON.stringify(json);
    },
    msgJson: function (json) {
        alert(this.JSONtoString(json));
    },
    ajaxError: function (jqXHR, status, error) {
        //alert(error + "-" + jqXHR.responseText);
        alert("Ajax " + error + " - " + jqXHR.responseText);
        //alert(status);
    },
    POST_Sync: function (urlToHandler, jsonData, fnsuccess) {
        $.ajax({
            type: "POST",
            url: urlToHandler,
            data: jsonData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: fnsuccess,
            error: byaPage.ajaxError
        });
    },
    POST_Async: function (urlToHandler, jsonData, fnsuccess) {
        $.ajax({
            type: "POST",
            url: urlToHandler,
            data: jsonData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: fnsuccess,
            error: byaPage.ajaxError
        });
    },
    retObj: function (d) {
        return (typeof d) == 'string' ? eval('(' + d + ')') : d;
    },
    msgResult: function (msg, HayError) {
        if (!HayError) {
            msg.removeClass('error');
            msg.addClass('information');
        }
        else {
            msg.removeClass('information');
            msg.addClass('error');
        }
    },
    pantallacompleta: function (pagina) {
        var opciones = ("toolbar=no,location=no, directories=no, status=no, menubar=no , resizable=no, fullscreen=yes");
        window.open(pagina, "", opciones, false);
    },
    AbrirPagina: function(url) {
        self.location.href = url;
    },
    msgLimpiar: function (msg) {
        msg.removeClass('error');
        msg.removeClass('information');
        msg.html("");
    },
    getLocalization: function () {
        var localizationobj = {};
        localizationobj.percentsymbol = "%";
        localizationobj.currencysymbol = "$";
        localizationobj.decimalseparator = '.';
        localizationobj.thousandsseparator = ',';
        localizationobj.pagergotopagestring = "Ir a:";
        localizationobj.pagershowrowsstring = "Mostrar filas:";
        localizationobj.pagerrangestring = " de ";
        localizationobj.pagerpreviousbuttonstring = "anterior";
        localizationobj.pagernextbuttonstring = "siguiente";
        localizationobj.groupsheaderstring = "Arrastre una columna y dejarlo aquí para agrupar por esa columna";
        localizationobj.sortascendingstring = "Orden Ascendente";
        localizationobj.sortdescendingstring = "Orden Descendente";
        localizationobj.sortremovestring = "Quitar Orden";
        localizationobj.groupbystring = "Agrupar por esta columna";
        localizationobj.groupremovestring = "Elimnar de Grupo";
        localizationobj.filterclearstring = "Quitar Filtro";
        localizationobj.filterstring = "Filtrar";
        localizationobj.filtershowrowstring = "Mostrar Filas Donde :";
        localizationobj.filterorconditionstring = " Ó ";
        localizationobj.filterandconditionstring = " Y ";
        localizationobj.filterstringcomparisonoperators = ['vacio', 'no vacio', 'contains', 'contains(match case)',
        'does not contain', 'does not contain(match case)', 'empieze con', 'empieze con(match case)',
        'termine con', 'termine con(match case)', 'igual', 'igual(match case)', 'null', 'not null'];
        localizationobj.filternumericcomparisonoperators = ['igual', 'diferente', 'menor que', 'menor que o igual', 'mayor que', 'mayor que o igual', 'null', 'not null'];
        localizationobj.filterdatecomparisonoperators = ['igual', 'no igual', 'menor que', 'menor que o igual', 'mayor que', 'mayor que o igual', 'null', 'not null'];

        localizationobj.firstDay = 0;
        var days = {
            // full day names
            names: ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"],
            // abbreviated day names
            namesAbbr: ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"],
            // shortest day names
            namesShort: ["Su", "Mo", "Tu", "We", "Th", "Fr", "Sa"]
        };
        localizationobj.days = days;

        var months = {
            // full month names (13 months for lunar calendards -- 13th month should be "" if not lunar)
            names: ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December", ""],
            // abbreviated month names
            namesAbbr: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec", ""]
        };
        localizationobj.months = months;

        localizationobj.twoDigitYearMax = 2029;
        var patterns = {
            // short date pattern
            d: "dd/MM/yyyy",
            // long date pattern
            D: "dddd, MMMM dd, yyyy",
            // short time pattern
            t: "h:mm tt",
            // long time pattern
            T: "h:mm:ss tt",
            // long date, short time pattern
            f: "dddd, MMMM dd, yyyy h:mm tt",
            // long date, long time pattern
            F: "dddd, MMMM dd, yyyy h:mm:ss tt",
            // month/day pattern
            M: "MMMM dd",
            // month/year pattern
            Y: "yyyy MMMM",
            // S is a sortable format that does not vary by culture
            S: "yyyy\u0027-\u0027MM\u0027-\u0027dd\u0027T\u0027HH\u0027:\u0027mm\u0027:\u0027ss"
        };
        localizationobj.patterns = patterns;
        return localizationobj;
    },

    converJSONDate: function (dateTime) {
        if (dateTime != null) {
            var date = new Date(parseInt(dateTime.substr(6)));
            var formatted = date.getFullYear() + "-" +
                                        ("0" + (date.getMonth() + 1)).slice(-2) + "-" +
                                            ("0" + date.getDate()).slice(-2);
            console.log(formatted);
            return formatted;
        }
    },
    
    converJSONDateTime: function (dateTime) {
        if (dateTime != null) {
            var date = new Date(parseInt(dateTime.substr(6)));
            var formatted = date.getFullYear() + "-" +
                                        ("0" + (date.getMonth() + 1)).slice(-2) + "-" +
                                            ("0" + date.getDate()+1).slice(-2) + " " + date.getHours() + ":" +
                                        date.getMinutes();
            return formatted;
        }
  },
    
    FechaShortX: function (f) {
       var sf = "";
       sf = f.getFullYear() + "-" + ("0" + (f.getMonth() + 1)).slice(-2) + "-" + ("0" + f.getDate()).slice(-2);
       //sf = ("0" + f.getDate()).slice(-2) + "/" + ("0" + (f.getMonth() + 1)).slice(-2) + "/" + f.getFullYear()
       console.log("Prueba de Asignacion de Fecha, se probo y funcionó..." + sf);
       return sf;
    },
    parseJsonDate: function (jsonDate) {
    var offset = new Date().getTimezoneOffset() * 60000;
    var parts = /\/Date\((-?\d+)([+-]\d{2})?(\d{2})?.*/.exec(jsonDate);
    
    if (parts[2] == undefined) 
      parts[2] = 0;
    
    if (parts[3] == undefined) 
      parts[3] = 0;
    
    return new Date(+parts[1] + offset + parts[2]*3600000 + parts[3]*60000);
    },
   
    getASync: function (urlToHandler, jsonData, fnsuccess) {
        $.ajax({
            type: "GET",
            url: urlToHandler,
            data: jsonData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: fnsuccess,
            error: byaPage.ajaxError
        });
    },
    getSource: function (Servicio, dataJSON) {
        var source = {};
        $.ajax({
            type: "GET",
            url: Servicio,
            data: dataJSON,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (result) {
                source = result.d;
            },
            error: function (jqXHR, status, error) {
                alert(error + "-" + jqXHR.responseText);
            }
        });
        return source;
    },
    getSource: function (Servicio, dataJSON) {
        var source = {};
        $.ajax({
            type: "GET",
            url: Servicio,
            data: dataJSON,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (result) {
                source = result.d;
            },
            error: function (jqXHR, status, error) {
                alert(error + "-" + jqXHR.responseText);
            }
        });
        return source;
    },
    postSource: function (Servicio, dataJSON) {
        var source = {};
        //this.msgJson  (dataJSON);
        $.ajax({
            type: "POST",
            url: Servicio,
            data: dataJSON,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (result) {
                source = result.d;
            },
            error: function (jqXHR, status, error) {
                alert(error + "-" + jqXHR.responseText);
            }
        });
        return source;
    }
    

}