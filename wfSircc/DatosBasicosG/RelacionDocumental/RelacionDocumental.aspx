<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBS.Master" AutoEventWireup="true" CodeBehind="RelacionDocumental.aspx.cs" Inherits="wfSircc.DatosBasicosG.RelacionDocumental.RelacionDocumental" %>

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

        <br />
    <br />
     <div class="form-horizontal" role="form" id="formDATOS">
         <ul class="nav nav-tabs">
            <li class="active"><a href="#tabSeries" data-toggle="tab">1.Registro Relacion Documental</a></li>
          
        </ul>
         <div   class="tab-content">
             <div id="tabSeries" class="tab-pane in active ">
              <div class="col-md-12"> 
                 &nbsp
             </div>         
              <div class="form-group">
                    <label for="CboIdUnidad" class="col-sm-2 control-label">
                        Unidad Documental: 
                    </label>
                    <div class="col-md-2">
                        <select id="CboIdUnidad" class="form-control input-sm"></select>           
                    </div>          
                </div>
              <div class="form-group">
                    <label for="CboIdTipoDoc" class="col-sm-2 control-label">
                        Tipo Documental: 
                    </label>
                    <div class="col-md-2">
                        <select id="CboIdTipoDoc" class="form-control input-sm"></select>           
                    </div>          
                </div>
              <div class="form-group">
                    <label for="TextCodigo" class="col-sm-2 control-label">
                       Codigo: 
                    </label>
                    <div class="col-md-2">
                        <input id="TextCodigo" type="text" class="form-control input-sm inputHab" />
                    </div>          
                </div>
                  <div class="form-group">
                    <label for="TextFecDoc" class="col-sm-2 control-label">
                      Fecha Documento: 
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
                    <label for="TextPaginaIni" class="col-sm-2 control-label">
                       Pagina Inicial: 
                    </label>
                    <div class="col-md-2">
                        <input id="TextPaginaIni" type="text" class="form-control input-sm inputHab" />
                    </div>          
                </div>
                  <div class="form-group">
                    <label for="TextCantidad" class="col-sm-2 control-label">
                       Cantidad Paginas: 
                    </label>
                    <div class="col-md-2">
                        <input id="TextCantidad" type="text" class="form-control input-sm inputHab" />
                    </div>          
                </div>
                  <div class="form-group">
                    <label for="TextDescripcion" class="col-sm-2 control-label">
                       Descripcion: 
                    </label>
                    <div class="col-md-4">
                        <textarea id="TextDescripcion" class="form-control input-sm inputHab" ></textarea>
                    </div>          
                </div>
                 
            </div>
           

          </div>
            
       </div>
    

    <script src="js/RelacionDocumental.js"></script>
</asp:Content>
