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
                <div class="col-md-6">
                        <div class="btn-toolbar">
                        <button type="button" class="btn btn-info" id="vistaButton">
                            <span class="glyphicon glyphicon-plus-sign"></span>
                            Vista Previa</button>                          
                        <button type="button" class="btn btn-success" id="descargarButton">
                            <span class="glyphicon glyphicon-pencil"></span>
                            Descargar</button>   
                                           
                                   
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
    
    
    
    <div class="modal fade Incrimentar" id="modalTerceros" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="H5">Vista previa</h4>
                </div>
                <div id="Pdf" class="modal-body">                    
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>  
     <script src="js/GesRelacionDocumental.js"></script>

</asp:Content>
