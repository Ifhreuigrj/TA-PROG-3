<%@ Page Title="Detalle del Pedido" Language="C#" MasterPageFile="~/Pantallas/MasterPages/SiteAdmin.master" AutoEventWireup="true" CodeBehind="DetallePedido.aspx.cs" Inherits="SoftWA.Pantallas.Admin.DetallePedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    Detalle del Pedido
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h3 class="mb-4">Detalle del Pedido</h3>
        <asp:GridView ID="gvDetalle" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="IdProducto" HeaderText="ID Producto" />
                <asp:BoundField DataField="NombreProducto" HeaderText="Nombre del Producto" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
        <h5 class="text-end mt-3">Total: <asp:Label ID="lblTotal" runat="server" CssClass="fw-bold" /></h5>
    </div>
    <div class="mt-4 text-end">
    <asp:Button ID="btnVolver" runat="server" Text="← Volver" CssClass="btn btn-secondary"
        OnClick="btnVolver_Click" />
</div>
</asp:Content>
