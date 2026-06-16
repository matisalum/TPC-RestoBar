<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioProducto.aspx.cs" Inherits="TPCRestoBar.ProductoFormulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="mb-4">Formulario de Productos</h2>


    <div class="mb-3">
        <asp:Label ID="lblNombre" CssClass="form-label" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="mb-3">
        <asp:Label ID="lblPrecio" CssClass="form-label" runat="server" Text="Precio"></asp:Label>
        <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server" ></asp:TextBox>
    </div>

    <div class="mb-3">
        <asp:Label ID="lblStock" CssClass="form-label" runat="server" Text="Stock"></asp:Label>
        <asp:TextBox ID="txtStock" CssClass="form-control" runat="server" ></asp:TextBox>
    </div>

    <div class="mb-3">
        <asp:CheckBox ID="chkActivo" runat="server" Text="Activo" />
    </div>

    <div class="mb-3">
        <asp:Label
            ID="lblMensaje"
            runat="server"
            CssClass="text-danger fw-bold">
        </asp:Label>
        </div>
        <div class="mb-3">
        <asp:Button ID="btnAgregar" Text="Agregar" OnClick="btnAgregar_Click" CssClass="btn btn-success me-2" runat="server" />
        
        <asp:Button ID="BtnCancelar" Text="Cancelar" OnClick="BtnCancelar_Click" CssClass="btn btn-danger me-2" runat="server" />

    </div>

</asp:Content>
