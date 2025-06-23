using SoftCiapasaBusiness.ServiciosWSClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCiapasaBusiness.Usuarios
{
    public class UsuarioBO
    {
        private UsuarioClient usuarioClienteSOAP;

        public UsuarioBO()
        {
            this.usuarioClienteSOAP = new UsuarioClient();
        }

        public int InsertarUsuario(usuarioDTO1 udto)
        {
            return usuarioClienteSOAP.insertarUsuario(udto);
        }

        public usuarioDTO1 ObtenerPorIdUsuario(int i)
        {
            return usuarioClienteSOAP.obtenerPorIdUsuario(i);
        }

        public BindingList<usuarioDTO1> ListarTodosUsuarios()
        {
            usuarioDTO1[] usuariosArray = this.usuarioClienteSOAP.listarTodosUsuarios();
            return new BindingList<usuarioDTO1>(usuariosArray);
        }

        public int ModificarUsuario(usuarioDTO1 udto)
        {
            return usuarioClienteSOAP.modificarUsuario(udto);
        }

        public int EliminarUsuario(usuarioDTO1 udto)
        {
            return usuarioClienteSOAP.eliminarUsuario(udto);
        }

        public BindingList<usuarioDTO1> ListarPorRolUsuario(int i)
        {
            usuarioDTO1[] usuariosArray = this.usuarioClienteSOAP.listarPorRolUsuario(i);
            return new BindingList<usuarioDTO1>(usuariosArray);
        }

        public usuarioDTO1 BuscarPorEmailUsuario(String email)
        {
            return usuarioClienteSOAP.buscarPorEmailUsuario(email);
        }

        public usuarioDTO1 AutenticarUsuario(String email, String contraseña)
        {
            return usuarioClienteSOAP.autenticarUsuario(email, contraseña);
        }
    }
}
