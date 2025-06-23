using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SoftCiapasaBusiness.ServiciosWSClient;

namespace SoftCiapasaBusiness.Pedidos
{
    public class ComprobanteBO
    {
        private ComprobanteClient comprobanteClienteSOAP;

        public ComprobanteBO()
        {
            this.comprobanteClienteSOAP = new ComprobanteClient();
        }

        public int InsertarComprobante(comprobanteDTO comprobante)
        {
            return this.comprobanteClienteSOAP.insertarComprobante(comprobante);
        }

        public comprobanteDTO ObtenerPorIdComprobante(int idComprobante)
        {
            return this.comprobanteClienteSOAP.obtenerPorIdComprobante(idComprobante);
        }

        public BindingList<comprobanteDTO> ListarTodosComprobante()
        {
            comprobanteDTO[] comprobantes = this.comprobanteClienteSOAP.listarTodosComprobante();
            return new BindingList<comprobanteDTO>(comprobantes);
        }

        public int ModificarComprobante(comprobanteDTO comprobante)
        {
            return this.comprobanteClienteSOAP.modificarComprobante(comprobante);
        }

        public int EliminarComprobante(comprobanteDTO comprobante)
        {
            return this.comprobanteClienteSOAP.eliminarComprobante(comprobante);
        }

        public BindingList<comprobanteDTO> ListarComprobantePedido(int pedidoId)
        {
            comprobanteDTO[] comprobantes = this.comprobanteClienteSOAP.listarComprobantePedido(pedidoId);
            return new BindingList<comprobanteDTO>(comprobantes);
        }

        public BindingList<comprobanteDTO> ListarComprobantePorTipo(string tipo)
        {
            comprobanteDTO[] comprobantes = this.comprobanteClienteSOAP.listarComprobantePorTipo(tipo);
            return new BindingList<comprobanteDTO>(comprobantes);
        }

        public BindingList<comprobanteDTO> ListarComprobanteInactivo()
        {
            comprobanteDTO[] comprobantes = this.comprobanteClienteSOAP.listarComprobanteInactivo();
            return new BindingList<comprobanteDTO>(comprobantes);
        }

        public BindingList<comprobanteDTO> ListarComprobanteRangoFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            comprobanteDTO[] comprobantes = this.comprobanteClienteSOAP.listarComprobanteRangoFecha(fechaInicio, fechaFin);
            return new BindingList<comprobanteDTO>(comprobantes);
        }

        public BindingList<comprobanteDTO> ListarComprobanteNumeroSerie(string serie)
        {
            comprobanteDTO[] comprobantes = this.comprobanteClienteSOAP.listarComprobanteNumeroSerie(serie);
            return new BindingList<comprobanteDTO>(comprobantes);
        }

        public BindingList<comprobanteDTO> ListarComprobanteUsuarioCreacion(int usuarioId)
        {
            comprobanteDTO[] comprobantes = this.comprobanteClienteSOAP.listarComprobanteUsuarioCreacion(usuarioId);
            return new BindingList<comprobanteDTO>(comprobantes);
        }

        public BindingList<comprobanteDTO> ListarComprobanteRangoTotal(double totalMin, double totalMax)
        {
            comprobanteDTO[] comprobantes = this.comprobanteClienteSOAP.listarComprobanteRangoTotal(totalMin, totalMax);
            return new BindingList<comprobanteDTO>(comprobantes);
        }

        public BindingList<comprobanteDTO> ListarComprobantePedidosTodos(int pedidoId)
        {
            comprobanteDTO[] comprobantes = this.comprobanteClienteSOAP.listarComprobantePedidosTodos(pedidoId);
            return new BindingList<comprobanteDTO>(comprobantes);
        }
    }
}
