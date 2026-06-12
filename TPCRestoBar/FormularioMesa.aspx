<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioMesa.aspx.cs" Inherits="TPCRestoBar.FormularioMesa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Formulario Mesa</h1>
    <div class="mb-3"> </div>
    <div class="mb-3">
        <asp:Label ID="lblNumero" CssClass="form-label" runat="server" Text="Numero"></asp:Label>
        <asp:TextBox ID="txtNumero" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="mb-3">
        <asp:Label ID="lblCapacidad" CssClass="form-label" runat="server" Text="Capacidad"></asp:Label>
        <asp:TextBox ID="txtCapacidad" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="mb-3">

        <asp:Button ID="btnAgregar" Text="Aceptar" CssClass="btn btn-success me-2" OnClick="btnAgregar_Click" runat="server" />

        <asp:Button ID="BtnCancelar" Text="Cancelar" CssClass="btn btn-danger me-2" runat="server" OnClick="BtnCancelar_Click" />

    </div>

</asp:Content>
