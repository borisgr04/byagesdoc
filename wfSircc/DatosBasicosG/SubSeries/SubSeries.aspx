﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBS.Master" AutoEventWireup="true" CodeBehind="SubSeries.aspx.cs" Inherits="wfSircc.DatosBasicosG.SubSeries.SubSeries" %>

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
                    <label for="TextIdSubSerie" class="col-sm-2 control-label">
                        Id SubSerie: 
                    </label>
                    <div class="col-md-2">
                        <input id="TextIdSubSerie" type="text" class="form-control input-sm inputHab" />
                    </div>          
                </div>
              <div class="form-group">
                    <label for="TextSubSerie" class="col-sm-2 control-label">
                        SubSerie: 
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
                        Disposición A: 
                    </label>
                    <div class="col-md-2">
                        <input id="TextA" type="text" class="form-control input-sm inputHab" />
                    </div>          
                </div>
                  <div class="form-group">
                    <label for="TextCT" class="col-sm-2 control-label">
                       Disposición CT: 
                    </label>
                    <div class="col-md-2">
                        <input id="TextCT" type="text" class="form-control input-sm inputHab" />
                    </div>          
                </div>
                  <div class="form-group">
                    <label for="TextE" class="col-sm-2 control-label">
                         Disposición E: 
                    </label>
                    <div class="col-md-2">
                        <input id="TextE" type="text" class="form-control input-sm inputHab" />
                    </div>          
                </div>
                  <div class="form-group">
                    <label for="TextMD" class="col-sm-2 control-label">
                        Disposición MD: 
                    </label>
                    <div class="col-md-2">
                        <input id="TextMD" type="text" class="form-control input-sm inputHab" />
                    </div>          
                </div>
                  <div class="form-group">
                    <label for="TextS" class="col-sm-2 control-label">
                        Disposición S: 
                    </label>
                    <div class="col-md-2">
                        <input id="TextS" type="text" class="form-control input-sm inputHab" />
                    </div>          
                </div>
                  <div class="form-group">
                    <label for="CboSeries" class="col-sm-2 control-label">
                      Serie: 
                    </label>
                    <div class="col-md-2">
                          <select id="CboSeries" class="form-control input-sm"></select>               
                    </div>               
                </div>
            </div>
           

          </div>
            
       </div>
    

    <script src="js/SubSeries.js"></script>
</asp:Content>