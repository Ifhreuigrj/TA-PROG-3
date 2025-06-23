<%@ Page Title="Lista de Clientes" Language="C#" MasterPageFile="~/Pantallas/MasterPages/SiteAdmin.master" AutoEventWireup="true" CodeBehind="ListaClientes.aspx.cs" Inherits="SoftCiapasaWA.Pantallas.Admin.ListaClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    Lista Clientes
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <h2 style="margin-bottom: 20px;">Lista de Clientes</h2>
    <!-- Filtros -->
    <asp:Panel ID="pnlFiltros" runat="server" style="margin-bottom: 20px; border: 1px solid #ccc; padding: 15px; border-radius: 8px;">
    <fieldset>
        <legend style="font-weight: bold; padding: 0 10px;">Filtros</legend>
        <div style="display: flex; flex-wrap: wrap; gap: 20px; align-items: end;">
            <div style="display: flex; flex-direction: column;">
                <label for="txtId">ID</label>
                <asp:TextBox ID="txtId" runat="server" CssClass="filtro" Width="100px" />
            </div>
            <div style="display: flex; flex-direction: column;">
                <label for="txtUsuarioId">Usuario ID</label>
                <asp:TextBox ID="txtUsuarioId" runat="server" CssClass="filtro" Width="100px" />
            </div>
            <div style="display: flex; flex-direction: column;">
                <label for="txtNombre">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="filtro" Width="150px" />
            </div>
            <div style="display: flex; flex-direction: column;">
                <label for="ddlTipoCliente">Tipo Cliente</label>
                <asp:DropDownList ID="ddlTipoCliente" runat="server" Width="160px">
                    <asp:ListItem Text="Todos" Value="" />
                    <asp:ListItem Text="Juridico" Value="Juridico" />
                    <asp:ListItem Text="Natural" Value="Natural" />
                    
                </asp:DropDownList>
            </div>
            <div style="display: flex; flex-direction: column;">
                <label for="txtEmail">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="filtro" Width="180px" />
            </div>
            <div style="display: flex; flex-direction: column;">
                <label for="txtTelefono">Teléfono</label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="filtro" Width="130px" />
            </div>
            <div style="display: flex; flex-direction: column;">
                <label>Fecha Registro</label>
                <div style="display: flex; gap: 5px;">
                    <asp:TextBox ID="txtFechaRegistroDesde" runat="server" Placeholder="Desde (dd/mm/aaaa)" Width="110px" />
                    <asp:TextBox ID="txtFechaRegistroHasta" runat="server" Placeholder="Hasta (dd/mm/aaaa)" Width="110px" />
                </div>
            </div>
            
            <div style="align-self: end;">
                <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click"
                    Style="background-color: #4CAF50; color: white; padding: 8px 18px; border: none; border-radius: 5px; cursor: pointer; font-weight: bold;" />
                <asp:Button ID="btnBorrarFiltros" runat="server" Text="Borrar Filtros" OnClick="btnBorrarFiltros_Click"
                    Style="background-color: #dc3545; color: white; padding: 8px 18px; border: none; border-radius: 5px; cursor: pointer; font-weight:10px;" />
            </div>
        </div>
    </fieldset>
</asp:Panel>


    <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" OnRowCommand="gvPedidos_RowCommand" CssClass="tabla-gridview"
        Width="100%" GridLines="None" HeaderStyle-BackColor="#007BFF" HeaderStyle-ForeColor="White" RowStyle-BackColor="#f9f9f9"
        AlternatingRowStyle-BackColor="#eef2f7" BorderStyle="None" CellPadding="10">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="UsuarioId" HeaderText="Uusuario ID" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="TipoCliente" HeaderText="Tipo Cliente" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
            <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro" DataFormatString="{0:dd/MM/yyyy}" />
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
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar Cliente" OnClick="btnAgregar_Click"
            Style="background-color: #007BFF; color: white; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer; font-weight: bold;" />
    </div>
      <!-- Sección inferior:paginación -->
  <div style="display: flex; justify-content: space-between; align-items: center; margin-top: 20px;">
     

      <div style="display: flex; gap: 6px;">
          <button style="padding: 6px 10px; border: 1px solid #ccc; background-color: #f9f9f9;">1</button>
          <button style="padding: 6px 10px; border: 1px solid #ccc; background-color: #f9f9f9;">2</button>
          <button style="padding: 6px 10px; border: 1px solid #ccc; background-color: #f9f9f9;">3</button>
          <button style="padding: 6px 10px; border: 1px solid #ccc; background-color: #f9f9f9;">...</button>
      </div>
  </div>
</asp:Content>