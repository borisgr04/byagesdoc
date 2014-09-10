<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBS.Master" AutoEventWireup="true" CodeBehind="GesUnidadDoc.aspx.cs" Inherits="wfSircc.UpDocumentos.UnidadDoc.GesUnidadDoc" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
            <div class="col-md-12">
               
                <div class="col-md-6">
                        <div class="btn-toolbar">
                        <button type="button" class="btn btn-warning" id="nuevoButton">
                            <span class="glyphicon glyphicon-plus-sign"></span>
                            Nuevo</button>
                             <button type="button" class="btn btn-primary" id="editarButton">
                            <span class="glyphicon glyphicon-pencil"></span>
                            Editar</button>                     
                             <button type="button" class="btn btn-danger" id="anularButton">
                             <span class="glyphicon glyphicon-remove">
                             </span>Anular</button>      
                                                                    
                                    
                    </div>
                </div>    
               
            </div>           
        </div>
       <div class="col-md-12"> 
         &nbsp
        </div>   
     
    <br />
    <br />
    <div class="form-horizontal" role="form" id="formDATOS">
        <!-- Nav tabs -->
        <ul class="nav nav-tabs">
            <li class="active"><a href="#tabhist" data-toggle="tab">1.Listado Documentos</a></li>                   
        </ul>

        <div class="tab-content">

          
            <!---Registro Presupuestal-->            
            <div id="tabhist" class="tab-pane in active">                          
                      <div class="row"> 
                           <div class="col-md-12">                           
                           
                                     
                      </div>                            
                      <div class="col-md-12">  
                             &nbsp                            
                      </div>   
                          
                                              
                      <div class="col-md-12"> 
                      <div id="jqxgridHisto"></div> 
                      </div>
                      </div>                             
            </div>
            <!---Polizas de Garantia-->
    
</div>
        </div>          
   
    <!-- /.modal TERCEROS-->  
        <script src="js/GesUnidadDoc.js"></script>
</asp:Content>
