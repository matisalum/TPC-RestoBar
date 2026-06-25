<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="TPCRestoBar.Pedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>MENU PEDIDOS</h1>

    <div class="card shadow">
        <div class="card-header bg-dark text-white">
            <h3 class="mb-0">🍽️ Gestión de Pedidos</h3>
        </div>

        <div class="card-body">

            <asp:GridView
                ID="dgvPedidos"
                runat="server"
                CssClass="table table-hover table-striped"
                AutoGenerateColumns="false"
                OnRowDataBound="dgvPedidos_RowDataBound">



                <Columns>

                    <asp:BoundField HeaderText="Pedido" DataField="idPedido" />
                    <asp:BoundField HeaderText="Fecha" DataField="fechaPedido" />

                    <asp:TemplateField HeaderText="Mesa">
                        <ItemTemplate>
                            <%# Eval("mesa.numero") %>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mesero">
                        <ItemTemplate>
                            <%# Eval("Empleado.nombre") %>
                            <%# Eval("Empleado.apellido") %>
                        </ItemTemplate>

                    </asp:TemplateField>
              
                      <asp:TemplateField HeaderText="Estado">
                          <ItemTemplate>
                              <asp:Label 
                                
                                  ID="lblEstado"
                                  runat="server"
                                  Text='<%# Eval("estadoPedido") %>'
                                  CssClass="badge bg-primary"
                                  >
                              </asp:Label>

                          </ItemTemplate>

                           </asp:TemplateField>

                </Columns>

            </asp:GridView>

        </div>
    </div>
</asp:Content>
