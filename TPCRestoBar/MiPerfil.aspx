<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TPCRestoBar.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="mb-4">👤 Mi Perfil</h2>
  
    <div class="row">

        <div class="col-md-4 text-center">

            <asp:Image
                ID="imgPerfil"
                runat="server"
                Width="220"
                Height="220"
                CssClass="img-thumbnail rounded-circle mb-3" />

            <asp:TextBox ID="txtImagen" OnTextChanged="txtImagen_TextChanged" CssClass="form-control" placeholder="Ej: https: // IMAGEN .jpg" runat="server"></asp:TextBox>
        </div>

        <div class="col-md-8">

            <div class="card mb-3">

                <div class="card-header">
                    Cuenta
                </div>

                <div class="card-body">

                    <div class="mb-3">
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                        <asp:TextBox ID="txtUsuario" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <asp:Label ID="lblContrasena" runat="server" Text="Contraseña"></asp:Label>
                        <asp:TextBox ID="txtContrasena" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                </div>

            </div>

            <div class="card mb-3">

                <div class="card-header">
                    Datos personales
                </div>

                <div class="card-body">

                    <div class="mb-3">
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>
                        <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                </div>

            </div>

            <div class="card mb-3">
                <div class="card-header">
                    Cargo
                </div>

                <div class="card-body">
                    <asp:TextBox
                        ID="txtCargo"
                        CssClass="form-control"
                        Enabled="false"
                        runat="server" />
                </div>
            </div>

            <div class="text-end">
                <asp:Button
                    ID="btnGuardar"
                    runat="server"
                    CssClass="btn btn-success"
                    Text="Guardar cambios"/>
            </div>
        </div>

    </div>
</asp:Content>
