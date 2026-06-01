<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="TPCRestoBar.Empleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>MENU EMPLEADOS</h1>


    <h2>Listado de Empleados</h2>

<asp:GridView
    ID="dgvEmpleados"
    runat="server"
    CssClass="table table-striped">
</asp:GridView>

</asp:Content>
