using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftCiapasaBusiness.Productos;
using System.Xml.Linq;
using SoftCiapasaBusiness.ServiciosWSClient;
using System.ComponentModel;

namespace SoftCiapasaBusiness.Productos
{
    public class PrecioPresentacionBO
    {
        private PrecioPresentacionClient precioPresentacionClienteSOAP;
        public PrecioPresentacionBO()
        {
            // Inicializar el cliente SOAP
            this.precioPresentacionClienteSOAP = new PrecioPresentacionClient();
        }

        public int InsertarPrecioPresentacion(precioPresentacionDTO1 precioPresentacion)
        {
            return this.precioPresentacionClienteSOAP.insertarPrecioPresentacion(precioPresentacion);
        }

        public precioPresentacionDTO1 ObtenerPorIdPrecioPresentacion(int idPrecioPresentacion)
        {
            return this.precioPresentacionClienteSOAP.obtenerPorIdPrecioPresentacion(idPrecioPresentacion);
        }

        public BindingList<precioPresentacionDTO1> ListarTodosPrecioPresentacion()
        {
            precioPresentacionDTO1[] precioPresentacionArray = this.precioPresentacionClienteSOAP.listarTodosPrecioPresentacion();
            return new BindingList<precioPresentacionDTO1>(precioPresentacionArray);
        }

        public int ModificarPrecioPresentacion(precioPresentacionDTO1 precioPresentacion)
        {
            return this.precioPresentacionClienteSOAP.modificarPrecioPresentacion(precioPresentacion);
        }

        public int EliminarPrecioPresentacion(precioPresentacionDTO1 precioPresentacion)
        {
            return this.precioPresentacionClienteSOAP.eliminarPrecioPresentacion(precioPresentacion);
        }

        public BindingList<precioPresentacionDTO1> ListarPrecioPresentacionPorProducto(int productoId)
        {
            precioPresentacionDTO1[] precioPresentacionArray = this.precioPresentacionClienteSOAP.listarPrecioPresentacionPorProducto(productoId);
            return new BindingList<precioPresentacionDTO1>(precioPresentacionArray);
        }

        public BindingList<precioPresentacionDTO1> ListarPrecioPresentacionInactivos()
        {
            precioPresentacionDTO1[] precioPresentacionArray = this.precioPresentacionClienteSOAP.listarPrecioPresentacionInactivos();
            return new BindingList<precioPresentacionDTO1>(precioPresentacionArray);
        }

        public BindingList<precioPresentacionDTO1> ListarPrecioPresentacionPorRangoCantidad(int min, int max)
        {
            precioPresentacionDTO1[] precioPresentacionArray = this.precioPresentacionClienteSOAP.listarPrecioPresentacionPorRangoCantidad(min, max);
            return new BindingList<precioPresentacionDTO1>(precioPresentacionArray);
        }

        public BindingList<precioPresentacionDTO1> ListarPrecioPresentacionPorRangoPrecio(double min, double max)
        {
            precioPresentacionDTO1[] precioPresentacionArray = this.precioPresentacionClienteSOAP.listarPrecioPresentacionPorRangoPrecio(min, max);
            return new BindingList<precioPresentacionDTO1>(precioPresentacionArray);
        }

        public BindingList<precioPresentacionDTO1> ListarPrecioPresentacionPorTipoMedida(string tipoMedidaStr)
        {
            //DECENA, DOCENA, CENTENA, MILLAR, son los valores que puede tomar tipoMedidaStr
            precioPresentacionDTO1[] precioPresentacionArray = this.precioPresentacionClienteSOAP.listarPrecioPresentacionPorTipoMedida(tipoMedidaStr);
            return new BindingList<precioPresentacionDTO1>(precioPresentacionArray);
        }

        public BindingList<precioPresentacionDTO1> ListarPrecioPresentacionPorProductoTodos(int productoId)
        {
            precioPresentacionDTO1[] precioPresentacionArray = this.precioPresentacionClienteSOAP.listarPrecioPresentacionPorProductoTodos(productoId);
            return new BindingList<precioPresentacionDTO1>(precioPresentacionArray);
        }

        public BindingList<precioPresentacionDTO1> ListarPrecioPresentacionPorUsuarioCreacion(int usuarioId)
        {
            precioPresentacionDTO1[] precioPresentacionArray = this.precioPresentacionClienteSOAP.listarPrecioPresentacionPorUsuarioCreacion(usuarioId);
            return new BindingList<precioPresentacionDTO1>(precioPresentacionArray);
        }

        public BindingList<precioPresentacionDTO1> ListarPrecioPresentacionPorPrecioMaximo(double precioMaximo)
        {
            precioPresentacionDTO1[] precioPresentacionArray = this.precioPresentacionClienteSOAP.listarPrecioPresentacionPorPrecioMaximo(precioMaximo);
            return new BindingList<precioPresentacionDTO1>(precioPresentacionArray);
        }

        public precioPresentacionDTO1 BuscarPrecioPresentacionPorTipoYCantidad(int productoId, string tipoMedidaStr, int cantidad)
        {
            //DECENA, DOCENA, CENTENA, MILLAR, son los valores que puede tomar tipoMedidaStr
            return this.precioPresentacionClienteSOAP.buscarPrecioPresentacionPorTipoYCantidad(productoId, tipoMedidaStr, cantidad);
        }
    }
}
