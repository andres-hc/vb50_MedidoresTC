using ComunicacionApp.Comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = ConfigurationManager.AppSettings["ip"];
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Iniciando conexion a servidor {0} en el puerto {1}", ip, puerto);
            ClienteSocket clienteSocket = new ClienteSocket(puerto, ip);
            if (clienteSocket.Conectar())
            {
                DateTime fechaActual = DateTime.Now;
                string fechaF = Convert.ToString(fechaActual.ToString("yyyy-MM-dd"));
                string fechaH = Convert.ToString(fechaActual.ToString("HH-mm-ss"));
                string fechaJ = fechaF + "-" + fechaH;
                Int32 idMedidor = 1;
                Int32 idMedidor2 = 2;
                Int32 valor = 1350;
                string consumo = "consumo";
                string trafico = "trafico";
                string mensaje = fechaJ + "|" + idMedidor + "|" + consumo;
                string mensaje2 = fechaF + "-" + fechaH + "|" + idMedidor + "|" + consumo + "|" + valor + "| UPDATE";
                string medidor = "";

                clienteSocket.Escribir(mensaje);
                while (medidor.ToLower() != "cerrar")
                {
                    medidor = clienteSocket.Leer();
                    Console.WriteLine("Servidor: {0}", medidor);
                    if (medidor.ToLower() != "cerrar")
                    {
                        clienteSocket.Escribir(mensaje2);
                        clienteSocket.Escribir("cerrar");
                    }
                }
                clienteSocket.Desconectar();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al conectar al servidor");
            }
        }
    }
}

