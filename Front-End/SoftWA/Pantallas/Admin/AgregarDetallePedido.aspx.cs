using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCiapasaBusiness.ServiciosWSClient;

namespace SoftCiapasaWA.Pantallas.Admin
{
    public partial class AgregarDetallePedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductosClient client = new ProductosClient("ProductosPort1");
                var productos = client.listarTodosProducto();

                ddlProducto.DataSource = productos;
                ddlProducto.DataTextField = "nombre";
                ddlProducto.DataValueField = "idProducto";
                ddlProducto.DataBind();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int idProducto = int.Parse(ddlProducto.SelectedValue);
                string nombre = ddlProducto.SelectedItem.Text;
                int cantidad = int.Parse(txtCantidad.Text);
                double precio = double.Parse(txtPrecio.Text);
                double subtotal = cantidad * precio;

                var item = new
                {
                    idProducto,
                    nombre,
                    cantidad,
                    precio,
                    subtotal
                };

                var lista = Session["detallePedido"] as List<object> ?? new List<object>();
                lista.Add(item);
                Session["detallePedido"] = lista;

                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = "Detalle agregado correctamente.";

                Response.Redirect("AgregarPedido.aspx");
            }
            catch (Exception ex)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPedido.aspx");
        }
    }
}