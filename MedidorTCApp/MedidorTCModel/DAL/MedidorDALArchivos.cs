using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedidorTCModel.DTO;

namespace MedidorTCModel.DAL
{
    public class MedidorDALArchivos : IMedidorDAL
    {
        private MedidorDALArchivos()
        {

        }

        private static IMedidorDAL instancia;

        public static IMedidorDAL GetInstance()
        {
            if (instancia == null)
                instancia = new MedidorDALArchivos();
            return instancia;
        }

        public List<Medidor> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(Medidor m)
        {
            throw new NotImplementedException();
        }
    }
}
