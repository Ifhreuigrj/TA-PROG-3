<%@ Page Title="Lista de Pedidos" Language="C#" MasterPageFile="~/Pantallas/MasterPages/SiteAdmin.master" AutoEventWireup="true" CodeBehind="ListaPedidos.aspx.cs" Inherits="SoftCiapasaWA.Pantallas.Admin.ListaPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    Lista de Pedidos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="margin-bottom: 20px;">Lista de Pedidos</h2>

<!-- Filtros -->
<asp:Panel ID="pnlFiltros" runat="server" style="margin-bottom: 20px; border: 1px solid #ccc; padding: 15px; border-radius: 8px;">
    <fieldset>
        <legend style="font-weight: bold; padding: 0 10px;">Filtros</legend>

        <div style="display: flex; flex-wrap: wrap; gap: 20px; align-items: end;">

            <div style="display: flex; flex-direction: column;">
                <label for="txtPedidoId">Pedido ID</label>
                <asp:TextBox ID="txtPedidoId" runat="server" CssClass="filtro" Width="100px" />
            </div>

            <div style="display: flex; flex-direction: column;">
                <label for="txtPersonaId">Persona ID</label>
                <asp:TextBox ID="txtPersonaId" runat="server" CssClass="filtro" Width="150px" />
            </div>
            <div style="display: flex; flex-direction: column;">
            <label for="txtNombreCliente">Nombre del Cliente</label>
            <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="filtro" Width="200px" />
            </div>

            <div style="display: flex; flex-direction: column;">
                <label for="txtTotal">Total</label>
                <asp:TextBox ID="txtTotal" runat="server" Width="100px" />
            </div>
            <div style="display: flex; flex-direction: column;">
            <label for="ddlMetodoPago">Metodo de Pago</label>
            <asp:DropDownList ID="ddlMetodoPago" runat="server" Width="160px">
            <asp:ListItem Text="Todas" Value="" />
            <asp:ListItem Text="Tarjeta de Crédito" Value="Tarjeta de Crédito" />
            <asp:ListItem Text="Tarjeta de Débito" Value="Tarjeta de Débito" />
            </asp:DropDownList>
            </div>
            <div style="display: flex; flex-direction: column;">
                <label for="ddlEstadoPago">Estado de Pago</label>
                <asp:DropDownList ID="ddlEstadoPago" runat="server" Width="160px">
                    <asp:ListItem Text="Todas" Value="" />
                    <asp:ListItem Text="Confirmado" Value="Confirmado" />
                    <asp:ListItem Text="En progreso" Value="En progreso" />
                    <asp:ListItem Text="Cancelado" Value="Cancelado" />
                </asp:DropDownList>
            </div>
            
            <div style="display: flex; flex-direction: column;">
            <label for="ddlEstadoEnvio">Estado de Envio</label>
            <asp:DropDownList ID="ddlEstadoEnvio" runat="server" Width="160px">
                <asp:ListItem Text="Todas" Value="" />
                <asp:ListItem Text="Entregado" Value="Entregado" />
                <asp:ListItem Text="En camino" Value="En camino" />
                <asp:ListItem Text="Cancelado" Value="Cancelado" />
            </asp:DropDownList>
            </div>
            <div style="display: flex; flex-direction: column;">
    <label for="ddlEstadoPedido">Estado Pedido</label>
    <asp:DropDownList ID="ddlEstadoPedido" runat="server" Width="160px">
        <asp:ListItem Text="Todos" Value="" />
        <asp:ListItem Text="Pendiente" Value="Pendiente" />
        <asp:ListItem Text="Procesado" Value="Procesado" />
        <asp:ListItem Text="Cancelado" Value="Cancelado" />
    </asp:DropDownList>
