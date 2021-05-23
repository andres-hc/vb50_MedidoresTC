using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedidorTCModel.DTO;

namespace MedidorTCModel.DAL
{
    public class MedidorDALArchivos : IMedidorDAL
    {
        //Aqui falta
        private string archivo = Directory.GetCurrentDirectory()
            + Path.DirectorySeparatorChar + "lecturas.csv";

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
            List<Medidor> lista = new List<Medidor>();
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    string linea = null;
                    do
                    {
                        linea = reader.ReadLine();
                        if (linea != null)
                        {
                            string[] textoArray = linea.Split('|');
                            Medidor m = new Medidor()
                            {
                                FechaConsumo = DateTime.ParseExact(textoArray[0], "yyyy-MM-dd-HH-mm-ss", CultureInfo.InvariantCulture),
                                IdMedidor = Convert.ToInt32(textoArray[1]),
                                Tipo = textoArray[2],
                                Valor = Convert.ToInt32(textoArray[3]),
                            };
                            lista.Add(m);
                        }
                    } while (linea != null);
                }
            }catch(IOException ex)
            {
                lista = null;
            }
            return lista;
        }

        public void Save(Medidor m)
        {
            try
            {
                using(StreamWriter writer = new StreamWriter(archivo, true))
                {
                    writer.WriteLine(m);
                    writer.Flush();
                }
            }catch(IOException ex)
            {

            }
        }
    }
}
