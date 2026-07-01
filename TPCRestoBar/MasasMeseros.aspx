<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MasasMeseros.aspx.cs" Inherits="TPCRestoBar.MasasMeseros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="mb-4">
            <h2 class="mb-4 text-right">Mis Mesas</h2>
        </div>
    </div>
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class='<%# (bool)Eval("estado") ? "card mesa-card shadow-sm border-danger" : "card mesa-card shadow-sm border-success" %>'>

                        <div class="card-header">
                            🍽 Mesa <%# Eval("numero") %>
                        </div>

                        <div class="card-body">
                            <h6>Capacidad: <%# Eval("capacidad") %></h6>

                            <span class='<%# (bool)Eval("estado") ? "badge bg-danger" : "badge bg-success" %>'>
                                <%# (bool)Eval("estado") ? "Ocupada" : "Libre" %>
                            </span>

                            <br />
                            <br />

                            <asp:Button
                                ID="btnNPedido"
                                runat="server"
                                Text='<%# (bool)Eval("estado") ? "Ver Pedido Abierto" : "Abrir Mesa" %>'
                                CssClass='<%# (bool)Eval("estado") ? "btn btn-info" : "btn btn-warning" %>'
                                CommandArgument='<%# Eval("idMesa") %>'
                                OnClick="btnNPedido_Click" />

                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
