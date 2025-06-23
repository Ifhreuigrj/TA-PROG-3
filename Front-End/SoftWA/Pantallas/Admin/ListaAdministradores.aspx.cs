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
    public partial class ListaAdministradores : System.Web.UI.Page
    {
        private List<administradorDTO> administradores;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAdministradores();
            }
        }

        private void CargarAdministradores()
        {
            AdministradorClient client = new AdministradorClient("AdministradorPort");
            administradorDTO[] data = client.listarTodosAdministrador();
            administradores = data != null ? data.ToList() : new List<administradorDTO>();

            ViewState["admins"] = administradores;
            gvAdministradores.DataSource = ProyectarDatos(administradores);
            gvAdministradores.DataBind();
        }

        private List<object> ProyectarDatos(List<administradorDTO> lista)
        {
            return lista.Select(a => new
            {
                id = a.id,
                UsuarioId = a.usuario != null ? a.usuario.id : 0,
                NombreUsuario = a.nombreUsuario,
                Cargo = a.cargo,
                UltimoIngreso = a.ultimoIngreso?.ToString() ?? "",
                Activo = a.activo == 1 ? "Sí" : "No",
                FechaCreacion = a.fechaCreacion?.ToString() ?? ""
            }).ToList<object>();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (ViewState["admins"] is List<administradorDTO> listaOriginal)
            {
                List<administradorDTO> resultado = listaOriginal;

                if (int.TryParse(txtIdAdmin.Text, out int id))
                    resultado = resultado.Where(a => a.id == id).ToList();

                if (!string.IsNullOrEmpty(txtNombreUsuario.Text))
                    resultado = resultado.Where(a => a.nombreUsuario != null &&
                        a.nombreUsuario.ToLower().Contains(txtNombreUsuario.Text.ToLower())).ToList();

                if (!string.IsNullOrEmpty(ddlCargo.SelectedValue))
                {
                    string cargo = ddlCargo.SelectedItem.Text;
                    resultado = resultado.Where(a => a.cargo == cargo).ToList();
                }

                if (DateTime.TryParse(txtFechaInicio.Text, out DateTime fechaInicio) &&
                    DateTime.TryParse(txtFechaFin.Text, out DateTime fechaFin))
                {
                    resultado = resultado.Where(a =>
                        a.ultimoIngreso != null &&
                        a.ultimoIngreso.ToString() != "" &&
                        Convert.ToDateTime(a.ultimoIngreso.ToString()) >= fechaInicio &&
                        Convert.ToDateTime(a.ultimoIngreso.ToString()) <= fechaFin).ToList();
                }

                if (ddlActivo.SelectedValue == "1")
                    resultado = resultado.Where(a => a.activo == 1).ToList();
                else if (ddlActivo.SelectedValue == "0")
                    resultado = resultado.Where(a => a.activo == 0).ToList();

                gvAdministradores.DataSource = ProyectarDatos(resultado);
                gvAdministradores.DataBind();
            }
        }

        protected void btnBorrarFiltros_Click(object sender, EventArgs e)
        {
            txtIdAdmin.Text = "";
            txtNombreUsuario.Text = "";
            ddlCargo.ClearSelection();
            ddlActivo.ClearSelection();
            txtFechaInicio.Text = "";
            txtFechaFin.Text = "";
            CargarAdministradores();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarAdministrador.aspx");
        }

        protected void gvAdministradores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("EditarAdministrador.aspx?id=" + id);
            }
            else if (e.CommandName == "Eliminar")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("EliminarAdministrador.aspx?id=" + id);
            }
        }
    }
}
