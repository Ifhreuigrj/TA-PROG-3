using Mysqlx.Crud;
using SoftCiapasaBusiness.Pedidos;
using SoftCiapasaBusiness.ServiciosWSClient;
using SoftCiapasaBusiness.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCiapasaWA.Pantallas.MasterPages
{
    public partial class PaginaMaster : System.Web.UI.MasterPage
    {
        private CarritoBO carritoBO;
        private ItemCarritoBO itemCarritoBO;
        private UsuarioBO usuarioBO;
        private NaturalBO naturalBO;

        public PaginaMaster()
        {
            this.carritoBO = new CarritoBO();
            this.itemCarritoBO = new ItemCarritoBO();
            this.usuarioBO = new UsuarioBO();
            this.naturalBO = new NaturalBO();
        }
        public string EmailUsuario { get; private set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                usuarioDTO1 usuario = (usuarioDTO1)Session["UsuarioAutenticado"];

                if (usuario != null)
                {

                    lblEmailUsuario.Text=usuario.email;

                    contenedorUsuario.Attributes["class"] = "";       // Mostrar contenedor del usuario
                    contenedorAnonimo.Attributes["class"] = "d-none"; // Ocultar contenedor anónimo
                }
                else
                {
                    contenedorUsuario.Attributes["class"] = "d-none"; // Ocultar contenedor del usuario
                    contenedorAnonimo.Attributes["class"] = "";       // Mostrar contenedor anónimo
                }

                if (Session["idCarrito"] == null)
                {
                    CrearCarritoTemporal();
                    CrearSessionCarritoTemporal();
                }
                CargarCantidadCarrito();
            }
        }
        protected void CargarCantidadCarrito()
        {
            int idCarrito = Convert.ToInt32(Session["idCarrito"]);
            try
            {
                if (Session["idCarrito"] == null)
                {
                    lblCantidadItemsCarrito.Text = "0";
                    return;
                }

                var todosLosItems = itemCarritoBO.ListarTodosItemCarrito();
                var itemsDelCarrito = todosLosItems
                    .Where(item => item.carrito != null && item.carrito.idCarrito == idCarrito)
                    .ToList();

                if (itemsDelCarrito == null)
                {
                    lblCantidadItemsCarrito.Text = "0";
                    return;
                }
                int cantidadItems = 0;
                foreach (var item in itemsDelCarrito)
                {
                    cantidadItems += item.cantidad;
                }
                lblCantidadItemsCarrito.Text = cantidadItems.ToString();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al cargar el carrito: " + ex.Message + "');</script>");
            }
        }
        private void CrearCarritoTemporal()
        {
            int i;
            //var usuarioTemp = new usuarioDTO1
            //{
            //    email = "invitado@ciapasa",
            //    contraseña = "1234",
            //    rol = new rolDTO1 { id = 3}
            //};
            //i = usuarioWSClient.insertarUsuario(usuarioTemp);
            //var naturalTemp = new naturalDTO
            //{
            //    usuario = usuarioTemp,
            //    nombres = "invitado1",
            //    apellidos = "invitado1",
            //    telefono = "1234",
            //    dni = 1234,
            //    fechaNacimiento = DateTime.Now, //solo para prueba
            //    genero = "invitado",
            //    usuarioCreacion = new usuarioDTO1 { id = 1}
            //};
            //i = naturalWSClient.insertarNatural(naturalTemp);
            if (Session["idCarrito"] == null)
            {
                return;
            }
            var carritoTemp = new carritoDTO
            {
                persona = new personaDTO { id = 1 },
                total = 0,
                usuarioCreacion = new usuarioDTO { id = 4 }
            };
            i = carritoBO.InsertarCarrito(carritoTemp);
            Session["idUsuario"] = 4; //estas id están en la base de datos directamente porque todavía falta concectarlo con las pantallas de registrarse inicio sesión, etc. podrían tratarse como invitado
            Session["idPersona"] = 1; /*INSERT INTO usuario(email, contrasena, activo, rol_id) VALUES
                                            ('invitado@ciapasa.com', '1234', 1, 3);

                                        INSERT INTO persona(usuario_id, nombres, apellidos, telefono, activo, usuario_creacion) VALUES
                                            (4, 'Estefano V.', 'Quispe V.', 982842547, 1, 2);*/
        }

        private void CrearSessionCarritoTemporal()
        {
            var todosLosCarritos = carritoBO.ListarTodosCarrito();

            var ultimo = todosLosCarritos?
                .Where(c => c != null &&
                            c.persona != null && c.persona.id == 1 &&
                            c.usuarioCreacion != null && c.usuarioCreacion.id == 4 &&
                            c.total == 0)
                .OrderByDescending(c => c.idCarrito)
                .FirstOrDefault();

            if (ultimo != null)
                Session["idCarrito"] = ultimo.idCarrito;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string termino = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(termino))
            {
                Response.Redirect("~/Pantallas/Productos.aspx?busqueda=" + Server.UrlEncode(termino));
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            // Limpiamos la sesión y redirigimos al Home
            Session.Clear();
            Response.Redirect("Inicio.aspx");
        }
    }
}