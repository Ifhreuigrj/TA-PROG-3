using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.ServiceReference1;

namespace WebApplication1.Pantallas
{
    public partial class DetallePedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["id"] != null)
            {
                int idPedido;
                if (int.TryParse(Request.QueryString["id"], out idPedido))
                {
                    CargarDetalleDesdePedido(idPedido);
                }
            }
        }

        private class DetalleItemViewModel
        {
            public int IdProducto { get; set; }
            public string NombreProducto { get; set; }
            public int Cantidad { get; set; }
            public decimal PrecioUnitario { get; set; }
            public decimal Subtotal => Cantidad * PrecioUnitario;
        }

        private void CargarDetalleDesdePedido(int pedidoId)
        {
            PedidoClient client = new PedidoClient("PedidoPort");
            pedidoDTO pedido = client.obtenerPorIdPedido(pedidoId); // <-- método esperado

            if (pedido != null && pedido.items != null)
            {
                List<DetalleItemViewModel> detalle = pedido.items.Select(i => new DetalleItemViewModel
                {
                    IdProducto = i.producto.idProducto,
                    NombreProducto = i.producto.nombre,
                    Cantidad = i.cantidad,
                    PrecioUnitario = (decimal)i.precio
                }).ToList();

                gvDetalle.DataSource = detalle;
                gvDetalle.DataBind();

                decimal total = detalle.Sum(i => i.Subtotal);
                lblTotal.Text = total.ToString("C");
            }
            else
            {
                gvDetalle.DataSource = null;
                gvDetalle.DataBind();
                lblTotal.Text = "S/ 0.00";
            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm5.aspx"); // o el nombre real de tu pantalla de pedidos
        }


    }
}

