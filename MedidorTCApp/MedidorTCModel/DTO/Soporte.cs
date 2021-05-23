using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorTCModel.DTO
{
    public class Soporte
    {
        private Int32 rut;
        private string nombre;
        private Int32 idPuntoCarga;

        public int Rut { get => rut; set => rut = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int IdPuntoCarga { get => idPuntoCarga; set => idPuntoCarga = value; }
    }
}
