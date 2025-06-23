using System;
using WebApplication1.ServiceReference1;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Pantallas
{
    public partial class EditarPedido : System.Web.UI.Page
    {
        int pedidoId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    pedidoId = int.Parse(Request.QueryString["id"]);
                    ViewState["pedidoId"] = pedidoId;
                    CargarPersonas();
                    CargarPedido(pedidoId);
                }
                else
                {
                    lblMensaje.Text = "ID no especificado.";
                }
            }
        }

        private void CargarPersonas()
        {
            PersonaClient personaClient = new PersonaClient("PersonaPort");
            var personas = personaClient.listarTodosPersona();
            ddlPersona.DataSource = personas;
            ddlPersona.DataTextField = "nombres";
            ddlPersona.DataValueField = "id";
            ddlPersona.DataBind();
        }

        private void CargarPedido(int id)
        {
            PedidoClient pedidoClient = new PedidoClient("PedidoPort");
            var pedidos = pedidoClient.listarTodosPedido();
            var pedido = pedidos.FirstOrDefault(p => p.idPedido == id);

            if (pedido != null)
            {
                ddlPersona.SelectedValue = pedido.persona?.id.ToString();
                ddlMetodoPago.SelectedValue = pedido.pago?.metodo ?? "";
                ddlEstadoPago.SelectedValue = pedido.pago?.estado ?? "";
                ddlEstadoEnvio.SelectedValue = pedido.envio?.estadoEnvio ?? "";
                ddlEstadoPedido.SelectedValue = pedido.estado;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)ViewState["pedidoId"];
                PedidoClient client = new PedidoClient("PedidoPort");

                pedidoDTO pedido = new pedidoDTO
                {
                    idPedido = id,
                    persona = new personaDTO { id = int.Parse(ddlPersona.SelectedValue) },
                    pago = new pagoDTO
                    {
                        metodo = ddlMetodoPago.SelectedValue,
                        estado = ddlEstadoPago.SelectedValue
                    },
                    envio = new envioDTO
                    {
                        estadoEnvio = ddlEstadoEnvio.SelectedValue
                    },
                    estado = ddlEstadoPedido.SelectedValue,
                    usuarioActualizacion = new usuarioDTO { id = 1 } // ← actualizar por sesión más adelante
                };

                int resultado = client.modificarPedido(pedido);

                if (resultado > 0)
                {
                    Response.Redirect("WebForm5.aspx");
                }
                else
                {
                    lblMensaje.Text = "No se pudo actualizar el pedido.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm5.aspx");
        }
    }
}