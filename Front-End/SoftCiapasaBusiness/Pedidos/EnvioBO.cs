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
    public class EnvioBO
    {
        private EnvioClient envioClienteSOAP;

        public EnvioBO()
        {
            this.envioClienteSOAP = new EnvioClient();
        }

        public int InsertarEnvio(envioDTO envio)
        {
            return envioClienteSOAP.insertarEnvio(envio);
        }

        public envioDTO ObtenerPorIdEnvio(int idEnvio)
        {
            return envioClienteSOAP.obtenerPorIdEnvio(idEnvio);
        }

        public BindingList<envioDTO> ListarTodosEnvio()
        {
            envioDTO[] envios = envioClienteSOAP.listarTodosEnvio();
            return new BindingList<envioDTO>(envios);
        }

        public int ModificarEnvio(envioDTO envio)
        {
            return envioClienteSOAP.modificarEnvio(envio);
        }

        public int EliminarEnvio(envioDTO envio)
        {
            return envioClienteSOAP.eliminarEnvio(envio);
        }

        public BindingList<envioDTO> ListarEnvioPedido(int pedidoId)
        {
            envioDTO[] envios = envioClienteSOAP.listarEnvioPedido(pedidoId);
            return new BindingList<envioDTO>(envios);
        }

        public BindingList<envioDTO> ListarEnvioEstado(string estado)
        {
            envioDTO[] envios = envioClienteSOAP.listarEnvioEstado(estado);
            return new BindingList<envioDTO>(envios);
        }

        public BindingList<envioDTO> ListarEnvioInactivos()
        {
            envioDTO[] envios = envioClienteSOAP.listarEnvioInactivos();
            return new BindingList<envioDTO>(envios);
        }

        public BindingList<envioDTO> ListarEnvioRangoFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            envioDTO[] envios = envioClienteSOAP.listarEnvioRangoFecha(fechaInicio, fechaFin);
            return new BindingList<envioDTO>(envios);
        }

        public BindingList<envioDTO> ListarEnvioUsuarioCreacion(int usuarioId)
        {
            envioDTO[] envios = envioClienteSOAP.listarEnvioUsuarioCreacion(usuarioId);
            return new BindingList<envioDTO>(envios);
        }

        public BindingList<envioDTO> ListarEnvioDireccion(int direccionId)
        {
            envioDTO[] envios = envioClienteSOAP.listarEnvioDireccion(direccionId);
            return new BindingList<envioDTO>(envios);
        }

        public BindingList<envioDTO> ListarEnvioRangoFechaCreacion(DateTime fechaInicio, DateTime fechaFin)
        {
            envioDTO[] envios = envioClienteSOAP.listarEnvioRangoFechaCreacion(fechaInicio, fechaFin);
            return new BindingList<envioDTO>(envios);
        }

        public BindingList<envioDTO> ListarEnvioPendientes()
        {
            envioDTO[] envios = envioClienteSOAP.listarEnvioPendientes();
            return new BindingList<envioDTO>(envios);
        }

        public BindingList<envioDTO> ListarEnvioEntregados()
        {
            envioDTO[] envios = envioClienteSOAP.listarEnvioEntregados();
            return new BindingList<envioDTO>(envios);
        }
    }
}
