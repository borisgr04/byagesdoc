<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBS.Master" AutoEventWireup="true" CodeBehind="TiposDocumentales.aspx.cs" Inherits="wfSircc.DatosBasicosG.TiposDocumentales.TiposDocumentales" %>

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
            <li class="active"><a href="#tabSeries" data-toggle="tab">1.Registro Tipos Documentales</a></li>
          
        </ul>
         <div   class="tab-content">
             <div id="tabSeries" class="tab-pane in active ">
              <div class="col-md-12"> 
                 &nbsp
             </div>         
              <div class="form-group">
                    <label for="TextIdDocumental" class="col-sm-2 control-label">
                        Id Documental: 
                    </label>
                    <div class="col-md-2">
                        <input id="TextIdDocumental" type="text" class="form-control input-sm inputHab" />
                    </div>          
                </div>
              <div class="form-group">
                    <label for="TextNombre" class="col-sm-2 control-label">
                        Nombre: 
                    </label>
                    <div class="col-md-2">
                        <input id="TextNombre" type="text" class="form-control input-sm inputHab" />
                    </div>          
                </div>
              <div class="form-group">
                    <label for="TextTdOriginal" class="col-sm-2 control-label">
                       TD_Original: 
                    </label>
                    <div class="col-md-2">
                        <input id="TextTdOriginal" type="text" class="form-control input-sm inputHab" />
                    </div>          
                </div>
                  <div class="form-group">
                    <label for="TextTdCopia" class="col-sm-2 control-label">
                        TD_Copia: 
                    </label>
                    <div class="col-md-2">
                        <input id="TextTdCopia" type="text" class="form-control input-sm inputHab" />
                    </div>          
                </div>
                  <div class="form-group">
                    <label for="CboSeries" class="col-sm-2 control-label">
                      Serie: 
                    </label>
                    <div class="col-md-2">
                          <select id="CboSubSeries" class="form-control input-sm"></select>               
                    </div>               
                </div>
            </div>
           

          </div>
            
       </div>
    

    <script src="js/TiposDocumentales.js"></script>
</asp:Content>
