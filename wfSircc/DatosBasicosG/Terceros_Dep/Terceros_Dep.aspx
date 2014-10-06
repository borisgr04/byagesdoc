<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBS.Master" AutoEventWireup="true" CodeBehind="Terceros_Dep.aspx.cs" Inherits="wfSircc.DatosBasicosG.Terceros_Dep.Terceros_Dep" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="row">
            <div class="col-md-12">
               
                <div class="col-md-6">
                        <div class="btn-toolbar">
                        <button type="button" class="btn btn-warning" id="nuevoButton">
                            <span class="glyphicon glyphicon-plus-sign"></span>
                            Nuevo</button>
                             <button type="button" class="btn btn-success" id="guardarButton">
                            <span class="glyphicon glyphicon-floppy-saved"></span>
                            Guardar</button>    
                            <button type="button" class="btn btn-info" id="editarButton">
                            <span class="glyphicon glyphicon-floppy-saved"></span>
                            Editar</button>                               
                        <button type="button" class="btn btn-danger" id="cancelarButton">
                            <span class="glyphicon glyphicon-remove"></span>
                            Cancelar</button>                 
                    </div>
                </div>    
               
            </div>           
        </div>

        <br />
    <br />
     <div class="form-horizontal" role="form" id="formDATOS">
         <ul class="nav nav-tabs">
            <li class="active"><a href="#tabDepen" data-toggle="tab">1.Asignar Dependencias a Terceros</a></li>
          
        </ul>
         <div   class="tab-content">
             <div id="tabDepen" class="tab-pane in active ">
              <div class="col-md-12"> 
                 &nbsp
             </div>         
                <div class="form-group">
                    <label for="TxtIdeCon" class="col-sm-3 control-label">
                        Identificacion: 
                    </label>
                    <div class="col-lg-3">
                        <input id="TxtIdeCon" type="text" class="form-control input-sm inputHab" />
                    </div>
                    <div class="col-lg-1">
                        <button type="button" value="Nuevo" id="BtnBuscCon" class="btn btn-primary btn-xs" title="Abrir Cuadro de Busqueda">
                            <span class="glyphicon glyphicon-search"></span>
                        </button>
                    </div>
                    <div class="col-lg-3">
                        <input id="TxtNomCon" type="text" class="form-control input-sm " disabled />
                    </div>
                </div> 
                   <div class="form-group">
                    <div class="col-md-12">  
                             &nbsp                            
                      </div>                                     
                      <div class="col-md-12"> 
                      <div id="jqxgridHisto"></div> 
                      </div>
                </div> 
                          
            </div>
           

          </div>
            
       </div>
     <div class="modal fade" id="modalTerceros" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="H5">Consulta de Terceros</h4>
                </div>
                <div class="modal-body">
                    <div id="jqxgridTer">
                            </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal TERCEROS-->

    <script src="js/Terceros_Dep.js"></script>

</asp:Content>
