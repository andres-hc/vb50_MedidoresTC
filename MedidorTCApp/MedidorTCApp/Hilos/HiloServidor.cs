using SocketUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MedidorTCApp.Hilos
{
    public class HiloServidor
    {
        private int puerto;
        private ServerSocket servidor;
        public HiloServidor(int puerto)
        {
            this.puerto = puerto;
        }

        public void Ejecutar()
        {
            Console.WriteLine("Iniciando Servidor");
            this.servidor = new ServerSocket(puerto);
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
                        Console.WriteLine("Recibiendo lectura.. ");
                        string medidor = "";
                        //string medidor2 = "";
                        while (medidor.ToLower() != "cerrar")
                        {
                            medidor = servidor.Leer();
                            Console.WriteLine("Medidor : {0}", medidor);
                            if (medidor.ToLower() != "cerrar")
                            {
                                Console.WriteLine("Servidor : " + fechaSF + "-" + fechaSH + "|" + "WAIT");
                                servidor.Escribir(fechaSF + "-" + fechaSH + "|" + "WAIT");
                                medidor = servidor.Leer();
                                if (medidor.ToLower() != "cerrar")
                                {
                                    Console.WriteLine("Medidor: " + medidor);

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
