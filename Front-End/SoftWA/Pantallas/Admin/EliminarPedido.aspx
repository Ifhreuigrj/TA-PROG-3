<%@ Page Title="Eliminar Pedido" Language="C#" MasterPageFile="~/Pantallas/MasterPages/SiteAdmin.master" AutoEventWireup="true" CodeBehind="EliminarPedido.aspx.cs" Inherits="SoftCiapasaWA.Pantallas.Admin.EliminarPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    ConfimarEliminarPedido
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <style>
        .container {
            border: 1px solid #ccc;
            padding: 30px;
            border-radius: 10px;
            max-width: 400px;
            margin: auto;
            background-color: #f9f9f9;
            text-align: center;
            font-family: Arial, sans-serif;
        }
        .boton {
            margin: 10px;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
        .btn-aceptar {
            background-color: #d9534f;
            color: white;
        }
        .btn-cancelar {
            background-color: #5bc0de;
            color: white;
        }
        .mensaje {
            margin-bottom: 20px;
            font-size: 16px;
            color: red;
        }
    </style>

    <div class="container">
        <div>
            ¿Estás seguro de que deseas eliminar este pedido?
        </div>

        <asp:Button ID="btnEliminar" runat="server" Text="Sí, eliminar" CssClass="boton btn-aceptar" OnClick="btnEliminar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="boton btn-cancelar" OnClick="btnCancelar_Click" />

        <div class="mensaje">
            <asp:Label ID="lblMensaje" runat="server" />
        </div>
    </div>
</asp:Content>
