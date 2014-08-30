<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBS.Master" AutoEventWireup="true" CodeBehind="Prueba.aspx.cs" Inherits="wfSircc.DatosBasicosG.Prueba.Prueba" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-horizontal">
        <div class="row">

            <div class="form-group" id="dvdTipDoc">
                <label for="CboTipDoc" class="col-sm-3 control-label">Serie</label>
                <div class="col-sm-3">
                    <asp:DropDownList ID="cboSerie" runat="server" AutoPostBack="True" DataSourceID="Obj" DataTextField="Serie" DataValueField="idSerie" class="form-control">
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group" id="Div1">
                <label for="CboTipDoc" class="col-sm-3 control-label">Sub-Serie</label>
                <div class="col-sm-3">
                    <asp:DropDownList ID="cboSubSerie" runat="server" DataSourceID="ObjSubSerie" DataTextField="SubSerie" DataValueField="idSubSeries" class="form-control">
                    </asp:DropDownList>
                </div>
            </div>


            <div class="form-group" id="Div2">
                <label for="CboTipDoc" class="col-sm-3 control-label">Dependencia</label>
                <div class="col-sm-3">
                    <asp:DropDownList ID="CboDependencias" runat="server" DataSourceID="ObjDependencias" DataTextField="Dependencia" DataValueField="idDependencia" class="form-control">
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group" id="Div3">
                <label for="CboTipDoc" class="col-sm-3 control-label"></label>
                <div class="col-sm-3">
                    <asp:Button ID="BtnAceptar" runat="server" OnClick="BtnAceptar_Click" Text="Ver Bandeja de Entrada" Width="167px" />

                </div>
            </div>

             <div class="form-group" id="Div4">
                <label for="CboTipDoc" class="col-sm-3 control-label"></label>
                <div class="col-sm-3">
                  <asp:Button ID="BtnMoverArchivos" runat="server" Text="Mover" OnClick="BtnMoverArchivos_Click" />
                </div>
            </div>
        </div>

    </div>

   
    <div class="row">
        <div class="col-md-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Bandeja de Entrada</h3>
                </div>
                <div class="panel-body">
                    <asp:CheckBoxList ID="ChkBE" runat="server" CssClass="table-hover">
                    </asp:CheckBoxList>
                </div>
            </div>
        </div>
        <div class="col-md-6">
    <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Lista de Documentos Seleccionados</h3>
                </div>
                <div class="panel-body">
                    <asp:CheckBoxList ID="ChkOK" runat="server" CssClass="table-hover">
                    </asp:CheckBoxList>
                </div>
            </div>
        </div>
    </div>


     Vista Preeliminar
     <div id="dvdemb">
      <%--   var _cambiarPDF = function (i) {
        var url = 'http://localhost:1476/ashx/ashxDoc.ashx?id=' + i + '#toolbar=1';
        var doc = "<embed src='" + url + "' width='100%' height='600'>";
        $('#dvdemb').html(doc);
    };--%>
         <embed src="/Docs/BE/10.10.0001.pdf" width="500" height="375">

     </div>


    <br />

    <asp:ObjectDataSource ID="ObjDependencias" runat="server" SelectMethod="Gets" TypeName="BLL.Gestion.mDependencias"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjSubSerie" runat="server" SelectMethod="Gets" TypeName="BLL.Gestion.mSubSeries">
        <SelectParameters>
            <asp:ControlParameter ControlID="cboSerie" Name="serieId" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="Obj" runat="server" SelectMethod="Gets" TypeName="BLL.Gestion.mSeries"></asp:ObjectDataSource>
    <br />
    <br />
</asp:Content>
