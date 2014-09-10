<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBS.Master" AutoEventWireup="true" CodeBehind="UnidadDoc.aspx.cs" Inherits="wfSircc.UpDocumentos.UnidadDoc.UnidadDoc" %>

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
                        <button type="button" class="btn btn-danger" id="cancelarButton">
                            <span class="glyphicon glyphicon-remove"></span>
                            Cancelar</button>                 
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
            <li class="active"><a href="#tabDoc" data-toggle="tab">1.Registrar Documentos</a></li>                   
        </ul>

        <div class="tab-content">

            <div id="tabDoc" class="tab-pane in active"> 
               
                <div class="col-md-12"> 
                 &nbsp
                </div> 

                <div class="form-group">
                    <label for="TextCodDoc" class="col-sm-2 control-label">
                      Codigo Documento: 
                    </label>
                    <div class="col-md-2">
                           <input id="TextCodDoc" type="text" class="form-control input-sm inputHab" />                
                    </div>               
                </div>               
                  <div class="form-group">
                    <label for="TextNomDoc" class="col-sm-2 control-label">
                      Nombre Documento: 
                    </label>
                    <div class="col-md-3">
                           <input id="TextNomDoc" type="text" class="form-control input-sm inputHab" />                
                    </div>               
                </div>
                 <div class="form-group">
                    <label for="TextPal" class="col-sm-2 control-label">
                      Palabras Clabe: 
                    </label>
                    <div class="col-md-4">
                           <textarea id="TextPal" class="form-control input-sm inputHab" ></textarea>                
                    </div>               
                </div>
                 <div class="form-group">
                    <label for="TextFecDoc" class="col-sm-2 control-label">
                      Fecha de Creacion: 
                    </label>
                      <div class="col-sm-3">
                       
                            <div class="input-medium">
                                <div class="input-group">
                                    <input class="input-medium date-picker" id="TextFecDoc" type="text" data-date-format="dd-mm-yyyy" placeholder="mm-dd-yyyy" />
                                    <span class="input-group-addon">
                                        <i class="icon-calendar"></i>
                                    </span>
                                </div>
                            </div>
                         </div>               
                </div>
                <div class="form-group">
                    <label for="TextNfolios" class="col-sm-2 control-label">
                      N° Folio: 
                    </label>
                    <div class="col-md-2">
                           <input id="TextNfolios" type="text" class="form-control input-sm inputHab" />                
                    </div>               
                </div>
                   <div class="form-group">
                    <label for="CboSubSeries" class="col-sm-2 control-label">
                      SubSerie: 
                    </label>
                    <div class="col-md-2">
                          <select id="CboSubSeries" class="form-control input-sm"></select>               
                    </div>               
                </div>
                 <div class="form-group">
                    <label for="TextEntidad" class="col-sm-2 control-label">
                      Entidad Productora: 
                    </label>
                    <div class="col-md-2">
                           <input id="TextEntidad" type="text" class="form-control input-sm inputHab" />                
                    </div>               
                </div>
                  <div class="form-group">
                    <label for="TextArchivador" class="col-sm-2 control-label">
                      N° Carpeta: 
                    </label>
                    <div class="col-md-2">
                           <input id="TextArchivador" type="text" class="form-control input-sm inputHab" />                
                    </div>               
                </div>
                <div class="form-group">
                    <label for="TextGabeta" class="col-sm-2 control-label">
                      N° Caja: 
                    </label>
                    <div class="col-md-2">
                           <input id="TextGabeta" type="text" class="form-control input-sm inputHab" />                
                    </div>               
                </div>
                 <div class="form-group">
                    <label for="TextFextIni" class="col-sm-2 control-label">
                     Fecha Extrema Inicial: 
                    </label>
                    <div class="col-sm-3">
                         
                            <div class="input-medium">
                                <div class="input-group">
                                    <input class="input-medium date-picker" id="TextFextIni" type="text" data-date-format="dd-mm-yyyy" placeholder="mm-dd-yyyy" />
                                    <span class="input-group-addon">
                                        <i class="icon-calendar"></i>
                                    </span>
                                </div>
                            </div>
                         </div>                    
                </div>
                <div class="form-group">
                    <label for="TextFextFin" class="col-sm-2 control-label">
                     Fecha Extrema Final: 
                    </label>
                    <div class="col-sm-3">
                      
                            <div class="input-medium">
                                <div class="input-group">
                                    <input class="input-medium date-picker" id="TextFextFin" type="text" data-date-format="dd-mm-yyyy" placeholder="mm-dd-yyyy" />
                                    <span class="input-group-addon">
                                        <i class="icon-calendar"></i>
                                    </span>
                                </div>
                            </div>
                         </div>                    
                </div>
                  <div class="form-group">
                    <label for="CboDependencia" class="col-sm-2 control-label">
                      Dependencia: 
                    </label>
                    <div class="col-md-2">
                          <select id="CboDependencia" class="form-control input-sm"></select>               
                    </div>               
                </div>
                     
            </div>    
            <!---Registro Presupuestal-->            
            <div id="tabhist" class="tab-pane ">                          
                      <div class="row"> 
                           <div class="col-md-12">  
                           
                                <div class="col-md-3">  
                                         Listado De Documentos  
                      </div>  
                                    <div class="col-md-7">  
                                     
                      </div>  
                                 <div class="col-md-2">
                              <button type="button" class="btn btn-danger" id="BtnEliminarAdi">
                             <span class="glyphicon glyphicon-remove">
                             </span>Anular</button>      
                         </div>                  
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
        <script src="js/UnidadDoc.js"></script>
</asp:Content>
