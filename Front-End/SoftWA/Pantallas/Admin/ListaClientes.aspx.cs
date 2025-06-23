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
    public partial class ListaClientes : System.Web.UI.Page
    {
        private List<personaDTO> personas;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPersonas();
            }
        }

        private void CargarPersonas()
        {
            PersonaClient client = new PersonaClient("PersonaPort");
            personaDTO1[] data = client.listarTodosPersona();
            List<personaDTO1> personas = data != null
            ? new List<personaDTO1>(data)
            : new List<personaDTO1>();


            gvClientes.DataSource = personas.Select(p => new
            {
                Id = p.id,
                Nombre = p.nombres + " " + p.apellidos,
                Telefono = p.telefono,
                Email = p.usuario.email??"Sin email",
                TipoCliente = p.usuario != null && p.usuario.rol != null
                ? (p.usuario.rol.id == 1 ? "Juridico" :
                p.usuario.rol.id == 2 ? "Natural" : "Sin rol")
                : "Sin rol",

                FechaRegistro = p.fechaCreacion != null ? p.fechaCreacion.ToString() : "",
                UsuarioId = p.usuario.id,
            }).ToList();


            gvClientes.DataBind();
            ViewState["clientes"] = personas;
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            PersonaClient client = new PersonaClient("PersonaPort");
            List<personaDTO1> personas = new List<personaDTO1>();
            DateTime fechaInicio = DateTime.MinValue;
            DateTime fechaFin = DateTime.MinValue;
            // Verificar si hay fechas para usar procedimiento
            bool usarFiltroFecha = DateTime.TryParse(txtFechaRegistroDesde.Text, out  fechaInicio)
                                && DateTime.TryParse(txtFechaRegistroHasta.Text, out  fechaFin);
            if (usarFiltroFecha)
            {
                personas = client.listarPorFechasPersona(fechaInicio, fechaFin)
                    .ToList() ?? new List<personaDTO1>();
            }
            else if (int.TryParse(txtUsuarioId.Text, out int usuarioId))
            {
                personas = client.listarPorUsuarioCreacionPersona(usuarioId).ToList() ?? new List<personaDTO1>();
            }
            else if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                // Dividir nombre ingresado en nombre y apellido aproximado
                string[] partes = txtNombre.Text.Trim().Split(' ');
                string nombre = partes.Length > 0 ? partes[0] : "";
                string apellido = partes.Length > 1 ? partes[1] : "";

                personas = client.listarPorNombreApellidoParcialPersona(nombre, apellido)?.ToList() ?? new List<personaDTO1>();
            }
            else
            {
                personas = client.listarTodosPersona()?.ToList() ?? new List<personaDTO1>();
            }

            // Filtros adicionales en frontend
            if (!string.IsNullOrEmpty(txtTelefono.Text))
            {
                personas = personas.Where(p => p.telefono != null && p.telefono.Contains(txtTelefono.Text)).ToList();
            }

            if (!string.IsNullOrEmpty(ddlTipoCliente.SelectedValue))
            {
                personas = personas.Where(p =>
                    p.usuario != null && p.usuario.rol != null &&
                    ((ddlTipoCliente.SelectedValue == "Juridico" && p.usuario.rol.id == 1) ||
                     (ddlTipoCliente.SelectedValue == "Natural" && p.usuario.rol.id == 2))
                ).ToList();
            }

            gvClientes.DataSource = personas.Select(p => new
            {
                Id = p.id,
                Nombre = p.nombres + " " + p.apellidos,
                Telefono = p.telefono,
                Email = p.usuario?.email ?? "Sin email",
                TipoCliente = p.usuario != null && p.usuario.rol != null
                    ? (p.usuario.rol.id == 1 ? "Juridico" :
                       p.usuario.rol.id == 2 ? "Natural" : "Sin rol")
                    : "Sin rol",
                FechaRegistro = p.fechaCreacion.ToString(), // No hay formato directo disponible
                UsuarioId = p.usuario?.id ?? 0
            }).ToList();

            gvClientes.DataBind();
        }





        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCliente.aspx");
        }

        protected void btnBorrarFiltros_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNombre.Text = "";
            ddlTipoCliente.SelectedIndex = 0;
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtFechaRegistroDesde.Text = "";
            txtFechaRegistroHasta.Text = "";

            // Recargar todos los datos sin filtros
            btnFiltrar_Click(null, null);

        }

        protected void gvPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {
                Response.Redirect($"EditarCliente.aspx?id={id}");
            }
            else if (e.CommandName == "Eliminar")
            {
                Response.Redirect($"EliminarCliente.aspx?id={id}");
                CargarPersonas();
            }
        }

    }
}

