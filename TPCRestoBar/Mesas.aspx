<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Mesas.aspx.cs" Inherits="TPCRestoBar.Mesas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mb-4">
    <h1 class="fw-bold">ADMINISTRACION DE MESAS</h1>
    <hr />
</div>
<div class="mb-3">
    <h4 class="text-muted">📋 Listado Mesas</h4>
</div>

<div class="card">
    <div class="card-body">
        <asp:GridView
            ID="dgvMesa"
            runat="server"
            CssClass="table table-striped table-hover">
            <HeaderStyle CssClass="table-dark"/>
        </asp:GridView>
    </div>
</div>

<div class="mt-3 mb-3">
    <asp:Button Text="Agregar" ID="btnAgregar" CssClass="btn btn-success me-2" runat="server" OnClick="btnAgregar_Click"/>
    <asp:Button Text="Modificar" ID="btnModificar" CssClass="btn btn-warning me-2" runat="server" />
    <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-danger me-2" runat="server" />
</div>
</asp:Content>
