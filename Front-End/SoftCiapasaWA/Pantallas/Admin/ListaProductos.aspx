<%@ Page Title="Lista de Productos" Language="C#" MasterPageFile="~/Pantallas/MasterPages/SiteAdmin.master" AutoEventWireup="true" CodeBehind="ListaProductos.aspx.cs" Inherits="SoftWA.Pantallas.Admin.ListaProductos" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    Lista de Productos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="margin-bottom: 20px;">Lista de Productos</h2>

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
                    <label for="txtNombre">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="filtro" Width="150px" />
                </div>
                <div style="display: flex; flex-direction: column;">
                    <label for="ddlCategoria">Categoría</label>
                    <asp:DropDownList ID="ddlCategoria" runat="server" Width="160px">
                        <asp:ListItem Text="Todas" Value="" />
                        <asp:ListItem Text="Electrónica" Value="Electrónica" />
                        <asp:ListItem Text="Ropa" Value="Ropa" />
                        <asp:ListItem Text="Hogar" Value="Hogar" />
                    </asp:DropDownList>
                </div>
                <div style="display: flex; flex-direction: column;">
                    <label>Precio</label>
                    <div style="display: flex; gap: 5px;">
                        <asp:TextBox ID="txtPrecioMin" runat="server" Placeholder="Mín" Width="70px" />
                        <asp:TextBox ID="txtPrecioMax" runat="server" Placeholder="Máx" Width="70px" />
                    </div>
                </div>
                <div style="display: flex; flex-direction: column;">
                    <label for="txtStock">Stock</label>
                    <asp:TextBox ID="txtStock" runat="server" Width="100px" />
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

    <!-- GridView de productos -->
    <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" OnRowCommand="gvProductos_RowCommand" CssClass="tabla-gridview"
        Width="100%" GridLines="None" HeaderStyle-BackColor="#007BFF" HeaderStyle-ForeColor="White" RowStyle-BackColor="#f9f9f9"
        AlternatingRowStyle-BackColor="#eef2f7" BorderStyle="None" CellPadding="10">
        <Columns>
            <asp:BoundField DataField="idProducto" HeaderText="Codigo" />
            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="categoria" HeaderText="Categoría" />
            <asp:BoundField DataField="precio" HeaderText="Precio" DataFormatString="{0:C}" />
            <asp:BoundField DataField="stock" HeaderText="Stock" />
            <asp:TemplateField HeaderText="Opciones">
                <ItemTemplate>
                    <asp:LinkButton runat="server" CommandName="Editar" CommandArgument='<%# Eval("idProducto") %>' CssClass="icon-btn" ToolTip="Editar">
                <i class="fas fa-search"></i>
            </asp:LinkButton>
            <asp:LinkButton runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("idProducto") %>' CssClass="icon-btn icon-delete" ToolTip="Eliminar">
             <i class="fas fa-trash-alt"></i>
            </asp:LinkButton>

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <!-- Botón Agregar debajo del GridView, alineado a la izquierda -->
<div style="margin-top: 20px; text-align: left;">
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Producto" OnClick="btnAgregar_Click"
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



