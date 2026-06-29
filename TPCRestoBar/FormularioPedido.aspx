<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioPedido.aspx.cs" Inherits="TPCRestoBar.FormularioPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <h2 class="mb-4">Formulario de Pedido</h2>

    <div class="mb-3">
        <asp:Label ID="lblId" CssClass="form-label" runat="server" Text="ID"></asp:Label>
        <asp:TextBox ID="txtId" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
    </div>

    <div class="mb-3">
        <asp:Label ID="lblFecha" CssClass="form-label" runat="server" Text="Fecha del Pedido"></asp:Label>
        <asp:TextBox ID="txtFecha" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
    </div>

    <div class="mb-3">
        <asp:Label ID="lblMesa" CssClass="form-label" runat="server" Text="Mesa"></asp:Label>
        <asp:DropDownList ID="ddlMesa" runat="server" CssClass="form-select"></asp:DropDownList>
    </div>

    <div class="mb-3">
        <asp:Label ID="lblEmpleado" CssClass="form-label" runat="server" Text="Mesero"></asp:Label>
        <asp:DropDownList ID="ddlEmpleado" runat="server" CssClass="form-select"></asp:DropDownList>
    </div>

    <div class="mb-3">
        <asp:Label ID="lblEstado" CssClass="form-label" runat="server" Text="Estado"></asp:Label>
        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select">
            <asp:ListItem Text="Pendiente"  Value="Pendiente" />
            <asp:ListItem Text="En proceso" Value="En proceso" />
            <asp:ListItem Text="Entregado"  Value="Entregado" />
            <asp:ListItem Text="Cancelado"  Value="Cancelado" />
        </asp:DropDownList>
    </div>

    <div class="mb-3">
        <asp:Button ID="btnAgregar"  Text="Agregar"         OnClick="btnAgregar_Click" CssClass="btn btn-success me-2" runat="server" />
        <asp:Button ID="btnCancelar" Text="Cancelar pedido"        OnClick="btnCancelar_Click" CssClass="btn btn-danger me-2"  runat="server" />
    </div>

</asp:Content>
