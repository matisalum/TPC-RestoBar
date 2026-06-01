<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPCRestoBar.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="text-center mb-5">

    <h1 class="display-4">
        Bienvenido a RestoBar3
    </h1>

    <p class="lead">
        Sistema de gestión de mesas, pedidos y personal.
    </p>

</div>

<div class="row">

    <div class="col-md-4 mb-3">
        <div class="card text-center shadow">
            <div class="card-body">
                <h3>🪑</h3>
                <h5>Mesas</h5>
                <p>Administración de mesas.</p>
            </div>
        </div>
    </div>

    <div class="col-md-4 mb-3">
        <div class="card text-center shadow">
            <div class="card-body">
                <h3>👨‍🍳</h3>
                <h5>Empleados</h5>
                <p>Gestión de meseros y gerentes.</p>
            </div>
        </div>
    </div>

    <div class="col-md-4 mb-3">
        <div class="card text-center shadow">
            <div class="card-body">
                <h3>🧾</h3>
                <h5>Pedidos</h5>
                <p>Administración de pedidos.</p>
            </div>
        </div>
    </div>

</div>

</asp:Content>
