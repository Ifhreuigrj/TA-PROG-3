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
    public partial class ListaPedidos : System.Web.UI.Page
    {
        public class PedidoDetalleViewModel
        {
            public int Id { get; set; }              // Pedido ID
            public int PersonaId { get; set; }
            public string NombreCliente { get; set; } // <- obtenido por método obtenerNombrePorID
            public DateTime FechaPedido { get; set; }
            public decimal Total { get; set; }
            public string Estado { get; set; } // Estado del Pedido
            public string EstadoPago { get; set; } // desde tabla pago
            public string MetodoPago { get; set; } // desde tabla pago
            public string EstadoEnvio { get; set; } // desde tabla envio
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPedidos();
            }
        }

        private BindingList<PedidoDetalleViewModel> pedidos;

        private void CargarPedidos()
        {
            PedidoClient client = new PedidoClient("PedidoPort"); // Usa tu binding name si lo tienes
            pedidoDTO[] pedidosWS = client.listarTodosPedido();

            // Asegurar que no es null
            if (pedidosWS == null)
            {
                pedidos = new BindingList<PedidoDetalleViewModel>(); // lista vacía para evitar errores
            }
            else
            {
                pedidos = new BindingList<PedidoDetalleViewModel>(
                    pedidosWS.Select(p => new PedidoDetalleViewModel
                    {
                        Id = p.idPedido,
                        PersonaId = p.persona != null ? p.persona.id : 0,
                        NombreCliente = p.persona != null ? p.persona.nombres + " " + p.persona.apellidos : "",
                        FechaPedido = DateTime.TryParse(p.fechaPedido?.ToString(), out DateTime fecha) ? fecha : DateTime.MinValue,
                        Total = (decimal)p.total,
                        Estado = p.estado,
                        EstadoPago = p.pago != null ? p.pago.estado : "No registrado",
                        MetodoPago = p.pago != null ? p.pago.metodo : "No registrado",
                        EstadoEnvio = p.envio != null ? p.envio.estadoEnvio : "No registrado"
                    }).ToList()
                );
            }

            gvPedidos.DataSource = pedidos;
            gvPedidos.DataBind();
        }



        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Aquí puedes implementar lógica de filtrado según estado, cliente, etc.
        }

        protected void btnBorrarFiltros_Click(object sender, EventArgs e)
        {
            txtPedidoId.Text = "";
            txtPersonaId.Text = "";
            txtTotal.Text = "";
            txtNombreCliente.Text = ""; // ← nuevo campo que agregaste

            ddlMetodoPago.SelectedIndex = 0;
            ddlEstadoPago.SelectedIndex = 0;
            ddlEstadoEnvio.SelectedIndex = 0;
            ddlEstadoPedido.SelectedIndex = 0;

            txtFechaInicio.Text = "";
            txtFechaFin.Text = "";

            btnFiltrar_Click(null, null); // vuelve a cargar con filtros limpios
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPedido.aspx"); // Redirige a otra página para agregar
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string id = btn.CommandArgument;

            string script = $"window.open('DetallePedido.aspx?id={id}', '_blank');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "abrirDetalle", script, true);
        }

        protected void btnVerComprobante_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string id = btn.CommandArgument;

            Response.Redirect($"ComprobantePedido.aspx?id={id}");
        }

        protected void gvPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {
                // Redirige a la pantalla de edición (puedes crear EditarPedido.aspx?id=...)
                Response.Redirect($"EditarPedido.aspx?id={id}");
            }
            else if (e.CommandName == "Eliminar")
            {
                Response.Redirect($"EliminarPedido.aspx?id={id}");
                CargarPedidos();
            }
        }

    }


}
