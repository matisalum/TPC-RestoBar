<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="TPCRestoBar.Empleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mb-4">
        <h1 class="fw-bold">ADMINISTRACION DE EMPLADOS</h1>
        <hr />
    </div>
    <div class="mb-3">
        <h4 class="text-muted">📋 Listado empleados</h4>
    </div>
    <div class="row">
        <div class="col mb-4">
            <label>Filtrar por Nombre</label>
            <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control"
                AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
        </div>
        <div class="col">
            <label>Filtro avanzado</label>
            <asp:CheckBox ID="chbAvanzado" AutoPostBack="true"
                OnCheckedChanged="chbAvanzado_CheckedChanged" runat="server" />
        </div>
    </div>
    <% if (chbAvanzado.Checked)
        { %>
    <div class="row mb-3">
        <div class="col">
            <label>Campo :</label>
            <asp:DropDownList ID="ddlCampo" runat="server" AutoPostBack="true"
                OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged"
                CssClass="btn btn-primary dropdown-toggle">
                <asp:ListItem Text="Nombre" />
                <asp:ListItem Text="Apellido" />
                <asp:ListItem Text="Usuario" />
            </asp:DropDownList>
        </div>
        <div class="col">
            <label>Rol :</label>
            <asp:DropDownList ID="ddlRol" runat="server"
                CssClass="btn btn-secondary dropdown-toggle">
                <asp:ListItem Text="Todos" />
                <asp:ListItem Text="Gerente" />
                <asp:ListItem Text="Mesero" />
             
            </asp:DropDownList>
        </div>
        <div class="col">
            <label>Estado :</label>
            <asp:DropDownList ID="ddlEstado" runat="server"
                CssClass="btn btn-secondary dropdown-toggle">
                <asp:ListItem Text="Todos" />
                <asp:ListItem Text="Activos" />
                <asp:ListItem Text="Inactivos" />
            </asp:DropDownList>
        </div>
        <div class="col">
            <asp:TextBox ID="txbFiltroA" CssClass="form-control" runat="server"
                placeholder="Valor a buscar..." />
        </div>
        <div class="col">
            <asp:Button ID="btnBuscar" CssClass="btn btn-primary" runat="server"
                OnClick="btnBuscar_Click" Text="Buscar" />
        </div>
    </div>
    <% } %>

    <div class="card">
        <div class="card-body">
            <asp:GridView
                ID="dgvEmpleados"
                runat="server"
                AutoGenerateColumns="false"
                DataKeyNames="idEmpleado"
                OnSelectedIndexChanged="dgvEmpleados_SelectedIndexChanged"
                CssClass="table table-striped table-hover">

                <Columns>

                    <asp:BoundField HeaderText="ID" DataField="idEmpleado" />
                    <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="apellido" />
                    <asp:BoundField HeaderText="Usuario" DataField="usuario" />
                    <asp:BoundField HeaderText="Contraseña" DataField="password" />
                    <asp:BoundField HeaderText="Rol" DataField="rol" />
                    <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />

                    <asp:CommandField HeaderText="Modificar"
                        ShowSelectButton="true"
                        SelectText="📝" />

                </Columns>

                <HeaderStyle CssClass="table-dark" />

            </asp:GridView>
        </div>
    </div>

    <div class="mt-3 mb-3">
        <asp:Button Text="Agregar" ID="btnAgregar" CssClass="btn btn-success me-2" OnClick="btnAgregar_Click" runat="server" />
    </div>

</asp:Content>


