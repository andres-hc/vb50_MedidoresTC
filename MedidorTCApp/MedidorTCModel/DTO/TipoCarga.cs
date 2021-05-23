using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorTCModel.DTO
{
    public class TipoCarga
    {
        private Int32 idTipoCarga;
        private string nombre;

        public int IdTipoCarga { get => idTipoCarga; set => idTipoCarga = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
