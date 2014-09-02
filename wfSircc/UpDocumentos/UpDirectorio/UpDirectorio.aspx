<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBS.Master" AutoEventWireup="true" CodeBehind="UpDirectorio.aspx.cs" Inherits="wfSircc.UpDocumentos.UpDirectorio.UpDirectorio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        var _Upload = function () {
            window.open("/jqfileupload/index.html", "mywindow", "width=1000,height=600");
        };
    </script>
    <div class="row">
        <div class="col-sm-3">
            <asp:Button ID="BtnAceptar" runat="server" class="btn btn-primary"  Text="Ver Bandeja de Entrada" Width="167px" OnClick="BtnAceptar_Click1" />
                                     </div>
        <div class="col-sm-3"> 
                                     </div>
        <div class="col-sm-3">
             <asp:Button ID="BtnMover" runat="server" class="btn btn-primary"  Text="Importar" OnClick="BtnMover_Click1" />
                                     </div>
        <div class="col-sm-3">
                                     </div>
        </div>
    <br />
     <div class="row">
        <div class="col-md-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Bandeja de Entrada</h3>
                </div>
                <div class="panel-body">
                                <a href="#"  id="BtnUpload" title="Subir Archivos" class="btn btn-danger" onclick="_Upload()">
                                    <span class="glyphicon glyphicon-paperclip"></span>
                                </a>
                                <a href="javascript:location.reload()" title="Actualizar" id="BtnUpdBandeja" class="btn btn-warning">
                                    <span class="glyphicon glyphicon-refresh"></span>
                                </a>
                    <asp:CheckBoxList ID="ChkBE" runat="server" CssClass="table-hover">
                    </asp:CheckBoxList>
                </div>
            </div>
        </div>
        <div class="col-md-6">
    <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Lista de Documentos Seleccionados</h3>
                </div>
                <div class="panel-body">
                    <asp:CheckBoxList ID="ChkOK" runat="server" CssClass="table-hover">
                    </asp:CheckBoxList>
                    
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <h3>Log de Resultados</h3>
    <asp:Label ID="lbLog" runat="server" Text=""></asp:Label>
        </div>
</asp:Content>
