using System;
using System.Collections.Generic;
using System.ComponentModel; // Para BindingList
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.ServiceReference1;

namespace WebApplication1.Pantallas
{
    public partial class AgregarPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PersonaClient personaClient = new PersonaClient("PersonaPort"); // Asegúrate de tener este servicio
                personaDTO1[] personas = personaClient.listarTodosPersona();

                // Si quieres mostrar nombres completos:
                ddlPersona.DataSource = personas.Select(p => new {
                    Id = p.id,
                    NombreCompleto = p.nombres + " " + p.apellidos
                }).ToList();

                ddlPersona.DataTextField = "NombreCompleto";
                ddlPersona.DataValueField = "Id";
                ddlPersona.DataBind();

                ddlPersona.Items.Insert(0, new ListItem("Seleccione un cliente", ""));
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int personaId = int.Parse(ddlPersona.Text.Trim());
                string estado = ddlEstadoEnvio.SelectedValue;
                string metodoPago = ddlMetodoPago.SelectedValue;
                string estadoPago = ddlEstadoPago.SelectedValue;
                string estadoEnvio = ddlEstadoEnvio.SelectedValue;

                pedidoDTO nuevoPedido = new pedidoDTO
                {
                    persona = new personaDTO
                    {
                        id = personaId
                    },
                    estado = estado,
                    

                    pago = new pagoDTO
                    {
                        metodo = metodoPago,
                        estado = estadoPago
                    },
                    envio = new envioDTO
                    {
                        estadoEnvio = estadoEnvio
                    },
                    total = 0, // Por ahora, si no se agregan productos en esta vista
                    usuarioCreacion = new usuarioDTO
                    {
                        // id = (int)Session["idUsuario"] // para cuando tengas login
                        id = 1
                    }
                };
                nuevoPedido.fechaPedido = new localDateTime();
                nuevoPedido.fechaCreacion = new localDateTime();
                nuevoPedido.fechaActualizacion = new localDateTime();



                PedidoClient client = new PedidoClient("PedidoPort");
                int resultado = client.insertarPedido(nuevoPedido);

                if (resultado > 0)
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    lblMensaje.Text = "Pedido registrado correctamente.";
                    Response.Redirect("WebForm5.aspx");
                }
                else
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "No se pudo registrar el pedido.";
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
            Response.Redirect("WebForm5.aspx");
        }

        

    }
    
}