using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorTCModel.DTO
{
    public class Medidor
    {
        private Int32 idMedidor;
        private DateTime fechaConsumo;
        private string tipo;

        public int IdMedidor { get => idMedidor; set => idMedidor = value; }
        public DateTime FechaConsumo { get => fechaConsumo; set => fechaConsumo = value; }
        public string Tipo { get => tipo; set => tipo = value; }

        public override string ToString()
        {
            return FechaConsumo + "|" + IdMedidor + "|" + Tipo;
        }

        
    }
}
