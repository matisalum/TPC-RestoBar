<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioEmpleado.aspx.cs" Inherits="TPCRestoBar.FormularioEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="mb-4">Formulario de Empleado</h2>


    <div class="mb-3">
        <asp:Label ID="lblId" CssClass="form-label" runat="server" Text="ID"></asp:Label>
        <asp:TextBox ID="txtId" CssClass="form-control" runat="server"></asp:TextBox>
    </div>


    <div class="mb-3">
        <asp:Label ID="lblNombre" CssClass="form-label" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="mb-3">
        <asp:Label ID="lblApellido" CssClass="form-label" runat="server" Text="Apellido"></asp:Label>
        <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="mb-3">
        <asp:Label ID="lblUsuario" CssClass="form-label" runat="server" Text="Usuario"></asp:Label>
        <asp:TextBox ID="txtUsuario" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="mb-3">
        <asp:Label ID="lblContrasena" CssClass="form-label" runat="server" Text="Contraseña"></asp:Label>
        <asp:TextBox ID="txtContrasena" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
    </div>

    <div class="mb-3">
        <asp:Label ID="lblRol" CssClass="form-label" runat="server" Text="Rol"></asp:Label>
        <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-select"></asp:DropDownList>
    </div>
    <div class="mb-3">
        <asp:CheckBox ID="chkActivo" runat="server" Text="Activo"></asp:CheckBox>
    </div>

    <div class="mb-3">

        <asp:Button ID="btnAgregar" Text="Agregar" OnClick="btnAgregar_Click" CssClass="btn btn-success me-2" runat="server" />

        <asp:Button ID="BtnCancelar" Text="Cancelar" OnClick="BtnCancelar_Click" CssClass="btn btn-danger me-2" runat="server" />

    </div>
</asp:Content>
