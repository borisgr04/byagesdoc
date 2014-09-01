<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBS.Master" AutoEventWireup="true" CodeBehind="GesSeries.aspx.cs" Inherits="wfSircc.DatosBasicosG.Series.GesSeries" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
            <div class="col-md-12">               
                <div class="col-md-6">
                        <div class="btn-toolbar">
                        <button type="button" class="btn btn-warning" id="nuevoButton">
                            <span class="glyphicon glyphicon-plus-sign"></span>
                            Nuevo</button>                          
                        <button type="button" class="btn btn-primary" id="editarButton">
                            <span class="glyphicon glyphicon-pencil"></span>
                            Editar</button>                  
                                   
                    </div>
                </div>    
               
            </div>           
        </div>
       <br />
    <br />
      <div class="row">                      
                      <div class="col-md-3">  
                                         Listado de Series  
                      </div>                                      
                      <div class="col-md-12">  
                             &nbsp                            
                      </div>                                     
                      <div class="col-md-12"> 
                      <div id="jqxgridHisto"></div> 
                      </div>
         </div>   
     <script src="js/GesSeries.js"></script>
</asp:Content>
