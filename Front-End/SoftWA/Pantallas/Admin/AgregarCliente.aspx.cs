using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCiapasaBusiness.ServiciosWSClient;

namespace SoftCiapasaWA.Pantallas.Admin
{
    public partial class AgregarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlTipoCliente.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccionar", ""));
                ddlTipoCliente.Items.Add(new System.Web.UI.WebControls.ListItem("Juridico", "Juridico"));
                ddlTipoCliente.Items.Add(new System.Web.UI.WebControls.ListItem("Natural", "Natural"));
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombres = txtNombre.Text.Trim();
                string apellidos = txtApellidos.Text.Trim();
                string telefono = txtTelefono.Text.Trim();
                string email = txtEmail.Text.Trim();
                string tipoCliente = ddlTipoCliente.SelectedValue;

                // Primero insertamos el usuario (es obligatorio)
                usuarioDTO1 usuario = new usuarioDTO1
                {
                    email = email,
                    contraseña = "123456", // o generar aleatoria, si fuera necesario
                    rol = new rolDTO1
                    {
                        id = (tipoCliente == "Juridico") ? 1 : 2
                    },
                    activo = 1
                };

                UsuarioClient usuarioClient = new UsuarioClient();
                int usuarioId = usuarioClient.insertarUsuario(usuario);
                if (usuarioId <= 0)
                    throw new Exception("No se pudo registrar el usuario.");

                // Luego insertamos a la persona, dependiendo del tipo
                

                if (tipoCliente == "Natural")
                {
                    NaturalClient personaClient = new NaturalClient();
                    naturalDTO persona = new naturalDTO
                    {
                        nombres = nombres,
                        apellidos = apellidos,
                        telefono = telefono,
                        usuario = new usuarioDTO1 { id = usuarioId },
                        activo = 1
                    };

                    int personaId = personaClient.insertarNatural(persona);
                    if (personaId <= 0)
                        throw new Exception("No se pudo registrar la persona natural.");
                }
                else if (tipoCliente == "Juridico")
                {
                    JuridicaClient personaClient = new JuridicaClient();
                    juridicaDTO persona = new juridicaDTO
                    {
                        nombres = nombres,
                        apellidos = apellidos,
                        telefono = telefono,
                        usuario = new usuarioDTO1 { id = usuarioId },
                        activo = 1
                    };

                    int personaId = personaClient.insertarJuridica(persona);
                    if (personaId <= 0)
                        throw new Exception("No se pudo registrar la persona jurídica.");
                }

                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = "Cliente registrado correctamente.";
                Response.Redirect("WebForm2.aspx"); // Volver al listado
            }
            catch (Exception ex)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm2.aspx");
        }

    }
}