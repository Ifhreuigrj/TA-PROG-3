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
    public partial class EliminarProducto : System.Web.UI.Page
    {
        private int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    id = Convert.ToInt32(Request.QueryString["id"]);
                    ViewState["id"] = id;
                }
                else
                {
                    lblMensaje.Text = "ID de producto no especificado.";
                    btnEliminar.Enabled = false;
                }
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ViewState["id"] != null)
            {
                int id = (int)ViewState["id"];

                productoDTO1 producto = new productoDTO1 { idProducto = id };

                // Obtener el usuario actual desde la sesión
                //usuarioDTO2 usuarioActual = (usuarioDTO2)Session["usuario"];
                usuarioDTO2 usuarioActual = new usuarioDTO2 { id = 1 }; // ← Prueba solo si estás en desarrollo

                if (usuarioActual != null)
                {
                    // Asignar el usuario que realiza la eliminación
                    producto.usuarioActualizacion = usuarioActual;

                    ProductosClient bo = new ProductosClient("ProductosPort1");
                    int resultado = bo.eliminarProducto(producto);

                    if (resultado > 0)
                    {
                        Response.Redirect("WebForm1.aspx"); // Redirigir al listado de productos
                    }
                    else
                    {
                        lblMensaje.Text = "No se pudo eliminar el producto.";
                    }
                }
                else
                {
                    lblMensaje.Text = "Debe iniciar sesión para eliminar un producto.";
                }
            }
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }
    }
}