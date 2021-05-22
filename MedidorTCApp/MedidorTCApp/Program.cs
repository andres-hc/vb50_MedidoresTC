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
                    DateTime fechaA = DateTime.Now;
                    string fechaF = Convert.ToString(fechaA.ToString("yyyy-MM-dd"));
                    string fechaH = Convert.ToString(fechaA.ToString("HH-mm-ss"));
                    string fechaSF = Convert.ToString(fechaA.ToString("yyyy-MM-dd"));
                    string fechaSH = Convert.ToString(fechaA.ToString("HH-mm-ss"));
                    string consumo = "consumo";
                    string trafico = "trafico";
                    //Esperando Cliente
                    Console.WriteLine("Esperando lecturas");
                    if (servidor.ObtenerCliente())
                    {
                        Int32 idMedidor = 1;
                        Int32 idMedidor2 = 2;
                        Int32 valor = 0;
                        string mensaje = fechaF + "-" + fechaH + "|" + idMedidor + "|" + consumo;
                        string mensaje2 = fechaF + "-" + fechaH + "|" + idMedidor + "|" + consumo + "|" + valor + "| UPDATE";
                        Console.WriteLine("Recibiendo lectura..");
                        string medidor = "";
                        string medidor2 = "";
                        while (medidor.ToLower() != "Cerrar")
                        {
                            medidor = servidor.Leer();
                            Console.WriteLine("Medidor : {0}", medidor);
                            if (medidor.ToLower() != "Cerrar")
                            {
                                Console.WriteLine("Servidor : " + fechaSF + "-" + fechaSH + "|" + "WAIT");
                                medidor2 = servidor.Leer();
                                if (medidor.ToLower() != mensaje2)
                                {
                                    Console.WriteLine("Medidor: {0}" + medidor2);
                                    servidor.Escribir("Cerrar");
                                }
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
