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
        <%--<%
            foreach (dominio.Mesa item in listaMesas)
            {  %>
        <div class="col"> 

                <div class="card text-bg-secondary mb-3" style="width: 18rem;">
                    <div class="card-header">Nro:  <%: item.numero %> </div>
                    <div class="card-body">
                        <p class="card-text">Capacidad: <%: item.capacidad %></p>
                        <a href="#" class="btn btn-warning">Liberar</a>
                    </div>
                </div>
        </div>
        <%  } %>--%>
        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card text-bg-secondary mb-3" style="width: 18rem;">
                        <div class="card-header">Nro:  <%#Eval("numero") %> </div>
                        <div class="card-body">
                            <p class="card-text">Capacidad: <%#Eval("capacidad") %></p>
                            <asp:Button ID="btnLiberar"
                                Text="Liberar"
                                CssClass="btn btn-warning"
                                runat="server"
                                CommandArgument='<%#Eval("idMesa")%>'
                                CommandName="IDMesa"
                                OnClick="btnLiberar_Click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>


</asp:Content>
