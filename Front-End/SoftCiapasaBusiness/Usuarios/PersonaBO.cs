using SoftCiapasaBusiness.ServiciosWSClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCiapasaBusiness.Usuarios
{
    public class PersonaBO
    {
        private PersonaClient personaClientSOAP;
        public PersonaBO()
        {
            this.personaClientSOAP = new PersonaClient();
        }

        public personaDTO1 ObtenerPorIdPersona(int i)
        {
            return personaClientSOAP.obtenerPorIdPersona(i);
        }

        public BindingList<personaDTO1> ListarTodosPersona()
        {
            personaDTO1[] personaArray = this.personaClientSOAP.listarTodosPersona();
            return new BindingList<personaDTO1>(personaArray);
        }

        public int ModificarPersona(personaDTO1 pdto)
        {
            return personaClientSOAP.modificarPersona(pdto);
        }

        public personaDTO1 ObtenerPorTelefonoPersona(String telefono)
        {
            return personaClientSOAP.obtenerPorTelefonoPersona(telefono);
        }

        public BindingList<personaDTO1> ListarPorApellidoPersona(String apellido)
        {
            personaDTO1[] personaArray = this.personaClientSOAP.listarPorApellidoPersona(apellido);
            return new BindingList<personaDTO1>(personaArray);
        }

        public BindingList<personaDTO1> ListarPorNombreParcialPersona(String nombre)
        {
            personaDTO1[] personaArray = this.personaClientSOAP.listarPorNombreParcialPersona(nombre);
            return new BindingList<personaDTO1>(personaArray);
        }

        public BindingList<personaDTO1> ListarPersonasActivos()
        {
            personaDTO1[] personaArray = this.personaClientSOAP.listarPersonasActivos();
            return new BindingList<personaDTO1>(personaArray);
        }

        public BindingList<personaDTO1> ListarPersonasInactivos()
        {
            personaDTO1[] personaArray = this.personaClientSOAP.listarPersonasInactivos();
            return new BindingList<personaDTO1>(personaArray);
        }

        public BindingList<personaDTO1> ListarPorFechasPersona(DateTime date, DateTime date1)
        {
            personaDTO1[] personaArray = this.personaClientSOAP.listarPorFechasPersona(date, date1);
            return new BindingList<personaDTO1>(personaArray);
        }

        public BindingList<personaDTO1> ListarPorUsuarioCreacionPersona(int i)
        {
            personaDTO1[] personaArray = this.personaClientSOAP.listarPorUsuarioCreacionPersona(i);
            return new BindingList<personaDTO1>(personaArray);
        }

        public BindingList<personaDTO1> ListarPorNombreApellidoParcialPersona(String nombreParcial, String apellidoParcial)
        {
            personaDTO1[] personaArray = this.personaClientSOAP.listarPorNombreApellidoParcialPersona(nombreParcial, apellidoParcial);
            return new BindingList<personaDTO1>(personaArray);
        }

        public BindingList<personaDTO1> ListarUltimosActualizadosPersona(int i)
        {
            personaDTO1[] personaArray = this.personaClientSOAP.listarUltimosActualizadosPersona(i);
            return new BindingList<personaDTO1>(personaArray);
        }

    }
}
