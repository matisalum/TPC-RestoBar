<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="TPCRestoBar.Categorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mb-4">
        <h1>Categorias</h1>
    </div>
    <div class="mb-4">
        <label>Filtrar x Nombre</label>
        <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control w-25" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged"/>
    </div>
    <div class="card">
        <div class="card-body">
            <asp:GridView
                ID="dvgCategoria"
                CssClass="table table-striped table-hover"
                DataKeyNames="Id"
                OnSelectedIndexChanged="dvgCategoria_SelectedIndexChanged"
                AutoGenerateColumns="false"
                AllowPaging="true"
                PageSize="10"
                OnPageIndexChanging="dvgCategoria_PageIndexChanging"
                runat="server">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="Id" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />

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

                    <%--<asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />--%>
                </Columns>

            </asp:GridView>
        </div>
    </div>
    <div class="mt-3 mb-3">
        <asp:Button Text="Agregar" ID="btnAgregar" CssClass="btn btn-success me-2" runat="server" OnClick="btnAgregar_Click" />
    </div>

</asp:Content>
