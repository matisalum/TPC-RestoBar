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

<div class="card">
    <div class="card-body">
        <asp:GridView
            ID="dgvEmpleados"
            runat="server"
            AutoGenerateColumns="false"
            DataKeyNames="idEmpleado"
            OnselectedIndexChanged="dgvEmpleados_SelectedIndexChanged"
            CssClass="table table-striped table-hover">

            <Columns>

                <asp:BoundField HeaderText="ID" DataField="idEmpleado" />
                <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="apellido" />
                <asp:BoundField HeaderText="Usuario" DataField="usuario" />
                 <asp:BoundField HeaderText="Contraseña" DataField="password" />
                <asp:BoundField HeaderText="Rol" DataField="rol" />
                <asp:CheckBoxField HeaderText="Activo" DataField="Activo"/>

                <asp:CommandField HeaderText="Modificar" 
                    ShowSelectButton="true"
                    SelectText="📝"  />

            </Columns>
            
            <HeaderStyle CssClass="table-dark"/>
            
        </asp:GridView>
    </div>
</div>

<div class="mt-3 mb-3">
    <asp:Button Text="Agregar" ID="btnAgregar" CssClass="btn btn-success me-2"  OnClick="btnAgregar_Click" runat="server" />
    <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-danger me-2" runat="server" />
</div>

</asp:Content>


