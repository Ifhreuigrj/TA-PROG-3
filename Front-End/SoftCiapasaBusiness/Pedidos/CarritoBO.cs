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
    public class CarritoBO
    {
        private CarritoClient carritoClienteSOAP;

        public CarritoBO()
        {
            this.carritoClienteSOAP = new CarritoClient();
        }

        public int InsertarCarrito(carritoDTO carrito)
        {
            return this.carritoClienteSOAP.insertarCarrito(carrito);
        }

        public carritoDTO ObtenerPorIdCarrito(int idCarrito)
        {
            return this.carritoClienteSOAP.obtenerPorIdCarrito(idCarrito);
        }

        public BindingList<carritoDTO> ListarTodosCarrito()
        {
            carritoDTO[] carritoArray = this.carritoClienteSOAP.listarTodosCarrito();
            return new BindingList<carritoDTO>(carritoArray);
        }

        public int ModificarCarrito(carritoDTO carrito)
        {
            return this.carritoClienteSOAP.modificarCarrito(carrito);
        }

        public int EliminarCarrito(carritoDTO carrito)
        {
            return this.carritoClienteSOAP.eliminarCarrito(carrito);
        }

        public int VaciarCarrito(int idCarrito, int idUsuario)
        {
            return this.carritoClienteSOAP.vaciarCarrito(idCarrito, idUsuario);
        }

        public BindingList<carritoDTO> ListarCarritoPorPersona(int idPersona)
        {
            carritoDTO[] carritoArray = this.carritoClienteSOAP.listarCarritoPorPersona(idPersona);
            return new BindingList<carritoDTO>(carritoArray);
        }

        public BindingList<carritoDTO> ListarCarritoInactivos()
        {
            carritoDTO[] carritoArray = this.carritoClienteSOAP.listarCarritoInactivos();
            return new BindingList<carritoDTO>(carritoArray);
        }

        public BindingList<carritoDTO> ListarCarritoPorRangoFechaCreacion(DateTime fechaInicio, DateTime fechaFin)
        {
            carritoDTO[] carritoArray = this.carritoClienteSOAP.listarCarritoPorRangoFechaCreacion(fechaInicio, fechaFin);
            return new BindingList<carritoDTO>(carritoArray);
        }

        public BindingList<carritoDTO> ListarCarritoPorUsuarioCreacion(int idUsuarioCreacion)
        {
            carritoDTO[] carritoArray = this.carritoClienteSOAP.listarCarritoPorUsuarioCreacion(idUsuarioCreacion);
            return new BindingList<carritoDTO>(carritoArray);
        }

        public BindingList<carritoDTO> ListarCarritoPersonaTodos(int idPersona)
        {
            carritoDTO[] carritoArray = this.carritoClienteSOAP.listarCarritoPersonaTodos(idPersona);
            return new BindingList<carritoDTO>(carritoArray);
        }

        public BindingList<carritoDTO> ListarCarritoPorRangoTotal(double montoMinimo, double montoMaximo)
        {
            carritoDTO[] carritoArray = this.carritoClienteSOAP.listarCarritoPorRangoTotal(montoMinimo, montoMaximo);
            return new BindingList<carritoDTO>(carritoArray);
        }
    }
}
