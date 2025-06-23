using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftCiapasaBusiness.ServiciosWSClient;
using System.Xml.Linq;
using System.ComponentModel;

namespace SoftCiapasaBusiness.Usuarios
{
    public class AdministradorBO
    {
        private AdministradorClient administradorClienteSOAP;

        public AdministradorBO()
        {
            // Inicializar el cliente SOAP
            this.administradorClienteSOAP = new AdministradorClient();
        }

        public int InsertarAdministrador(administradorDTO administrador)
        {
            return administradorClienteSOAP.insertarAdministrador(administrador);
        }

        public administradorDTO ObtenerPorIdAdministrador(int administradorId)
        {
            return administradorClienteSOAP.obtenerPorIdAdministrador(administradorId);
        }

        public BindingList<administradorDTO> ListarTodosAdministrador()
        {
            administradorDTO[] administradores = administradorClienteSOAP.listarTodosAdministrador();
            return new BindingList<administradorDTO>(administradores);
        }

        public int ModificarAdministrador(administradorDTO administrador)
        {
            return administradorClienteSOAP.modificarAdministrador(administrador);
        }

        public int EliminarAdministrador(administradorDTO administrador)
        {
            return administradorClienteSOAP.eliminarAdministrador(administrador);
        }
    }
}
