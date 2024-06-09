using System;

namespace TP_ClubDeportivo
{
    public abstract class ServicioDeportivo
    {
        public string Tipo { get; set; }
        public decimal Duracion { get; set; }

        public ServicioDeportivo(string tipo, decimal duracion)
        {
            Tipo = tipo;
            Duracion = duracion / 60;
        }
        public virtual void MostrarDetalles()
        {
            Console.WriteLine($"Nombre de servicio: {Tipo}");
            Console.WriteLine($"Duración: {Duracion}");
        }

        public abstract decimal CalcularPrecio();
    }

    public class EntrenamientoPersonalizado : ServicioDeportivo
    {
        public EntrenamientoPersonalizado(string tipo, decimal duracion) : base(tipo, duracion) { }

        public override decimal CalcularPrecio()
        {
            decimal precio = Duracion * 2000;
            decimal precioConIVA = precio + precio * 0.21m / 2; // Agregar la mitad del 21% de IVA
            return precioConIVA;
        }
        public override void MostrarDetalles()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Tipo Entrenamiento personalizado:");
            Console.ResetColor();
            base.MostrarDetalles();
        }
    }

    public class ClasesGrupales : ServicioDeportivo
    {
        public int NumeroParticipantes { get; set; }

        public ClasesGrupales(string tipo, decimal duracion, int numeroParticipantes) : base(tipo, duracion)
        {
            NumeroParticipantes = numeroParticipantes;
        }

        public override decimal CalcularPrecio()
        {
            decimal precio = Duracion * 80;
            if (NumeroParticipantes > 10)
            {
                precio *= 0.8m; // Disminuir el precio en un 20%
            }
            decimal precioConIVA = precio + precio * 0.21m / 2; // Agregar la mitad del 21% de IVA
            return precioConIVA;
        }
        public override void MostrarDetalles()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Tipo Clase Grupal:");
            Console.ResetColor();
            base.MostrarDetalles();
        }
    }
}
