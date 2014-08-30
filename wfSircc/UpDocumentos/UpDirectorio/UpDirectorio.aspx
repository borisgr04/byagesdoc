<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBS.Master" AutoEventWireup="true" CodeBehind="UpDirectorio.aspx.cs" Inherits="wfSircc.UpDocumentos.UpDirectorio.UpDirectorio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-group" id="Div3">
                <label for="CboTipDoc" class="col-sm-3 control-label"></label>
                <div class="col-sm-3">
                    <asp:Button ID="BtnAceptar" runat="server" OnClick="BtnAceptar_Click" Text="Ver Bandeja de Entrada" Width="167px" />

                </div>
            </div>

             <div class="form-group" id="Div4">
                <label for="CboTipDoc" class="col-sm-3 control-label"></label>
                <div class="col-sm-3">
                  <asp:Button ID="BtnMoverArchivos" runat="server" Text="Mover" OnClick="BtnMoverArchivos_Click" />
                </div>
            </div>

     <div class="row">
        <div class="col-md-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Bandeja de Entrada</h3>
                </div>
                <div class="panel-body">
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
</asp:Content>
