<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBS.Master" AutoEventWireup="true" CodeBehind="Vigencias.aspx.cs" Inherits="wfSircc.DatosBasicosG.Vigencias.Vigencias" %>
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
                             <button type="button" class="btn btn-danger" id="anularButton">
                            <span class="glyphicon glyphicon-remove"></span>
                            Anular</button>                 
                    </div>
                </div>    
               
            </div>           
        </div>

        <br />
    <br />
     <div class="form-horizontal" role="form" id="formDATOS">
         <ul class="nav nav-tabs">
            <li class="active"><a href="#tabVigencias" data-toggle="tab">1.Registro de Vigencias</a></li>
          
        </ul>
         <div   class="tab-content">
             <div id="tabVigencias" class="tab-pane in active ">
              <div class="col-md-12"> 
                 &nbsp
             </div>         
              <div class="form-group">
                  <div class="col-md-12">
                    <label for="TextVigencia" class="col-sm-2 control-label">
                        Vigencia: 
                    </label>
                    <div class="col-md-2">
                        <input id="TextVigencia" type="text" class="form-control input-sm inputHab" />
                    </div> 
                      <div class="col-md-5"> 
                      <div id="jqxgridHisto"></div> 
                      </div>  
                  </div>
                       
                       
                </div>
                                   
                                                      
                                                     
                    
         
   
            </div>
           

          </div>
            
       </div>
    

    <script src="js/Vigencias.js"></script>
</asp:Content>
