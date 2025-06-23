<%@ Page Title="Agregar Cliente" Language="C#" MasterPageFile="~/Pantallas/MasterPages/SiteAdmin.master" AutoEventWireup="true" CodeBehind="AgregarCliente.aspx.cs" Inherits="SoftCiapasaWA.Pantallas.Admin.AgregarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    Agregar Cliente
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <style>
        .form-container {
            max-width: 600px;
            margin: auto;
            padding: 20px;
            border-radius: 10px;
            background-color: #f9f9f9;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }

        .form-group {
            margin-bottom: 15px;
        }

        .form-group label {
            font-weight: bold;
        }

        .form-group input,
        .form-group select {
            width: 100%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .form-actions {
            margin-top: 20px;
            text-align: right;
        }

        .form-actions input {
            margin-left: 10px;
        }

        .message {
            margin-top: 15px;
            font-weight: bold;
        }
    </style>

    <div class="form-container">
        <h2>Agregar Cliente</h2>

        <div class="form-group">
            <label for="txtNombre">Nombres</label>
            <asp:TextBox ID="txtNombre" runat="server" />
        </div>

        <div class="form-group">
            <label for="txtApellidos">Apellidos</label>
            <asp:TextBox ID="txtApellidos" runat="server" />
        </div>

        <div class="form-group">
            <label for="txtTelefono">Teléfono</label>
            <asp:TextBox ID="txtTelefono" runat="server" />
        </div>

        <div class="form-group">
            <label for="txtEmail">Correo Electrónico</label>
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" />
        </div>

        <div class="form-group">
            <label for="ddlTipoCliente">Tipo de Cliente</label>
            <asp:DropDownList ID="ddlTipoCliente" runat="server">
                <asp:ListItem Text="Seleccionar" Value="" />
                <asp:ListItem Text="Jurídico" Value="1" />
                <asp:ListItem Text="Natural" Value="2" />
            </asp:DropDownList>
        </div>

        <div class="form-actions">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        </div>

        <div class="message">
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />
        </div>
    </div>
</asp:Content>
