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
    public partial class EliminarPedido : System.Web.UI.Page
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
                    lblMensaje.Text = "ID de pedido no especificado.";
                    btnEliminar.Enabled = false;
                }
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ViewState["id"] != null)
            {
                int idPedido = (int)ViewState["id"];

                pedidoDTO pedido = new pedidoDTO { idPedido = idPedido };

                // Obtener usuario desde sesión
                usuarioDTO usuarioActual = (usuarioDTO)Session["usuario"];
                if (usuarioActual == null)
                {
                    usuarioActual = new usuarioDTO { id = 1 }; // TEMPORAL para pruebas
                }

                pedido.usuarioActualizacion = usuarioActual;
                pedido.activo = 0;

                PedidoClient client = new PedidoClient("PedidoPort");
                int resultado = client.eliminarPedido(pedido);

                if (resultado > 0)
                {
                    Response.Redirect("WebForm5.aspx"); // Volver al listado de pedidos
                }
                else
                {
                    lblMensaje.Text = "No se pudo eliminar el pedido.";
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm5.aspx");
        }
    }
}