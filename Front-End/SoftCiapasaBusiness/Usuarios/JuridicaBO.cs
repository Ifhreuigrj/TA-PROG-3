using SoftCiapasaBusiness.ServiciosWSClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCiapasaBusiness.Usuarios
{
    public class JuridicaBO
    {
        private JuridicaClient juridicaClientSOAP;
        public JuridicaBO() { 
            this.juridicaClientSOAP = new JuridicaClient();
        }

        public int InsertarJuridica(juridicaDTO jdto)
        {
            
            return juridicaClientSOAP.insertarJuridica(jdto);
        }

        public juridicaDTO ObtenerPorIdJuridica(int i)
        {
            return juridicaClientSOAP.obtenerPorIdJuridica(i);
        }

        public BindingList<juridicaDTO> ListarTodosJuridica()
        {
            juridicaDTO[] juridicolArray = this.juridicaClientSOAP.listarTodosJuridica();
            return new BindingList<juridicaDTO>(juridicolArray);
        }

        public int ModificarJuridica(juridicaDTO jdto)
        {
            return juridicaClientSOAP.modificarJuridica(jdto);
        }

        public int EliminarJuridica(juridicaDTO jdto)
        {
            return juridicaClientSOAP.eliminarJuridica(jdto);
        }

        public juridicaDTO ObtenerPorRucJuridica(String ruc)
        {
            return juridicaClientSOAP.obtenerPorRucJuridica(ruc);
        }

    }
}
