using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SoftCiapasaBusiness.ServiciosWSClient;

namespace SoftCiapasaBusiness.Pedidos
{
    public class PedidoItemBO
    {
        private PedidoItemClient pedidoItemClienteSOAP;

        public PedidoItemBO()
        {
            this.pedidoItemClienteSOAP = new PedidoItemClient();
        }

        public int InsertarPedidoItem(pedidoItemDTO pedidoItem)
        {
            return pedidoItemClienteSOAP.insertarPedidoItem(pedidoItem);
        }

        public pedidoItemDTO ObtenerPorIdPedidoItem(int idPedidoItem)
        {
            return pedidoItemClienteSOAP.obtenerPorIdPedidoItem(idPedidoItem);
        }

        public BindingList<pedidoItemDTO> ListarTodosPedidoItem()
        {
            pedidoItemDTO[] pedidoItemArray = pedidoItemClienteSOAP.listarTodosPedidoItem();
            return new BindingList<pedidoItemDTO>(pedidoItemArray);
        }

        public int ModificarPedidoItem(pedidoItemDTO pedidoItem)
        {
            return pedidoItemClienteSOAP.modificarPedidoItem(pedidoItem);
        }

        public int EliminarPedidoItem(pedidoItemDTO pedidoItem)
        {
            return pedidoItemClienteSOAP.eliminarPedidoItem(pedidoItem);
        }

        public BindingList<pedidoItemDTO> ListarPedidoItemPorPedido(int idPedido)
        {
            pedidoItemDTO[] pedidoItemArray = pedidoItemClienteSOAP.listarPedidoItemPorPedido(idPedido);
            return new BindingList<pedidoItemDTO>(pedidoItemArray);
        }

        public BindingList<pedidoItemDTO> ListarPedidoItemPorProductoTodos(int idProducto)
        {
            pedidoItemDTO[] pedidoItemArray = pedidoItemClienteSOAP.listarPedidoItemPorProductoTodos(idProducto);
            return new BindingList<pedidoItemDTO>(pedidoItemArray);
        }

        public BindingList<pedidoItemDTO> ListarPedidoItemPorRangoCantidad(int min, int max)
        {
            pedidoItemDTO[] pedidoItemArray = pedidoItemClienteSOAP.listarPedidoItemPorRangoCantidad(min, max);
            return new BindingList<pedidoItemDTO>(pedidoItemArray);
        }

        public BindingList<pedidoItemDTO> ListarPedidoItemPorRangoPrecio(double min, double max)
        {
            pedidoItemDTO[] pedidoItemArray = pedidoItemClienteSOAP.listarPedidoItemPorRangoPrecio(min, max);
            return new BindingList<pedidoItemDTO>(pedidoItemArray);
        }

        public BindingList<pedidoItemDTO> ListarPedidoItemPorPedidoTodos(int idPedido)
        {
            pedidoItemDTO[] pedidoItemArray = pedidoItemClienteSOAP.listarPedidoItemPorPedidoTodos(idPedido);
            return new BindingList<pedidoItemDTO>(pedidoItemArray);
        }

        public BindingList<pedidoItemDTO> ListarPedidoItemPorUsuarioCreacion(int idUsuario)
        {
            pedidoItemDTO[] pedidoItemArray = pedidoItemClienteSOAP.listarPedidoItemPorUsuarioCreacion(idUsuario);
            return new BindingList<pedidoItemDTO>(pedidoItemArray);
        }

        public BindingList<pedidoItemDTO> ListarPedidoItemPorPedidoYProducto(int idPedido, int idProducto)
        {
            pedidoItemDTO[] pedidoItemArray = pedidoItemClienteSOAP.listarPedidoItemPorPedidoYProducto(idPedido, idProducto);
            return new BindingList<pedidoItemDTO>(pedidoItemArray);
        }
    }
}
