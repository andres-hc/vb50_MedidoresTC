using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorTCModel.DTO
{
    public class Tarifa
    {
        private Int32 idTarifa;
        private string nombre;
        private Int32 valor;

        public int IdTarifa { get => idTarifa; set => idTarifa = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Valor { get => valor; set => valor = value; }
    }
}
