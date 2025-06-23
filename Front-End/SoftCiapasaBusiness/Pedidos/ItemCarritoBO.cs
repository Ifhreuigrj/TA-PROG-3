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
    public class ItemCarritoBO
    {
        private ItemCarritoClient itemCarritoClienteSOAP;

        public ItemCarritoBO()
        {
            this.itemCarritoClienteSOAP = new ItemCarritoClient();
        }

        public int InsertarItemCarrito(itemCarritoDTO itemCarrito)
        {
            return itemCarritoClienteSOAP.insertarItemCarrito(itemCarrito);
        }

        public itemCarritoDTO ObtenerPorIdItemCarrito(int idItemCarrito)
        {
            return itemCarritoClienteSOAP.obtenerPorIdItemCarrito(idItemCarrito);
        }

        public BindingList<itemCarritoDTO> ListarTodosItemCarrito()
        {
            itemCarritoDTO[] itemCarritoArray = itemCarritoClienteSOAP.listarTodosItemCarrito();
            return new BindingList<itemCarritoDTO>(itemCarritoArray);
        }

        public int ModificarItemCarrito(itemCarritoDTO itemCarrito)
        {
            return itemCarritoClienteSOAP.modificarItemCarrito(itemCarrito);
        }

        public int EliminarItemCarrito(itemCarritoDTO itemCarrito)
        {
            return itemCarritoClienteSOAP.eliminarItemCarrito(itemCarrito);
        }

        public BindingList<itemCarritoDTO> ListarItemCarritoInactivo()
        {
            itemCarritoDTO[] itemCarritoArray = itemCarritoClienteSOAP.listarItemCarritoInactivo();
            return new BindingList<itemCarritoDTO>(itemCarritoArray);
        }

        public BindingList<itemCarritoDTO> ListarItemCarritoPorProducto(int productoId)
        {
            itemCarritoDTO[] itemCarritoArray = itemCarritoClienteSOAP.listarItemCarritoPorProducto(productoId);
            return new BindingList<itemCarritoDTO>(itemCarritoArray);
        }

        public BindingList<itemCarritoDTO> ListarItemCarritoRangoCantidad(int min, int max)
        {
            itemCarritoDTO[] itemCarritoArray = itemCarritoClienteSOAP.listarItemCarritoRangoCantidad(min, max);
            return new BindingList<itemCarritoDTO>(itemCarritoArray);
        }

        public BindingList<itemCarritoDTO> ListarItemCarritoRangoSubTotal(double min, double max)
        {
            itemCarritoDTO[] itemCarritoArray = itemCarritoClienteSOAP.listarItemCarritoRangoSubTotal(min, max);
            return new BindingList<itemCarritoDTO>(itemCarritoArray);
        }

        public BindingList<itemCarritoDTO> ListarItemCarritoCantidadMinima(int minimo)
        {
            itemCarritoDTO[] itemCarritoArray = itemCarritoClienteSOAP.listarItemCarritoCantidadMinima(minimo);
            return new BindingList<itemCarritoDTO>(itemCarritoArray);
        }

        public BindingList<itemCarritoDTO> ListarItemCarritoFechaCreacion(DateTime fechaInicio, DateTime fechaFin)
        {
            itemCarritoDTO[] itemCarritoArray = itemCarritoClienteSOAP.listarItemCarritoFechaCreacion(fechaInicio, fechaFin);
            return new BindingList<itemCarritoDTO>(itemCarritoArray);
        }

        public BindingList<itemCarritoDTO> ListarItemCarritoPorCarritoYProducto(int carritoId, int productoId)
        {
            itemCarritoDTO[] itemCarritoArray = itemCarritoClienteSOAP.listarItemCarritoPorCarritoYProducto(carritoId, productoId);
            return new BindingList<itemCarritoDTO>(itemCarritoArray);
        }
    }
}
