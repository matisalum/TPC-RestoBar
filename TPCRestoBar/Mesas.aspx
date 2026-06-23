<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Mesas.aspx.cs" Inherits="TPCRestoBar.Mesas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mb-4">
        <h1 class="fw-bold">ADMINISTRACION DE MESAS</h1>
        <hr />
    </div>
    <div class="mb-4">
        <label>Filtrar</label>
        <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control w-25" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged"/>
    </div>
    <div class="card">
        <div class="card-body">
            <asp:GridView
                ID="dgvMesa"
                runat="server"
                AutoGenerateColumns="false"
                DataKeyNames="idMesa"
                OnSelectedIndexChanged="dgvMesa_SelectedIndexChanged"
                AllowPaging="true"
                PageSize="10"
                OnPageIndexChanging="dgvMesa_PageIndexChanging"
                CssClass="table table-striped table-hover">
                <Columns>
                    <asp:BoundField HeaderText="Numero" DataField="numero" />
                    <asp:BoundField HeaderText="Capacidad" DataField="capacidad" />
                    <asp:BoundField HeaderText="Empleado" DataField="idEmpleado" />
                    <asp:CommandField HeaderText="Asignar" ShowSelectButton="true" SelectText="🧑‍🍳" />

                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <div class="d-flex align-items-center">
                                <span class='<%# Convert.ToBoolean(Eval("estado")) ? "badge bg-success" : "badge bg-secondary" %>'
                                    style="width: 12px; height: 12px; display: inline-block; border-radius: 50%;"></span>
                                <span class="ms-2">
                                    <%# Convert.ToBoolean(Eval("estado")) ? "Activo" : "Inactivo" %>
                                </span>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="✏️" />
                </Columns>
                <HeaderStyle CssClass="table-dark" />
            </asp:GridView>
        </div>
    </div>

    <div class="mt-3 mb-3">
        <asp:Button Text="Agregar" ID="btnAgregar" CssClass="btn btn-success me-2" runat="server" OnClick="btnAgregar_Click" />
    </div>
</asp:Content>
