using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SoftCiapasaBusiness.ServiciosWSClient;

namespace SoftCiapasaBusiness.Usuarios
{
    public class DireccionBO
    {
        private DireccionClient direccionClienteSOAP;

        public DireccionBO()
        {
            // Inicializar el cliente SOAP
            this.direccionClienteSOAP = new DireccionClient();
        }

        public int InsertarDireccion(direccionDTO1 direccion)
        {
            return direccionClienteSOAP.insertarDireccion(direccion);
        }

        public direccionDTO1 ObtenerPorIdDireccion(int idDireccion)
        {
            return direccionClienteSOAP.obtenerPorIdDireccion(idDireccion);
        }

        public BindingList<direccionDTO1> ListarTodosDireccion()
        {
            direccionDTO1[] direcciones = direccionClienteSOAP.listarTodosDireccion();
            return new BindingList<direccionDTO1>(direcciones);
        }

        public int ModificarDireccion(direccionDTO1 direccion)
        {
            return direccionClienteSOAP.modificarDireccion(direccion);
        }

        public int EliminarDireccion(direccionDTO1 direccion)
        {
            return direccionClienteSOAP.eliminarDireccion(direccion);
        }

        //faltan métodos por implementar (en teoría)
    }
}
