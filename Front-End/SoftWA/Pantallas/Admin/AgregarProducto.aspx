<%@ Page Title="Agregar Producto" Language="C#" MMasterPageFile="~/Pantallas/MasterPages/SiteAdmin.master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="SoftCiapasaWA.Pantallas.Admin.AgregarProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    Agregar Producto
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

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
        <h2>Agregar Producto</h2>

        

        <div class="form-group">
            <label for="txtNombre">Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" />
        </div>

        <div class="form-group">
            <label for="ddlCategoria">Categoría</label>
            <asp:DropDownList ID="ddlCategoria" runat="server">
                <asp:ListItem Text="Seleccionar" Value="" />
                <asp:ListItem Text="OLLA" Value="OLLA" />
                <asp:ListItem Text="Ropa" Value="Ropa" />
                <asp:ListItem Text="Hogar" Value="Hogar" />
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="txtPrecio">Precio</label>
            <asp:TextBox ID="txtPrecio" runat="server" />
        </div>

        <div class="form-group">
            <label for="txtStock">Stock</label>
            <asp:TextBox ID="txtStock" runat="server" />
        </div>

        <div class="form-group">
            <label for="txtDescripcion">Descripción</label>
            <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="4" />
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
