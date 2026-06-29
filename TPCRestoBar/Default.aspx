<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPCRestoBar.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="text-center mb-5">

    <h1 class="display-4">
        Bienvenido a RestoBar3
    </h1>

    <p class="text-muted">
        Panel principal de administración del Restobar.
    </p>

</div>

<div class="row g-4">

    <div class="col-md-3">

        <div class="dashboard-card mesas">

            <i class="bi bi-grid-3x3-gap-fill"></i>

            <h5>Mesas</h5>

            <h2>12</h2>

        </div>

    </div>

    <div class="col-md-3">

        <div class="dashboard-card productos">

            <i class="bi bi-box-seam"></i>

            <h5>Productos</h5>

            <h2>48</h2>

        </div>

    </div>

    <div class="col-md-3">

        <div class="dashboard-card pedidos">

            <i class="bi bi-bag-fill"></i>

            <h5>Pedidos</h5>

            <h2>5</h2>

        </div>

    </div>

    <div class="col-md-3">

        <div class="dashboard-card empleados">

            <i class="bi bi-people-fill"></i>

            <h5>Empleados</h5>

            <h2>8</h2>

        </div>

    </div>

</div>

<hr class="my-5"/>

<h4 class="mb-4">

    Accesos rápidos

</h4>

<div class="row g-3">

    <div class="col-md-3">

        <a href="FormularioProducto.aspx" class="btn btn-warning w-100 p-3">

            <i class="bi bi-plus-circle"></i>

            Nuevo Producto

        </a>

    </div>

    <div class="col-md-3">

        <a href="Carta.aspx" class="btn btn-danger w-100 p-3">

            <i class="bi bi-journal-richtext"></i>

            Ver Carta

        </a>

    </div>

    <div class="col-md-3">

        <a href="Mesas.aspx" class="btn btn-primary w-100 p-3">

            <i class="bi bi-grid-3x3-gap-fill"></i>

            Gestionar Mesas

        </a>

    </div>

    <div class="col-md-3">

        <a href="Pedidos.aspx" class="btn btn-success w-100 p-3">

            <i class="bi bi-bag-fill"></i>

            Pedidos

        </a>

    </div>

</div>

</asp:Content>
