<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBS.Master" AutoEventWireup="true" CodeBehind="Series.aspx.cs" Inherits="wfSircc.DatosBasicosG.Series.Series" %>

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
            <li class="active"><a href="#tabSeries" data-toggle="tab">1.Registro Series</a></li>
          
        </ul>
         <div   class="tab-content">
             <div id="tabSeries" class="tab-pane in active ">
              <div class="col-md-12"> 
                 &nbsp
             </div>         
              <div class="form-group">
                    <label for="TextIdSerie" class="col-sm-2 control-label">
                        Id Serie: 
                    </label>
                    <div class="col-md-2">
                        <input id="TextIdSerie" type="text" class="form-control input-sm inputHab" />
                    </div>          
                </div>
              <div class="form-group">
                    <label for="TextSerie" class="col-sm-2 control-label">
                        Nombre: 
                    </label>
                    <div class="col-md-2">
                        <input id="TextSerie" type="text" class="form-control input-sm inputHab" />
                    </div>          
                </div>
              <div class="form-group">
                    <label for="TextPro" class="col-sm-2 control-label">
                        Procedimiento: 
                    </label>
                    <div class="col-md-2">
                        <input id="TextPro" type="text" class="form-control input-sm inputHab" />
                    </div>          
                </div>
            </div>
           

          </div>
            
       </div>
    

    <script src="js/Series.js"></script>
</asp:Content>
