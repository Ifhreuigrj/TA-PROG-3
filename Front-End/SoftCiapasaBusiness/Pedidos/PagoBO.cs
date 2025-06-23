using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using SoftCiapasaBusiness.Pedidos;
using System.Xml.Linq;
using SoftCiapasaBusiness.ServiciosWSClient;
using System.ComponentModel;

namespace SoftCiapasaBusiness.Pedidos
{
    public class PagoBO
    {
        private PagoClient pagoClienteSOAP;

        public PagoBO()
        {
            this.pagoClienteSOAP = new PagoClient();
        }

        public int InsertarPago(pagoDTO pago)
        {
            return pagoClienteSOAP.insertarPago(pago);
        }

        public pagoDTO ObtenerPorIdPago(int idPago)
        {
            return pagoClienteSOAP.obtenerPorIdPago(idPago);
        }

        public BindingList<pagoDTO> ListarTodosPago()
        {
            pagoDTO[] pagos = pagoClienteSOAP.listarTodosPago();
            return new BindingList<pagoDTO>(pagos);
        }

        public int ModificarPago(pagoDTO pago)
        {
            return pagoClienteSOAP.modificarPago(pago);
        }

        public int EliminarPago(pagoDTO pago)
        {
            return pagoClienteSOAP.eliminarPago(pago);
        }

        public BindingList<pagoDTO> ListarPagoPorPedido(int idPedido)
        {
            pagoDTO[] pagos = pagoClienteSOAP.listarPagoPorPedido(idPedido);
            return new BindingList<pagoDTO>(pagos);
        }

        public BindingList<pagoDTO> ListarPagoInactivo()
        {
            pagoDTO[] pagos = pagoClienteSOAP.listarPagoInactivo();
            return new BindingList<pagoDTO>(pagos);
        }

        public BindingList<pagoDTO> ListarPagoRangoFechaPago(DateTime fechaInicio, DateTime fechaFin)
        {
            pagoDTO[] pagos = pagoClienteSOAP.listarPagoRangoFechaPago(fechaInicio, fechaFin);
            return new BindingList<pagoDTO>(pagos);
        }

        public BindingList<pagoDTO> ListarPagoPorUsuarioCreacion(int usuarioId)
        {
            pagoDTO[] pagos = pagoClienteSOAP.listarPagoPorUsuarioCreacion(usuarioId);
            return new BindingList<pagoDTO>(pagos);
        }

        public BindingList<pagoDTO> ListarPagoPorPedidosTodos(int pedidoId)
        {
            pagoDTO[] pagos = pagoClienteSOAP.listarPagoPorPedidosTodos(pedidoId);
            return new BindingList<pagoDTO>(pagos);
        }

        public BindingList<pagoDTO> ListarPagoPorMontoMinimo(double montoMinimo)
        {
            pagoDTO[] pagos = pagoClienteSOAP.listarPagoPorMontoMinimo(montoMinimo);
            return new BindingList<pagoDTO>(pagos);
        }

        public BindingList<pagoDTO> ListarPagoPorRangoMonto(double min, double max)
        {
            pagoDTO[] pagos = pagoClienteSOAP.listarPagoPorRangoMonto(min, max);
            return new BindingList<pagoDTO>(pagos);
        }

        public BindingList<pagoDTO> ListarPagoPorEstadoYFecha(string estado, DateTime fecha)
        {
            pagoDTO[] pagos = pagoClienteSOAP.listarPagoPorEstadoYFecha(estado, fecha);
            return new BindingList<pagoDTO>(pagos);
        }
    }
}
