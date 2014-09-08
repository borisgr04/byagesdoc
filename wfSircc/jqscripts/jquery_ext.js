$.extend({
    getUrlVars: function () {
        var vars = [], hash;
        var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        for (var i = 0; i < hashes.length; i++) {
            hash = hashes[i].split('=');
            vars.push(hash[0]);
            vars[hash[0]] = hash[1];
        }
        return vars;
    },
    getUrlVar: function (name) {
        return $.getUrlVars()[name];
    },
    getCookie: function (c_name) {
        var i, x, y, ARRcookies = document.cookie.split(";");
        for (i = 0; i < ARRcookies.length; i++) {
            x = ARRcookies[i].substr(0, ARRcookies[i].indexOf("="));
            y = ARRcookies[i].substr(ARRcookies[i].indexOf("=") + 1);
            x = x.replace(/^\s+|\s+$/g, "");
            if (x == c_name) {
                return unescape(y);
            }
        }
    },
    setCookie: function (c_name, value, exdays) {
        var exdate = new Date();
        exdate.setDate(exdate.getDate() + exdays);
        var c_value = escape(value) + ((exdays == null) ? "" : "; expires=" + exdate.toUTCString());
        document.cookie = c_name + "=" + c_value;
    }
});
jQuery.fn.extend({
    byaCombo: function(options) {
        placeHolder=options.placeHolder==null?"Seleccione":options.placeHolder;
        var IdCombo = $(this);
        IdCombo.children().remove().end();
        //alert($(this).id);
        //PlaceHolder Automatico
        IdCombo.get(0).options[IdCombo.get(0).options.length] = new Option(placeHolder, "");

        $.each(options.DataSource, function (index, item) {           
            IdCombo.get(0).options[IdCombo.get(0).options.length] = new Option(item[options.Display], item[options.Value]);
        });
    }
});
jQuery.fn.extend({
    byaSetHabilitar: function (value) {
        
    if(value){
        $(this).removeAttr('disabled');
        
    }
    else{
        $(this).attr('disabled', '-1');
        
    }
}
});
jQuery.fn.extend({
    byaSetDecimal: function(valor) {
        $(this).val(valor);
        $(this).formatCurrency();
        $(this).css("text-align", "right");
    }
});
jQuery.fn.extend({
    byaGetDecimal: function () {
        return $(this).asNumber();
    }
});

jQuery.fn.extend({
    msgBox: function (options) {
        var bu = new BootStrap.Utils();
        options.tipo = options.tipo == true ? "success" : options.tipo;
        options.tipo = options.tipo == false ? "danger" : options.tipo;
        bu.crearAlert(options.titulo, options.mensaje, options.tipo, $(this));
    }
});

//Patron Módulo
byaMsgBox = (function(){
    "use strict";
    //Zona Privada Auto Ejecutable
    return {
        alert: function (message, callback) {
            bootbox.alert(message, callback); //callback(alert(message));
        },
        confirm: function (message, callback) {
            bootbox.confirm(message, callback);//callback(confirm(message));
        },
        prompt: function (message, callback) {
            bootbox.prompt(message, callback);//callback(prompt(message));
        }
    };
})(); // copia cacheada


(function (BootStrap, $, undefined) {

    var Utils = (function () {
        function Utils() {
            //ctor
        }

        Utils.prototype.createAlert = function (title, message, alertType, targetElement) {
            var html = '<div class="alert alert-' + alertType + '">' +
                                    '<button type="button" class="close" data-dismiss="alert">&times;</button>' +
                                    '<h4>' + title + '</h4>' + message +
                                '</div>'
            $(targetElement).prepend(html);
        }
        Utils.prototype.crearAlert = function (title, message, alertType, targetElement) {
            var html = '<div class="alert alert-' + alertType + '">' +
                                    '<button type="button" class="close" data-dismiss="alert">&times;</button>' +
                                    '<h4>' + title + '</h4>' + message +
                                '</div>'
            targetElement.html(html);
        }

        return Utils;

    })();

    BootStrap.Utils = Utils;

})(window.BootStrap || (window.BootStrap = {}), jQuery);

function byaComboBox(config) {
    config = {
        Id: null,
        Value: null,
        Display: null,
        Source: null
    };
    var _create = function () {
        $(config.Id).byaCombo({ DataSource: config.Source, Value: config.Value, Display: config.Display, placeHolder:config.placeHolder });
    };
    var _getItem = function (key) {
        var found = null;
        $.each(config.Source, function (index, item) {
            if (item[config.Value] == key) {
                found = item;
                return;
            }
        });
        return found;
    };
    this.init = function (Config) {
        config = Config;
        _create();
    };
    this.getSource = function () {
        return config.Source;
    };
    this.getSeleccionado = function () {
        return _getItem($(config.Id).val());
    };
    this.DesHabilitar = function () {
        $(config.Id).find("option:selected").attr('disabled', true);
    };
};

Number.prototype.padLeft = function (width, char) {
    if (!char) {
        char = " ";
    }

    if (("" + this).length >= width) {
        return "" + this;
    }
    else {
        return arguments.callee.call(
          char + this,
          width,
          char
        );
    }
};

(function (a) {
    a.fn.byaFormatInput = function (b) {
        a(this).on({
            keypress: function (a) {
                var c = a.which,
                  d = a.keyCode,
                  e = String.fromCharCode(c).toLowerCase(),
                  f = b;
                (-1 != f.indexOf(e) || 9 == d || 37 != c && 37 == d || 39 == d && 39 != c || 8 == d || 46 == d && 46 != c) && 161 != c || a.preventDefault()
            }
        })
    }
})(jQuery);

/* EJEMPLO DE USU DE CLASES
var Example = (function () {
    "use strict";

    var elem,
        hideHandler,
        that = {};

    that.init = function (options) {
        elem = $(options.selector);
    };

    that.show = function (text) {
        clearTimeout(hideHandler);

        elem.find("span").html(text);
        elem.delay(200).fadeIn().delay(4000).fadeOut();
    };

    return that;
}());
var modalMsgBox = (function () {
    "use strict";

    var elem,
        hideHandler,
        that = {};

    that.init = function (options) {
        elem = $(options.selector);
    };

    that.show = function (text) {
        //clearTimeout(hideHandler);
        elem.find("span").html(text);
        $(elem).modal('show');
        //elem.delay(200).fadeIn().delay(4000).fadeOut();
    };

    return that;
}());
*/