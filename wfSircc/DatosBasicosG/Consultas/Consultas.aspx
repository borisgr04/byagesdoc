<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBS.Master" AutoEventWireup="true" CodeBehind="Consultas.aspx.cs" Inherits="wfSircc.DatosBasicosG.Consultas.Consultas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">

                    <div class="form-group">
                    
                     <div class="col-md-5" >
                         <input id="TextFiltro" class="form-control inputHab" placeholder="Escriba Una Palabra clave"/>
                       </div>
                         <div class="col-md-2">
                             <button type="button" class="btn btn-info" id="BtnBuscar">
                             <span class="glyphicon glyphicon-floppy-saved">
                             </span>Buscar</button>         
                         </div>    
                     
                     
                    </div>              
        
        <div class="col-md-12"> 
         &nbsp
        </div>          
        <div class="col-md-6">             
        <div id="jqxgridConsul"></div> 
                     
        <%--    <asp:GridView ID="GridView1" runat="server" CssClass="table-hover" DataKeyNames="idUnidadDocumental" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>--%>
        </div>
        <div id="kevin" class="col-md-6">
        <asp:Literal ID="ltPrew" runat="server"></asp:Literal>
        </div>
    </div>

     <script src="js/Consultas.js"></script>
</asp:Content>
