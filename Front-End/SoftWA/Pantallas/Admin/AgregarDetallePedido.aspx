<%@ Page Title="Agregar Detalle del Pedido" Language="C#" MasterPageFile="~/Pantallas/MasterPages/SiteAdmin.master" AutoEventWireup="true" CodeBehind="AgregarDetallePedido.aspx.cs" Inherits="SoftCiapasaWA.Pantallas.Admin.AgregarDetallePedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    Agregar Detalle del Pedido
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .form-container {
            max-width: 500px;
            margin: auto;
            padding: 25px;
            border: 1px solid #ccc;
            border-radius: 10px;
            background-color: #fff;
            box-shadow: 0 0 15px rgba(0,0,0,0.1);
        }

        .form-container h2 {
            text-align: center;
            margin-bottom: 25px;
            color: #333;
        }

        .form-group {
            margin-bottom: 18px;
        }

        .form-group label {
            font-weight: bold;
            display: block;
            margin-bottom: 5px;
        }

        .form-group input,
        .form-group select {
            width: 100%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .form-actions {
            display: flex;
            justify-content: space-between;
            margin-top: 30px;
        }

        .form-actions input {
            padding: 10px 20px;
            font-weight: bold;
            border-radius: 5px;
            border: none;
            cursor: pointer;
        }

        .btn-guardar {
            background-color: #28a745;
            color: white;
        }

        .btn-volver {
            background-color: #6c757d;
            color: white;
        }

        .mensaje {
            margin-top: 15px;
            text-align: center;
            color: red;
        }
    </style>

    <div class="form-container">
        <h2>Agregar Detalle del Pedido</h2>

        <div class="form-group">
            <label>Producto</label>
            <asp:DropDownList ID="ddlProducto" runat="server" />
        </div>

        <div class="form-group">
            <label>Cantidad</label>
            <asp:TextBox ID="txtCantidad" runat="server" />
        </div>

        <div class="form-group">
            <label>Precio Unitario</label>
            <asp:TextBox ID="txtPrecio" runat="server" />
        </div>

        <div class="form-actions">
            <asp:Button ID="btnCancelar" runat="server" Text="Volver" CssClass="btn-volver" OnClick="btnCancelar_Click" />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Detalle" CssClass="btn-guardar" OnClick="btnGuardar_Click" />
        </div>

        <div class="mensaje">
            <asp:Label ID="lblMensaje" runat="server" />
        </div>
    </div>
</asp:Content>
