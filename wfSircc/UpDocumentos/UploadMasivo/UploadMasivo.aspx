<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBS.Master" AutoEventWireup="true" CodeBehind="UploadMasivo.aspx.cs" Inherits="wfSircc.UpDocumentos.UploadMasivo.UploadMasivo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />
    <br />
    
         <asp:Label ID="LbMsg" runat="server" Text=""></asp:Label>
    
   
        <br />
    <br />
           <br />
    <br />
           <div class="form-horizontal" role="form" id="formDATOS">
        <!-- Nav tabs -->
        <ul class="nav nav-tabs">
            <li class="active"><a href="#tabUpload" data-toggle="tab">1.Guardar Masivamente</a></li>                   
        </ul>

        <div class="tab-content">

            <div id="tabUpload" class="tab-pane in active">
                 <div class="row">
                <div class="col-md-12">
                
                <div class="col-md-9" >
                     <asp:FileUpload ID="FileUpload1"  runat="server" />
                </div>
                 <div class="col-md-3" >
                       <asp:Button ID="BtnCargar" class="btn btn-primary" runat="server" Text="Cargar Archivo Plano" OnClick="BtnCargar_Click" />
                      <asp:Button ID="BtnPlano" class="btn btn-success" runat="server" Text="Guardar" OnClick="BtnPlano_Click" />
                </div>
                    
           <br />
    <br />
                      <br />
    <br />
                 
                    <div style="width:100%; height:300px; overflow: scroll;">   
                         <asp:GridView ID="GridPlano" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                         <AlternatingRowStyle BackColor="White" />
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
                    </asp:GridView>
                    </div>
                    
                 </div>
                    
            </div>      
            </div>

       </div>

               </div>
                  
       
    <script src="js/UploadMasivo.js"></script>
</asp:Content>
