using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorTCModel.DTO
{
    public class EstacionCarga
    {
        private Int32 idEstacionCarga;
        private string direccion;
        private Int32 capacidad;
        private string horarioAtencion;
        private Int32 idTarifa;

        public int IdEstacionCarga { get => idEstacionCarga; set => idEstacionCarga = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Capacidad { get => capacidad; set => capacidad = value; }
        public string HorarioAtencion { get => horarioAtencion; set => horarioAtencion = value; }
        public int IdTarifa { get => idTarifa; set => idTarifa = value; }
    }
}
