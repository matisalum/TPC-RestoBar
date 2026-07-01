<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VerPedido.aspx.cs" Inherits="TPCRestoBar.VerPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="d-flex justify-content-between align-content-center mb-4">
            <h2>📋 Pedido Actual - <asp:Label ID="lblNroMesa" runat="server" Text="" CssClass="text-danger" /></h2>
            <asp:Button ID="btnVolver" runat="server" Text="Volver a Mis Mesas" CssClass="btn btn-secondary" OnClick="btnVolver_Click" />
            <asp:Button ID="btnModificar" runat="server" Text="➕Agregar/Modificar Productos" CssClass="btn btn-secondary" OnClick="btnModificar_Click" />

             </div>

        <div class="card shadow-sm mb-4">
            <div class="card-body">
                <h5>Información del Pedido</h5>
                <p><strong>Fecha/Hora de Apertura:</strong> <asp:Label ID="lblFecha" runat="server" /></p>
                <p><strong>Estado:</strong> <span class="badge bg-warning text-dark">Abierto / En Proceso</span></p>
            </div>
        </div>

        <div class="card shadow-sm">
            <div class="card-body">
                <asp:GridView
                    ID="dgvDetallePedido"
                    AutoGenerateColumns="False"
                    runat="server"
                    CssClass="table table-striped">

                    <Columns>

                        <asp:TemplateField HeaderText="Producto">
                            <ItemTemplate>
                                <%# Eval("Producto.nombre") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField
                            DataField="Cantidad"
                            HeaderText="Cantidad" />

                        <asp:TemplateField HeaderText="Precio Unitario">
                            <ItemTemplate>
                                $ <%# Eval("PrecioUnitario") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Subtotal">
                            <ItemTemplate>
                                $ <%# Eval("Subtotal") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>

                <div class="text-end mt-3 me-3">
                    <h3>Total: <asp:Label ID="lblTotal" runat="server" Text="$ 0.00" CssClass="fw-bold text-success" /></h3>
                </div>
            </div>
        </div>
        
        <div class="text-end mt-4">
            <asp:Button ID="btnCerrarMesa" runat="server" Text="Finalizar y Cobrar Cuenta" CssClass="btn btn-success btn-lg" />
        </div>
    </div>
</asp:Content>
