<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBS.Master" AutoEventWireup="true" CodeBehind="PerfilxUsuario.aspx.cs" Inherits="wfSircc.Seguridad.PerfilxUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-2">
            <label>
            Nombre de Usuario</label>
            </div>
            <div class="col-md-3">
                
            <div id="username"></div>
                </div>
        </div>
    <div class="row">
        <div class="col-md-2">
            <label for="CboFil">
                Dependencia:</label>
        </div>
        <div class="col-md-3" >
            <select id="CboFil" class="form-control input-sm">
                <optgroup label="PreContractual">
                    <option value="ESPR4">Estudios Previos</option>
                    <option value="SOLI4">Procesos</option>
                </optgroup>
                <optgroup label="Contractual">
                    <option value="CONT">Contratos</option>
                    <option value="SUPV4">Supervisión</option>
                </optgroup>
                <optgroup label="Administración">
                    <option value="SUPV4">Datos Básicos</option>
                    <option value="ADMI4">Seguridad</option>
                </optgroup>


            </select>
        </div>
        <div class="col-md-7">
            <div class="btn-toolbar">

                <button type="button" value="Consultar" id="BtnConsulta" data-loading-text="Loading..." class="btn btn-warning">
                    <span class="glyphicon glyphicon-search"></span>Consultar
                </button>

                <button type="button" value="Nuevo" id="BtnGuardar" class="btn btn-danger">
                    <span class="glyphicon glyphicon-book"></span>Guardar
                </button>
            </div>
        </div>
    </div>
    
    <div class="col-lg-6">
                <div class="form-group">
                    <div class="checkbox" >
                        <input type="checkbox" id="chkTodos"  > Todos
                    </div>
                </div>
            </div>

    <div id="jqxgrid">
    </div>



    <script src="js/PerfilxUsuario.js"></script>
</asp:Content>
