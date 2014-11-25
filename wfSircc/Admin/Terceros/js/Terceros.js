var admTercero = (function () {

    var urlToAbrir = "/Servicios/DatosBasicosG/wsTerceros.asmx/Gets";
    var urlToAbrir2 = "/Servicios/DatosBasicosG/wsTerceros.asmx/Get";
    var urlToGuardarNuevo = "/Servicios/DatosBasicosG/wsTerceros.asmx/Insert";
    var urlToGuardarMod = "/Servicios/DatosBasicosG/wsTerceros.asmx/Update";
    var activarValidar = false;
    var ejecutar;
    var terceroId;
    
    var msgPpal = "#LbMsg";

    var _addHandlers = function () {
        $('#BtnDwnAbrir').click(function (event) {
            _Abrir($("#txtNumero").val());
        });
        $("#txtFecNac").datepicker({
            showOtherMonths: true,
            selectOtherMonths: false,
        });

        $("#guardarButton").click(function (event) {
            _guardar();
        });
        $("#editarButton").click(function (event) {
            Editar();
        });
        $("#cancelarButton").click(function (event) {
            _cancelar();
        });
        $("#nuevoButton").click(function (event) {
            Nuevo();
        });
        $(".validar").change(function () {
            _esValido();
        });
        $(".validar").blur(function () {
            _esValido();
        });
    };

    var _esValido = function () {
        var error = false;
        var _ValidarEmpty = function (Tipo, Control) {
            if ($("#" + Tipo + Control).val() == "") {
                $("#dvd" + Control).addClass("has-error");
                error = true;
            }
            else {
                $("#dvd" + Control).removeClass("has-error");
            }
        };

        var _MensajeFinalValidacion = function () {
            if (error) {
                $("#dvdMsg").addClass("alert alert-danger");
                $("#LbMsg").html("Por favor diligencie los datos resaltos en Rojo. Son Obligatorios");
            } else {
                $("#dvdMsg").removeClass("alert alert-danger");
                $("#LbMsg").html("");
            }
        };

        if (activarValidar) {
            _ValidarEmpty("txt", "Nombre");
            _ValidarEmpty("Cbo", "TipDoc");
            _ValidarEmpty("txt", "LugExp");
            _ValidarEmpty("txt", "Dir");
            _ValidarEmpty("txt", "Tel");
            _ValidarEmpty("txt", "Ema");
            _ValidarEmpty("Cbo", "TipPer");
         
            _MensajeFinalValidacion();
            
        }
        return !error;
    };

    var _guardar = function () {
        activarValidar = true;
        if (_esValido()) {
            ejecutar();
        }
    };
    
    var _crearElements = function () {

        var sourceTD = [
            { "NOM_DOC": "CÉDULA DE CIUDADANÍA", "COD_DOC": "CC" },
            { "NOM_DOC": "NIT", "COD_DOC": "NI" },
            { "NOM_DOC": "CÉDULA DE EXTRANJERÍA", "COD_DOC": "CE" },
            { "NOM_DOC": "PASAPORTE", "COD_DOC": "PA" }
        ];
        $('#CboTipDoc').byaCombo({
            DataSource: sourceTD, placeHolder: 'Seleccione el Tipo de Documento', Display: "NOM_DOC", Value: "COD_DOC"
        });

        var sourceTP = [
                 { "NOM_DOC": "NATURAL", "COD_DOC": "PN" },
                 { "NOM_DOC": "JURIDICA", "COD_DOC": "PJ" }
        ];
        $('#CboTipPer').byaCombo({
            DataSource: sourceTP, placeHolder: 'Seleccione el Tipo de Persona', Display: "NOM_DOC", Value: "COD_DOC"
        }); 
      
        /*
        var sourceDep = [
               { "NOM_EST": "ACTIVO", "COD_EST": "AC" },
               { "NOM_EST": "INACTIVO", "COD_EST": "IN" }  
        ];
        $('#cbotEst').byaCombo({
            DataSource: sourceDep, placeHolder: 'Estado del Tercero', Display: "NOM_EST", Value: "COD_EST"
        });
        */
    };

    var _cancelar = function () {
        byaMsgBox.confirm("Desea cancelar el proceso?", function (result) {
            if (result) {
                admTercero.config.oper = 'cancelar';
                _reset();
            }
        });
    };

    var _reset = function () {
        $("#nuevoButton").byaSetHabilitar(true);
        $("#guardarButton").byaSetHabilitar(false);
        $("#editarButton").byaSetHabilitar(false);
        $("#cancelarButton").byaSetHabilitar(false);
        $("#abrirButton").byaSetHabilitar(false);
        $("#txtNumero").byaSetHabilitar(true);
        $("#BtnDwnAbrir").byaSetHabilitar(true);
        admTercero.Deshabilitar();
        admTercero.Limpiar();
    };

    var _getDatos = function () {
        var e = {};
        e.tipodoc = $('#CboTipDoc').val();
        e.terceroId = $('#txtNroDoc').val();
        e.tipoper = $('#CboTipPer').val();
        e.nombre = $('#txtNombre').val();
        e.Direccion = $('#txtDir').val();
        e.Telefono = $('#txtTel').val();
        e.Correo = $('#txtEma').val();
        e.lugarexpe = $('#txtLugExp').val();

        //e.EXP_IDE = $('#txtLugExp').val();
        //e.DV_TER = $('#TxtDV').val();
        //Representante legal
        
        return e;
    };

    var _guardarNuevo = function () {
        jsonData = "{'Reg':" + JSON.stringify(_getDatos()) + "}";
        byaPage.POST_Sync(urlToGuardarNuevo, jsonData, function (result) {
            byaRpta = byaPage.retObj(result.d);            
            $(msgPpal).msgBox({ titulo: "Registro de Nuevo Tercero", mensaje: byaRpta.Mensaje + " N°: <b>" + byaRpta.id + "</b>", tipo: !byaRpta.Error });
            if (!byaRpta.Error) {
             //   $("#txtNSol").val(byaRpta.id);
             
                $("#nuevoButton").byaSetHabilitar(true);
                $("#editarButton").byaSetHabilitar(false);
                $("#guardarButton").byaSetHabilitar(false);
                $("#cancelarButton").byaSetHabilitar(false);
                $("#BtnDwnAbrir").byaSetHabilitar(true);
                $("#txtNumero").byaSetHabilitar(true);
            }
        });
    };
    
    var _guardarMod = function () {
        var byaRpta = {};
        var jsonData = "{'Reg':" + JSON.stringify(_getDatos()) + "}";
        byaPage.POST_Sync(urlToGuardarMod, jsonData, function (result) {
            byaRpta = byaPage.retObj(result.d);
            admTercero.Limpiar();
            $(msgPpal).msgBox({ titulo: "Registro de Tercero", mensaje: byaRpta.Mensaje, tipo: !byaRpta.Error });
        });
        $("#nuevoButton").byaSetHabilitar(true);
        $("#editarButton").byaSetHabilitar(false);
        $("#guardarButton").byaSetHabilitar(false);
        $("#cancelarButton").byaSetHabilitar(false);
        $("#BtnDwnAbrir").byaSetHabilitar(true);
        $("#txtNumero").byaSetHabilitar(true);
        
    };

    var Nuevo = function () {
        $("#nuevoButton").byaSetHabilitar(false);
        $("#editarButton").byaSetHabilitar(false);
        $("#guardarButton").byaSetHabilitar(true);
        $("#cancelarButton").byaSetHabilitar(true);
        $("#abrirButton").byaSetHabilitar(false);
        $("#txtNumero").prop('disabled',false);
        $("#BtnDwnAbrir").byaSetHabilitar(false);
        admTercero.config.oper = 'Nuevo';
        admTercero.Limpiar();
        admTercero.Habilitar();
       
        ejecutar = _guardarNuevo;
        
    };
    
    var Editar = function () {
        admTercero.config.oper = 'Editar';
        admTercero.Habilitar();
        $("#txtNumero").byaSetHabilitar(false);
        admTercero.disabled = false;
        //Solicitudes._createValidacionEL(GuardarMod);
        $(msgPpal).msgBox({ titulo: "Registro de Nuevo Terceros", mensaje: "Después de modificar los datos y presione el botón Guardar...!!!", tipo: "info" });
        ejecutar = _guardarMod;
    };

    var _Abrir = function (ideTer) {
        var sw = false;
        
        if (ideTer == "") {
            $(msgPpal).msgBox({ titulo: "Consulta de Tercero", mensaje: "Debe especificar un número de Identificación", tipo: false });
            $("#txtNumero").focus();
            return false;
        }
        var parametrosJSON = { "tercerosId": ideTer };                
        $.ajax({
            type: "GET",
            url: urlToAbrir2,
            data: parametrosJSON,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            beforeSend: function () {
               $(msgPpal).msgBox({ titulo: "Tercero", mensaje: "Procesando.. espere por favor...!!!", tipo: "info" });
            },
            success: function (result) {
                var ter = byaPage.retObj(result.d);
                //alert(JSON.stringify(ter));
                if (ter.IDE_TER == 0) {
                   $(msgPpal).msgBox({ titulo: "Tercero", mensaje: "El tercero con N° Identificación  " + nep + " no se encuentra registrado...!!!", tipo: "warning" });                   
                }
                else {
                    $('.input').attr('disabled', false);                    
                    $('#CboTipDoc').val(ter.tipodoc);
                    $('#txtNroDoc').val(ter.terceroId);
                    $('#CboTipPer').val(ter.tipoper);
                    $('#txtNombre').val(ter.nombre); 
                    $('#txtLugExp').val(ter.lugarexpe);
                    $('#txtDir').val(ter.direccion);
                    $('#txtTel').val(ter.telefono);
                    $('#txtEma').val(ter.correo);

                    $("#txtNroDoc").byaSetHabilitar(false);
                    $("#guardarButton").byaSetHabilitar(false);
                    $("#nuevoButton").byaSetHabilitar(false);
                    $("#BtnDwnAbrir").byaSetHabilitar(false);
                    $("#editarButton").byaSetHabilitar(true);
                    $("#cancelarButton").byaSetHabilitar(false);
                    $("#txtNumero").byaSetHabilitar(false);
                    $("#BtnDwnAbrir").byaSetHabilitar(false);
                   
                    
                    $(msgPpal).msgBox({ titulo: "Tercero", mensaje: "Se cargaron los datos del Tercero", tipo: "info" });
                    sw = true;
                    Editar();
                }
            },
            error: function (jqXHR, status, error) {
                alert(error + "-" + jqXHR.responseText);
            }
        });
        return sw;
    };
   
    return {
        formulario: '#form1',
        disabled: true,
        config: {
            theme: null,
            oper: null
        },
        init: function () {
            _addHandlers();
            _crearElements();
            terceroId = $.getUrlVar('terceroId');
            if (terceroId != null) {
               _Abrir(terceroId);
            } else {
                Nuevo();
            }
            //$("#txtNumero").val(terceroId);
            
            
        },

        Deshabilitar: function () {
            //Deshabilita todos los controles
            $('input').prop('disabled', true);
            $('#txtObs').prop('disabled', true);
            var value = false;
            $('#CboTipNro').byaSetHabilitar(value);
            $('#CboDepNec').byaSetHabilitar(value);
            $('#cbotEst').byaSetHabilitar(value);
            $('#CboTpTer').byaSetHabilitar(value);
            $('#CboClasf').byaSetHabilitar(value);
            this.disabled = true;
        },

        Habilitar: function () {
            //Deshabilita todos los controles
            $('input').prop('disabled', false);
            $('#txtObs').prop('disabled', false);
            var value = true;
            $('#CboTipNro').byaSetHabilitar(value);
            $('#CboDepNec').byaSetHabilitar(value);
            $('#cbotEst').byaSetHabilitar(value);
            $('#CboTpTer').byaSetHabilitar(value);
            $('#CboClasf').byaSetHabilitar(value);
            $("#nuevoButton").byaSetHabilitar(false);
            $("#abrirButton").byaSetHabilitar(false);
            $("#editarButton").byaSetHabilitar(false);
            $("#guardarButton").byaSetHabilitar(true);
            $("#cancelarButton").byaSetHabilitar(true);
            this.disabled = false;
        },
     
        Limpiar: function () {
            //Colocar Valores Por Defecto
            $('#form1')[0].reset();
            byaPage.msgLimpiar($("#LbMsg"));
        }
    }
}());

$(function () {
    byaSite.SetModuloP({ TituloForm: " Terceros", Modulo: "Administración", urlToPanelModulo: "gTerceros.aspx", Cod_Mod: "ADMIN", Rol: "AD_DB_TER" });
    //admTercero.config.theme = byaSite.tema;
    admTercero.init();
    //GesCronograma.init();
});
