﻿using SoftCiapasaBusiness.Pedidos;
using SoftCiapasaBusiness.ServiciosWSClient;
using SoftCiapasaBusiness.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCiapasaWA.Pantallas
{
    public partial class DireccionEnvio : System.Web.UI.Page
    {
        private ItemCarritoBO itemCarritoBO;

        private ItemCarritoClient itemCarritoWSClient = new ItemCarritoClient();
        private DireccionClient direccionWSClient = new DireccionClient();
        private CarritoClient carritoWSClient = new CarritoClient();
        private PersonaClient personaWSClient = new PersonaClient();

        public DireccionEnvio()
        {
            // Constructor vacío para inicializar los clientes de servicios web
            this.itemCarritoBO = new ItemCarritoBO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarResumenCarrito();
            }
        }

        private void CargarResumenCarrito()
        {
            int idCarrito = Convert.ToInt32(Session["idCarrito"]);
            var carrito = carritoWSClient.obtenerPorIdCarrito(idCarrito);

            double subtotal = 0;

            if (carrito != null && carrito.items != null)
            {
                foreach (var item in carrito.items)
                {
                    subtotal += item.subtotal;
                }

                double igv = subtotal * 0.18;
                double total = subtotal + igv;

                lblSubtotal.Text = subtotal.ToString("F2");
                lblIGV.Text = igv.ToString("F2");
                lblTotal.Text = total.ToString("F2");
            }
            else
            {
                lblSubtotal.Text = "0.00";
                lblIGV.Text = "0.00";
                lblTotal.Text = "0.00";
            }
        }

        protected void btnGuardarDireccion_Click(object sender, EventArgs e)
        {
            if (Session["idPersona"] != null)
            {
                int idPersona = Convert.ToInt32(Session["idPersona"]);
                int idUsuario = Convert.ToInt32(Session["idUsuario"]);

                // Ensure the correct namespace and type are used here
                var nuevaDireccion = new direccionDTO1
                {
                    personaId = new personaDTO1 { id = idPersona },
                    alias = txtAlias.Text,
                    direccion = txtDireccion.Text,
                    ciudad = txtCiudad.Text,
                    referencia = txtReferencia.Text,
                    usuarioCreacion = new usuarioDTO1 { id = idUsuario }
                };

                int i = direccionWSClient.insertarDireccion(nuevaDireccion);

                // Obtener la última dirección registrada por esa persona y usuario

                var listaDirecciones = direccionWSClient.listarTodosDireccion();

                var ultimaDireccion = listaDirecciones?
                    .Where(d => d != null &&
                                d.personaId != null && d.personaId.id == idPersona &&
                                d.usuarioCreacion != null && d.usuarioCreacion.id == idUsuario &&
                                d.direccion == txtDireccion.Text && d.alias == txtAlias.Text)
                    .OrderByDescending(d => d.id)
                    .FirstOrDefault();

                if (ultimaDireccion != null)
                {
                    Session["idDireccionSelececionada"] = ultimaDireccion.id;
                    lblMensaje.CssClass = "text-success mt-2 d-block";
                    lblMensaje.Text = "¡Dirección guardada con éxito!";
                }
                else
                {
                    lblMensaje.CssClass = "text-danger mt-2 d-block";
                    lblMensaje.Text = "No se pudo guardar la dirección. Intenta nuevamente.";
                }
                Response.Redirect("DireccionEnvio.aspx");
            }
        }

        protected void btnVerDirecciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("DireccionesGuardadas.aspx");
        }

        protected void btnContinuarPago_Click(object sender, EventArgs e)
        {
            if (Session["idDireccionSelececionada"] == null)
            {
                lblMensaje.Text = "Por favor selecciona o registra una dirección antes de continuar.";
                return;
            }

            Response.Redirect("DatosDePago.aspx");
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static bool SeleccionarDireccion(int idDireccion)
        {
            HttpContext.Current.Session["idDireccionSelececionada"] = idDireccion;
            return true;
        }
    }
}