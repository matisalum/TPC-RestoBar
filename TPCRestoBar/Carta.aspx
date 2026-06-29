<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Carta.aspx.cs" Inherits="TPCRestoBar.Carta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container ">
        <h1>Cartilla </h1>
        <div class="row">
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
        <div class="text-center mb-5">

            <h1 class="titulo-carta">🍽 Nuestra Carta

            </h1>

            <p class="subtitulo-carta">
                Descubrí nuestros platos destacados

            </p>

        </div>


        <div class="row mb-4">

            <div class="col-md-6 mx-auto">

                <asp:TextBox
                    ID="txtBuscar"
                    runat="server"
                    CssClass="form-control form-control-lg"
                    placeholder="🔎 Buscar producto..."
                    AutoPostBack="true"
                    OnTextChanged="txtBuscar_TextChanged" />

            </div>

        </div>
        <div class="row mb-4">

            <div class="col-md-4 mx-auto">

                <asp:DropDownList
                    ID="ddlCategoria"
                    runat="server"
                    CssClass="form-select"
                    AutoPostBack="true"
                    OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged">
                </asp:DropDownList>

            </div>

        </div>
        <div class="row">

    <asp:Repeater ID="repProductos" runat="server">

        <ItemTemplate>

            <div class="col-lg-4 col-md-6 mb-4">

                <div class="card carta-card h-100">

                    <img src='<%# string.IsNullOrEmpty(Eval("imagen.Url")?.ToString())
                        ? "https://static.vecteezy.com/system/resources/previews/022/059/000/non_2x/no-image-available-icon-vector.jpg"
                        : Eval("imagen.Url") %>'

                        class="card-img-top"
                        alt="Producto" />

                    <div class="card-body d-flex flex-column">

                        <h5 class="fw-bold">
                            <%# Eval("nombre") %>
                        </h5>

                        <p class="categoria">
                            <%# Eval("categoria.Nombre") %>
                        </p>

                        <h4 class="precio">
                            $ <%# Eval("precio") %>
                        </h4>

                       

                    </div>

                </div>

            </div>

        </ItemTemplate>

    </asp:Repeater>

</div>

</asp:Content>
