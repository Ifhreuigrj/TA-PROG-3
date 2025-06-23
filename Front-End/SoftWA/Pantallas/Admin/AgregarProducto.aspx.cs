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
    public partial class AgregarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Nada que cargar por ahora
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text.Trim();
                string categoria = ddlCategoria.SelectedValue;
                double precio = double.Parse(txtPrecio.Text.Trim());
                int stock = int.Parse(txtStock.Text.Trim());
                string descripcion = txtDescripcion.Text.Trim();
                

                productoDTO1 nuevoProducto = new productoDTO1
                {
                    nombre = nombre,
                    categoria = categoria,
                    precio = precio,
                    stock = stock,
                    descripcion = descripcion,

                    usuarioCreacion = new usuarioDTO2
                    {
                        //id = (int)Session["idUsuario"] // Asegúrate de que tu login guarde esto
                        id = 1,
                    }
                };

                // Llamar al servicio para insertar
                ProductosClient client = new ProductosClient("ProductosPort1");
                int resultado = client.insertarProducto(nuevoProducto); // ← este es el cambio clave


                if (resultado>0)
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    lblMensaje.Text = "Producto guardado correctamente.";
                    Response.Redirect("ListaProductos.aspx");
                }
                else
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "No se pudo guardar el producto.";
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
            Response.Redirect("ListaProductos.aspx");
        }
    }
}
