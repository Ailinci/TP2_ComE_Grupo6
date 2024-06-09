using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TP_ClubDeportivo
{
    public class Suplemento
    {
        public string Nombre { get; set; }
        public decimal PorcentajeGanancia { get; set; }
        public decimal PrecioLista { get; set; }
        public decimal Precio
        {
            get
            {
                return CalcularPrecioFinal();
            }
        }

        public Suplemento(string nombre, decimal porcentajeGanancia, decimal precioLista)
        {
            Nombre = nombre;
            PorcentajeGanancia = porcentajeGanancia;
            PrecioLista = precioLista;
        }

        public decimal CalcularPrecioFinal()
        {
            decimal ganancia = PrecioLista * PorcentajeGanancia / 100;
            decimal precioSinIVA = PrecioLista + ganancia;
            decimal precioFinal = precioSinIVA + precioSinIVA * 0.21m; // Agregar 21% de IVA

            return precioFinal;
        }

        public static Suplemento CrearSuplemento()
        {
            string nombre = Utilidad.LeerEntradaNoVacia("Ingrese el nombre del suplemento:");
            decimal porcentajeGanancia = Utilidad.LeerNumero("Ingrese el numero de porcentaje de ganancia del suplemento:");
            decimal precioLista = Utilidad.LeerNumero("Ingrese el precio de lista del suplemento:");

            Suplemento nuevoSuplemento = new Suplemento(nombre, porcentajeGanancia, precioLista);

            Console.WriteLine($"Suplemento {nombre} creado con éxito.");

            return nuevoSuplemento;
        }
        public static void ListarSuplementos(List<Suplemento> suplementos)
        {
            if (suplementos.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay suplementos creados.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Lista de suplementos creados");
                Console.ResetColor();

                foreach (Suplemento suplemento in suplementos)
                {
                    Console.WriteLine($"Nombre: {suplemento.Nombre}");
                    Console.WriteLine($"Porcentaje de Ganancia: {suplemento.PorcentajeGanancia}%");
                    Console.WriteLine($"Precio de Lista: {suplemento.PrecioLista}");
                    Console.WriteLine($"Precio Final: {suplemento.CalcularPrecioFinal()}");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("-------------------------");
                    Console.ResetColor();
                }
            }
        }
    }
}