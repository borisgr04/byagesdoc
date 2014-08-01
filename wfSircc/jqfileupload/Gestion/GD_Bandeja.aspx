<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBS.Master" AutoEventWireup="true" CodeBehind="GD_Bandeja.aspx.cs" Inherits="wfSircc.jqfileupload.Gestion.GD_Bandeja" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function abrir() {
            window.open("../index.html", "mywindow", "width=1000,height=600");
        }
        
    </script>
    <a href="#" onclick="javascript:abrir();">Carga de Archivos</a>
    
      

    <div>
        <div class="col-lg-6">
            <div id="jqxgrid">
    </div>
        </div>
        <div id="InfoFile"></div>
        <div id="dvdemb">
        </div>
    </div>
    
    
    <script src="js/GD_Bandeja.js"></script>


</asp:Content>
