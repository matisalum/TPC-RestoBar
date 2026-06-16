<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="TPCRestoBar.Producto1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Productos</h2>

  
    <asp:GridView
    ID="dgvProductos"
    runat="server"
    CssClass="table table-striped"
    AutoGenerateColumns="false">

    <Columns>
        <asp:BoundField DataField="idProducto" HeaderText="ID" />
        <asp:BoundField DataField="nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="precio" HeaderText="Precio" />
        <asp:BoundField DataField="stock" HeaderText="Stock" />

        <asp:HyperLinkField
            HeaderText="Acción"
            Text="Modificar"
            DataNavigateUrlFields="idProducto"
            DataNavigateUrlFormatString="FormularioProducto.aspx?id={0}" />
    </Columns>

</asp:GridView>

      <asp:Button ID="btnNuevo"
      runat="server"
      Text="Nuevo Producto"
      CssClass="btn btn-primary mb-3"
      PostBackUrl="~/FormularioProducto.aspx"/>

    
</asp:Content>

