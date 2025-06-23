using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCiapasaBusiness.ServiciosWSClient;

namespace SoftCiapasaWA.Pantallas.MasterPages
{
    public partial class PaginaInicio : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                usuarioDTO1 usuario = (usuarioDTO1)Session["UsuarioAutenticado"];

                if (usuario != null)
                {
                    contenedorUsuario.Visible = true;
                    contenedorAnonimo.Visible = false;

                    lblEmailUsuario.Text = usuario.email;
                }
                else
                {
                    contenedorUsuario.Visible = false;
                    contenedorAnonimo.Visible = true;
                }
            }
        }
    }
}