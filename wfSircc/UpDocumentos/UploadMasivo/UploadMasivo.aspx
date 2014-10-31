<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBS.Master" AutoEventWireup="true" CodeBehind="UploadMasivo.aspx.cs" Inherits="wfSircc.UpDocumentos.UploadMasivo.UploadMasivo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
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
                
                <div class="col-md-11" >
                     <asp:FileUpload ID="FileUpload1"  runat="server" />
                </div>
                 <div class="col-md-1" >
                      <asp:Button ID="BtnPlano" class="btn btn-success" runat="server" Text="Guardar" OnClick="BtnPlano_Click" />
                </div>
                 </div>
            </div>      
            </div>

       </div>

               </div>
                  
       
  
</asp:Content>
