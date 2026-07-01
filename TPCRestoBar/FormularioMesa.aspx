<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioMesa.aspx.cs" Inherits="TPCRestoBar.FormularioMesa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="position-relative p-4 border rounded bg-light shadow-sm max-w-md mx-auto mt-4">

        <asp:Button ID="BtnCancelar" Text="✕" CssClass="btn btn-sm btn-outline-secondary position-absolute top-0 end-0 m-3 fw-bold rounded-circle" runat="server" OnClick="BtnCancelar_Click" />

        <h2 class="mb-4 text-right text-success">Formulario Mesa</h2>

        <div class="row g-3">
            <div class="col-12 col-md-6">
                <asp:Label ID="lblNumero" CssClass="form-label fw-semibold" runat="server" Text="*Número"></asp:Label>
                <asp:TextBox ID="txtNumero" CssClass="form-control" placeholder="Ej: 5" runat="server" ></asp:TextBox>
                <asp:Label ID="lblMensajeN" runat="server" CssClass="text-danger fw-bold"></asp:Label>
            </div>

            <div class="col-12 col-md-6">
                <asp:Label ID="lblCapacidad" CssClass="form-label fw-semibold" runat="server" Text="*Capacidad"></asp:Label>
                <asp:TextBox ID="txtCapacidad" CssClass="form-control" placeholder="Ej: 4 personas" runat="server"></asp:TextBox>
                <asp:Label ID="lblMensajeC" runat="server" CssClass="text-danger fw-bold"></asp:Label>
            </div>

            <div class="col-12 mb-3">
                <asp:Label ID="lblEmpleados" CssClass="form-label fw-semibold" Text="Empleados asignados" runat="server" />
                <asp:Label ID="lblMensajeD" runat="server" CssClass="text-danger fw-bold"></asp:Label>
                <asp:DropDownList ID="ddlEmpleados" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>

            <hr class="text-mutedmy-2">

            <div class="col-12 d-flex justify-content-end gap-2">
                <asp:Button ID="BtnInactivar" Text="Inactivar" CssClass="btn btn-outline-danger" runat="server" OnClick="BtnInactivar_Click" />
                <asp:Button ID="btnLiberar" Text="Liberar" CssClass="btn btn-warning px-4" OnClick="btnLiberar_Click" runat="server" />
                <asp:Button ID="btnAgregar" Text="Aceptar" CssClass="btn btn-success px-4" OnClick="btnAgregar_Click" runat="server" />
            </div>
        </div>

    </div>
</asp:Content>
