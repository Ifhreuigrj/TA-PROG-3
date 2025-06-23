using SoftCiapasaBusiness.ServiciosWSClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCiapasaBusiness.Usuarios
{
    public class NaturalBO
    {
        private NaturalClient naturalClientSOAP;
        public NaturalBO() { 
            
            this.naturalClientSOAP = new NaturalClient();
        }

        public int InsertarNatural(naturalDTO ndto)
        {
            
            return naturalClientSOAP.insertarNatural(ndto);
        }

        public naturalDTO ObtenerPorIdNatural(int i)
        {
            return naturalClientSOAP.obtenerPorIdNatural(i);
        }

        public BindingList<naturalDTO> ListarTodosNatural()
        {
            naturalDTO[] naturalArray = this.naturalClientSOAP.listarTodosNatural();
            return new BindingList<naturalDTO>(naturalArray);
        }

        public int ModificarNatural(naturalDTO ndto)
        {
           
            return naturalClientSOAP.modificarNatural(ndto);
        }

        public int EliminarNatural(naturalDTO ndto)
        {
            
            return naturalClientSOAP.eliminarNatural(ndto);
        }

        public BindingList<naturalDTO> ListarPorGeneroNatural(String genero)
        {
            naturalDTO[] naturalArray = this.naturalClientSOAP.listarPorGeneroNatural(genero);
            return new BindingList<naturalDTO>(naturalArray);
        }

        public naturalDTO ObtenerPorDniNatural(int dni)
        {
            return naturalClientSOAP.obtenerPorDniNatural(dni);
        }


    }
}
