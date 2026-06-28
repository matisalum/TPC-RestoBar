<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioCategoria.aspx.cs" Inherits="TPCRestoBar.FormularioCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    

    <div class="position-relative p-4 border rounded bg-light shadow-sm max-w-md mx-auto mt-4">

        <asp:Button ID="BtnCancelar" Text="✕" CssClass="btn btn-sm btn-outline-secondary position-absolute top-0 end-0 m-3 fw-bold rounded-circle" runat="server" OnClick="BtnCancelar_Click" />

        <h2 class="mb-4 text-right text-success">Formulario Categoria</h2>

        <div class="row g-3">
            <div class="col-12 col-md-6">
                <asp:Label ID="lblNombre" CssClass="form-label fw-semibold" runat="server" Text="Número"></asp:Label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="Ej: Bebida" runat="server"></asp:TextBox>
                <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger fw-bold"></asp:Label>
            </div>

            <hr class="text-mutedmy-2">

            <div class="col-12 d-flex justify-content-end gap-2">
                <asp:Button ID="BtnInactivar" Text="Inactivar" CssClass="btn btn-outline-danger" runat="server" OnClick="BtnInactivar_Click" />
                <asp:Button ID="btnAgregar" Text="Aceptar" CssClass="btn btn-success px-4" OnClick="btnAgregar_Click" runat="server" />
            </div>
        </div>

    </div>

</asp:Content>
