using MedidorTCModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorTCModel.DAL
{
    public interface IMedidorDAL
    {

        void Save(Medidor m);
        List<Medidor> GetAll();
    }
}
