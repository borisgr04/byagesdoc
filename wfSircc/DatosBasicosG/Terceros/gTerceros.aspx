<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBS.Master" AutoEventWireup="true" CodeBehind="gTerceros.aspx.cs" Inherits="wfSircc.DatosBasicosG.Terceros.gTerceros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div id="msgResult">
    </div>
    <div class="row">
        <div class="col-md-2">
            <label>Delegación:</label>
        </div>
        <div class="col-md-4">
            <select id="CboDepDel" class="form-control input-sm"></select>
        </div>
        <div class="col-md-6">
            <div class="btn-toolbar">
                <div class="btn-group">
                    <button type="button" value="Consultar" id="BtnConsulta" data-loading-text="Loading..." class="btn btn-default" title="Actualiza el listado de Solicitudes de acuerdo a la dependencia Seleccionada">
                        <span class="glyphicon glyphicon-search"></span>Consultar
                    </button>
                    <button type="button" value="Nuevo" id="BtnDetalle" class="btn btn-default detalle">
                        <span class="glyphicon glyphicon-zoom-in"></span>Detalle
                    </button>
                </div>
                <div class="btn-group">
                    <button type="button" value="Nuevo" id="BtnNuevo" class="btn btn-default" title="Registrar Nueva Solicitud de Contratación.">
                        <span class="glyphicon glyphicon-plus"></span>Nuevo
                    </button>
                    <button type="button" value="Editar" id="BtnEditar" class="btn btn-default" title="Editar Solicitud Actual">
                        <span class="glyphicon glyphicon-pencil"></span>Editar
                    </button>
                </div>
            </div>

        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <br />
        </div>
    </div>

    <div id="jqxgridSol">
    </div>

    <script src="js/gTercersos.js"></script>


</asp:Content>
