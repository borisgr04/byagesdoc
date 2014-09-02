<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBS.Master" AutoEventWireup="true" CodeBehind="Dependencias.aspx.cs" Inherits="wfSircc.DatosBasicosG.Dependencias.Dependencias" %>

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
            <li class="active"><a href="#tabDepen" data-toggle="tab">1.Registro Dependencias</a></li>
          
        </ul>
         <div   class="tab-content">
             <div id="tabDepen" class="tab-pane in active ">
              <div class="col-md-12"> 
                 &nbsp
             </div>         
              <div class="form-group">
                    <label for="TextIdDependencia" class="col-sm-2 control-label">
                        Id Dependencia: 
                    </label>
                    <div class="col-md-2">
                        <input id="TextIdDependencia" type="text" class="form-control input-sm inputHab" />
                    </div>          
                </div>
              <div class="form-group">
                    <label for="TextDependencia" class="col-sm-2 control-label">
                        Dependencia: 
                    </label>
                    <div class="col-md-2">
                        <input id="TextDependencia" type="text" class="form-control input-sm inputHab" />
                    </div>          
                </div>            
            </div>
           

          </div>
            
       </div>
    

    <script src="js/Dependencias.js"></script>

</asp:Content>
