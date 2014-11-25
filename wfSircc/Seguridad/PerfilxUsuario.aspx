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
                <optgroup label="Datos Básicos">
                    <option value="ADMIN">Administrador</option>
                </optgroup>
                <optgroup label="Seguridad">
                    <option value="SEGU">Seguridad</option>
                </optgroup>
                <optgroup label="Datos Básicos">
                    <option value="GESDOC">Datos Básicos</option>
                </optgroup>
                <optgroup label="Documentos">
                    <option value="DOCU">Documentos</option>
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
