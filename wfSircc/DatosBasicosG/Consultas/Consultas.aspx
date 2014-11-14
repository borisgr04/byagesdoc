<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBS.Master" AutoEventWireup="true" CodeBehind="Consultas.aspx.cs" Inherits="wfSircc.DatosBasicosG.Consultas.Consultas" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <style>

        .Incrimentar {
            height:800px;
        }

    </style>

    <div class="row">
         <div class="col-md-12">
               
                <div class="col-md-9">
                       
                          <button type="button" class="btn btn-warning" id="BtnNuevo">
                            <span class="glyphicon glyphicon-file "></span>
                            Vista Previa</button>
                           <button type="button" class="btn btn-info" id="BtnBuscar">
                            <span class="glyphicon glyphicon-search"></span>
                            Filtrar</button>   
                           <button type="button" class="btn btn-danger" id="tiposButton">
                                <span class="glyphicon glyphicon-info-sign">
                                </span>Tipos Documentales</button>  
                            <asp:LinkButton ID="LinkButton1"  runat="server" Text="<span class='glyphicon glyphicon-download-alt'></span>  Descargar Archivos " CssClass="btn btn-success" OnClick="LinkButton1_Click" />

                           </div>
                            
         </div>      
         <div class="col-md-12"> 
         &nbsp
         &nbsp
        </div>                         
         
        
     </div>    
    <div class="form-horizontal" role="form" id="formDATOS">
        <!-- Nav tabs -->
        <ul class="nav nav-tabs">
            <li class="active"><a href="#tabRadi" data-toggle="tab">1.Filtros</a></li>
            <li><a href="#tabhist" data-toggle="tab">2.Consultas</a></li>  
            <li><a href="#tabreporte" data-toggle="tab">3.Reporte</a></li>
              <li><a href="#tabrotulo" data-toggle="tab">3.Rotulos</a></li>        
        </ul>

        <div class="tab-content">

            <div id="tabRadi" class="tab-pane in active">                
                <div class="col-md-12"> 
                 &nbsp
                </div> 
                <div class="form-group">
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
                   <input id="TextFoliosF" class="form-control inputHab" />
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
                    </div>
                    <div class="col-md-12"> 
                 &nbsp
                </div>
                    <div class="col-md-12">
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
                                    <input class="input-medium date-picker" id="TextFecDoc" type="text" data-date-format="dd-mm-yyyy" placeholder="Desde mm-dd-yyyy" />
                                    <span class="input-group-addon">
                                        <i class="icon-calendar"></i>
                                    </span>
                                </div>
                            </div>
                             <div class="input-medium">
                                <div class="input-group">
                                    <input class="input-medium date-picker" id="TextFecDocFin" type="text" data-date-format="dd-mm-yyyy" placeholder="Hasta mm-dd-yyyy" />
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
                                    <input class="input-medium date-picker" id="TextFextIni" type="text" data-date-format="dd-mm-yyyy" placeholder="Desde mm-dd-yyyy" />
                                    <span class="input-group-addon">
                                        <i class="icon-calendar"></i>
                                    </span>
                                </div>
                            </div>
                              <div class="input-medium">
                                <div class="input-group">
                                    <input class="input-medium date-picker" id="TextFextIniFin" type="text" data-date-format="dd-mm-yyyy" placeholder="Hasta mm-dd-yyyy" />
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
                                    <input class="input-medium date-picker" id="TextFextFin" type="text" data-date-format="dd-mm-yyyy" placeholder="Desde mm-dd-yyyy" />
                                    <span class="input-group-addon">
                                        <i class="icon-calendar"></i>
                                    </span>
                                </div>
                            </div>
                               <div class="input-medium">
                                <div class="input-group">
                                    <input class="input-medium date-picker" id="TextFextFin2" type="text" data-date-format="dd-mm-yyyy" placeholder="Hasta mm-dd-yyyy" />
                                    <span class="input-group-addon">
                                        <i class="icon-calendar"></i>
                                    </span>
                                </div>
                            </div>
                </div>      
                    </div>
                    <div class="col-md-12"> 
                 &nbsp
                </div>
                    <div class="col-md-12">
                          <div class="col-md-2">
                    <input id="CheckEstante" type="checkbox" />             
                    <label for="TextEstante" >
                       Estante: 
                    </label>
                   <input id="TextEstante" class="form-control inputHab" />
                   
                </div> 
                          <div class="col-md-2">
                    <input id="CheckFrecuencia" type="checkbox" />             
                    <label for="CboFrecuencia" >
                       Frecuencia: 
                    </label>
                    <select id="CboFrecuencia" class="form-control input-sm">    
                              <option value="" >Seleccione</option>                          
                              <option value="BAJA" >Baja</option>
                              <option value="MEDIA">Media</option>
                              <option value="ALTA">Alta</option>
                              
                          </select>             
                </div> 
                          <div class="col-md-2">
                    <input id="CheckVigencia" type="checkbox" />             
                    <label for="CboVigencia" >
                        Vigencia: 
                    </label>
                     <select id="CboVigencia" class="form-control input-sm"></select> 
              
                    </div>
                          <div class="col-md-3">
                    <input id="CheckFisico" type="checkbox" />             
                    <label for="CheckFisico" >
                       Soporte Fisico
                    </label>   
                          <select id="CboFisico" class="form-control input-sm">   
                              <option value="" >Seleccione</option>          
                              <option value="1" >SI</option>                          
                              <option value="0" >NO</option>                    
                          </select>            
                    </div>                   
                          <div class="col-md-3">
                    <input id="CheckDigital" type="checkbox" />             
                    <label for="CheckDigital" >
                        Soporte Digital: 
                    </label>
                       <select id="CboDigital" class="form-control input-sm">    
                              <option value="" >Seleccione</option> 
                              <option value="1" >SI</option>                          
                              <option value="0" >NO</option>                    
                          </select>     
                </div>
                         
                    </div>
                          
               </div>
                
                     
            </div>                       
            <div id="tabhist" class="tab-pane ">          

          <div class="col-md-12">  
               <div class="col-md-10">     
                
        
                   </div>
              </div>
                   <div class="form-group"> 
                 
                       
                          <div class="col-md-12">             
                  &nbsp
                  &nbsp       
        </div>
                      <div class="col-md-12">             
        <div id="jqxgridConsul"></div>                     
       
        </div>
                      <div id="kevin" class="col-md-6">
        <asp:Literal ID="ltPrew" runat="server"></asp:Literal>
        </div>   
                       </div>       
           </div> 
             <div id="tabreporte" class="tab-pane ">          
                 
              <div id="Reporte" class="form-group">                  
                  <rsweb:ReportViewer ID="ReportViewer1" Width="100%" Height="300px" runat="server">
                      <LocalReport ReportPath="Rpt\RptListaUniDoc.rdlc">
                          <DataSources>
                  <rsweb:ReportDataSource DataSourceId="ObjReporte" Name="DsetTunidadDocumental" />
                      </DataSources>
                      </LocalReport>
                  </rsweb:ReportViewer>
                  <asp:ObjectDataSource ID="ObjReporte" runat="server" SelectMethod="Reporte" TypeName="wfSircc.Servicios.Archivos.wsDocumentos" >
                    
                  </asp:ObjectDataSource>
                
              </div>
                  
           </div>  
             <div id="tabrotulo" class="tab-pane ">          
                 
              <div id="Rotulo" class="form-group">                  
                  <rsweb:ReportViewer ID="ReportViewer2" Width="100%" Height="300px" runat="server">
                      <LocalReport ReportPath="Rpt\RptRotulos.rdlc">
                          <DataSources>
                  <rsweb:ReportDataSource DataSourceId="ObjRotulos" Name="DataSet1" />
                      </DataSources>
                      </LocalReport>
                  </rsweb:ReportViewer>
 <asp:ObjectDataSource ID="ObjRotulos" runat="server" SelectMethod="Reporte" TypeName="wfSircc.Servicios.Archivos.wsDocumentos" >
                    
                  </asp:ObjectDataSource>
                
              </div>
                  
           </div>  

        </div>
           
    
       </div>
       
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
         
         
        
    
          

    

     <div class="modal fade Incrimentar" id="modalTerceros" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;           <h4 class="modal-title" id="H5">Vista en Pdf</h4>
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
