<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioCategoria.aspx.cs" Inherits="TPCRestoBar.FormularioCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="position-relative p-3">

        <asp:Button ID="BtnCancelar" Text="✕" CssClass="btn btn-light border position-absolute top-0 end-0 m-2 fw-bold" runat="server" OnClick="BtnCancelar_Click"/>

        <h1>Formulario Categoria</h1>

        <div class="mb-3">
            <asp:Label ID="lblNombre" CssClass="form-label" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <%--<div class="mb-3">
            <asp:Label ID="lblDescripcion" CssClass="form-label" runat="server" Text="Descripcion"></asp:Label>
            <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server"></asp:TextBox>
        </div>--%>

        <div class="mb-3 d-flex gap-2">
            <asp:Button ID="btnAgregar" Text="Aceptar" CssClass="btn btn-success" runat="server" OnClick="btnAgregar_Click"/>
            <asp:Button ID="BtnInactivar" Text="Inactivar" CssClass="btn btn-warning" runat="server"  />
        </div>

    </div>

</asp:Content>
