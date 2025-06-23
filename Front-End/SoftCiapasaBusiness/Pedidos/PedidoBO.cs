using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftCiapasaBusiness.ServiciosWSClient;

namespace SoftCiapasaBusiness.Pedidos
{
    public class PedidoBO
    {
        private PedidoClient pedidoClienteSOAP;

        public PedidoBO()
        {
            this.pedidoClienteSOAP = new PedidoClient();
        }

        public int InsertarPedido(pedidoDTO pedido)
        {
            return this.pedidoClienteSOAP.insertarPedido(pedido);
        }

        public pedidoDTO ObtenerPorIdPedido(int idPedido)
        {
            return this.pedidoClienteSOAP.obtenerPorIdPedido(idPedido);
        }

        public BindingList<pedidoDTO> ListarTodosPedido()
        {
            pedidoDTO[] pedidosArray = this.pedidoClienteSOAP.listarTodosPedido();
            return new BindingList<pedidoDTO>(pedidosArray);
        }

        public int ModificarPedido(pedidoDTO pedido)
        {
            return this.pedidoClienteSOAP.modificarPedido(pedido);
        }

        public int EliminarPedido(pedidoDTO pedido)
        {
            return this.pedidoClienteSOAP.eliminarPedido(pedido);
        }

        public BindingList<pedidoDTO> ListarPedidosPorPersona(int idPersona)
        {
            pedidoDTO[] pedidosArray = this.pedidoClienteSOAP.listarPedidoPorPersona(idPersona);
            return new BindingList<pedidoDTO>(pedidosArray);
        }

        public BindingList<pedidoDTO> ListarPedidosPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            pedidoDTO[] pedidosArray = this.pedidoClienteSOAP.listarPedidoPorFecha(fechaInicio,fechaFin);
            return new BindingList<pedidoDTO>(pedidosArray);
        }

        public BindingList<pedidoDTO> ListarPedidosPorEstado(string estado)
        {
            pedidoDTO[] pedidosArray = this.pedidoClienteSOAP.listarPedidoPorEstado(estado);
            return new BindingList<pedidoDTO>(pedidosArray);
        }

        public BindingList<pedidoDTO> listarPedidosInactivos()
        {
            pedidoDTO[] pedidosArray = this.pedidoClienteSOAP.listarPedidoInactivo();
            return new BindingList<pedidoDTO>(pedidosArray);
        }

        public BindingList<pedidoDTO> ListarPedidosPorRangoTotal(double montoMinimo, double montoMaximo)
        {
            pedidoDTO[] pedidosArray = this.pedidoClienteSOAP.listarPedidoPorRangoTotal(montoMinimo, montoMaximo);
            return new BindingList<pedidoDTO>(pedidosArray);
        }

        public BindingList<pedidoDTO> ListarPedidosPorUsuarioCreacion(int usuarioId)
        {
            pedidoDTO[] pedidosArray = this.pedidoClienteSOAP.listarPedidoPorUsuarioCreacion(usuarioId);
            return new BindingList<pedidoDTO>(pedidosArray);
        }

        public BindingList<pedidoDTO> ListarPedidosPorEstadoYFecha(DateTime fechaInicio, DateTime fechaFin, string estado)
        {
            pedidoDTO[] pedidosArray = this.pedidoClienteSOAP.listarPedidoPorEstadoYFecha(estado, fechaInicio, fechaFin);
            return new BindingList<pedidoDTO>(pedidosArray);
        }

        public BindingList<pedidoDTO> ListarPedidosPorPersonaYEstado(int idPersona, string estado)
        {
            pedidoDTO[] pedidosArray = this.pedidoClienteSOAP.listarPedidoPorPersonaYEstado(idPersona, estado);
            return new BindingList<pedidoDTO>(pedidosArray);
        }
    }
}
