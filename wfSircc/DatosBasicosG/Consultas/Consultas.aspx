<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBS.Master" AutoEventWireup="true" CodeBehind="Consultas.aspx.cs" Inherits="wfSircc.DatosBasicosG.Consultas.Consultas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">

        <div class="col-md-6">

            <asp:GridView ID="GridView1" runat="server" CssClass="table-hover" DataKeyNames="idUnidadDocumental" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-md-6">
        <asp:Literal ID="ltPrew" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
