<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBS.Master" AutoEventWireup="true" CodeBehind="SubSeries.aspx.cs" Inherits="wfSircc.DatosBasicosG.SubSeries.SubSeries" %>

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
            <li class="active"><a href="#tabSeries" data-toggle="tab">1.Registro SubSeries</a></li>
          
        </ul>
         <div   class="tab-content">
             <div id="tabSeries" class="tab-pane in active ">
              <div class="col-md-12"> 
                 &nbsp
             </div>         
              <div class="form-group">
                    <div class="form-group">
                    <label for="CboSeries" class="col-sm-2 control-label">
                      Serie: 
                    </label>
                    <div class="col-md-2">
                          <select id="CboSeries" class="form-control input-sm"></select>               
                    </div>               
                </div>
                    <label for="TextIdSubSerie" class="col-sm-2 control-label">
                        Id SubSerie: 
                    </label>
                    <div class="col-md-2">
                        <input id="TextIdSubSerie" type="text" class="form-control input-sm inputHab" />
                    </div>          
                </div>
              <div class="form-group">
                    <label for="TextSubSerie" class="col-sm-2 control-label">
                        Nombre: 
                    </label>
                    <div class="col-md-2">
                        <input id="TextSubSerie" type="text" class="form-control input-sm inputHab" />
                    </div>          
                </div>
              <div class="form-group">
                    <label for="TextAg" class="col-sm-2 control-label">
                        Retención Ag: 
                    </label>
                    <div class="col-md-2">
                        <input id="TextAg" type="text" class="form-control input-sm inputHab" />
                    </div>          
                </div>
                  <div class="form-group">
                    <label for="TextA" class="col-sm-2 control-label">
                        Retención AC: 
                    </label>
                    <div class="col-md-2">
                            <input id="TextA" type="text" class="form-control input-sm inputHab" />
                    </div>          
                </div>

                <div class="row" >
                       <div class="col-md-12">
                             <div class="col-md-1">
                            
                               </div>
                           <div class="col-md-3">
                            Disposición: 
                               </div>
                           </div>
                    <div class="col-md-12">
                        </div>
                    <div class="col-md-12">
                        <div class="col-md-1">
                          
                               </div>
                          <div class="col-md-1">                          
                       CT                      
                       <input id="CheckCT" type="checkbox" />
                   
                           </div>
                          <div class="col-md-1">                         
                            E
                           <input id="CheckE" type="checkbox" />
                   
                           </div>
                          <div class="col-md-1">
                           MD 
                               <input id="CheckMD" type="checkbox" />
                           </div>
                          <div class="col-md-1">
                          S 
                               <input id="CheckS" type="checkbox" />
                           </div>
                           </div>
                      
                   
                      

                      
  
                </div>
                 
               
                 
                
                
            </div>
           

          </div>
            
       </div>
    

    <script src="js/SubSeries.js"></script>
</asp:Content>
