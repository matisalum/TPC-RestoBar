<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="TPCRestoBar.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mb-4">
        <h1> Categorias</h1>
    </div>
    <div class="card">
        <div class="card-body">
            <asp:GridView 
                ID="dvgCategoria"
                CssClass="table table-striped table-hover"
                AutoGenerateColumns="false"
                runat="server">
                <columns>
                    <asp:BoundField HeaderText="ID" DataField="Id" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Estado" DataField="Estado" />
                    <%--<asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />--%>
                </columns>

            </asp:GridView>
        </div>
    </div>
     <div class="mt-3 mb-3">
     <asp:Button Text="Agregar" ID="btnAgregar" CssClass="btn btn-success me-2" runat="server" OnClick="btnAgregar_Click" />
    </div>

</asp:Content>
