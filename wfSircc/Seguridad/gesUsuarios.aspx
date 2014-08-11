<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBS.Master" AutoEventWireup="true" CodeBehind="gesUsuarios.aspx.cs" Inherits="wfSircc.Seguridad.gesUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row">
        <div class="col-md-1">
            <label>
                Filtro:</label>
        </div>
        <div class="col-md-2">
            <input type="text" id="txtFiltro" placeHolder="Identificación o Nombre" class="form-control input-sm" title="Identificación o Nombre" />
        </div>
        <div class="col-md-8">
            <div class="btn-toolbar">

                <button type="button" value="Consultar" id="BtnConsulta" data-loading-text="Loading..." class="btn btn-warning">
                    <span class="glyphicon glyphicon-search"></span>Buscar
                </button>

                <button type="button" value="Nuevo" id="BtnNuevo" class="btn btn-success">
                    <span class="glyphicon glyphicon-user"></span>Nuevo
                </button>

                <button type="button" value="Nuevo" id="BtnRoles" title="Funciones o Permiso que se le autorizan al Usuario por Cada Módulo" class="btn btn-primary" disabled>
                    <span class="glyphicon glyphicon-check"></span> Roles
                </button>

                <button type="button" value="Nuevo" id="BtnActivar" class="btn btn-danger" disabled>
                    <span class="glyphicon glyphicon-ok-sign"></span>Activar
                </button>

                <button type="button" value="Nuevo" id="BtnInactivar" class="btn btn-danger" disabled>
                    <span class="glyphicon glyphicon-off"></span>Inactivar
                </button>

                <button type="button" value="Nuevo" id="BtnDesbloq" class="btn btn-danger" disabled>
                    <span class="glyphicon glyphicon-asterisk"></span>Desbloqueo
                </button>

                <button type="button" value="Nuevo" id="BtnClave" class="btn btn-warning" disabled>
                    <span class="glyphicon glyphicon-edit"></span>Clave
                </button>

            </div>
        </div>


    </div>
    <div class="row">
        <div class="col-md-12">
            <br />
        </div>
    </div>

    <div class="modal fade" id="modalNuevo" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="H1">Registro de Nuevo Usuario</h4>
                </div>
                <div class="modal-body">
                    <div class="row form-group">
                        <div class="col-md-4">
                            <label for="exampleInputPassword1">Identificación</label>
                            <div class="input-group">
                                <input id='txtIde' title="Identificación" placeholder="Identificación" class="form-control" autofocus />
                                <span class="input-group-btn">
                                    <button class="btn btn-default" type="button" id="BtnBuscar">
                                        <span class="glyphicon glyphicon-search"></span>
                                    </button>
                                </span>
                            </div>
                            <!-- /input-group -->
                        </div>
                        <div class="col-md-8" >
                            <label for="exampleInputPassword1">Nombre</label>
                            <input id='txtNom' title="Nombre del Tercero." placeholder="Nombre" class="form-control input-sm" disabled />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group" id="pw1">
                                <label for="txtPassword1" class="control-label">Contraseña</label>
                                <input type="password" class="form-control validar"  id="txtPassword1" placeholder="Contraseña" >
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group" id="pw2">
                                <label for="txtPassword2" class="control-label">Confirmar Contraseña</label>
                                <input type="password" class="form-control validar" id="txtPassword2" placeholder="Confirme Contraseña">
                            </div>
                        </div>
                    </div>
            </div>
        

        <div class="modal-footer">
            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
            <button type="button" id="BtnGuardarNuevo" class="btn btn-primary">Guardar</button>
        </div>
    </div>
    <!-- /.modal-content -->
    </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->


    
    <div id="jqxgridSol">
    </div>
    
    <div id="winTer">
        <div id="winHTer">
            <span>Listado de Terceros </span>
        </div>
        <div style="overflow: hidden;" id="wConTer">
            <div id="msgTer" class="information">
                Hacer click para seleccionar el funcionario
            </div>
            <div>
                <div id="jqxgridTer">
                </div>
            </div>
        </div>
    </div>
    <script src="/jqscripts/ModalTer.js"></script>
   <%-- <script src="/EstPrev/js/ModalTer.js"></script>--%>
    <script src="js/GesUsuarios.js"></script>

</asp:Content>
