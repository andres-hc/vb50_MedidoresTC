using MedidorTCApp.Hilos;
using SocketUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MedidorTCApp
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando Hilo del servidor");
            int puerto = int.Parse(ConfigurationManager.AppSettings["puerto"]);
            HiloServidor hiloServidor = new HiloServidor(puerto);
            Thread t = new Thread(new ThreadStart(hiloServidor.Ejecutar));

            t.IsBackground = true;
            t.Start();

            Console.ReadKey();



        }
    }
}
