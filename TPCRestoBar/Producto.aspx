<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="TPCRestoBar.Producto1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Productos</h2>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label ID="lblBuscar" Text="Filtrar Por Nombre: " runat="server"></asp:Label>
                <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control mb-2"></asp:TextBox>

                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary mb-3" OnClick="btnBuscar_Click" />
            </div>
        </div>
    </div>
    <asp:GridView
    ID="dgvProductos"
    runat="server"
    AutoGenerateColumns="false"
    DataKeyNames="idProducto"
    OnRowCommand="dgvProductos_RowCommand"
    CssClass="table table-striped">

    <Columns>
        <asp:BoundField DataField="idProducto" HeaderText="ID" />
        <asp:BoundField DataField="nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="precio" HeaderText="Precio" />
        <asp:BoundField DataField="stock" HeaderText="Stock" />

        <asp:HyperLinkField
            HeaderText="Modificar"
            Text="✏️ Modificar"
            DataNavigateUrlFields="idProducto"
            DataNavigateUrlFormatString="FormularioProducto.aspx?id={0}" />

        <asp:TemplateField HeaderText="Eliminar">
    <ItemTemplate>
        <asp:LinkButton
            ID="btnEliminar"
            runat="server"
            Text="🗑️ Eliminar"
            CommandName="Eliminar"
            CommandArgument="<%# Container.DataItemIndex %>"
            OnClientClick="return confirm('¿Está seguro de eliminar este producto?');">
        </asp:LinkButton>
    </ItemTemplate>
</asp:TemplateField>
    </Columns>

</asp:GridView>

      <asp:Button ID="btnNuevo"
      runat="server"
      Text="Nuevo Producto"
      CssClass="btn btn-primary mb-3"
      PostBackUrl="~/FormularioProducto.aspx"/>

    

    
</asp:Content>

