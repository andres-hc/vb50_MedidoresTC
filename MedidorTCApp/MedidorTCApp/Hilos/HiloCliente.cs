    using MedidorTCModel.DAL;
using SocketUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorTCApp.Hilos
{
    public class HiloCliente
    {
        private int puerto;
        private ClienteSocket clienteSocket;
        private IMedidorDAL dal = MedidorDALFactory.CreateDAL();

        //public HiloClienteIniciar(int puerto)
        //{
        //    this.puerto = puerto;
        //}

        public HiloCliente(int puerto)
        {
            //this.clienteSocket = clienteSocket;
            this.puerto = puerto;
        }

        public void Ejecutar()
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
            clienteSocket.CerrarConexion();

        }
    }
}
