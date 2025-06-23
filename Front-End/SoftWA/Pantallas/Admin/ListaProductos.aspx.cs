using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCiapasaBusiness.ServiciosWSClient;

namespace SoftCiapasaWA.Pantallas.Admin
{
    public partial class ListaProductos : System.Web.UI.Page
    {
        ProductosClient client = new ProductosClient("ProductosPort");
        private BindingList<productoDTO1> productos;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductos();
            }
        }

        private void CargarProductos()
        {
            // Adaptar de productoDTO1[] a BindingList<productoDTO>
            productoDTO1[] productosWS = client.listarTodosProducto() ?? new productoDTO1[0];
            productos = new BindingList<productoDTO1>(
                productosWS.Select(p => new productoDTO1
                {
                    idProducto = p.idProducto,
                    nombre = p.nombre,
                    categoria = p.categoria,
                    precio = p.precio,
                    stock = p.stock,
                    descripcion = p.descripcion
                }).ToList()
            );

            gvProductos.DataSource = productos;
            gvProductos.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Repetir conversión
            productoDTO1[] productosWS = client.listarTodosProducto();
            productos = new BindingList<productoDTO1>(
                productosWS.Select(p => new productoDTO1
                {
                    idProducto = p.idProducto,
                    nombre = p.nombre,
                    categoria = p.categoria,
                    precio = p.precio,
                    stock = p.stock,
                    descripcion = p.descripcion
                }).ToList()
            );

            var resultado = productos;

            if (int.TryParse(txtId.Text, out int id))
                resultado = new BindingList<productoDTO1>(resultado.Where(p => p.idProducto == id).ToList());

            if (!string.IsNullOrEmpty(txtNombre.Text))
                resultado = new BindingList<productoDTO1>(resultado.Where(p => p.nombre.ToLower().Contains(txtNombre.Text.ToLower())).ToList());

            if (!string.IsNullOrEmpty(ddlCategoria.SelectedValue))
                resultado = new BindingList<productoDTO1>(resultado.Where(p => p.categoria == ddlCategoria.SelectedValue).ToList());

            if (double.TryParse(txtPrecioMin.Text, out double precioMin))
                resultado = new BindingList<productoDTO1>(resultado.Where(p => p.precio >= precioMin).ToList());

            if (double.TryParse(txtPrecioMax.Text, out double precioMax))
                resultado = new BindingList<productoDTO1>(resultado.Where(p => p.precio <= precioMax).ToList());

            if (int.TryParse(txtStock.Text, out int stock))
                resultado = new BindingList<productoDTO1>(resultado.Where(p => p.stock == stock).ToList());

            gvProductos.DataSource = resultado;
            gvProductos.DataBind();
        }
        protected void btnBorrarFiltros_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNombre.Text = "";
            ddlCategoria.SelectedIndex = 0; // O usar .ClearSelection() si necesitas
            txtPrecioMin.Text = "";
            txtPrecioMax.Text = "";
            txtStock.Text = "";
            btnFiltrar_Click(null, null);
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarProducto.aspx"); // Redirige a otra página para agregar
        }

        protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {
                Response.Redirect($"EditarProducto.aspx?id={id}");
            }
            else if (e.CommandName == "Eliminar")
            {
                Response.Redirect($"EliminarProducto.aspx?id={id}");
                CargarProductos();
            }
        }
    }
}
