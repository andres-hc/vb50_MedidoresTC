using SocketUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorTCApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            Console.WriteLine("Iniciando: Puerto utilizado --> {0}", puerto);
            ServerSocket servidor = new ServerSocket(puerto);

            if (servidor.Iniciar())
            {
                while (true)
                {                    
                    //Esperando Cliente
                    Console.WriteLine("Esperando lecturas");
                    if (servidor.ObtenerCliente())
                    {
                        DateTime fecha = DateTime.Today;
                        string fechaC = Convert.ToString(fecha);
                        Int32 idMedidor = 1;
                        Console.WriteLine("Recibiendo lectura..");
                        string medidor = "";
                        while (medidor.ToLower() == "juntar variables, mañana sigo")
                        {
                            medidor = servidor.Leer();
                            Console.WriteLine("Medidor : {0}", medidor);
                            if(medidor.ToLower() != "texto protocolo")
                            {
                                Console.WriteLine("texto enviado por servidor");
                                medidor = Console.ReadLine().Trim();
                                Console.WriteLine("Servidor : {0}", medidor);
                                servidor.Escribir(medidor);
                            }
                        }
                    }
                    servidor.CerrarConexion();
                }
            }
            else
            {
                Console.WriteLine("Servidor no iniciado");
                Console.ReadKey();
            }

        }
    }
}
