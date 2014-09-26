<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBS.Master" AutoEventWireup="true" CodeBehind="Consultas.aspx.cs" Inherits="wfSircc.DatosBasicosG.Consultas.Consultas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
         <div class="col-md-12">
               
                <div class="col-md-6">
                        <div class="btn-toolbar">
                        <button type="button" class="btn btn-warning" id="BtnNuevo">
                            <span class="glyphicon glyphicon-plus-sign"></span>
                            ver Pdf</button>
                        <button type="button" class="btn btn-info" id="BtnBuscar">
                            <span class="glyphicon glyphicon-pencil"></span>
                            Buscar</button>                   
                                
                                                                    
                                    
                    </div>
                </div>    
               
            </div>      
         <div class="col-md-12"> 
         &nbsp
        </div> 
                        <div class="col-md-12">             
        <div id="jqxgridConsul"></div>                     
       
        </div>

        <div id="kevin" class="col-md-6">
        <asp:Literal ID="ltPrew" runat="server"></asp:Literal>
        </div>         
                  <div class="col-md-12"> 
         &nbsp
        </div>      
        
                
    
          <div class="col-md-12">               
                 <div class="col-md-3">
                    <input id="CheckSubSeries" type="checkbox" />             
                    <label for="CheckSubSeries" >
                       SubSeries: 
                    </label>
                    <select id="CboSubSeries" class="form-control input-sm"></select>         
                    </div> 
                <div class="col-md-3">
                    <input id="CheckDep" type="checkbox" />             
                    <label for="CheckDep" >
                        Dependencia: 
                    </label>
                    <select id="CboDep" class="form-control input-sm"></select>         
                </div> 
               <div class="col-md-2">
                    <input id="CheckFolios" type="checkbox" />             
                    <label for="CheckFolios" >
                        Nº Folios: 
                    </label>
                   <input id="TextFolios" class="form-control inputHab" />
                </div> 
               <div class="col-md-2">
                    <input id="CheckCaja" type="checkbox" />             
                    <label for="CheckCaja" >
                       Nº Caja: 
                    </label>
                     <input id="TextCaja" class="form-control inputHab" />  
                </div> 
               <div class="col-md-2">
                    <input id="CheckCarpeta" type="checkbox" />             
                    <label for="CheckCarpeta" >
                        Nº Carpeta: 
                    </label>
                     <input id="TextCarpeta" class="form-control inputHab" />  
                </div> 
                <div class="col-md-3">
                    <input id="CheckEntidad" type="checkbox" />             
                    <label for="CheckEntidad" >
                        Entidad Productora: 
                    </label>
                     <input id="TextEntidad" class="form-control inputHab" />  
                </div> 
                <div class="col-md-3">
                    <input id="CheckCreacion" type="checkbox" />             
                    <label for="CheckCreacion" >
                        Fecha de Creacion: 
                    </label>                    
                            <div class="input-medium">
                                <div class="input-group">
                                    <input class="input-medium date-picker" id="TextFecDoc" type="text" data-date-format="dd-mm-yyyy" placeholder="mm-dd-yyyy" />
                                    <span class="input-group-addon">
                                        <i class="icon-calendar"></i>
                                    </span>
                                </div>
                            </div>
                </div> 
               <div class="col-md-3">
                    <input id="CheckInicial" type="checkbox" />             
                    <label for="CheckInicial" >
                        Fecha Ext Inicial: 
                    </label>                    
                            <div class="input-medium">
                                <div class="input-group">
                                    <input class="input-medium date-picker" id="TextFextIni" type="text" data-date-format="dd-mm-yyyy" placeholder="mm-dd-yyyy" />
                                    <span class="input-group-addon">
                                        <i class="icon-calendar"></i>
                                    </span>
                                </div>
                            </div>
                </div> 
               <div class="col-md-3">
                    <input id="CheckFinal" type="checkbox" />             
                    <label for="CheckFinal" >
                       Fecha Ext Final: 
                    </label>                    
                            <div class="input-medium">
                                <div class="input-group">
                                    <input class="input-medium date-picker" id="TextFextFin" type="text" data-date-format="dd-mm-yyyy" placeholder="mm-dd-yyyy" />
                                    <span class="input-group-addon">
                                        <i class="icon-calendar"></i>
                                    </span>
                                </div>
                            </div>
                </div> 
               <div class="col-md-12"> 
         &nbsp

        </div>  
               
                
                            
               
        
        </div>  

    </div>

     <div class="modal fade" id="modalTerceros" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="H5">Vista en Pdf</h4>
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
     <script src="js/Consultas.js"></script>
</asp:Content>
