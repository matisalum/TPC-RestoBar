<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Categoria.aspx.cs" Inherits="TPCRestoBar.Categoria" %>
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
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                </columns>

            </asp:GridView>
        </div>
    </div>

</asp:Content>
