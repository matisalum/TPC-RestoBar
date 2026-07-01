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

            <h2><asp:Label ID="lblMesas" runat="server" /></h2>

        </div>

    </div>

    <div class="col-md-3">

        <div class="dashboard-card productos">

            <i class="bi bi-box-seam"></i>

            <h5>Productos</h5>

            <h2><asp:Label ID="lblProductos" runat="server" /></h2>

        </div>

    </div>

    <div class="col-md-3">

        <div class="dashboard-card pedidos">

            <i class="bi bi-bag-fill"></i>

            <h5>Pedidos</h5>

            <h2><asp:Label ID="lblPedidos" runat="server" /></h2>

        </div>

    </div>

    <div class="col-md-3">

        <div class="dashboard-card empleados">

            <i class="bi bi-people-fill"></i>

            <h5>Empleados</h5>

            <h2><asp:Label ID="lblEmpleados" runat="server" /></h2>

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


    <div class="col-md-4 mb-4" id="divCardReportes" runat="server">
    <div class="card h-100 shadow-sm border-danger">
        <div class="card-body text-center">
            <h5 class="card-title text-danger">
                <i class="fas fa-chart-line fa-2x mb-2"></i><br />
                Panel de Reportes
            </h5>
            <p class="card-text text-muted">Estadísticas de facturación, mozos y platos más vendidos del negocio.</p>
            <a href="Reportes.aspx" class="btn btn-outline-danger w-100">Ver Estadísticas</a>
        </div>
    </div>
</div>

</asp:Content>
