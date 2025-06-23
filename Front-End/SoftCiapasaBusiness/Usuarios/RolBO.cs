using SoftCiapasaBusiness.ServiciosWSClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCiapasaBusiness.Usuarios
{
    public class RolBO
    {
        private RolClient rolClienteSOAP;
        public RolBO()
        {
            rolClienteSOAP = new RolClient();
        }

        public rolDTO1 ObtenerPorIdRol(int i)
        {
            return rolClienteSOAP.obtenerPorIdRol(i);
        }

        public BindingList<rolDTO1> ListarTodosRoles()
        {
            rolDTO1[] rolArray = this.rolClienteSOAP.listarTodosRoles();
            return new BindingList<rolDTO1>(rolArray);
        }

        public int InsertarRol(rolDTO1 roldto)
        {
            return rolClienteSOAP.insertarRol(roldto);
        }

        public int ModificarRol(rolDTO1 roldto)
        {
            return rolClienteSOAP.modificarRol(roldto);
        }

        public int EliminarRol(rolDTO1 roldto)
        {
            return rolClienteSOAP.eliminarRol(roldto);
        }
    }
}
