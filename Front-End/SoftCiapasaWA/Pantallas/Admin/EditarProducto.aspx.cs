
using WebApplication1.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Pantallas
{
    public partial class EditarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int idProducto = int.Parse(Request.QueryString["id"]);
                    hfIdProducto.Value = idProducto.ToString();
                    CargarProducto(idProducto);
                }
                else
                {
                    lblMensaje.Text = "No se especificó un ID de producto.";
                }
            }
        }

        private void CargarProducto(int id)
        {
            ProductosClient client = new ProductosClient("ProductosPort1");
            productoDTO1 producto = client.obtenerPorIdProducto(id); 

            if (producto != null)
            {
                txtNombre.Text = producto.nombre;
                ddlCategoria.SelectedValue = producto.categoria;
                txtPrecio.Text = producto.precio.ToString();
                txtStock.Text = producto.stock.ToString();
                txtDescripcion.Text = producto.descripcion;
            }
            else
            {
                lblMensaje.Text = "Producto no encontrado.";
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(hfIdProducto.Value);
                string nombre = txtNombre.Text.Trim();
                string categoria = ddlCategoria.SelectedValue;
                double precio = double.Parse(txtPrecio.Text.Trim());
                int stock = int.Parse(txtStock.Text.Trim());
                string descripcion = txtDescripcion.Text.Trim();

                productoDTO1 productoActualizado = new productoDTO1
                {
                    idProducto = id,
                    nombre = nombre,
                    categoria = categoria,
                    precio = precio,
                    stock = stock,
                    descripcion = descripcion,

                    
                };

                usuarioDTO2 usuarioActualizacion = new WebApplication1.ServiceReference1.usuarioDTO2
                {
                    id = 1 // ⚠️ Reemplazar con Session["idUsuario"] más adelante
                };

                ProductosClient client = new ProductosClient("ProductosPort1"); 
                int resultado = client.modificarProducto(productoActualizado);

                if (resultado > 0)
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    lblMensaje.Text = "Producto actualizado correctamente.";
                    Response.Redirect("WebForm1.aspx");
                }
                else
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "No se pudo actualizar el producto.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }
    }
}