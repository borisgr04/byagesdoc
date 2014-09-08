<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBS.Master" AutoEventWireup="true" CodeBehind="GesRelacionDocumental.aspx.cs" Inherits="wfSircc.DatosBasicosG.RelacionDocumental.GesRelacionDocumental" %>

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
                            <span class="glyphicon glyphicon-remove"></span>
                            Anular</button>                 
                                   
                    </div>
                </div>    
               
            </div>           
        </div>
       <br />
    <br />
      <div class="row">                      
                      <div class="col-md-3">  
                                         Listado de Relacion Documental  
                      </div>                                      
                      <div class="col-md-12">  
                             &nbsp                            
                      </div>                                     
                      <div class="col-md-12"> 
                      <div id="jqxgridHisto"></div> 
                      </div>
         </div>   
     <script src="js/GesRelacionDocumental.js"></script>

</asp:Content>
