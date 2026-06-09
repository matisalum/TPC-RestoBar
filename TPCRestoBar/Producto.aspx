<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="TPCRestoBar.Producto1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Productos</h2>

    <asp:Button ID="btnNuevo"
        runat="server"
        Text="Nuevo Producto"
        CssClass="btn btn-primary mb-3"
        PostBackUrl="~/ProductoFormulario.aspx"/>

    <asp:GridView
        ID="dgvProductos"
        runat="server"
        CssClass="table table-striped">
    </asp:GridView>

</asp:Content>

