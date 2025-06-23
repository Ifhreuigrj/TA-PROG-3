using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SoftCiapasaBusiness.ServiciosWSClient;

namespace SoftCiapasaBusiness.Productos
{
    public class ProductoBO
    {
        private ProductosClient productosClienteSOAP;
        public ProductoBO()
        {
            // Inicializar el cliente SOAP
            this.productosClienteSOAP = new ProductosClient();
        }

        public int InsertarProducto(productoDTO1 producto)
        {
            // Llamar al servicio SOAP para insertar el producto
            return this.productosClienteSOAP.insertarProducto(producto);
        }

        public productoDTO1 ObtenerPorIdProducto(int idProducto)
        {
            // Llamar al servicio SOAP para obtener el producto por ID
            return this.productosClienteSOAP.obtenerPorIdProducto(idProducto);
        }

        public BindingList<productoDTO1> ListarTodosProducto()
        {
            // Llamar al servicio SOAP para obtener todos los productos
            productoDTO1[] productosArray = this.productosClienteSOAP.listarTodosProducto();
            return new BindingList<productoDTO1>(productosArray);
        }

        public int ModificarProducto(productoDTO1 producto)
        {
            // Llamar al servicio SOAP para actualizar el producto
            return this.productosClienteSOAP.modificarProducto(producto);
        }

        public int EliminarProducto(productoDTO1 producto)
        {
            // Llamar al servicio SOAP para eliminar el producto
            return this.productosClienteSOAP.eliminarProducto(producto);
        }

        public BindingList<productoDTO1> ListarProductosInactivos()
        {
            // Llamar al servicio SOAP para obtener productos inactivos
            productoDTO1[] productosArray = this.productosClienteSOAP.listarProductosInactivos();
            return new BindingList<productoDTO1>(productosArray);
        }

        public BindingList<productoDTO1> ListarProductosPorRangoPrecio(double precioMin, double precioMax)
        {
            // Llamar al servicio SOAP para listar productos por rango de precio
            productoDTO1[] productosArray = this.productosClienteSOAP.listarProductosPorRangoPrecio(precioMin, precioMax);
            return new BindingList<productoDTO1>(productosArray);
        }

        public BindingList<productoDTO1> ListarProductosPorStockMinimo(int stockMinimo)
        {
            // Llamar al servicio SOAP para listar productos por stock mínimo
            productoDTO1[] productosArray = this.productosClienteSOAP.listarProductosPorStockMinimo(stockMinimo);
            return new BindingList<productoDTO1>(productosArray);
        }

        public BindingList<productoDTO1> ListarProductosPorUsuarioCreacion(int usuarioId)
        {
            // Llamar al servicio SOAP para listar productos por usuario de creación
            productoDTO1[] productosArray = this.productosClienteSOAP.listarProductosPorUsuarioCreacion(usuarioId);
            return new BindingList<productoDTO1>(productosArray);
        }

        public BindingList<productoDTO1> ListarProductosPorRangoFechaCreacion(DateTime fechaInicio, DateTime fechaFin)
        {
            // Llamar al servicio SOAP para listar productos por rango de fecha de creación
            productoDTO1[] productosArray = this.productosClienteSOAP.listarProductosPorRangoFechaCreacion(fechaInicio, fechaFin);
            return new BindingList<productoDTO1>(productosArray);
        }

        public BindingList<productoDTO1> ListarProductosPorCategoria(string categoria)
        {
            // Llamar al servicio SOAP para listar productos por categoría
            productoDTO1[] productosArray = this.productosClienteSOAP.listarProductosPorCategoria(categoria);
            return new BindingList<productoDTO1>(productosArray);
        }

        public BindingList<productoDTO1> ListarProductosPorDescripcionParcial(string descripcionParcial)
        {
            // Llamar al servicio SOAP para listar productos por descripción parcial
            productoDTO1[] productosArray = this.productosClienteSOAP.listarProductosPorDescripcionParcial(descripcionParcial);
            return new BindingList<productoDTO1>(productosArray);
        }

        public BindingList<productoDTO1> ListarProductosPorNombre(string nombre)
        {
            // Llamar al servicio SOAP para listar productos por nombre
            productoDTO1[] productosArray = this.productosClienteSOAP.listarProductosPorNombre(nombre);
            return new BindingList<productoDTO1>(productosArray);
        }

        public BindingList<productoDTO1> ListarProductosPorRangoStock(int stockMin, int stockMax)
        {
            // Llamar al servicio SOAP para listar productos por rango de stock
            productoDTO1[] productosArray = this.productosClienteSOAP.listarProductosPorRangoStock(stockMin, stockMax);
            return new BindingList<productoDTO1>(productosArray);
        }

        public BindingList<productoDTO1> ListarProductosPaginado(int offset, int limit)
        {
            // Llamar al servicio SOAP para listar productos paginados
            productoDTO1[] productosArray = this.productosClienteSOAP.listarProductosPaginado(offset, limit);
            return new BindingList<productoDTO1>(productosArray);
        }

        public BindingList<productoDTO1> ListarProductosSinStock()
        {
            // Llamar al servicio SOAP para listar productos sin stock
            productoDTO1[] productosArray = this.productosClienteSOAP.listarProductosSinStock();
            return new BindingList<productoDTO1>(productosArray);
        }

        public BindingList<productoDTO1> ListarProductosPorNombreYPrecioMaximo(string nombre, double precioMaximo)
        {
            // Llamar al servicio SOAP para listar productos por nombre y precio máximo
            productoDTO1[] productosArray = this.productosClienteSOAP.listarProductosPorNombreYPrecioMaximo(nombre, precioMaximo);
            return new BindingList<productoDTO1>(productosArray);
        }

        public int ActualizarStockProducto(int productoId, int stockNuevo, int usuarioActualizacion)
        {
            // Llamar al servicio SOAP para actualizar el stock del producto
            return this.productosClienteSOAP.actualizarStockProducto(productoId, stockNuevo, usuarioActualizacion);
        }

    }
}
