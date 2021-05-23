using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorTCModel.DTO
{
    public class EstadoMantencion
    {
        private Int32 idEstadoMantencion;
        private string nombre;

        public int IdEstadoMantencion { get => idEstadoMantencion; set => idEstadoMantencion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
