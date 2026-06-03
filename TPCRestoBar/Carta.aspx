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
            <div class="col">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" />
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
        <div class="row">
            <div class="col-2"></div>
            <div class="col">
                <asp:GridView ID="dvgCartilla" CssClass="table" runat="server"></asp:GridView>
            </div>
            <div class="col-2"></div>
        </div>
    </div>
</asp:Content>
