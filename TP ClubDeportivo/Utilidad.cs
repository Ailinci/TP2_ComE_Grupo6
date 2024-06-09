using System;
using System.Collections.Generic;
using System.Text;

namespace TP_ClubDeportivo
{
    public static class Utilidad
    {
        public static int LeerNumero(string mensaje)
        {
            int numero;
            Console.WriteLine(mensaje);
            while (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.WriteLine("Por favor, ingrese un número válido.");
            }
            return numero;
        }

        public static string LeerEntradaNoVacia(string mensaje)
        {
            string entrada;
            do
            {
                Console.WriteLine(mensaje);
                entrada = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(entrada));

            return entrada;
        }
    }
}