</div>

            <div style="display: flex; flex-direction: column;">
            <label for="txtFechaInicio">Desde</label>
        <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date" Width="130px" />
        </div>
        <div style="display: flex; flex-direction: column;">
            <label for="txtFechaFin">Hasta</label>
            <asp:TextBox ID="txtFechaFin" runat="server" TextMode="Date" Width="130px" />
        </div>


            <div style="align-self: end;">
                <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click"
                    Style="background-color: #4CAF50; color: white; padding: 8px 18px; border: none; border-radius: 5px; cursor: pointer; font-weight: bold;" />
                <asp:Button ID="btnBorrarFiltros" runat="server" Text="Borrar Filtros" OnClick="btnBorrarFiltros_Click"
                    Style="background-color: #dc3545; color: white; padding: 8px 18px; border: none; border-radius: 5px; cursor: pointer; font-weight: bold; margin-left: 10px;" />
            </div>
        </div>
    </fieldset>
</asp:Panel>
    <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="False" OnRowCommand="gvPedidos_RowCommand" CssClass="tabla-gridview"
        Width="100%" GridLines="None" HeaderStyle-BackColor="#007BFF" HeaderStyle-ForeColor="White" RowStyle-BackColor="#f9f9f9"
        AlternatingRowStyle-BackColor="#eef2f7" BorderStyle="None" CellPadding="10">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="Codigo de Pedido" />
        <asp:BoundField DataField="PersonaId" HeaderText="Codigo de Persona" />
        <asp:BoundField DataField="NombreCliente" HeaderText="Nombre del Cliente" />
        <asp:BoundField DataField="FechaPedido" HeaderText="Fecha de Pedido" DataFormatString="{0:yyyy-MM-dd}" />
        <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:C}" />
        <asp:BoundField DataField="Estado" HeaderText="Estado del Pedido" />
        <asp:BoundField DataField="EstadoPago" HeaderText="Estado de Pago" />
        <asp:BoundField DataField="MetodoPago" HeaderText="Método de Pago" />
        <asp:BoundField DataField="EstadoEnvio" HeaderText="Estado de Envío" />

        
        <asp:TemplateField HeaderText="Detalle">
            <ItemTemplate>
                <asp:LinkButton ID="btnVerDetalle" runat="server" CommandArgument='<%# Eval("Id") %>'
                    OnClick="btnVerDetalle_Click" CssClass="btn btn-sm btn-info" ToolTip="Ver detalle">
                    <i class="fas fa-search"></i>
                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>

       
        <asp:TemplateField HeaderText="Comprobante">
            <ItemTemplate>
                <asp:LinkButton ID="btnVerComprobante" runat="server" CommandArgument='<%# Eval("Id") %>'
                    OnClick="btnVerComprobante_Click" CssClass="btn btn-sm btn-secondary" ToolTip="Ver comprobante">
                    <i class="fas fa-file-invoice"></i>
                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Opciones">
        <ItemTemplate>
        <asp:LinkButton runat="server" CommandName="Editar" CommandArgument='<%# Eval("Id") %>' CssClass="icon-btn" ToolTip="Editar">
    <i class="fas fa-search"></i>
</asp:LinkButton>
<asp:LinkButton runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' CssClass="icon-btn icon-delete" ToolTip="Eliminar">
 <i class="fas fa-trash-alt"></i>
</asp:LinkButton>

    </ItemTemplate>
</asp:TemplateField>
    </Columns>
</asp:GridView>

        
<div style="margin-top: 20px; text-align: left;">
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Pedido" OnClick="btnAgregar_Click"
        Style="background-color: #007BFF; color: white; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer; font-weight: bold;" />
</div>
      
  <div style="display: flex; justify-content: space-between; align-items: center; margin-top: 20px;">
     

      <div style="display: flex; gap: 6px;">
          <button style="padding: 6px 10px; border: 1px solid #ccc; background-color: #f9f9f9;">1</button>
          <button style="padding: 6px 10px; border: 1px solid #ccc; background-color: #f9f9f9;">2</button>
          <button style="padding: 6px 10px; border: 1px solid #ccc; background-color: #f9f9f9;">3</button>
          <button style="padding: 6px 10px; border: 1px solid #ccc; background-color: #f9f9f9;">...</button>
      </div>
  </div>

</asp:Content>
