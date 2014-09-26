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
                                    </div>
        <div class="col-sm-3"> 
                                     </div>
        <div class="col-sm-3">
            
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
                      <button type="button" title="Subir Archivos" onclick="_Upload()" class="btn btn-danger" id="BtnUpload">
                            <span class="glyphicon glyphicon-paperclip"></span>
                            Cargar</button>   
                      <button  type="button" title="Actualizar" onclick="javascript:location.reload()" class="btn btn-warning" id="BtnUpdBandeja">
                            <span class="glyphicon glyphicon-refresh"></span>
                            Actualizar</button>
                       <asp:LinkButton ID="BtnMover2" OnClick="BtnMover_Click1" runat="server" Text="<span class='glyphicon glyphicon-save'></span> Importar" CssClass="btn btn-primary" />

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
                      <asp:Label ID="lbLog" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>
    
         <script src="js/UpDirectorio.js"></script>
</asp:Content>
