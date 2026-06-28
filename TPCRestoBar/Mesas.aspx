<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Mesas.aspx.cs" Inherits="TPCRestoBar.Mesas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mb-4">
        <h1 class="fw-bold">ADMINISTRACION DE MESAS</h1>
        <hr />
    </div>
    <div class="row">
        <div class="col mb-4">
            <label>Filtrar x Nro Mesa</label>
            <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
        </div>
        <div class="col">
            <label>Flitro avanzado </label>
            <asp:CheckBox ID="chbAvanzado" AutoPostBack="true" OnCheckedChanged="chbAvanzado_CheckedChanged" runat="server" />
        </div>
    </div>
    <%if (chbAvanzado.Checked)
        { %>
    <div class="row mb-3">
        <div class="col">
            <label>Campo :</label>
            <asp:DropDownList ID="ddlCampo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" CssClass="btn btn-primary dropdown-toggle">
                <asp:ListItem Text="Numero" />
                <asp:ListItem Text="Capacidad" />
                <asp:ListItem Text="Empleado" />
            </asp:DropDownList>
        </div>
        <div class="col">
            <label>Estado :</label>
            <asp:DropDownList ID="ddlEstado" runat="server" class="btn btn-secondary dropdown-toggle">
                <asp:ListItem Text="Todos" />
                <asp:ListItem Text="Activos" />
                <asp:ListItem Text="Inactivos" />
            </asp:DropDownList>
        </div>
        <div class="col">
            <asp:TextBox ID="txbFiltroA" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col">
            <asp:Button ID="btnBuscar" CssClass="btn btn-primary" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
        </div>
    </div>
    <div class="row mb-3">
        <div class="col">
            <label>Mosos :</label>
            <asp:DropDownList ID="ddlMosos" runat="server"
                AutoPostBack="true"
                OnSelectedIndexChanged="ddlMosos_SelectedIndexChanged"
                CssClass="btn btn-primary dropdown-toggle">
            </asp:DropDownList>
        </div>
    </div>
    <%  } %>
    <div class="row">
        <div class="col">
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
                    <asp:TemplateField HeaderText="Empleado">
                        <ItemTemplate>
                            <asp:Label ID="lblEmpleado" runat="server"
                                Text='<%# buscarEmpleado(Convert.ToInt32(Eval("idEmpleado"))) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:CommandField HeaderText="Asignar" ShowSelectButton="true" SelectText="🧑‍🍳" />--%>

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
