<%@ Page Title="Agregar Pedido" Language="C#" MasterPageFile="~/Pantallas/MasterPages/SiteAdmin.master" AutoEventWireup="true" CodeBehind="AgregarPedido.aspx.cs" Inherits="SoftWA.Pantallas.Admin.AgregarPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    Agregar Pedido
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<style>
        .form-container {
            max-width: 700px;
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
        .form-group select,
        .form-group textarea {
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
        <h2>Agregar Pedido</h2>
        <div class="form-group">
         <label for="ddlPersona">Cliente</label>
            <asp:DropDownList ID="ddlPersona" runat="server" CssClass="form-control" />
        </div>


        <div class="form-group">
            <label for="txtFechaPedido">Fecha del Pedido</label>
            <asp:TextBox ID="txtFechaPedido" runat="server" TextMode="Date" />
        </div>

        <div class="form-group">
            <label for="ddlMetodoPago">Método de Pago</label>
            <asp:DropDownList ID="ddlMetodoPago" runat="server">
                <asp:ListItem Text="Seleccionar" Value="" />
                <asp:ListItem Text="Tarjeta de Crédito" Value="Tarjeta de Crédito" />
                <asp:ListItem Text="Tarjeta de Débito" Value="Tarjeta de Débito" />
                <asp:ListItem Text="Efectivo" Value="Efectivo" />
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="ddlEstadoPago">Estado de Pago</label>
            <asp:DropDownList ID="ddlEstadoPago" runat="server">
                <asp:ListItem Text="Seleccionar" Value="" />
                <asp:ListItem Text="Confirmado" Value="Confirmado" />
                <asp:ListItem Text="En Proceso" Value="En Proceso" />
                <asp:ListItem Text="Cancelado" Value="Cancelado" />
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="ddlEstadoEnvio">Estado de Envio</label>
            <asp:DropDownList ID="ddlEstadoEnvio" runat="server">
                <asp:ListItem Text="Seleccionar" Value="" />
                <asp:ListItem Text="En camino" Value="En camino" />
                <asp:ListItem Text="Entregado" Value="Entregado" />
                <asp:ListItem Text="Cancelado" Value="Cancelado" />
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="txtTotal">Total</label>
            <asp:TextBox ID="txtTotal" runat="server" TextMode="Number" />
        </div>

        <div style="text-align: left; margin-bottom: 20px;">
    <asp:Button ID="btnAgregarDetalle" runat="server" Text="Agregar Detalle"
        PostBackUrl="AgregarDetallePedido.aspx"
        Style="background-color: #ffc107; color: black; padding: 10px 20px; border: none; border-radius: 5px; font-weight: bold;" />
</div>


        <div class="form-actions">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            

            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        </div>

        <div class="message">
            <asp:Label ID="lblMensaje" runat="server" />
        </div>
    </div>
</asp:Content>
