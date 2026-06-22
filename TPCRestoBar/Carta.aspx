<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Carta.aspx.cs" Inherits="TPCRestoBar.Carta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container ">
        <h1>Cartilla </h1>
        <div class="row">
            <div class="col-2"></div>
            <div class="col">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
                <asp:TextBox ID="txbBuscar" runat="server"></asp:TextBox>
            </div>
            <div class="col">
                <asp:DropDownList ID="ddlFiltro" runat="server"></asp:DropDownList>
            </div>
            
        </div>
        <div class="row">
            <div class="col">
                <div class="card shadow-sm mb-5">
                    <div class="row">
                        <div class="col-3"></div>
                        <div class="col">
                            <asp:Image ID="imgPlato"
                                CssClass="img-fluid rounded-start"
                                runat="server"
                                ImageUrl="https://i.pinimg.com/736x/1c/ab/6a/1cab6a3074c2a0aa99c848c24823f8a0.jpg"
                                alt="Plato del dia..." />
                        </div>
                        <div class="col">
                            <div class="card-body">
                                <h3>Plato del Día</h3>
                                <p>Descripción del plato destacado.</p>
                                <asp:Button ID="btnOrdenar" CssClass="btn btn-danger me-2" runat="server" Text="Ordenar" />
                            </div>
                        </div>
                        <div class="col-3"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <h2 class="mb-4 text-center">🍽️ Nuestra Carta</h2>

    <div class="row">
       
        <asp:Repeater ID="repProductos" runat="server">
    <ItemTemplate>
        <div class="col-md-4 mb-4">
            <div class="card h-100 shadow-sm">

                <img src='<%# string.IsNullOrEmpty(Eval("imagen.Url")?.ToString())
                            ? "https://static.vecteezy.com/system/resources/previews/022/059/000/non_2x/no-image-available-icon-vector.jpg"
                            : Eval("imagen.Url") %>'
                     class="card-img-top"
                     alt="Imagen del producto"
                     style="height:250px; object-fit:cover;" />

                <div class="card-body">
                    <h5 class="card-title"><%# Eval("nombre") %></h5>
                    <p class="card-text">
                        <strong>$ <%# Eval("precio") %></strong>
                    </p>
                </div>

            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>

    </div>

</asp:Content>
