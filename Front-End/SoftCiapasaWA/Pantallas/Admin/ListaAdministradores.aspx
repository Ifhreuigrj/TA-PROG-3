<%@ Page Title="Lista de Administradores" Language="C#" MasterPageFile="~/Pantallas/MasterPages/SiteAdmin.master" AutoEventWireup="true" CodeBehind="ListaAdministradores.aspx.cs" Inherits="SoftWA.Pantallas.Admin.ListaAdministradores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    Lista Administradores
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="margin-bottom: 20px;">Lista de Administradores</h2>

    <!-- Contenedor filtros -->
   <asp:Panel ID="pnlFiltrosAdmin" runat="server" style="margin-bottom: 20px; border: 1px solid #ccc; padding: 15px; border-radius: 8px;">
    <fieldset>
        <legend style="font-weight: bold; padding: 0 10px;">Filtros </legend>
        <div style="display: flex; flex-wrap: wrap; gap: 20px; align-items: end;">
            <div style="display: flex; flex-direction: column;">
                <label for="txtIdAdmin">ID</label>
                <asp:TextBox ID="txtIdAdmin" runat="server" Width="100px" />
            </div>
            <div style="display: flex; flex-direction: column;">
                <label for="txtNombreUsuario">Nombre de Usuario</label>
                <asp:TextBox ID="txtNombreUsuario" runat="server" Width="150px" />
            </div>
            <div style="display: flex; flex-direction: column;">
                <label for="ddlCargo">Cargo</label>
                <asp:DropDownList ID="ddlCargo" runat="server" Width="120px">
                    <asp:ListItem Text="Todos" Value="" />
                     <asp:ListItem Text="Admin" Value="1" />
                    <asp:ListItem Text="View" Value="0" />
                 </asp:DropDownList>
            </div>
            <div style="display: flex; flex-direction: column;">
                <label>Último Ingreso (Rango)</label>
                <div style="display: flex; gap: 5px;">
                    <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="DateTimeLocal" Width="160px" />
                    <asp:TextBox ID="txtFechaFin" runat="server" TextMode="DateTimeLocal" Width="160px" />
                </div>
            </div>
            <div style="display: flex; flex-direction: column;">
                <label for="ddlActivo">Estado</label>
                <asp:DropDownList ID="ddlActivo" runat="server" Width="120px">
                    <asp:ListItem Text="Todos" Value="" />
                    <asp:ListItem Text="Activos" Value="1" />
                    <asp:ListItem Text="Inactivos" Value="0" />
                </asp:DropDownList>
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

<!-- Tabla para mostrar administradores filtrados -->
<asp:GridView ID="gvAdministradores" runat="server" AutoGenerateColumns="False" OnRowCommand="gvAdministradores_RowCommand" CssClass="tabla-gridview"
        Width="100%" GridLines="None" HeaderStyle-BackColor="#007BFF" HeaderStyle-ForeColor="White" RowStyle-BackColor="#f9f9f9"
        AlternatingRowStyle-BackColor="#eef2f7" BorderStyle="None" CellPadding="10">
    <Columns>
        <asp:BoundField DataField="id" HeaderText="ID" />
        <asp:BoundField DataField="UsuarioId" HeaderText="Usuario ID" />
        <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre de Usuario" />
        <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
        <asp:BoundField DataField="UltimoIngreso" HeaderText="Último Ingreso" DataFormatString="{0:dd/MM/yyyy}" />
        <asp:BoundField DataField="Activo" HeaderText="Activo" />
         <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha Creacion" DataFormatString="{0:dd/MM/yyyy}" />
     
        <asp:TemplateField HeaderText="Opciones">
    <ItemTemplate>
                <asp:LinkButton runat="server" CommandName="Editar" CommandArgument='<%# Eval("id") %>' CssClass="icon-btn" ToolTip="Editar">
    <i class="fas fa-search"></i>
</asp:LinkButton>
<asp:LinkButton runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("id") %>' CssClass="icon-btn icon-delete" ToolTip="Eliminar">
 <i class="fas fa-trash-alt"></i>
</asp:LinkButton>
    </ItemTemplate>
</asp:TemplateField>
    </Columns>
</asp:GridView>

    <div style="margin-top: 20px; text-align: left;">
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Administrador" OnClick="btnAgregar_Click"
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
