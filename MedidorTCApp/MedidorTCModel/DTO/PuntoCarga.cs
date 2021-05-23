using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorTCModel.DTO
{
    public class PuntoCarga
    {
        private Int32 idPuntoCarga;
        private Int32 capacidad;
        private string vidaUtil;
        private Int32 idTipoCarga;
        private Int32 idEstacionCarga;
        private Int32 idEstadoMantencion;

        public int IdPuntoCarga { get => idPuntoCarga; set => idPuntoCarga = value; }
        public int Capacidad { get => capacidad; set => capacidad = value; }
        public string VidaUtil { get => vidaUtil; set => vidaUtil = value; }
        public int IdTipoCarga { get => idTipoCarga; set => idTipoCarga = value; }
        public int IdEstacionCarga { get => idEstacionCarga; set => idEstacionCarga = value; }
        public int IdEstadoMantencion { get => idEstadoMantencion; set => idEstadoMantencion = value; }
    }
}
