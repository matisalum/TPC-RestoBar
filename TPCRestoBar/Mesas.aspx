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
                AllowPaging="true"
                PageSize="10"
                OnPageIndexChanging="dgvMesa_PageIndexChanging" 
                OnSelectedIndexChanged="dgvMesa_SelectedIndexChanged"
                CssClass="table table-striped table-hover">
                <Columns>
                    <asp:BoundField HeaderText="Numero" DataField="numero" />
                    <asp:BoundField HeaderText="Capacidad" DataField="capacidad" />
                    <%--<asp:BoundField HeaderText="Empleado" DataField="idEmpleado" />--%>

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
            <%--<nav aria-label="...">
                <ul class="pagination">
                    <li class="page-item"><a href="#" class="page-link">Previous</a></li>
                    <li class="page-item"><a class="page-link" href="#">1</a></li>
                    <li class="page-item active">
                        <a class="page-link" href="#" aria-current="page">2</a>
                    </li>
                    <li class="page-item"><a class="page-link" href="#">3</a></li>
                    <li class="page-item"><a class="page-link" href="#">Next</a></li>
                </ul>
            </nav>--%>
        </div>
    </div>

    <div class="mt-3 mb-3">
        <asp:Button Text="Agregar" ID="btnAgregar" CssClass="btn btn-success me-2" runat="server" OnClick="btnAgregar_Click" />
    </div>
</asp:Content>
