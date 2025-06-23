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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    
    protected void btnVerProductos_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx"); // Cambia al nombre correcto si es distinto
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarProducto.aspx"); // Asegúrate que exista esta página
        }


    }

}