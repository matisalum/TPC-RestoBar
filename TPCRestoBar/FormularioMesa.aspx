<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioMesa.aspx.cs" Inherits="TPCRestoBar.FormularioMesa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="position-relative p-3">

        <asp:Button ID="BtnCancelar" Text="✕" CssClass="btn btn-light border position-absolute top-0 end-0 m-2 fw-bold" runat="server" OnClick="BtnCancelar_Click" />

        <h1>Formulario Mesa</h1>

        <div class="mb-3">
            <asp:Label ID="lblNumero" CssClass="form-label" runat="server" Text="Numero"></asp:Label>
            <asp:TextBox ID="txtNumero" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="mb-3">
            <asp:Label ID="lblCapacidad" CssClass="form-label" runat="server" Text="Capacidad"></asp:Label>
            <asp:TextBox ID="txtCapacidad" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="mb-3 d-flex gap-2">
            <asp:Button ID="btnAgregar" Text="Aceptar" CssClass="btn btn-success" OnClick="btnAgregar_Click" runat="server" />
            <asp:Button ID="BtnInactivar" Text="Inactivar" CssClass="btn btn-warning" runat="server" OnClick="BtnInactivar_Click" />
        </div>

    </div>
</asp:Content>
