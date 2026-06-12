<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Mesas.aspx.cs" Inherits="TPCRestoBar.Mesas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mb-4">
        <h1 class="fw-bold">ADMINISTRACION DE MESAS</h1>
        <hr />
    </div>
    <div class="mb-3">
        <h4 class="text-muted">📋 Listado Mesas</h4>
    </div>

    <div class="card">
        <div class="card-body">
            <asp:GridView
                ID="dgvMesa"
                runat="server"
                AutoGenerateColumns="false"
                DataKeyNames="idMesa"
                OnSelectedIndexChanged ="dgvMesa_SelectedIndexChanged"
                CssClass="table table-striped table-hover"
                OnRowDataBound="dgvMesa_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="Numero" DataField="numero" />
                    <asp:BoundField HeaderText="Capacidad" DataField="capacidad" />
                    <asp:BoundField HeaderText="Empleado" DataField="idEmpleado" />
                    <asp:BoundField HeaderText="Estado" DataField="estado" />

                    <asp:CommandField HeaderText="Modificar"
                        ShowSelectButton="true"
                        SelectText="✏️" />
                </Columns>
                <HeaderStyle CssClass="table-dark" />
            </asp:GridView>
        </div>
    </div>

    <div class="mt-3 mb-3">
        <asp:Button Text="Agregar" ID="btnAgregar" CssClass="btn btn-success me-2" runat="server" OnClick="btnAgregar_Click" />
        <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-danger me-2" runat="server" />
    </div>
</asp:Content>
