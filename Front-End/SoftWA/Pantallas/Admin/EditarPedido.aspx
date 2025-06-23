<%@ Page Title="Editar Pedido" Language="C#" MasterPageFile="~/Pantallas/MasterPages/SiteAdmin.master" AutoEventWireup="true" CodeBehind="EditarPedido.aspx.cs" Inherits="SoftCiapasaWA.Pantallas.Admin.EditarPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    Editar Pedido
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
            display: flex;
            justify-content: space-between;
        }

        .form-actions input {
            padding: 10px 20px;
            font-weight: bold;
            border-radius: 5px;
            border: none;
            cursor: pointer;
        }

        .message {
            margin-top: 15px;
            font-weight: bold;
        }
    </style>

    <div class="form-container">
        <h2>Editar Pedido</h2>

        <div class="form-group">
            <label for="ddlPersona">Cliente</label>
            <asp:DropDownList ID="ddlPersona" runat="server" />
        </div>

        <div class="form-group">
            <label for="ddlMetodoPago">Método de Pago</label>
            <asp:DropDownList ID="ddlMetodoPago" runat="server">
                <asp:ListItem Text="Seleccionar" Value="" />
                <asp:ListItem Text="Tarjeta de Crédito" Value="Tarjeta de Crédito" />
                <asp:ListItem Text="Tarjeta de Débito" Value="Tarjeta de Débito" />
                <asp:ListItem Text="Transferencia" Value="Transferencia" />
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="ddlEstadoPago">Estado de Pago</label>
            <asp:DropDownList ID="ddlEstadoPago" runat="server">
                <asp:ListItem Text="Seleccionar" Value="" />
                <asp:ListItem Text="Confirmado" Value="Confirmado" />
                <asp:ListItem Text="En progreso" Value="En progreso" />
                <asp:ListItem Text="Cancelado" Value="Cancelado" />
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="ddlEstadoEnvio">Estado de Envío</label>
            <asp:DropDownList ID="ddlEstadoEnvio" runat="server">
                <asp:ListItem Text="Seleccionar" Value="" />
                <asp:ListItem Text="Entregado" Value="Entregado" />
                <asp:ListItem Text="En camino" Value="En camino" />
                <asp:ListItem Text="Cancelado" Value="Cancelado" />
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="ddlEstadoPedido">Estado del Pedido</label>
            <asp:DropDownList ID="ddlEstadoPedido" runat="server">
                <asp:ListItem Text="Seleccionar" Value="" />
                <asp:ListItem Text="Pendiente" Value="Pendiente" />
                <asp:ListItem Text="Procesado" Value="Procesado" />
                <asp:ListItem Text="Cancelado" Value="Cancelado" />
            </asp:DropDownList>
        </div>

        <div class="form-actions">
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click"
                Style="background-color: #007BFF; color: white;" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"
                Style="background-color: #dc3545; color: white;" />
        </div>

        <div class="message">
            <asp:Label ID="lblMensaje" runat="server" />
        </div>
    </div>

</asp:Content>
