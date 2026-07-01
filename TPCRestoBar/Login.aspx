<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPCRestoBar.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--login--%>
    <div class="row">   
        <div class="col-2"></div>
        <div class="col">
            <div class="mb-3">
                <label for="lblUsuario" class="form-label">Usuario</label>
                <asp:TextBox runat="server" cssclass="form-control" id="txtUsuario"/>  
              </div>
              <div class="mb-3">
                <label for="txtContrasenia" class="form-label">Contraseña</label>
                <asp:TextBox runat="server" cssclass="form-control" type="password" id="txtContrasenia"/>    
              </div>
              
              <asp:Button ID="btnIngresar" class="btn btn-primary" runat="server" Text="Ingresar" OnClick="btnIngresar_Click"/>
              <%--<asp:Button ID="btnRegistrarse" class="btn btn-primary" runat="server" Text="Registrarse" />--%>
        </div>
        <div class="col-2"></div>
    </div>


</asp:Content>
